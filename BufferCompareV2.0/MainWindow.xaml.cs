using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;
using ConsoleControl;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create OpenFileDialog
        Microsoft.Win32.OpenFileDialog dlgnewfile = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.OpenFileDialog dlgoldfile = new Microsoft.Win32.OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void UploadButtonNewFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewNewFile.Items.Count != 0)
            {
                try
                {
                    //clear sort everytime new file is uploaded
                    ListViewNewFile.Items.SortDescriptions.Clear();
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                }

                catch {/*let code work*/}
            }
     
            //setting .csv filter
            dlgnewfile.DefaultExt = ".csv";
            dlgnewfile.Filter = "CSV Files (*.csv)|*.csv";

            //calling ShowDialog method
            Variables.bool_newfilepath = dlgnewfile.ShowDialog();

            if (Variables.bool_newfilepath == true)
            {
                Variables.string_newfilepath = dlgnewfile.FileName;
                TextBoxNewFilePath.Text = Variables.string_newfilepath;
            }

            else
                return;

            TextBlockNewFileProgress.Text = "Loading...";

            //object to call methods in Read class
            Read readfile = new Read();

            //call NewFileRead method
             await Task.Run(() => readfile.NewFileRead());
           
            //show standard in TextBlock
            if (Variables.bool_newfilestandard1080i50 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();
              
                TextBlockNewFileStandard.Text = "1080i50";
                sortobject.NewFileSort1080i50();
                Variables.bool_newfilestandard1080i50 = false;
                Variables.bool_find1080i50 = true;
            }

            else if (Variables.bool_newfilestandard1080i59 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockNewFileStandard.Text = "1080i5994";
                sortobject.NewFileSort1080i59();
                Variables.bool_newfilestandard1080i59 = false;
                Variables.bool_find1080i59 = true;
            }

            else if (Variables.bool_newfilestandard720p50 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockNewFileStandard.Text = "720p50";
                sortobject.NewFileSort720p50();
                Variables.bool_newfilestandard720p50 = false;
                Variables.bool_find720p50 = true;
            }

            else if (Variables.bool_newfilestandard720p59 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockNewFileStandard.Text = "720p5994";
                sortobject.NewFileSort720p59();
                Variables.bool_newfilestandard720p59 = false;
                Variables.bool_find720p59 = true;
            }

            TextBlockNewFileProgress.Text = " ";
            
        }

        private async void UploadButtonOldFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOldFile.Items.Count != 0)
            {
                try
                {
                    //clear sort everytime new file is uploaded
                    ListViewOldFile.Items.SortDescriptions.Clear();
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                }

                catch {/*let code work*/}
            }

            //setting .csv filter
            dlgoldfile.DefaultExt = ".csv";
            dlgoldfile.Filter = "CSV Files (*.csv)|*.csv";

            //calling ShowDialog method
            Variables.bool_oldfilepath = dlgoldfile.ShowDialog();

            if (Variables.bool_oldfilepath == true)
            {
                Variables.string_oldfilepath = dlgoldfile.FileName;
                TextBoxOldFilePath.Text = Variables.string_oldfilepath;
            }

            else
                return;

            TextBlockOldFileProgress.Text = "Loading...";

            //object to call methods in Read class
            Read readfile = new Read();

            //call OldFileRead method
            await Task.Run(() => readfile.OldFileRead());

            //show standard in TextBlock
            if (Variables.bool_oldfilestandard1080i50 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockOldFileStandard.Text = "1080i50";
                sortobject.OldFileSort1080i50();
                Variables.bool_oldfilestandard1080i50 = false;
            }

            else if (Variables.bool_oldfilestandard1080i59 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockOldFileStandard.Text = "1080i5994";
                sortobject.OldFileSort1080i59();
                Variables.bool_oldfilestandard1080i59 = false;
            }

            else if (Variables.bool_oldfilestandard720p50 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockOldFileStandard.Text = "720p50";
                sortobject.OldFileSort720p50();
                Variables.bool_oldfilestandard720p50 = false;
            }

            else if (Variables.bool_oldfilestandard720p59 == true)
            {
                //object to call methods in Sort class
                Sort sortobject = new Sort();

                TextBlockOldFileStandard.Text = "720p5994";
                sortobject.OldFileSort720p59();
                Variables.bool_oldfilestandard720p59 = false;
            }

            TextBlockOldFileProgress.Text = " ";
        }

        private void ListViewNewFile_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListViewNewFile.Items.Count != 0)
            {
                try
                {
                    //object for DetailPopUp
                    DetailPopUp popup = new DetailPopUp();
                    Variables selecteditem = ListViewNewFile.SelectedItem as Variables;
                    popup.TextBoxDIDSDID.Text = selecteditem.DIDSDID;
                    popup.TextBoxLineNumber.Text = System.Convert.ToString(selecteditem.linenumber);
                    popup.TextBoxSampleNumber.Text = System.Convert.ToString(selecteditem.samplenumber);
                    popup.TextBoxDataCount.Text = System.Convert.ToString(selecteditem.datecount);
                    popup.ShowDialog();
                    return;
                }

                catch
                {

                    return;
                }
            }
        }

        private void ButtonCompare_Click(object sender, RoutedEventArgs e)
        {
            //disable sort before running code behind
            if (ListViewNewFile.Items.Count != 0 && ListViewOldFile.Items.Count != 0)
            {
                try
                {
                    ListViewNewFile.Items.SortDescriptions.Clear();
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);

                    ListViewOldFile.Items.SortDescriptions.Clear();
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                }

                catch {/*let code work*/}
            }
            //exceptions

            if (TextBlockNewFileProgress.Text == "Loading..." || TextBlockOldFileProgress.Text == "Loading..." || (TextBlockNewFileProgress.Text == "Loading..." && TextBlockOldFileProgress.Text == "Loading..."))
            {
                MessageBox.Show("Loading...Please wait.");
                return;
            }

            if (Variables.bool_newfilepath != Variables.bool_oldfilepath)
            {
                MessageBox.Show("Please select two files!");
                return;
            }

            if (TextBlockNewFileStandard.Text != TextBlockOldFileStandard.Text)
            {
                MessageBox.Show("Standard mis-match!");
                return;
            }

            /****************************************************************************************************************************************************/

            if (Variables.bool_find720p50 == true)
            {
                //clear listviews
                //ListViewNewFile.Items.Clear();
                //ListViewOldFile.Items.Clear();

                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = "Loading...";

                //object to call methods in Find class
                Find findfile = new Find();

                //call findfile method
                findfile.NewFileFind720p50(ListViewNewFile, ListViewOldFile);

                int greater = Math.Max(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);
                int smaller = Math.Min(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);

                if (ListViewNewFile.Items.Count > ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        newitem.ItemBrush = Brushes.Orange;
                    }
                }

                else if (ListViewNewFile.Items.Count < ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;
                        olditem.ItemBrush = Brushes.Orange;
                    }
                }

                Variables.bool_find720p50 = false;
                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = " ";
                return;
            }


            else if (Variables.bool_find720p59 == true)
            {
                //clear listviews
                //ListViewNewFile.Items.Clear();
                //ListViewOldFile.Items.Clear();

                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = "Loading...";

                //object to call methods in Find class
                Find findfile = new Find();

                //call findfile method
                findfile.NewFileFind720p59(ListViewNewFile, ListViewOldFile);

                int greater = Math.Max(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);
                int smaller = Math.Min(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);

                if (ListViewNewFile.Items.Count > ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        newitem.ItemBrush = Brushes.Orange;
                    }
                }

                else if (ListViewNewFile.Items.Count < ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;
                        olditem.ItemBrush = Brushes.Orange;
                    }
                }

                Variables.bool_find720p59 = false;
                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = " ";
                return;
            }


            else if (Variables.bool_find1080i50 == true)
            {
                //clear listviews
                //ListViewNewFile.Items.Clear();
                //ListViewOldFile.Items.Clear();

                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = "Loading...";

                //object to call methods in Find class
                Find findfile = new Find();

                //call findfile method
                findfile.NewFileFind1080i50(ListViewNewFile, ListViewOldFile);

                int greater = Math.Max(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);
                int smaller = Math.Min(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);

                if (ListViewNewFile.Items.Count > ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        newitem.ItemBrush = Brushes.Orange;
                    }
                }

                else if (ListViewNewFile.Items.Count < ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;
                        olditem.ItemBrush = Brushes.Orange;
                    }
                }

                Variables.bool_find1080i50 = false;
                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = " ";
                return;
            }

            else if (Variables.bool_find1080i59 == true)
            {
                //clear listviews
                //ListViewNewFile.Items.Clear();
                //ListViewOldFile.Items.Clear();

                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = "Loading...";

                //object to call methods in Find class
                Find findfile = new Find();

                //call findfile method
                findfile.NewFileFind1080i59(ListViewNewFile, ListViewOldFile);

                int greater = Math.Max(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);
                int smaller = Math.Min(ListViewNewFile.Items.Count, ListViewOldFile.Items.Count);

                if (ListViewNewFile.Items.Count > ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        newitem.ItemBrush = Brushes.Orange;
                    }
                }

                else if (ListViewNewFile.Items.Count < ListViewOldFile.Items.Count)
                {
                    for (int listcounter = 0; listcounter < smaller; listcounter++)
                    {
                        Variables newitem = ListViewNewFile.Items[listcounter] as Variables;
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;

                        if (newitem.DIDSDID == olditem.DIDSDID)
                        {
                            if (newitem.samplenumber != olditem.samplenumber || newitem.linenumber != olditem.linenumber)
                            {
                                newitem.ItemBrush = Brushes.Red;
                            }
                        }
                    }

                    for (int listcounter = smaller; listcounter < greater; listcounter++)
                    {
                        Variables olditem = ListViewOldFile.Items[listcounter] as Variables;
                        olditem.ItemBrush = Brushes.Orange;
                    }
                }

                Variables.bool_find1080i59 = false;
                TextBlockNewFileProgress.Text = TextBlockOldFileProgress.Text = " ";
                return;
            }
        }

        //following methods(and class) are for handling the column sort feature in ListView.
        public GridViewColumnHeader listViewSortCol = null;
        public SortAdorner listViewSortAdorner = null;

        private void lvColumnHeaderNew_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                ListViewNewFile.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            ListViewNewFile.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void lvColumnHeaderOld_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                ListViewOldFile.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            ListViewOldFile.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                    Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                    Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                        (
                                AdornedElement.RenderSize.Width - 15,
                                (AdornedElement.RenderSize.Height - 5) / 2
                        );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }


        private async void ButtonNewInvoke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String wpf_Executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string console_Executable = wpf_Executable.Replace("BufferCompareV2.0\\bin\\Debug\\BufferCompareV2.0.exe", "ConvUSB Tool\\convUSBv1.5.exe");

                await Task.Run(() => Process.Start(console_Executable));
            }

            catch
            {
                MessageBox.Show("convUSBv1.5.exe could not be found!");
                return;
            }
            
        }

        private async void ButtonOldInvoke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String wpf_Executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string console_Executable = wpf_Executable.Replace("BufferCompareV2.0\\bin\\Debug\\BufferCompareV2.0.exe", "ConvUSB Tool\\convUSBv1.5.exe");

                await Task.Run(() => Process.Start(console_Executable));
            }

            catch
            {
                MessageBox.Show("convUSBv1.5.exe could not be found!");
                return;
            }
        }

        private async void TextBoxNewFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBlockNewFileProgress.Text = "Loading...";

                //object to call methods in Read class
                Read readfile = new Read();

                //call NewFileRead method
                await Task.Run(() => readfile.NewFileRead());

                //show standard in TextBlock
                if (Variables.bool_newfilestandard1080i50 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockNewFileStandard.Text = "1080i50";
                    sortobject.NewFileSort1080i50();
                    Variables.bool_newfilestandard1080i50 = false;
                    Variables.bool_find1080i50 = true;
                }

                else if (Variables.bool_newfilestandard1080i59 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockNewFileStandard.Text = "1080i5994";
                    sortobject.NewFileSort1080i59();
                    Variables.bool_newfilestandard1080i59 = false;
                    Variables.bool_find1080i59 = true;
                }

                else if (Variables.bool_newfilestandard720p50 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockNewFileStandard.Text = "720p50";
                    sortobject.NewFileSort720p50();
                    Variables.bool_newfilestandard720p50 = false;
                    Variables.bool_find720p50 = true;
                }

                else if (Variables.bool_newfilestandard720p59 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockNewFileStandard.Text = "720p5994";
                    sortobject.NewFileSort720p59();
                    Variables.bool_newfilestandard720p59 = false;
                    Variables.bool_find720p59 = true;
                }

                TextBlockNewFileProgress.Text = " ";
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror);
                return;
            }

        }

        private async void TextBoxOldFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBlockOldFileProgress.Text = "Loading...";

                //object to call methods in Read class
                Read readfile = new Read();

                //call OldFileRead method
                await Task.Run(() => readfile.OldFileRead());

                //show standard in TextBlock
                if (Variables.bool_oldfilestandard1080i50 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockOldFileStandard.Text = "1080i50";
                    sortobject.OldFileSort1080i50();
                    Variables.bool_oldfilestandard1080i50 = false;
                }

                else if (Variables.bool_oldfilestandard1080i59 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockOldFileStandard.Text = "1080i5994";
                    sortobject.OldFileSort1080i59();
                    Variables.bool_oldfilestandard1080i59 = false;
                }

                else if (Variables.bool_oldfilestandard720p50 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockOldFileStandard.Text = "720p50";
                    sortobject.OldFileSort720p50();
                    Variables.bool_oldfilestandard720p50 = false;
                }

                else if (Variables.bool_oldfilestandard720p59 == true)
                {
                    //object to call methods in Sort class
                    Sort sortobject = new Sort();

                    TextBlockOldFileStandard.Text = "720p5994";
                    sortobject.OldFileSort720p59();
                    Variables.bool_oldfilestandard720p59 = false;
                }

                TextBlockOldFileProgress.Text = " ";
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror);
                return;
            }
        }
    }
}

