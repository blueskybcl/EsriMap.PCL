using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public abstract class InteractionOptions
    {
        internal InteractionOptions()
        {
        }
        
        public bool IsEnabled { get; set; } = true;
        
        public WheelZoomDirection WheelZoomDirection { get; set; }

        internal virtual bool CanMouseWheelZoom => IsEnabled;

        internal virtual bool CanPan => IsEnabled;

        internal virtual bool CanZoom => IsEnabled;
    }
}
