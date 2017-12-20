using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public class Map : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string BaseMapName { get; set; }

        public MapType MapType { get; set; }

        public ObservableCollection<Layer> OperationalLayers { get; set; }

        public double MinScale { get; set; }

        public double MaxScale { get; set; }

        public Viewpoint InitialViewpoint { get; set; }
    }
}
