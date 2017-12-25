using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EsriMap.Common;
using Xamarin.Forms;

namespace EsriMap.Controls
{
    public class SketchEditor : INotifyPropertyChanged
    {
        private bool _isEnabled = true;
        private bool _isVisible = true;
        private double _opacity = 1.0;
        private DelegateCommand _cancel;
        private DelegateCommand _complete;
        private DelegateCommand _undo;
        private DelegateCommand _redo;
        private DelegateCommand _deleteVertex;
        private DelegateCommand _addVertex;

        public SketchEditor()
        {
            EditConfiguration = new SketchEditConfiguration();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
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
                _opacity = value;
                OnPropertyChanged();
            }
        }

        public SketchEditConfiguration EditConfiguration { get; }

        public DelegateCommand CancelCommand => _cancel ?? (_cancel = new DelegateCommand(OnCancel));

        private void OnCancel(object obj)
        {
            MessagingCenter.Send(this, Constants.MessageCenterKeys.SketchCancelKey);
        }

        public DelegateCommand CompleteCommand => _complete ?? (_complete = new DelegateCommand(OnComplete));

        private void OnComplete(object obj)
        {
            MessagingCenter.Send(this, Constants.MessageCenterKeys.SketchCompleteKey);
        }

        public void Start
    }
}
