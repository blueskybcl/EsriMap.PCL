
using Android.Views;
using CusTouchEventArgs = EsriMap.Controls.EventArgs.TouchEventArgs;
using CusDragEventArgs = EsriMap.Controls.EventArgs.DragEventArgs;
using EsriMap.Controls;
using System;
using Android.Graphics;
using Java.Lang;
using DragAction = Android.Views.DragAction;
using MapPoint = Esri.ArcGISRuntime.Geometry.MapPoint;
using MapView = Esri.ArcGISRuntime.UI.Controls.MapView;

namespace EsriMap.Droid.Renderer.Converters
{
    public class EsriEnumConverter
    {
        public static MapView _currentMapView;

        public static void Init(MapView mapView)
        {
            _currentMapView = mapView;
        }

        public static CusTouchEventArgs ConvertFrom(View.TouchEventArgs e)
        {
            MapPoint mapPoint = _currentMapView.ScreenToLocation(new PointF(e.Event.RawX, e.Event.RawY));
            return new CusTouchEventArgs
            {
                Handled = e.Handled,
                PointerCount = e.Event.PointerCount,
                Log = mapPoint.X,
                Lat = mapPoint.Y
            };
        }

        public static CusDragEventArgs ConvertFrom(View.DragEventArgs e)
        {
            MapPoint mapPoint = _currentMapView.ScreenToLocation(new PointF(e.Event.GetX(), e.Event.GetY()));
            return new CusDragEventArgs
            {
                Handled = e.Handled,
                Action = GetAction(e.Event.Action),
                Log = mapPoint.X,
                Lat = mapPoint.Y
            };
        }

        private static Controls.DragAction GetAction(DragAction action)
        {
            switch (action)
            {
                case DragAction.Started:
                    return Controls.DragAction.Started;

                case DragAction.Location:
                    return Controls.DragAction.Location;

                case DragAction.Drop:
                    return Controls.DragAction.Drop;

                case DragAction.Ended:
                    return Controls.DragAction.Ended;

                case DragAction.Entered:
                    return Controls.DragAction.Entered;

                case DragAction.Exited:
                    return Controls.DragAction.Exited;

                    default:
                    throw new IllegalArgumentException();
            }
        }
    }
}