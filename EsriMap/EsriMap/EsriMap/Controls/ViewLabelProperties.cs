using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public sealed class ViewLabelProperties : INotifyPropertyChanged
    {
        private bool _isLabelingEnabled = true;
        private bool _isAnimationEnabled = true;

        public ViewLabelProperties()
        {
        }
        
        public ViewLabelProperties(bool isAnimationEnabled, bool isLabelingEnabled)
        {
            _isLabelingEnabled = isLabelingEnabled;
            _isAnimationEnabled = isAnimationEnabled;
        }
        
        public bool IsAnimationEnabled
        {
            get => _isAnimationEnabled;
            set
            {
                _isAnimationEnabled = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsLabelingEnabled
        {
            get => _isLabelingEnabled;
            set
            {
                _isLabelingEnabled = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
