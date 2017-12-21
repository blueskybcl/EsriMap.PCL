using System;


namespace EsriMap.Controls.EventArgs
{
    public class ViewpointEventArgs : System.EventArgs
    {
        public ViewpointEventArgs(Viewpoint viewpoint)
        {
            CurrentPoint = viewpoint;
        }

        public Viewpoint CurrentPoint { get; }
    }
}
