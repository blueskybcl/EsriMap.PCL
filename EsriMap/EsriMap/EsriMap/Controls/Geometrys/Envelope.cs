using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls.Geometrys
{
    public class Envelope : Geometry
    {
        public Envelope(double xMin, double yMin, double xMax, double yMax, SpatialReferenceType spatialReference)
        {
            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
            SpatialReferenceType = spatialReference;
        }

        public double XMin { get; }

        public double YMin { get; }

        public double XMax { get; }

        public double YMax { get; }

        public SpatialReferenceType SpatialReferenceType { get; }
    }
}
