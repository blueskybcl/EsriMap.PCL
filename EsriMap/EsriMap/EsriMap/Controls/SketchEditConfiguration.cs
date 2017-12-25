using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public class SketchEditConfiguration : INotifyPropertyChanged
    {
        private bool _allowRotate;
        private SketchResizeMode _resizeMode;
        private bool _allowMove;
        private bool _allowVertexEditing;
        
        public bool AllowRotate
        {
            get => _allowRotate;
            set
            {
                if (_allowRotate == value)
                    return;

                _allowRotate = value;
                OnPropertyChanged();
            }
        }
        
        public SketchResizeMode ResizeMode
        {
            get => _resizeMode;
            set
            {
                if (_resizeMode == value)
                    return;
                _resizeMode = value;
                OnPropertyChanged();
            }
        }
        
        public bool AllowMove
        {
            get => _allowMove;
            set
            {
                if (_allowMove == value)
                    return;
                _allowMove = value;
                OnPropertyChanged();
            }
        }
        
        public bool AllowVertexEditing
        {
            get => _allowVertexEditing;
            set
            {
                if (_allowVertexEditing == value)
                    return;
                _allowVertexEditing = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null || string.IsNullOrEmpty(propertyName))
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
