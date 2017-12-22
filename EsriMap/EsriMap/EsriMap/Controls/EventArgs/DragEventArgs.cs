using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls.EventArgs
{
    public class DragEventArgs
    {
        public bool Handled { get; set; }
        public DragAction Action { get; set; } = DragAction.Started;
        public double Log { get; set; }
        public double Lat { get; set; }
    }
}
