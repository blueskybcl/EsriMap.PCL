using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    public class GraphicsOverlay : INotifyPropertyChanged
    {
        private GraphicsRenderingMode _renderingMode = GraphicsRenderingMode.Dynamic;
        private bool _isVisible = true;
        private double _opacity = 0.8;
        private bool _isPopupEnabled = true;
        private bool _labelsEnabled = true;
        private double _minScale = 1;
        private double _maxScale = 20;
        private readonly List<Graphic> _graphicsCollection;

        public GraphicsOverlay()
        {
            _graphicsCollection = new List<Graphic>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string Id { get; set; }
        
        public GraphicsRenderingMode RenderingMode
        {
            get => _renderingMode;
            set
            {
                _renderingMode = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }
        
        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = (float)value;
                OnPropertyChanged();
            }
        }
        
        public bool IsPopupEnabled
        {
            get => _isPopupEnabled;
            set
            {
                _isPopupEnabled = value;
                OnPropertyChanged();
            }
        }
        
        public double MinScale
        {
            get => _minScale;
            set
            {
                _minScale = value;
                OnPropertyChanged();
            }
        }

        public double MaxScale
        {
            get => _maxScale;
            set
            {
                _maxScale = value;
                OnPropertyChanged();
            }
        }
        
        public bool LabelsEnabled
        {
            get => _labelsEnabled;
            set
            {
                _labelsEnabled = value;
                OnPropertyChanged();
            }
        }

        public List<Graphic> Graphics => _graphicsCollection;
    }
}
