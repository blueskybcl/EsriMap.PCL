using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Controls.Geometrys;

namespace EsriMap.Controls
{
    public class Viewpoint
    {
        public Viewpoint(Envelope envelope)
        {
            Envelope = envelope;
        }

        public Envelope Envelope { get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Scale { get; set; }
        public double Rotation { get; set; }
    }
}
