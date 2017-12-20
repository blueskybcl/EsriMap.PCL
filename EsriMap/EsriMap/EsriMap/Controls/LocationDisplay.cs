using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public class LocationDisplay : INotifyPropertyChanged
    {
        private double _navigationPointHeightFactor = 1;
        private double _initialZoomScale = 1;
        private double _wanderExtentFactor = 1;
        private double _opacity = 0.8;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double NavigationPointHeightFactor
        {
            get => _navigationPointHeightFactor;
            set
            {
                _navigationPointHeightFactor = value;
                OnPropertyChanged();
            }
        }

        public double InitialZoomScale
        {
            get => _initialZoomScale;
            set
            {
                _initialZoomScale = value;
                OnPropertyChanged();
            }
        }

        public double WanderExtentFactor
        {
            get => _wanderExtentFactor;
            set
            {
                _wanderExtentFactor = value;
                OnPropertyChanged();
            }
        }

        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged();
            }
        }
    }
}
