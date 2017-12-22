using System;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using EsriMap.Controls;
using CusMapView = EsriMap.Controls.MapView;
using EsriMapView = Esri.ArcGISRuntime.UI.Controls.MapView;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using Viewpoint = Esri.ArcGISRuntime.Mapping.Viewpoint;

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

        public Basemap GetBaseMap(CusMapView cusMapView)
        {
            switch (cusMapView.Map.MapType)
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

                case MapType.WebMap:
                    if (!string.IsNullOrEmpty(cusMapView.Map.WebMapUrl))
                    {
                        return new Basemap(new Uri(cusMapView.Map.WebMapUrl));
                    }

                    throw new ArgumentOutOfRangeException(nameof(cusMapView.Map.WebMapUrl), cusMapView.Map.WebMapUrl, null);

                default:
                    throw new ArgumentOutOfRangeException(nameof(cusMapView.Map.MapType), cusMapView.Map.MapType, null);
            }
        }

        public void SetInitialViewpoint(EsriMapView xfMapView, CusMapView cusMapView)
        {
            if (cusMapView.Map.InitialViewpoint?.Envelope != null)
            {
                var envelope = cusMapView.Map.InitialViewpoint.Envelope;
                SpatialReference spatialReference = SpatialReferences.WebMercator;
                if (SpatialReferenceType.Wgs84 == envelope.SpatialReferenceType)
                {
                    spatialReference = SpatialReferences.Wgs84;
                }

                xfMapView.Map.InitialViewpoint = new Viewpoint(new Envelope(envelope.XMin, envelope.YMin,
                    envelope.XMax, envelope.YMax, spatialReference));
                xfMapView.SetViewpoint(xfMapView.Map.InitialViewpoint);
                Task.Run(async () =>
                {
                   await xfMapView.SetViewpointCenterAsync(34.3177313608, 108.9576703038);
                });
            }
        }

        private void MappingMap(EsriMapView xfMapView, CusMapView cusMapView)
        {
            Basemap baseMap = GetBaseMap(cusMapView);
            xfMapView.Map = new Map(baseMap);
            SetInitialViewpoint(xfMapView, cusMapView);
        }
    }
}