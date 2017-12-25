using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public enum GeometryType
    {
        Unknown = -1,
        Point = 1,
        Envelope = 2,
        Polyline = 3,
        Polygon = 4,
        Multipoint = 5,
    }
}
