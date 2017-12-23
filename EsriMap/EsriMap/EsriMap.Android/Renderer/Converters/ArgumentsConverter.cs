using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.UI;

namespace EsriMap.Droid.Renderer.Converters
{
    public class ArgumentsConverter
    {
        public static MapPoint ConvertFrom(Controls.MapPoint mapPoint)
        {
            MapPoint nativeMapPoint = new MapPoint(mapPoint.X, mapPoint.Y);
            return nativeMapPoint;
        }

        public static CalloutDefinition ConvertFrom(Controls.CalloutDefinition definition)
        {
            CalloutDefinition nativeDefinition = new CalloutDefinition(definition.Title, definition.Message);
            return nativeDefinition;
        }
    }
}