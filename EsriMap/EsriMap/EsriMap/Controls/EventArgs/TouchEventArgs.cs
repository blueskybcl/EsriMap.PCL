using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls.EventArgs
{
    public class TouchEventArgs: System.EventArgs
    {
        public int PointerCount { get; set; }
        public double Log { get; set; }
        public double Lat { get; set; }
        public bool Handled { get; set; }
    }
}
