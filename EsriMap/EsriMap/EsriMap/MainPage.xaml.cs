using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Controls;
using Xamarin.Forms;

namespace EsriMap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMapView.Map = new Map();
        }

        private void MapTypeTab_OnItemTapped(object sender, int e)
        {
            switch (e)
            {
                case 0:
                    MyMapView.MapType = MapType.Imagery;
                    break;

                case 1:
                    MyMapView.MapType = MapType.ImageryWithLabels;
                    break;

                case 2:
                    MyMapView.MapType = MapType.Oceans;
                    break;

                case 3:
                    MyMapView.MapType = MapType.Streets;
                    break;

                case 4:
                    MyMapView.MapType = MapType.StreetsVector;
                    break;

                case 5:
                    MyMapView.MapType = MapType.TerrainWithLabels;
                    break;
            }
        }
    }
}
