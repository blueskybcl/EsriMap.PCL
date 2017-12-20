using System;
using Esri.ArcGISRuntime.Mapping;
using EsriMap.Controls;
using CusMapView = EsriMap.Controls.MapView;
using EsriMapView = Esri.ArcGISRuntime.UI.Controls.MapView;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace EsriMap.iOS.Renderer.Adapters
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

        private Basemap GetBaseMap(MapType mapType)
        {
            switch (mapType)
            {
                case MapType.Imagery:
                    return Basemap.CreateImagery();

                case MapType.Streets:
                    return Basemap.CreateStreets();

                case MapType.ImageryWithLabels:
                    break;

                case MapType.ImageryWithLabelsVector:
                    break;

                case MapType.LightGrayCanvas:
                    break;

                case MapType.LightGrayCanvasVector:
                    break;

                case MapType.DarkGrayCanvasVector:
                    break;

                case MapType.NationalGeographic:
                    break;

                case MapType.Oceans:
                    break;

                case MapType.StreetsVector:
                    break;

                case MapType.StreetsWithReliefVector:
                    break;

                case MapType.StreetsNightVector:
                    break;

                case MapType.NavigationVector:
                    break;

                case MapType.TerrainWithLabels:
                    break;

                case MapType.TerrainWithLabelsVector:
                    break;

                case MapType.Topographic:
                    break;

                case MapType.TopographicVector:
                    break;

                case MapType.OpenStreetMap:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mapType), mapType, null);
            }

            return null;
        }
    }
}
