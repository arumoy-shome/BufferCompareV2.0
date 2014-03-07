using System;
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
using FileHelpers;
using System.Diagnostics;

namespace WpfApplication1
{
    public class Read
    {
        public void NewFileRead()
        {
            try
            {
                FileHelperEngine newread = new FileHelperEngine(typeof(DefineArray));

                //reading new csv file
                DefineArray[] newpixel = newread.ReadFile(Variables.string_newfilepath) as DefineArray[];

                // copying content to newpixelgetset
                //and clear newpixel
                GetSet.newpixelgetset = (DefineArray[])newpixel.Clone();
                System.Array.Clear(newpixel, 0, newpixel.Length);

                //defining standard
                switch (GetSet.newpixelgetset.Length)
                {
                    case Variables.totalrows720p50 - 1:
                        Variables.bool_newfilestandard720p50 = true;
                        break;

                    case Variables.totalrows720p59 - 1:
                        Variables.bool_newfilestandard720p59 = true;
                        break;

                    case Variables.totalrows1080i50 - 1:
                        Variables.bool_newfilestandard1080i50 = true;
                        break;

                    case Variables.totalrows1080i59 - 1:
                        Variables.bool_newfilestandard1080i59 = true;
                        break;

                    default:
                        MessageBox.Show("Bad Capture! Please re-capture the file and try again.");
                        break;
                }
            }

            catch
            {
                MessageBox.Show("Invalid format! Please upload the simple format and try again.");
                return;
            }
        }

        public void OldFileRead()
        {
            try
            {
                FileHelperEngine oldread = new FileHelperEngine(typeof(DefineArray));

                //reading old csv file
                DefineArray[] oldpixel = oldread.ReadFile(Variables.string_oldfilepath) as DefineArray[];


                //copying content to oldpixelgetset
                //and clear oldpixel
                GetSet.oldpixelgetset = (DefineArray[])oldpixel.Clone();
                System.Array.Clear(oldpixel, 0, oldpixel.Length);

                //defining standard
                switch (GetSet.oldpixelgetset.Length)
                {
                    case Variables.totalrows720p50 - 1:
                        Variables.bool_oldfilestandard720p50 = true;
                        break;

                    case Variables.totalrows720p59 - 1:
                        Variables.bool_oldfilestandard720p59 = true;
                        break;

                    case Variables.totalrows1080i50 - 1:
                        Variables.bool_oldfilestandard1080i50 = true;
                        break;

                    case Variables.totalrows1080i59 - 1:
                        Variables.bool_oldfilestandard1080i59 = true;
                        break;

                    default:
                        MessageBox.Show("Bad Capture! Please re-capture the file and try again.");
                        break;
                }
            }

            catch
            {
                MessageBox.Show("Invalid format! Please upload the simple format and try again.");
                return;
            }
            
        }
    }
}
