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
    class Sort
    {
        public void NewFileSort720p50()
        {
            try
            {
                //initializing samplearray720p50
                for (int a = 0; a < Variables.rowsperline720p50; a++)
                {
                    if (Variables.firstsample720p == 1980)
                    {
                        Variables.firstsample720p = 0;
                    }

                    Variables.samplearray720p50[a, 0] = Variables.firstsample720p;
                    Variables.samplearray720p50[a, 1] = Variables.firstsample720p + 1;
                    Variables.firstsample720p += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray newpiece720p50 in GetSet.newpixelgetset)
                {
                    if (samplecounter == Variables.rowsperline720p50)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline720p50)
                    {
                        Variables.s_linenumber = 746;
                    }

                    else if (Variables.linecounter == Variables.rowsperline720p50 || Variables.linecounter < (2 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 747;
                    }

                    else if (Variables.linecounter == (2 * Variables.rowsperline720p50) || Variables.linecounter < (3 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 748;
                    }

                    else if (Variables.linecounter == (3 * Variables.rowsperline720p50) || Variables.linecounter < (4 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 749;
                    }

                    else if (Variables.linecounter == (4 * Variables.rowsperline720p50) || Variables.linecounter < (5 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 750;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline720p50) - 4;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : even sample number
                    //3rd col : odd sample number
                    Variables.newfiledataarray720p50[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.newfiledataarray720p50[Variables.linecounter, 1] = Variables.samplearray720p50[samplecounter, 0];
                    Variables.newfiledataarray720p50[Variables.linecounter, 2] = Variables.samplearray720p50[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample720p = 1284;
                System.Array.Clear(Variables.samplearray720p50, 0, Variables.samplearray720p50.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }

        public void NewFileSort720p59()
        {
            try
            {
                //initializing samplearray720p59
                for (int b = 0; b < Variables.rowsperline720p59; b++)
                {
                    if (Variables.firstsample720p == 1650)
                    {
                        Variables.firstsample720p = 0;
                    }

                    Variables.samplearray720p59[b, 0] = Variables.firstsample720p;
                    Variables.samplearray720p59[b, 1] = Variables.firstsample720p + 1;
                    Variables.firstsample720p += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray newpiece720p59 in GetSet.newpixelgetset)
                {
                    //calculate sample number
                    if (samplecounter == Variables.rowsperline720p59)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline720p59)
                    {
                        Variables.s_linenumber = 746;
                    }

                    else if (Variables.linecounter == Variables.rowsperline720p59 || Variables.linecounter < (2 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 747;
                    }

                    else if (Variables.linecounter == (2 * Variables.rowsperline720p59) || Variables.linecounter < (3 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 748;
                    }

                    else if (Variables.linecounter == (3 * Variables.rowsperline720p59) || Variables.linecounter < (4 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 749;
                    }

                    else if (Variables.linecounter == (4 * Variables.rowsperline720p59) || Variables.linecounter < (5 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 750;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline720p59) - 4;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : even sample number
                    //3rd col : odd sample number

                    Variables.newfiledataarray720p59[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.newfiledataarray720p59[Variables.linecounter, 1] = Variables.samplearray720p59[samplecounter, 0];
                    Variables.newfiledataarray720p59[Variables.linecounter, 2] = Variables.samplearray720p59[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample720p = 1284;
                System.Array.Clear(Variables.samplearray720p59, 0, Variables.samplearray720p59.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }

        public void NewFileSort1080i50()
        {
            try
            {
                //initializing samplearray1080i50
                for (int c = 0; c < Variables.rowsperline1080i50; c++)
                {
                    if (Variables.firstsample1080i == 2640)
                    {
                        Variables.firstsample1080i = 0;
                    }

                    Variables.samplearray1080i50[c, 0] = Variables.firstsample1080i;
                    Variables.samplearray1080i50[c, 1] = Variables.firstsample1080i + 1;
                    Variables.firstsample1080i += 2;
                }
                int samplecounter = 0;
                foreach (DefineArray newpiece1080i50 in GetSet.newpixelgetset)
                {
                    if (samplecounter == Variables.rowsperline1080i50)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline1080i50)
                    {
                        Variables.s_linenumber = 1124;
                    }

                    else if (Variables.linecounter == Variables.rowsperline1080i50 || Variables.linecounter < (2 * Variables.rowsperline1080i50))
                    {
                        Variables.s_linenumber = 1125;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline1080i50) - 1;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.newfiledataarray1080i50[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.newfiledataarray1080i50[Variables.linecounter, 1] = Variables.samplearray1080i50[samplecounter, 0];
                    Variables.newfiledataarray1080i50[Variables.linecounter, 2] = Variables.samplearray1080i50[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample1080i = 1924;
                System.Array.Clear(Variables.samplearray1080i50, 0, Variables.samplearray1080i50.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }

        }

        public void NewFileSort1080i59()
        {
            try
            {
                //initializing samplearray1080i59
                for (int d = 0; d < Variables.rowsperline1080i59; d++)
                {
                    if (Variables.firstsample1080i == 2200)
                    {
                        Variables.firstsample1080i = 0;
                    }

                    Variables.samplearray1080i59[d, 0] = Variables.firstsample1080i;
                    Variables.samplearray1080i59[d, 1] = Variables.firstsample1080i + 1;
                    Variables.firstsample1080i += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray newpiece1080i59 in GetSet.newpixelgetset)
                {
                    //calculate sample number
                    if (samplecounter == Variables.rowsperline1080i59)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline1080i59)
                    {
                        Variables.s_linenumber = 1124;
                    }

                    else if (Variables.linecounter == Variables.rowsperline1080i59 || Variables.linecounter < (2 * Variables.rowsperline1080i59))
                    {
                        Variables.s_linenumber = 1125;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline1080i59) - 1;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.newfiledataarray1080i59[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.newfiledataarray1080i59[Variables.linecounter, 1] = Variables.samplearray1080i59[samplecounter, 0];
                    Variables.newfiledataarray1080i59[Variables.linecounter, 2] = Variables.samplearray1080i59[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample1080i = 1924;
                System.Array.Clear(Variables.samplearray1080i59, 0, Variables.samplearray1080i59.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }

        public void OldFileSort720p50()
        {
            try
            {
                //initializing samplearray720p50
                for (int e = 0; e < Variables.rowsperline720p50; e++)
                {
                    if (Variables.firstsample720p == 1980)
                    {
                        Variables.firstsample720p = 0;
                    }

                    Variables.samplearray720p50[e, 0] = Variables.firstsample720p;
                    Variables.samplearray720p50[e, 1] = Variables.firstsample720p + 1;
                    Variables.firstsample720p += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray oldpiece720p50 in GetSet.oldpixelgetset)
                {
                    //calculate sample number
                    if (samplecounter == Variables.rowsperline720p50)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline720p50)
                    {
                        Variables.s_linenumber = 746;
                    }

                    else if (Variables.linecounter == Variables.rowsperline720p50 || Variables.linecounter < (2 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 747;
                    }

                    else if (Variables.linecounter == (2 * Variables.rowsperline720p50) || Variables.linecounter < (3 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 748;
                    }

                    else if (Variables.linecounter == (3 * Variables.rowsperline720p50) || Variables.linecounter < (4 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 749;
                    }

                    else if (Variables.linecounter == (4 * Variables.rowsperline720p50) || Variables.linecounter < (5 * Variables.rowsperline720p50))
                    {
                        Variables.s_linenumber = 750;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline720p50) - 4;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.oldfiledataarray720p50[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.oldfiledataarray720p50[Variables.linecounter, 1] = Variables.samplearray720p50[samplecounter, 0];
                    Variables.oldfiledataarray720p50[Variables.linecounter, 2] = Variables.samplearray720p50[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample720p = 1284;
                System.Array.Clear(Variables.samplearray720p50, 0, Variables.samplearray720p50.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }

        public void OldFileSort720p59()
        {
            try
            {
                //initializing samplearray720p59
                for (int f = 0; f < Variables.rowsperline720p59; f++)
                {
                    if (Variables.firstsample720p == 1650)
                    {
                        Variables.firstsample720p = 0;
                    }

                    Variables.samplearray720p59[f, 0] = Variables.firstsample720p;
                    Variables.samplearray720p59[f, 1] = Variables.firstsample720p + 1;
                    Variables.firstsample720p += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray newpiece720p59 in GetSet.oldpixelgetset)
                {
                    //calculate sample number
                    if (samplecounter == Variables.rowsperline720p59)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline720p59)
                    {
                        Variables.s_linenumber = 746;
                    }

                    else if (Variables.linecounter == Variables.rowsperline720p59 || Variables.linecounter < (2 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 747;
                    }

                    else if (Variables.linecounter == (2 * Variables.rowsperline720p59) || Variables.linecounter < (3 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 748;
                    }

                    else if (Variables.linecounter == (3 * Variables.rowsperline720p59) || Variables.linecounter < (4 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 749;
                    }

                    else if (Variables.linecounter == (4 * Variables.rowsperline720p59) || Variables.linecounter < (5 * Variables.rowsperline720p59))
                    {
                        Variables.s_linenumber = 750;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline720p59) - 4;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.oldfiledataarray720p59[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.oldfiledataarray720p59[Variables.linecounter, 1] = Variables.samplearray720p59[samplecounter, 0];
                    Variables.oldfiledataarray720p59[Variables.linecounter, 2] = Variables.samplearray720p59[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample720p = 1284;
                System.Array.Clear(Variables.samplearray720p59, 0, Variables.samplearray720p59.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
           
        }

        public void OldFileSort1080i50()
        {
            try
            {
                //initializing samplearray1080i50
                for (int g = 0; g < Variables.rowsperline1080i50; g++)
                {
                    if (Variables.firstsample1080i == 2640)
                    {
                        Variables.firstsample1080i = 0;
                    }

                    Variables.samplearray1080i50[g, 0] = Variables.firstsample1080i;
                    Variables.samplearray1080i50[g, 1] = Variables.firstsample1080i + 1;
                    Variables.firstsample1080i += 2;
                }
                int samplecounter = 0;

                foreach (DefineArray oldpiece1080i50 in GetSet.oldpixelgetset)
                {
                    if (samplecounter == Variables.rowsperline1080i50)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline1080i50)
                    {
                        Variables.s_linenumber = 1124;
                    }

                    else if (Variables.linecounter == Variables.rowsperline1080i50 || Variables.linecounter < (2 * Variables.rowsperline1080i50))
                    {
                        Variables.s_linenumber = 1125;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline1080i50) - 1;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.oldfiledataarray1080i50[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.oldfiledataarray1080i50[Variables.linecounter, 1] = Variables.samplearray1080i50[samplecounter, 0];
                    Variables.oldfiledataarray1080i50[Variables.linecounter, 2] = Variables.samplearray1080i50[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample1080i = 1924;
                System.Array.Clear(Variables.samplearray1080i50, 0, Variables.samplearray1080i50.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }

        public void OldFileSort1080i59()
        {
            try
            {
                //initializing samplearray1080i59
                for (int h = 0; h < Variables.rowsperline1080i59; h++)
                {
                    if (Variables.firstsample1080i == 2200)
                    {
                        Variables.firstsample1080i = 0;
                    }

                    Variables.samplearray1080i59[h, 0] = Variables.firstsample1080i;
                    Variables.samplearray1080i59[h, 1] = Variables.firstsample1080i + 1;
                    Variables.firstsample1080i += 2;
                }

                int samplecounter = 0;
                foreach (DefineArray oldpiece1080i59 in GetSet.oldpixelgetset)
                {
                    //calculate sample number
                    if (samplecounter == Variables.rowsperline1080i59)
                    {
                        samplecounter = 0;
                    }

                    //calculate line number
                    if (Variables.linecounter < Variables.rowsperline1080i59)
                    {
                        Variables.s_linenumber = 1124;
                    }

                    else if (Variables.linecounter == Variables.rowsperline1080i59 || Variables.linecounter < (2 * Variables.rowsperline1080i59))
                    {
                        Variables.s_linenumber = 1125;
                    }

                    else
                    {
                        Variables.s_linenumber = (Variables.linecounter / Variables.rowsperline1080i59) - 1;
                    }

                    //save line number for item in samplearray
                    //1st col : linenumber
                    //2nd col : sample number

                    Variables.oldfiledataarray1080i59[Variables.linecounter, 0] = System.Convert.ToInt32(Variables.s_linenumber);
                    Variables.oldfiledataarray1080i59[Variables.linecounter, 1] = Variables.samplearray1080i59[samplecounter, 0];
                    Variables.oldfiledataarray1080i59[Variables.linecounter, 2] = Variables.samplearray1080i59[samplecounter, 1];
                    Variables.linecounter++;
                    samplecounter++;
                }

                //re-initialize to initial value for re-use
                Variables.linecounter = 0;
                Variables.firstsample1080i = 1924;
                System.Array.Clear(Variables.samplearray1080i59, 0, Variables.samplearray1080i59.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_sort);
                return;
            }
            
        }
    }
}
