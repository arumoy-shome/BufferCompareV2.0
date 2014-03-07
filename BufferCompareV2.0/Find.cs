using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    class Find
    {

        public void NewFileFind720p50(ListView newlistview720p50, ListView oldlistview720p50)
        {
            try
            {
                //create new list
                List<Variables> newitem720p50 = new List<Variables>();
                List<Variables> olditem720p50 = new List<Variables>();

                //itirate through newfiledataarray and populate list
                for (int i = 0; i < Variables.totalrows720p50; i++)
                {
                    //run the following only when linenumber is NOT 26-745 (ancillary data)
                    if (i < (Variables.rowsperline720p50 * 30))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((i <= Variables.totalrows720p50 - 2) && (Variables.newfiledataarray720p50[i, 0] == Variables.newfiledataarray720p50[(i + 1), 0]))
                        {
                            //locate packet and print DID-SDID
                            if (GetSet.newpixelgetset[i].Y.Equals("000") && GetSet.newpixelgetset[i + 1].Yc.Equals("3ff") && GetSet.newpixelgetset[i + 1].Y.Equals("3ff"))
                            {
                                newitem720p50.Add(new Variables() { linenumber = Variables.newfiledataarray720p50[i + 2, 0], samplenumber = Variables.newfiledataarray720p50[i, 2], DIDSDID = GetSet.newpixelgetset[i + 2].Yc.Substring(1) + "/" + GetSet.newpixelgetset[i + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[i + 3].Yc.Substring(1), 16) });
                                //for (int ii = 0; ii < System.Convert.ToInt32(GetSet.newpixelgetset[i + 3].Yc.Substring(1), 16); ii++)
                                //{
                                //    if ( i % 2 = 0)
                                //    { }
                                //}
                            }

                            else if (GetSet.newpixelgetset[i].Yc.Equals("000") && GetSet.newpixelgetset[i].Y.Equals("3ff") && GetSet.newpixelgetset[i + 1].Yc.Equals("3ff"))
                            {
                                newitem720p50.Add(new Variables() { linenumber = Variables.newfiledataarray720p50[i + 1, 0], samplenumber = Variables.newfiledataarray720p50[i, 1], DIDSDID = GetSet.newpixelgetset[i + 1].Y.Substring(1) + "/" + GetSet.newpixelgetset[i + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[i + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item720p50 in newitem720p50)
                    {
                        if (item720p50.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item720p50.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item720p50.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item720p50 in newitem720p50)
                    {
                        if (item720p50.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item720p50.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item720p50.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item720p50 in newitem720p50)
                    if (item720p50.usedwhere == null)
                    {
                        item720p50.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                newlistview720p50.ItemsSource = newitem720p50;


                //itirate through oldfiledataarray
                for (int i = 0; i < Variables.totalrows720p50; i++)
                {
                    //run the following only when linenumber is NOT 26-745 (ancillary data)
                    if (i < (Variables.rowsperline720p50 * 30))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((i <= Variables.totalrows720p50 - 2) && (Variables.oldfiledataarray720p50[i, 0] == Variables.oldfiledataarray720p50[(i + 1), 0]))
                        {
                            if (GetSet.oldpixelgetset[i].Y.Equals("000") && GetSet.oldpixelgetset[i + 1].Yc.Equals("3ff") && GetSet.oldpixelgetset[i + 1].Y.Equals("3ff"))
                            {
                                olditem720p50.Add(new Variables() { linenumber = Variables.oldfiledataarray720p50[i + 2, 0], samplenumber = Variables.oldfiledataarray720p50[i, 2], DIDSDID = GetSet.oldpixelgetset[i + 2].Yc.Substring(1) + "/" + GetSet.oldpixelgetset[i + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[i + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.oldpixelgetset[i].Yc.Equals("000") && GetSet.oldpixelgetset[i].Y.Equals("3ff") && GetSet.oldpixelgetset[i + 1].Yc.Equals("3ff"))
                            {
                                olditem720p50.Add(new Variables() { linenumber = Variables.oldfiledataarray720p50[i + 1, 0], samplenumber = Variables.oldfiledataarray720p50[i, 1], DIDSDID = GetSet.oldpixelgetset[i + 1].Y.Substring(1) + "/" + GetSet.oldpixelgetset[i + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[i + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item720p50 in olditem720p50)
                    {
                        if (item720p50.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item720p50.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item720p50.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item720p50 in olditem720p50)
                    {
                        if (item720p50.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item720p50.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item720p50.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item720p50 in olditem720p50)
                    if (item720p50.usedwhere == null)
                    {
                        item720p50.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                oldlistview720p50.ItemsSource = olditem720p50;


                //refresh listviews
                oldlistview720p50.Items.Refresh();
                newlistview720p50.Items.Refresh();

                //clear arrays/variables for re-sure
                System.Array.Clear(Variables.newfiledataarray720p50, 0, Variables.newfiledataarray720p50.Length);
                System.Array.Clear(Variables.oldfiledataarray720p50, 0, Variables.oldfiledataarray720p50.Length);
                System.Array.Clear(GetSet.newpixelgetset, 0, GetSet.newpixelgetset.Length);
                System.Array.Clear(GetSet.oldpixelgetset, 0, GetSet.oldpixelgetset.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_find);
                return;
            }
           
        }

        public void NewFileFind720p59(ListView newlistview720p59, ListView oldlistview720p59)
        {
            try
            {
                //create new list
                List<Variables> newitem720p59 = new List<Variables>();
                List<Variables> olditem720p59 = new List<Variables>();

                //Search for DID/SDID within same line number
                //itirate through newfiledataarray
                for (int j = 0; j < Variables.totalrows720p59; j++)
                {
                    //run the following only when linenumber is NOT 26-745 (ancillary data)
                    if (j < (Variables.rowsperline720p59 * 30))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((j <= Variables.totalrows720p59 - 2) && (Variables.newfiledataarray720p59[j, 0] == Variables.newfiledataarray720p59[(j + 1), 0]))
                        {
                            if (GetSet.newpixelgetset[j].Y.Equals("000") && GetSet.newpixelgetset[j + 1].Yc.Equals("3ff") && GetSet.newpixelgetset[j + 1].Y.Equals("3ff"))
                            {
                                newitem720p59.Add(new Variables() { linenumber = Variables.newfiledataarray720p59[j + 2, 0], samplenumber = Variables.newfiledataarray720p59[j, 2], DIDSDID = GetSet.newpixelgetset[j + 2].Yc.Substring(1) + "/" + GetSet.newpixelgetset[j + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[j + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.newpixelgetset[j].Yc.Equals("000") && GetSet.newpixelgetset[j].Y.Equals("3ff") && GetSet.newpixelgetset[j + 1].Yc.Equals("3ff"))
                            {
                                newitem720p59.Add(new Variables() { linenumber = Variables.newfiledataarray720p59[j + 1, 0], samplenumber = Variables.newfiledataarray720p59[j, 1], DIDSDID = GetSet.newpixelgetset[j + 1].Y.Substring(1) + "/" + GetSet.newpixelgetset[j + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[j + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                ////manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item720p59 in newitem720p59)
                    {
                        if (item720p59.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item720p59.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item720p59.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item720p59 in newitem720p59)
                    {
                        if (item720p59.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item720p59.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item720p59.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                ////set used where to unknown if no match for DID/SDID is found
                foreach (Variables item720p59 in newitem720p59)
                    if (item720p59.usedwhere == null)
                    {
                        item720p59.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                newlistview720p59.ItemsSource = newitem720p59;


                //Search for DID/SDID within same line number
                //itirate through oldfiledataarray
                for (int j = 0; j < Variables.totalrows720p59; j++)
                {
                    //run the following only when linenumber is NOT 26-745 (ancillary data)
                    if (j < (Variables.rowsperline720p59 * 30))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((j <= Variables.totalrows720p59 - 2) && (Variables.oldfiledataarray720p59[j, 0] == Variables.oldfiledataarray720p59[(j + 1), 0]))
                        {
                            if (GetSet.oldpixelgetset[j].Y.Equals("000") && GetSet.oldpixelgetset[j + 1].Yc.Equals("3ff") && GetSet.oldpixelgetset[j + 1].Y.Equals("3ff"))
                            {
                                olditem720p59.Add(new Variables() { linenumber = Variables.oldfiledataarray720p59[j + 2, 0], samplenumber = Variables.oldfiledataarray720p59[j, 2], DIDSDID = GetSet.oldpixelgetset[j + 2].Yc.Substring(1) + "/" + GetSet.oldpixelgetset[j + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[j + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.oldpixelgetset[j].Yc.Equals("000") && GetSet.oldpixelgetset[j].Y.Equals("3ff") && GetSet.oldpixelgetset[j + 1].Yc.Equals("3ff"))
                            {
                                olditem720p59.Add(new Variables() { linenumber = Variables.oldfiledataarray720p59[j + 1, 0], samplenumber = Variables.oldfiledataarray720p59[j, 1], DIDSDID = GetSet.oldpixelgetset[j + 1].Y.Substring(1) + "/" + GetSet.oldpixelgetset[j + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[j + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item720p59 in olditem720p59)
                    {
                        if (item720p59.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item720p59.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item720p59.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item720p59 in olditem720p59)
                    {
                        if (item720p59.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item720p59.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item720p59.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item720p59 in olditem720p59)
                    if (item720p59.usedwhere == null)
                    {
                        item720p59.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                oldlistview720p59.ItemsSource = olditem720p59;

                //Refresh listviews

                oldlistview720p59.Items.Refresh();
                newlistview720p59.Items.Refresh();

                //clear arrays/variables for re-sure
                System.Array.Clear(Variables.newfiledataarray720p59, 0, Variables.newfiledataarray720p59.Length);
                System.Array.Clear(Variables.oldfiledataarray720p59, 0, Variables.oldfiledataarray720p59.Length);
                System.Array.Clear(GetSet.newpixelgetset, 0, GetSet.newpixelgetset.Length);
                System.Array.Clear(GetSet.oldpixelgetset, 0, GetSet.oldpixelgetset.Length);
            }

            catch 
            {
                MessageBox.Show(Variables.string_unknownerror_find);
                return;
            }
           
        }

        public void NewFileFind1080i50(ListView newlistview1080i50, ListView oldlistview1080i50)
        {
            try
            {
                //create new list for newpixelgetset
                List<Variables> newitem1080i50 = new List<Variables>();

                //Search for DID/SDID within same line number
                //itirate through findnewfiledataarray
                for (int k = 0; k < Variables.totalrows1080i50; k++)
                {
                    //run the following only when linenumber is NOT 21-560 and 584-1123 (ancillary data)
                    if (k < (Variables.rowsperline1080i50 * 22) || (k >= (Variables.rowsperline1080i50 * 562) && k < (Variables.rowsperline1080i50 * 585)))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((k <= Variables.totalrows1080i50 - 2) && (Variables.newfiledataarray1080i50[k, 0] == Variables.newfiledataarray1080i50[(k + 1), 0]))
                        {
                            if (GetSet.newpixelgetset[k].Y.Equals("000") && GetSet.newpixelgetset[k + 1].Yc.Equals("3ff") && GetSet.newpixelgetset[k + 1].Y.Equals("3ff"))
                            {
                                newitem1080i50.Add(new Variables() { linenumber = Variables.newfiledataarray1080i50[k + 2, 0], samplenumber = Variables.newfiledataarray1080i50[k, 2], DIDSDID = GetSet.newpixelgetset[k + 2].Yc.Substring(1) + "/" + GetSet.newpixelgetset[k + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[k + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.newpixelgetset[k].Yc.Equals("000") && GetSet.newpixelgetset[k].Y.Equals("3ff") && GetSet.newpixelgetset[k + 1].Yc.Equals("3ff"))
                            {
                                newitem1080i50.Add(new Variables() { linenumber = Variables.newfiledataarray1080i50[k + 1, 0], samplenumber = Variables.newfiledataarray1080i50[k, 1], DIDSDID = GetSet.newpixelgetset[k + 1].Y.Substring(1) + "/" + GetSet.newpixelgetset[k + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[k + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item1080i50 in newitem1080i50)
                    {
                        if (item1080i50.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item1080i50.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item1080i50.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item1080i50 in newitem1080i50)
                    {
                        if (item1080i50.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item1080i50.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item1080i50.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item1080i50 in newitem1080i50)
                    if (item1080i50.usedwhere == null)
                    {
                        item1080i50.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                newlistview1080i50.ItemsSource = newitem1080i50;


                //new list for oldpixelgetset
                List<Variables> olditem1080i50 = new List<Variables>();

                //Search for DID/SDID within same line number
                //itirate through findoldfiledataarray
                for (int k = 0; k < Variables.totalrows1080i50; k++)
                {
                    //run the following only when linenumber is NOT 21-560 and 584-1123 (ancillary data)
                    if (k < (Variables.rowsperline1080i50 * 22) || (k >= (Variables.rowsperline1080i50 * 562) && k < (Variables.rowsperline1080i50 * 585)))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((k <= Variables.totalrows1080i50 - 2) && (Variables.oldfiledataarray1080i50[k, 0] == Variables.oldfiledataarray1080i50[(k + 1), 0]))
                        {
                            if (GetSet.oldpixelgetset[k].Y.Equals("000") && GetSet.oldpixelgetset[k + 1].Yc.Equals("3ff") && GetSet.oldpixelgetset[k + 1].Y.Equals("3ff"))
                            {
                                olditem1080i50.Add(new Variables() { linenumber = Variables.oldfiledataarray1080i50[k + 2, 0], samplenumber = Variables.oldfiledataarray1080i50[k, 2], DIDSDID = GetSet.oldpixelgetset[k + 2].Yc.Substring(1) + "/" + GetSet.oldpixelgetset[k + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[k + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.oldpixelgetset[k].Yc.Equals("000") && GetSet.oldpixelgetset[k].Y.Equals("3ff") && GetSet.oldpixelgetset[k + 1].Yc.Equals("3ff"))
                            {
                                olditem1080i50.Add(new Variables() { linenumber = Variables.oldfiledataarray1080i50[k + 1, 0], samplenumber = Variables.oldfiledataarray1080i50[k, 1], DIDSDID = GetSet.oldpixelgetset[k + 1].Y.Substring(1) + "/" + GetSet.oldpixelgetset[k + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[k + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item1080i50 in olditem1080i50)
                    {
                        if (item1080i50.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item1080i50.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item1080i50.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item1080i50 in olditem1080i50)
                    {
                        if (item1080i50.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item1080i50.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item1080i50.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item1080i50 in olditem1080i50)
                    if (item1080i50.usedwhere == null)
                    {
                        item1080i50.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                oldlistview1080i50.ItemsSource = olditem1080i50;

                //Refresh listviews
                newlistview1080i50.Items.Refresh();
                oldlistview1080i50.Items.Refresh();

                //clear arrays/variables for re-sure
                System.Array.Clear(Variables.newfiledataarray1080i50, 0, Variables.newfiledataarray1080i50.Length);
                System.Array.Clear(Variables.oldfiledataarray1080i50, 0, Variables.oldfiledataarray1080i50.Length);
                System.Array.Clear(GetSet.newpixelgetset, 0, GetSet.newpixelgetset.Length);
                System.Array.Clear(GetSet.oldpixelgetset, 0, GetSet.oldpixelgetset.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_find);
                return;
            }
           
        }

        public void NewFileFind1080i59(ListView newlistview1080i59, ListView oldlistview1080i59)
        {
            try
            {
                //create new list
                List<Variables> newitem1080i59 = new List<Variables>();
                List<Variables> olditem1080i59 = new List<Variables>();

                //Search for DID/SDID within same line number
                //itirate through findnewfiledataarray
                for (int l = 0; l < Variables.totalrows1080i59; l++)
                {
                    //run the following only when linenumber is NOT 21-560 and 584-1123 (ancillary data)
                    if (l < (Variables.rowsperline1080i59 * 22) || (l >= (Variables.rowsperline1080i59 * 562) && l < (Variables.rowsperline1080i59 * 585)))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((l <= Variables.totalrows1080i59 - 2) && (Variables.newfiledataarray1080i59[l, 0] == Variables.newfiledataarray1080i59[(l + 1), 0]))
                        {
                            if (GetSet.newpixelgetset[l].Y.Equals("000") && GetSet.newpixelgetset[l + 1].Yc.Equals("3ff") && GetSet.newpixelgetset[l + 1].Y.Equals("3ff"))
                            {
                                newitem1080i59.Add(new Variables() { linenumber = Variables.newfiledataarray1080i59[l + 2, 0], samplenumber = Variables.newfiledataarray1080i59[l, 2], DIDSDID = GetSet.newpixelgetset[l + 2].Yc.Substring(1) + "/" + GetSet.newpixelgetset[l + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[l + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.newpixelgetset[l].Yc.Equals("000") && GetSet.newpixelgetset[l].Y.Equals("3ff") && GetSet.newpixelgetset[l + 1].Yc.Equals("3ff"))
                            {
                                newitem1080i59.Add(new Variables() { linenumber = Variables.newfiledataarray1080i59[l + 1, 0], samplenumber = Variables.newfiledataarray1080i59[l, 1], DIDSDID = GetSet.newpixelgetset[l + 1].Y.Substring(1) + "/" + GetSet.newpixelgetset[l + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.newpixelgetset[l + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item1080i59 in newitem1080i59)
                    {
                        if (item1080i59.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item1080i59.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item1080i59.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item1080i59 in newitem1080i59)
                    {
                        if (item1080i59.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item1080i59.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item1080i59.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item1080i59 in newitem1080i59)
                    if (item1080i59.usedwhere == null)
                    {
                        item1080i59.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                newlistview1080i59.ItemsSource = newitem1080i59;

                //Search for DID/SDID within same line number
                //itirate through findnewfiledataarray
                for (int l = 0; l < Variables.totalrows1080i59; l++)
                {
                    //run the following only when linenumber is NOT 21-560 and 584-1123 (ancillary data)
                    if (l < (Variables.rowsperline1080i59 * 22) || (l >= (Variables.rowsperline1080i59 * 562) && l < (Variables.rowsperline1080i59 * 585)))
                    {
                        //carry out until second last row
                        //carry out only within same line number
                        if ((l <= Variables.totalrows1080i59 - 2) && (Variables.oldfiledataarray1080i59[l, 0] == Variables.oldfiledataarray1080i59[(l + 1), 0]))
                        {

                            if (GetSet.oldpixelgetset[l].Y.Equals("000") && GetSet.oldpixelgetset[l + 1].Yc.Equals("3ff") && GetSet.oldpixelgetset[l + 1].Y.Equals("3ff"))
                            {
                                olditem1080i59.Add(new Variables() { linenumber = Variables.oldfiledataarray1080i59[l + 2, 0], samplenumber = Variables.oldfiledataarray1080i59[l, 2], DIDSDID = GetSet.oldpixelgetset[l + 2].Yc.Substring(1) + "/" + GetSet.oldpixelgetset[l + 2].Y.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[l + 3].Yc.Substring(1), 16) });
                            }

                            else if (GetSet.oldpixelgetset[l].Yc.Equals("000") && GetSet.oldpixelgetset[l].Y.Equals("3ff") && GetSet.oldpixelgetset[l + 1].Yc.Equals("3ff"))
                            {
                                olditem1080i59.Add(new Variables() { linenumber = Variables.oldfiledataarray1080i59[l + 1, 0], samplenumber = Variables.oldfiledataarray1080i59[l, 1], DIDSDID = GetSet.oldpixelgetset[l + 1].Y.Substring(1) + "/" + GetSet.oldpixelgetset[l + 2].Yc.Substring(1), datecount = System.Convert.ToInt32(GetSet.oldpixelgetset[l + 2].Y.Substring(1), 16) });
                            }
                        }
                    }
                }

                //manipulate list
                for (int ii = 0; ii < 34; ii++)
                {
                    foreach (Variables item1080i59 in olditem1080i59)
                    {
                        if (item1080i59.DIDSDID.Substring(0, 2).Contains(Variables.onlydidarray[ii, 0]))
                        {
                            item1080i59.DIDSDID = Variables.onlydidarray[ii, 0] + "/--";
                            item1080i59.usedwhere = Variables.onlydidarray[ii, 2];
                        }
                    }
                }

                for (int ii = 0; ii < 42; ii++)
                {
                    foreach (Variables item1080i59 in olditem1080i59)
                    {
                        if (item1080i59.DIDSDID.Substring(0, 2).Contains(Variables.didsdidarray[ii, 0]) && item1080i59.DIDSDID.Substring(3, 2).Contains(Variables.didsdidarray[ii, 1]))
                        {
                            item1080i59.usedwhere = Variables.didsdidarray[ii, 2];
                        }
                    }
                }

                //set used where to unknown if no match for DID/SDID is found
                foreach (Variables item1080i59 in olditem1080i59)
                    if (item1080i59.usedwhere == null)
                    {
                        item1080i59.usedwhere = "Unknown";
                    }

                //set itemsource of listview
                oldlistview1080i59.ItemsSource = olditem1080i59;

                //Refresh listviews
                oldlistview1080i59.Items.Refresh();
                newlistview1080i59.Items.Refresh();

                //clear arrays/variables for re-sure
                System.Array.Clear(Variables.newfiledataarray1080i59, 0, Variables.newfiledataarray1080i59.Length);
                System.Array.Clear(Variables.oldfiledataarray1080i59, 0, Variables.oldfiledataarray1080i59.Length);
                System.Array.Clear(GetSet.newpixelgetset, 0, GetSet.newpixelgetset.Length);
                System.Array.Clear(GetSet.oldpixelgetset, 0, GetSet.oldpixelgetset.Length);
            }

            catch
            {
                MessageBox.Show(Variables.string_unknownerror_find);
                return;
            }
          
        }
    }
}
