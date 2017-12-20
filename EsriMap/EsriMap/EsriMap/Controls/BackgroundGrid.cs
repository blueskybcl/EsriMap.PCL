using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    public sealed class BackgroundGrid : INotifyPropertyChanged
    {
        private Color _color;
        private Color _gridLineColor;
        private float _gridLineWidth;
        private float _gridSize;
        private bool _isVisible;
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
        
        public Color GridLineColor
        {
            get => _gridLineColor;
            set
            {
                _gridLineColor = value;
                OnPropertyChanged();
            }
        }
        
        public float GridLineWidth
        {
            get => _gridLineWidth;
            set
            {
                _gridLineWidth = value;
                OnPropertyChanged();
            }
        }
        
        public float GridSize
        {
            get => _gridSize;
            set
            {
                _gridSize = value;
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
    }
}
