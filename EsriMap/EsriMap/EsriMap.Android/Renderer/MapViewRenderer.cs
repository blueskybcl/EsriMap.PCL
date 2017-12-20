using System.ComponentModel;
using Esri.ArcGISRuntime.UI.Controls;
using EsriMap.Android.Renderer;
using EsriMap.Android.Renderer.Adapters;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CusMapView = EsriMap.Controls.MapView;

[assembly: ExportRenderer(typeof(CusMapView), typeof(MapViewRenderer))]

namespace EsriMap.Android.Renderer
{
    public class MapViewRenderer : ViewRenderer<CusMapView, MapView>
    {
        private MapView OriginMapView;

        protected override void OnElementChanged(ElementChangedEventArgs<CusMapView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {

            }

            CusMapView currentElement = e.NewElement;
            if (currentElement != null)
            {
                OriginMapView = MapViewAdapter.Instance.Adapter(currentElement);
            }

            if (Control == null)
            {
                SetNativeControl(OriginMapView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

        }
    }
}