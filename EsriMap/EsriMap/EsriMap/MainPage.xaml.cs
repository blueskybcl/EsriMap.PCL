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
        private readonly Viewpoint _defaultViewpoint = new Viewpoint(new Envelope(107.40, 33.42, 109.49,
            34.45, SpatialReferenceType.WebMercator));

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
                    MyMapView.Map = new Map {MapType = MapType.ImageryWithLabels};
                    break;

                case 2:
                    MyMapView.Map = new Map {MapType = MapType.Oceans};
                    break;

                case 3:
                    MyMapView.Map = new Map {MapType = MapType.Streets};
                    break;

                case 4:
                    MyMapView.Map = new Map {MapType = MapType.StreetsVector};
                    break;

                case 5:
                    MyMapView.Map = new Map {MapType = MapType.TerrainWithLabels};
                    break;
            }
        }
    }
}
