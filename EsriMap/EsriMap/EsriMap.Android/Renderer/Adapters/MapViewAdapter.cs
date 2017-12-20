using System;
using Esri.ArcGISRuntime.Mapping;
using EsriMap.Controls;
using CusMapView = EsriMap.Controls.MapView;
using EsriMapView = Esri.ArcGISRuntime.UI.Controls.MapView;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace EsriMap.Android.Renderer.Adapters
{
    public sealed class MapViewAdapter
    {
        private MapViewAdapter()
        {
        }

        public static readonly MapViewAdapter Instance = new MapViewAdapter();

        public EsriMapView Adapter(CusMapView cusMapView)
        {
            EsriMapView XFMapView = new EsriMapView();
            MappingMap(XFMapView, cusMapView);
            //TODO: Attach custom property
            return XFMapView;
        }

        private void MappingMap(EsriMapView xfMapView, CusMapView cusMapView)
        {
            Basemap baseMap = GetBaseMap(cusMapView.Map.MapType);
            xfMapView.Map = new Map(baseMap);
        }

        public Basemap GetBaseMap(MapType mapType)
        {
            switch (mapType)
            {
                case MapType.Imagery:
                    return Basemap.CreateImagery();

                case MapType.Streets:
                    return Basemap.CreateStreets();

                case MapType.ImageryWithLabels:
                    return Basemap.CreateImageryWithLabels();

                case MapType.ImageryWithLabelsVector:
                    return Basemap.CreateImageryWithLabelsVector();

                case MapType.LightGrayCanvas:
                    return Basemap.CreateLightGrayCanvas();

                case MapType.LightGrayCanvasVector:
                    return Basemap.CreateLightGrayCanvasVector();

                case MapType.DarkGrayCanvasVector:
                    return Basemap.CreateDarkGrayCanvasVector();

                case MapType.NationalGeographic:
                    return Basemap.CreateNationalGeographic();

                case MapType.Oceans:
                    return Basemap.CreateOceans();

                case MapType.StreetsVector:
                    return Basemap.CreateStreetsVector();

                case MapType.StreetsWithReliefVector:
                    return Basemap.CreateStreetsWithReliefVector();

                case MapType.StreetsNightVector:
                    return Basemap.CreateStreetsNightVector();

                case MapType.NavigationVector:
                    return Basemap.CreateNavigationVector();

                case MapType.TerrainWithLabels:
                    return Basemap.CreateTerrainWithLabels();

                case MapType.TerrainWithLabelsVector:
                    return Basemap.CreateTerrainWithLabelsVector();

                case MapType.Topographic:
                    return Basemap.CreateTopographic();

                case MapType.TopographicVector:
                    return Basemap.CreateTopographicVector();

                case MapType.OpenStreetMap:
                    return Basemap.CreateOpenStreetMap();

                default:
                    throw new ArgumentOutOfRangeException(nameof(mapType), mapType, null);
            }
        }
    }
}