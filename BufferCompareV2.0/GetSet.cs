using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public static class GetSet
    {

        private static DefineArray[] _newpixelgetset;
        public static DefineArray[] newpixelgetset
        {
            get
            {
                return _newpixelgetset;
            }

            set
            {
                _newpixelgetset = value;
            }
        }

        private static DefineArray[] _oldpixelgetset;
        public static DefineArray[] oldpixelgetset
        {
            get
            {
                return _oldpixelgetset;
            }

            set
            {
                _oldpixelgetset = value;
            }
        }
    }
}
