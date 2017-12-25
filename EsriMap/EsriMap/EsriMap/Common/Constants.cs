using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Controls;
using EsriMap.Controls.Geometrys;

namespace EsriMap.Common
{
    public class Constants
    {
       public static class DefaultValues
       {
           public const string DefaultWebMapUrl = "https://www.arcgis.com/home/item.html?id=2d6fa24b357d427f9c737774e7b0f977";
           public static readonly Viewpoint DefaultViewpoint = new Viewpoint(new Envelope(108.6576703038, 34.1177313608, 109.2576703038,
               34.5177313608, SpatialReferenceType.Wgs84));
       }

        public static class MessageCenterKeys
        {
            public const string ShowCalloutAtKey = "ShowCalloutAtKey";
            public const string SketchCancelKey = "SketchCancelKey";
            public const string SketchCompleteKey = "SketchCompleteKey";
        }
    }
}
