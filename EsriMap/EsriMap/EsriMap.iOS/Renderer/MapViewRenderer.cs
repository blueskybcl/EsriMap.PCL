using System.ComponentModel;
using Esri.ArcGISRuntime.UI.Controls;
using EsriMap.iOS.Renderer;
using EsriMap.iOS.Renderer.Adapters;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CusMapView = EsriMap.Controls.MapView;

[assembly: ExportRenderer(typeof(CusMapView), typeof(MapViewRenderer))]

namespace EsriMap.iOS.Renderer
{
    public class MapViewRenderer : ViewRenderer<CusMapView, MapView>
    {
        private MapView _originMapView;
        private readonly MapViewAdapter _adapter = MapViewAdapter.Instance;

        protected override void OnElementChanged(ElementChangedEventArgs<CusMapView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {

            }

            CusMapView currentElement = e.NewElement;
            if (currentElement != null)
            {
                _originMapView = _adapter.Adapter(currentElement);
            }

            if (Control == null)
            {
                SetNativeControl(_originMapView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CusMapView.MapProperty.PropertyName)
            {
                UpdateMap();
            }
        }

        private void UpdateMap()
        {
            if (Element is CusMapView cusMapView)
            {
                _originMapView.Map.Basemap = _adapter.GetBaseMap(cusMapView);
            }
        }
    }
}
