using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace WpfApplication1
{
    [IgnoreFirst(19)]
    [DelimitedRecord(",")]
    public class DefineArray
    {
        public string Cb;
        public string Yc;
        public string Cr;
        public string Y;
    }
}
