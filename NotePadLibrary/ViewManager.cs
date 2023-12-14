namespace NotePadLibrary
{
    public class ViewManager : IViewManager
    {
        public double ZoomFactor { get; set; }
        public double MinZoom { get; set; }
        public double MaxZoom { get; set; }
        private double _defaultZoom;
        public ViewManager(double defaultZoom) 
        { 
            _defaultZoom = defaultZoom;
            ZoomFactor = 1d;
            MaxZoom = 200d;
            MinZoom = 5d;
        }
        public double ZoomIn(double zoom)
        {
            if(zoom + ZoomFactor > MaxZoom)
            {
                return MaxZoom;
            }
            return (zoom + ZoomFactor);
        }
        public double ZoomOut(double zoom)
        {
            if (zoom - ZoomFactor < MinZoom)
            {
                return MinZoom;
            }
            return (zoom - ZoomFactor);
        }
        public double ResetZoom()
        {
            return _defaultZoom;
        }
    }
}