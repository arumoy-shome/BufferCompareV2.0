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

namespace WpfApplication1{

  class Index{

    public int Read(string file_path, int [] new_array){
      try{
        FileHelperEngine new_read = new FileHelperEngine(typeof(DefineArray));

        //reading new csv file
        public DefineArray[] new_pixel = new_read.ReadFile(file_path) as DefineArray[];
        return new_pixel.Length;
      }

      catch{
        MessageBox.Show("Invalid format! Please upload the simple format and try again.");
        return;
      }
    }

    public void Sort(string type){
      //sets params based on type
      int total_rows = 0;
      int rows_per_line = 0;
      int first_sample = 0;
      int sample_counter = 0;
      int line_counter = 0;
      int s_line_number = 0;

      switch(type){
        case "720p50":{
          total_rows = 742500;
          rows_per_line = 990;
          first_sample = 1284;
        }
        case "720p59":{
          total_rows =  618750;
          rows_per_line = 825;
          first_sample = 1284;
        }
        case "1080i50":{
          total_rows = 1485000;
          rows_per_line = 1320;
          first_sample = 1924;
        }
        case "1080i59":{
          total_rows = 1237500;
          rows_per_line = 1100;
          first_sample = 1924;
        }
        default:
        //
      }

      try{
        //initializing sample_array
        int[,] sample_array = new int[rows_per_line, 2];
        for (int a = 0; a < rows_per_line; a++){
          if (first_sample == 1980){
            first_sample = 0;
          }

          sample_array[a, 0] = sample_array;
          sample_array[a, 1] = sample_array + 1;
          first_sample += 2;
        }

        
        int[,] data_array = new int[total_rows, 3]
        foreach (DefineArray item in new_pixel){
          
          if (sample_counter == rows_per_line){
            sample_counter = 0;
          }

        //calculate line number
        if (line_counter < rows_per_line){
          s_line_number = 746;
        }

        else if (line_counter == rows_per_line || line_counter < (2 * rows_per_line)){
          s_line_number = 747;
        }

        else if (line_counter == (2 * rows_per_line) || line_counter < (3 * rows_per_line)){
          s_line_number = 748;
        }

        else if (line_counter == (3 * rows_per_line) || line_counter < (4 * rows_per_line)){
          s_line_number = 749;
        }

        else if (line_counter == (4 * rows_per_line) || line_counter < (5 * rows_per_line)){
          s_line_number = 750;
        }

        else{
          s_line_number = (line_counter / rows_per_line) - 4;
        }

            //save line number for item in samplearray
            //1st col : linenumber
            //2nd col : even sample number
            //3rd col : odd sample number
            data_array[line_counter, 0] = System.Convert.ToInt32(s_line_number);
            data_array[line_counter, 1] = sample_array[sample_counter, 0];
            data_array[line_counter, 2] = sample_array[sample_counter, 1];
            line_counter++;
            sample_counter++;
        }
      }

      catch{
        return MessageBox.Show(Variables.string_unknownerror_sort);
      }
    }


  }
}