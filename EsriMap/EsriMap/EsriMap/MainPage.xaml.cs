using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Controls;
using EsriMap.Controls.Geometrys;
using Xamarin.Forms;

namespace EsriMap
{
    public partial class MainPage : ContentPage
    {
        private const string DefaultWebMapUrl =
            "https://www.arcgis.com/home/item.html?id=2d6fa24b357d427f9c737774e7b0f977";
        private readonly Viewpoint _defaultViewpoint = new Viewpoint(new Envelope(108.6576703038, 34.1177313608, 109.2576703038,
            34.5177313608, SpatialReferenceType.Wgs84));

        public MainPage()
        {
            InitializeComponent();
            MyMapView.Map = new Map
            {
                MapType = MapType.WebMap,
                WebMapUrl = DefaultWebMapUrl,
                InitialViewpoint = _defaultViewpoint
            };
        }

        private void MapTypeTab_OnItemTapped(object sender, int e)
        {
            switch (e)
            {
                case 0:
                    MyMapView.Map = new Map {MapType = MapType.Imagery, InitialViewpoint = _defaultViewpoint};
                    break;

                case 1:
                    MyMapView.Map = new Map {MapType = MapType.ImageryWithLabels, InitialViewpoint = _defaultViewpoint };
                    break;

                case 2:
                    MyMapView.Map = new Map {MapType = MapType.Oceans, InitialViewpoint = _defaultViewpoint };
                    break;

                case 3:
                    MyMapView.Map = new Map {MapType = MapType.Streets, InitialViewpoint = _defaultViewpoint };
                    break;

                case 4:
                    MyMapView.Map = new Map {MapType = MapType.StreetsVector, InitialViewpoint = _defaultViewpoint };
                    break;

                case 5:
                    MyMapView.Map = new Map {MapType = MapType.TerrainWithLabels, InitialViewpoint = _defaultViewpoint };
                    break;
            }
        }
    }
}
