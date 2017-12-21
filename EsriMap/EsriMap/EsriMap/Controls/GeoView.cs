using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Controls.EventArgs;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    public class GeoView : View
    {
        public static readonly BindableProperty GraphicsOverlaysProperty =
            BindableProperty.Create(nameof(GraphicsOverlays), typeof(ObservableCollection<GraphicsOverlay>),
                typeof(GeoView));

        public static readonly BindableProperty IsAttributionTextVisibleProperty = BindableProperty.Create(
            nameof(IsAttributionTextVisible), typeof(bool), typeof(GeoView), true);

        public static readonly BindableProperty ViewInsetsProperty = BindableProperty.Create(nameof(ViewInsets),
            typeof(Thickness), typeof(GeoView), new Thickness(0.0));

        #region Event
        public event EventHandler<GeoViewInputEventArgs> GeoViewTapped;
        public event EventHandler<GeoViewInputEventArgs> GeoViewDoubleTapped;
        public event EventHandler<GeoViewInputEventArgs> GeoViewHolding;
        public event EventHandler NavigationCompleted;
        public event EventHandler SpatialReferenceChanged;
        public event EventHandler<DrawStatusChangedEventArgs> DrawStatusChanged;
        public event EventHandler<LayerViewStateChangedEventArgs> LayerViewStateChanged;
        #endregion

        public ObservableCollection<GraphicsOverlay> GraphicsOverlays
        {
            get => (ObservableCollection<GraphicsOverlay>) GetValue(GraphicsOverlaysProperty);
            set => SetValue(GraphicsOverlaysProperty, value);
        }

        public bool IsAttributionTextVisible
        {
            get => (bool) GetValue(IsAttributionTextVisibleProperty);
            set => SetValue(IsAttributionTextVisibleProperty, value);
        }

        public Thickness ViewInsets
        {
            get => (Thickness) GetValue(ViewInsetsProperty);
            set => SetValue(ViewInsetsProperty, value);
        }

        public void OnGeoViewTapped(GeoViewInputEventArgs e)
        {
            GeoViewTapped?.Invoke(this, e);
        }

        public void OnGeoViewDoubleTapped(GeoViewInputEventArgs e)
        {
            GeoViewDoubleTapped?.Invoke(this, e);
        }

        public void OnGeoViewHolding(GeoViewInputEventArgs e)
        {
            GeoViewHolding?.Invoke(this, e);
        }

        public void OnNavigationCompleted()
        {
            NavigationCompleted?.Invoke(this, null);
        }

        public void OnSpatialReferenceChanged()
        {
            SpatialReferenceChanged?.Invoke(this, null);
        }

        public void OnDrawStatusChanged(DrawStatusChangedEventArgs e)
        {
            DrawStatusChanged?.Invoke(this, e);
        }

        public void OnLayerViewStateChanged(LayerViewStateChangedEventArgs e)
        {
            LayerViewStateChanged?.Invoke(this, e);
        }
    }
}
