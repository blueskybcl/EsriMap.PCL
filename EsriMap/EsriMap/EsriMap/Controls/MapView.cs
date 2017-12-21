using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    [ContentProperty("Map")]
    public class MapView : GeoView
    {
        public static readonly BindableProperty MapProperty =
            BindableProperty.Create(nameof(Map), typeof(Map), typeof(MapView));

        public static readonly BindableProperty WrapAroundModeProperty = BindableProperty.Create(nameof(WrapAroundMode),
            typeof(WrapAroundMode), typeof(MapView), WrapAroundMode.EnabledWhenSupported);

        public static readonly BindableProperty LabelingProperty = BindableProperty.Create(nameof(Labeling),
            typeof(ViewLabelProperties), typeof(MapView));

        public static readonly BindableProperty LocationDisplayProperty = BindableProperty.Create(
            nameof(LocationDisplay), typeof(LocationDisplay), typeof(MapView));

        public static readonly BindableProperty SketchEditorProperty = BindableProperty.Create(nameof(SketchEditor),
            typeof(SketchEditor), typeof(MapView));

        public static readonly BindableProperty BackgroundGridProperty =
            BindableProperty.Create(nameof(BackgroundGrid), typeof(BackgroundGrid), typeof(MapView));

        public static readonly BindableProperty InteractionOptionsProperty = BindableProperty.Create(
            nameof(InteractionOptions), typeof(MapViewInteractionOptions), typeof(MapView));

        public static readonly BindableProperty MapGridProperty =
            BindableProperty.Create(nameof(MapGrid), typeof(MapGrid), typeof(MapView));
        
        public Map Map
        {
            get => (Map)GetValue(MapProperty);
            set => SetValue(MapProperty, value);
        }

        public WrapAroundMode WrapAroundMode
        {
            get => (WrapAroundMode)GetValue(WrapAroundModeProperty);
            set => SetValue(WrapAroundModeProperty, value);
        }

        public ViewLabelProperties Labeling
        {
            get => GetValue(LabelingProperty) as ViewLabelProperties;
            set => SetValue(LabelingProperty, value);
        }

        public LocationDisplay LocationDisplay => (LocationDisplay)GetValue(LocationDisplayProperty);

        public SketchEditor SketchEditor
        {
            get => (SketchEditor)GetValue(SketchEditorProperty);
            set => SetValue(SketchEditorProperty, value);
        }

        public MapViewInteractionOptions InteractionOptions
        {
            get => (MapViewInteractionOptions)GetValue(InteractionOptionsProperty);
            set => SetValue(InteractionOptionsProperty, value);
        }

        public MapGrid Grid
        {
            get => (MapGrid)GetValue(MapGridProperty);
            set => SetValue(MapGridProperty, value);
        }

        public BackgroundGrid BackgroundGrid
        {
            get => (BackgroundGrid)GetValue(BackgroundGridProperty);
            set => SetValue(BackgroundGridProperty, value);
        }
    }
}
