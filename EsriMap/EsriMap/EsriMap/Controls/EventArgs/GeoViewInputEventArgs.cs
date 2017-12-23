using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsriMap.Controls.EventArgs
{
    public class GeoViewInputEventArgs : System.EventArgs
    {
        public GeoViewInputEventArgs(MapPoint location, Point position)
        {
            Location = location;
            Position = position;
        }

        public bool Handled { get; set; }

        public MapPoint Location { get; }

        public Point Position { get; }
    }
}
