using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Common;
using EsriMap.Controls;
using EsriMap.Controls.Geometrys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsriMap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SketchMap : ContentPage
    {
        private GraphicsOverlay _sketchOverlay;
        private SketchCreationMode _creationMode;

        public SketchMap()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            MyMapView.Map = new Map { MapType = MapType.Streets, InitialViewpoint = Constants.DefaultValues.DefaultViewpoint };
            _sketchOverlay = new GraphicsOverlay();
            MyMapView.GraphicsOverlays.Add(_sketchOverlay);

            var config = MyMapView.SketchEditor.EditConfiguration;
            config.AllowVertexEditing = true;
            config.ResizeMode = SketchResizeMode.Uniform;
            config.AllowMove = true;

            BindingContext = MyMapView.SketchEditor;
        }

        private async void Draw()
        {
            try
            {
                Geometry geometry = await MyMapView.SketchEditor.StartAsync(creationMode, true);

                // Create and add a graphic from the geometry the user drew
                Graphic graphic = CreateGraphic(geometry);
                _sketchOverlay.Graphics.Add(graphic);
            }
            catch (TaskCanceledException)
            {
                // Ignore ... let the user cancel drawing
            }
            catch (Exception ex)
            {
                // Report exceptions
                await DisplayAlert("Error", "Error drawing graphic shape: " + ex.Message, "OK");
            }
        }

        private Graphic CreateGraphic(Geometry geometry)
        {
            // Create a graphic to display the specified geometry
            Symbol symbol = null;
            switch (geometry.GeometryType)
            {
                // Symbolize with a fill symbol
                case GeometryType.Envelope:
                case GeometryType.Polygon:
                {
                    symbol = new SimpleFillSymbol()
                    {
                        Color = Colors.Red,
                        Style = SimpleFillSymbolStyle.Solid,
                    };
                    break;
                }
                // Symbolize with a line symbol
                case GeometryType.Polyline:
                {
                    symbol = new SimpleLineSymbol()
                    {
                        Color = Colors.Red,
                        Style = SimpleLineSymbolStyle.Solid,
                        Width = 5d
                    };
                    break;
                }
                // Symbolize with a marker symbol
                case GeometryType.Point:
                case GeometryType.Multipoint:
                {

                    symbol = new SimpleMarkerSymbol()
                    {
                        Color = Colors.Red,
                        Style = SimpleMarkerSymbolStyle.Circle,
                        Size = 15d
                    };
                    break;
                }
            }

            // pass back a new graphic with the appropriate symbol
            return new Graphic(geometry, symbol);
        }

        private void SketchModeTab_OnItemTapped(object sender, int e)
        {
            switch (e)
            {
                case 0:
                    _creationMode = SketchCreationMode.Circle;
                    break;

                case 1:
                    _creationMode = SketchCreationMode.Rectangle;
                    break;

                case 2:
                    _creationMode = SketchCreationMode.FreehandLine;
                    break;

                case 3:
                    _creationMode = SketchCreationMode.FreehandPolygon;
                    break;
            }
        }
    }
}