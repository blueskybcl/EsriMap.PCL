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
             MapView.Map = new Map
            {
                BaseMapName = "Streets",
                MapType = MapType.Streets
            };
        }
    }
}
