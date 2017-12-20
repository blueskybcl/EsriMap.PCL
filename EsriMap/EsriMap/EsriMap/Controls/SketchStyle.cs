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
    public class SketchStyle : INotifyPropertyChanged
    {
        private Color _selectionColor;
        private Color _fillColor;
        private Color _lineColor;
        private Color _vertexColor;
        private Color _midVertexColor;
        private Color _selectedVertexColor;
        private Color _scaleColor;
        private Color _rotateColor;
        private Color _transformBoxColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public Color SelectionColor
        {
            get => _selectionColor;
            set
            {
                _selectionColor = value;
                OnPropertyChanged();
            }
        }

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                OnPropertyChanged();
            }
        }

        public Color LineColor
        {
            get => _lineColor;
            set
            {
                _lineColor = value;
                OnPropertyChanged();
            }
        }

        public Color VertexColor
        {
            get => _vertexColor;
            set
            {
                _vertexColor = value;
                OnPropertyChanged();
            }
        }

        public Color MidVertexColor
        {
            get => _midVertexColor;
            set
            {
                _midVertexColor = value;
                OnPropertyChanged();
            }
        }

        public Color SelectedVertexColor
        {
            get => _selectedVertexColor;
            set
            {
                _selectedVertexColor = value;
                OnPropertyChanged();
            }
        }

        public Color ScaleColor
        {
            get => _scaleColor;
            set
            {
                _scaleColor = value;
                OnPropertyChanged();
            }
        }

        public Color RotateColor
        {
            get => _rotateColor;
            set
            {
                _rotateColor = value;
                OnPropertyChanged();
            }
        }

        public Color TransformBoxColor
        {
            get => _transformBoxColor;
            set
            {
                _transformBoxColor = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
