using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    public class GeoView : View
    {
        public static readonly BindableProperty GraphicsOverlaysProperty = 
            BindableProperty.Create(nameof(GraphicsOverlays), typeof(ObservableCollection<GraphicsOverlay>), typeof(GeoView));
        
        public static readonly BindableProperty IsAttributionTextVisibleProperty = BindableProperty.Create(
            nameof(IsAttributionTextVisible), typeof(bool), typeof(GeoView), true);
        
        public static readonly BindableProperty ViewInsetsProperty = BindableProperty.Create(nameof(ViewInsets),
            typeof(Thickness), typeof(GeoView), new Thickness(0.0));


        public ObservableCollection<GraphicsOverlay> GraphicsOverlays
        {
            get => (ObservableCollection<GraphicsOverlay>)GetValue(GraphicsOverlaysProperty);
            set => SetValue(GraphicsOverlaysProperty, value);
        }

        public bool IsAttributionTextVisible
        {
            get => (bool)GetValue(IsAttributionTextVisibleProperty);
            set => SetValue(IsAttributionTextVisibleProperty, value);
        }

        public Thickness ViewInsets
        {
            get => (Thickness)GetValue(ViewInsetsProperty);
            set => SetValue(ViewInsetsProperty, value);
        }
    }
}
