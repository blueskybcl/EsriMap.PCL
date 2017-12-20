using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public sealed class MapViewInteractionOptions : InteractionOptions
    {
        public bool IsPanEnabled { get; set; } = true;
        
        public bool IsZoomEnabled { get; set; } = true;
        
        public bool IsRotateEnabled { get; set; } = true;
        
        public double SnapToNorthThreshold { get; set; } = 7.5;
        
        public bool IsMagnifierEnabled { get; set; } = true;
        
        public bool AllowMagnifierToPan { get; set; } = true;

        internal bool CanRotate
        {
            get
            {
                if (IsEnabled)
                    return IsRotateEnabled;
                return false;
            }
        }

        internal bool ResetRotation
        {
            get
            {
                if (IsRotateEnabled)
                    return SnapToNorthThreshold > 0.0;
                return false;
            }
        }

        internal override bool CanPan
        {
            get
            {
                if (base.CanPan)
                    return IsPanEnabled;
                return false;
            }
        }

        internal override bool CanZoom
        {
            get
            {
                if (base.CanZoom)
                    return IsZoomEnabled;
                return false;
            }
        }

        internal override bool CanMouseWheelZoom
        {
            get
            {
                if (CanZoom)
                    return base.CanMouseWheelZoom;
                return false;
            }
        }
    }
}
