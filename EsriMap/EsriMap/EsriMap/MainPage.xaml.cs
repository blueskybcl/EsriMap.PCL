using EsriMap.Common;
using EsriMap.Controls;
using EsriMap.Controls.EventArgs;
using EsriMap.Controls.Geometrys;
using Xamarin.Forms;

namespace EsriMap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMapView.Map = new Map
            {
                MapType = MapType.WebMap,
                WebMapUrl = Constants.DefaultValues.DefaultWebMapUrl,
                InitialViewpoint = Constants.DefaultValues.DefaultViewpoint
            };
        }

        private void MapTypeTab_OnItemTapped(object sender, int e)
        {
            switch (e)
            {
                case 0:
                    MyMapView.Map = new Map {MapType = MapType.Imagery, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;

                case 1:
                    MyMapView.Map = new Map {MapType = MapType.ImageryWithLabels, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;

                case 2:
                    MyMapView.Map = new Map {MapType = MapType.Oceans, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;

                case 3:
                    MyMapView.Map = new Map {MapType = MapType.Streets, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;

                case 4:
                    MyMapView.Map = new Map {MapType = MapType.StreetsVector, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;

                case 5:
                    MyMapView.Map = new Map {MapType = MapType.TerrainWithLabels, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
                    break;
            }
        }

        private void MyMapView_OnGeoViewTapped(object sender, GeoViewInputEventArgs e)
        {
            MyMapView.ShowCalloutAt(new CalloutDefinition
            {
                Location = e.Location,
                Title = "Test",
                Message = "只不过测试一下"
            });
        }
    }
}
