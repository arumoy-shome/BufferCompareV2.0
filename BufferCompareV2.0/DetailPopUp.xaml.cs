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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DetailPopUp.xaml
    /// </summary>
    public partial class DetailPopUp : Window
    {
        public DetailPopUp()
        {
            InitializeComponent();
            int[] array = new int[50];
            for (int i = 0; i < 50; i++)
            {
                array[i] = 500;
            }


            
        }

        public void PopulateDateCount()
        {
 
        }
    }
}
