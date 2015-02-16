using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApplication1
{

    public class Variables : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

         public double linenumber { get; set; }
         public int samplenumber { get; set; }
         public string DIDSDID { get; set; }
         public int datecount { get; set; }
         public string usedwhere { get; set; }
         public Brush _itemBrush = Brushes.Transparent;
         
        public Brush ItemBrush
         {
             get
             {
                 return _itemBrush;
             }
            set
            {
                if (value != _itemBrush) 
                {
                    _itemBrush = value;
                    NotifyPropertyChanged("ItemBrush");
                }
             }
         }

         // This method is called by the Set accessor of each property. 
         // The CallerMemberName attribute that is applied to the optional propertyName 
         // parameter causes the property name of the caller to be substituted as an argument. 
         private void NotifyPropertyChanged(String propertyName)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
             }
         }
         
         public static Nullable<bool> bool_capturefilepath;
         public static string new_file_path { get; set; }
         public static string old_file_path { get; set; }
         public static string string_capturefilepath { get; set; }
         public static int samplenumvar1 = 0;
         public static int s_samplenumber = 0;
         public static string[,] didsdidarray = new string[42, 3] { { "08", "08", "S353" }, { "08", "0c", "S353" }, { "40", "01", "S305" }, { "40", "02", "S348" }, { "40", "04", "S427" }, { "40", "05", "S427" }, { "40", "06", "S427" }, { "41", "01", "S352" }, { "41", "05", "S2016-3" }, { "41", "06", "S2016-6" }, { "41", "07", "S2010" }, { "41", "08", "S2031" }, { "41", "09", "ST 2056" }, { "41", "0a", "ST 2068" }, { "43", "01", "ITU-R BT.1685" }, { "43", "02", "RDD8" }, { "43", "03", "RDD8" }, { "43", "04", "ARIB TR-B29" }, { "43", "05", "RDD18" }, { "44", "04", "RP214" }, { "44", "14", "RP214" }, { "44", "44", "RP223" }, { "45", "01", "S2020-1" }, { "45", "02", "S2020-1" }, { "45", "03", "S2020-1" }, { "45", "04", "S2020-1" }, { "45", "05", "S2020-1" }, { "45", "06", "S2020-1" }, { "45", "07", "S2020-1" }, { "45", "08", "S2020-1" }, { "45", "09", "S2020-1" }, { "46", "01", "ST 2051" }, { "50", "01", "RDD8" }, { "51", "01", "RP215" }, { "60", "60", "S12M-2" }, { "61", "01", "S334-1" }, { "61", "02", "S334-1" }, { "62", "01", "RP207" }, { "62", "02", "S334-1" }, { "62", "03", "RP208" }, { "64", "64", "RP196" }, { "64", "7f", "RP196" }};
         public static string[,] onlydidarray = new string[34, 3] { { "00", "", "S291" }, { "80", "", "S291" }, { "84", "", "S291" }, { "88", "", "S291" }, { "a0", "", "ST 299-2" }, { "a1", "", "ST 299-2" }, { "a2", "", "ST 299-2" }, { "a3", "", "ST 299-2" }, { "a4", "", "ST 299-2" }, { "a5", "", "ST 299-2" }, { "a6", "", "ST 299-2" }, { "a7", "", "ST 299-2" }, { "e0", "", "ST 299-1" }, { "e1", "", "ST 299-1" }, { "e2", "", "ST 299-1" }, { "e3", "", "ST 299-1" }, { "e4", "", "ST 299-1" }, { "e5", "", "ST 299-1" }, { "e6", "", "ST 299-1" }, { "e7", "", "ST 299-1" }, { "ec", "", "S272" }, { "ed", "", "S272" }, { "ee", "", "S272" }, { "ef", "", "S272" }, { "f0", "", "S315" }, { "f4", "", "RP165" }, { "f8", "", "S272" }, { "f9", "", "S272" }, { "fa", "", "S272" }, { "fb", "", "S272" }, { "fc", "", "S272" }, { "fd", "", "S272" }, { "fe", "", "S272" }, { "ff", "", "S272" } };
         public static string string_unknownerror = "An unexpected error in occcured. Please check the error log for more details or try again.";
         public static string string_unknownerror_sort = "An unexpected error in Sort.cs occcured. Please check the error log for more details or try again.";
         public static string string_unknownerror_find = "An unexpected error in Find.cs occcured. Please check the error log for more details or try again.";
         public static int session_id = 0;
         public static string executable_path = System.Reflection.Assembly.GetExecutingAssembly().Location;
         public static string errorlog_path = executable_path.Replace("BufferCompareV2.0\\bin\\Debug\\BufferCompareV2.0.exe", "Error log\\Log.txt");
     }
}
