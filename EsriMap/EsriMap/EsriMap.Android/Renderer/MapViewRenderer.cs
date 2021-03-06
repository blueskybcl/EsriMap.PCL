﻿using System;
using System.ComponentModel;
using EsriMap.Android.Renderer;
using EsriMap.Android.Renderer.Adapters;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CusMapView = EsriMap.Controls.MapView;
using CusGeoViewInputEventArgs = EsriMap.Controls.EventArgs.GeoViewInputEventArgs;
using CusMapPoint = EsriMap.Controls.MapPoint;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.Mapping;
using EsriMap.Common;
using EsriMap.Controls;
using EsriMap.Droid.Renderer.Converters;
using GeoViewInputEventArgs = Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs;
using MapView = Esri.ArcGISRuntime.UI.Controls.MapView;

[assembly: ExportRenderer(typeof(CusMapView), typeof(MapViewRenderer))]

namespace EsriMap.Android.Renderer
{
    public class MapViewRenderer : ViewRenderer<CusMapView, MapView>
    {
        private MapView _originMapView;
        private readonly MapViewAdapter _adapter = MapViewAdapter.Instance;

        protected override void OnElementChanged(ElementChangedEventArgs<CusMapView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.GeoViewTapped -= OnGeoViewTapped;
                Control.GeoViewDoubleTapped -= OnGeoViewDoubleTapped;
                Control.GeoViewHolding -= OnGeoViewHolding;
                Control.NavigationCompleted -= OnNavigationCompleted;
                Control.SpatialReferenceChanged -= OnSpatialReferenceChanged;
                Control.DrawStatusChanged -= OnDrawStatusChanged;
                Control.LayerViewStateChanged -= OnLayerViewStateChanged;
                Control.Drag -= OnMapDrag;
                Control.Touch -= OnMapTouch;
                MessagingCenter.Unsubscribe<GeoView>(this, Constants.MessageCenterKeys.ShowCalloutAtKey);
            }

            CusMapView currentElement = e.NewElement;
            if (currentElement != null)
            {
                _originMapView = _adapter.Adapter(currentElement);
                if (Control == null)
                {
                    SetNativeControl(_originMapView);
                }

                EsriEnumConverter.Init(_originMapView);
                Control.GeoViewTapped += OnGeoViewTapped;
                Control.GeoViewDoubleTapped += OnGeoViewDoubleTapped;
                Control.GeoViewHolding += OnGeoViewHolding;
                Control.NavigationCompleted += OnNavigationCompleted;
                Control.SpatialReferenceChanged += OnSpatialReferenceChanged;
                Control.DrawStatusChanged += OnDrawStatusChanged;
                Control.LayerViewStateChanged += OnLayerViewStateChanged;
                Control.Drag += OnMapDrag;
                Control.Touch += OnMapTouch;
                MessagingCenter.Subscribe<GeoView, Controls.CalloutDefinition>(this,
                    Constants.MessageCenterKeys.ShowCalloutAtKey, ShowCallout);
            }
        }

        private void ShowCallout(GeoView sender, Controls.CalloutDefinition definition)
        {
            _originMapView.ShowCalloutAt(ArgumentsConverter.ConvertFrom(definition.Location),
                ArgumentsConverter.ConvertFrom(definition));
        }

        private void OnMapTouch(object sender, TouchEventArgs e)
        {
            Element.OnTouch(sender, EsriEnumConverter.ConvertFrom(e));
        }

        private void OnMapDrag(object sender, DragEventArgs e)
        {
            Element.OnDrag(sender, EsriEnumConverter.ConvertFrom(e));
        }

        private void OnLayerViewStateChanged(object sender, LayerViewStateChangedEventArgs e)
        {

        }

        private void OnDrawStatusChanged(object sender, DrawStatusChangedEventArgs e)
        {

        }

        private void OnSpatialReferenceChanged(object sender, EventArgs e)
        {
            Element.OnSpatialReferenceChanged();
        }

        private void OnNavigationCompleted(object sender, EventArgs e)
        {
            Element.OnNavigationCompleted();
        }

        private void OnGeoViewHolding(object sender, GeoViewInputEventArgs e)
        {
            CusGeoViewInputEventArgs args = new CusGeoViewInputEventArgs(new CusMapPoint
            {
                X = e.Location.X,
                Y = e.Location.Y,
                M = e.Location.M,
                Z = e.Location.Z
            }, new Point(e.Position.X, e.Position.Y))
            {
                Handled = e.Handled
            };

            Element.OnGeoViewHolding(args);
        }

        private void OnGeoViewDoubleTapped(object sender, GeoViewInputEventArgs e)
        {
            CusGeoViewInputEventArgs args = new CusGeoViewInputEventArgs(new CusMapPoint
            {
                X = e.Location.X,
                Y = e.Location.Y,
                M = e.Location.M,
                Z = e.Location.Z
            }, new Point(e.Position.X, e.Position.Y))
            {
                Handled = e.Handled
            };

            Element.OnGeoViewDoubleTapped(args);
        }

        private void OnGeoViewTapped(object sender, GeoViewInputEventArgs e)
        {
            CusGeoViewInputEventArgs args = new CusGeoViewInputEventArgs(new CusMapPoint
            {
                X = e.Location.X,
                Y = e.Location.Y,
                M = e.Location.M,
                Z = e.Location.Z
            }, new Point(e.Position.X, e.Position.Y))
            {
                Handled = e.Handled
            };

            Element.OnGeoViewTapped(args);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CusMapView.MapProperty.PropertyName)
            {
                UpdateMap();
            }
        }

        private void UpdateMap()
        {
            if (Element is CusMapView cusMapView)
            {
                _originMapView.Map.Basemap = _adapter.GetBaseMap(cusMapView);
                _adapter.SetInitialViewpoint(_originMapView, cusMapView);
            }
        }
    }
}