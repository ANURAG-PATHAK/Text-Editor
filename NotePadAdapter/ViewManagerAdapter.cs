using NotePadLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotePadAdapter
{
    public class ViewManagerAdapter : IAdapter
    {
        private IViewManager _viewManager;
        private TextBox _textBox;
        private double _defaultFontSize;
        public ViewManagerAdapter(TextBox textBox)
        {
            _textBox = textBox;
            _defaultFontSize = textBox.Font.Size;
            _viewManager = new ViewManager(_defaultFontSize);
            _viewManager.ZoomFactor = 2;
        }
        public void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler)
        {
            switch (eventHandler)
            {
                case Event.ZoomIn:
                    item.Click += ZoomIn;
                    break;
                case Event.ZoomOut:
                    item.Click += ZoomOut;
                    break;
                case Event.ResetZoom: 
                    item.Click += ResetZoom; 
                    break;
            }
        }
        private void ZoomIn(object sender, EventArgs e)
        {
            _textBox.Font = new Font(_textBox.Font.FontFamily, (float)_viewManager.ZoomIn(_textBox.Font.Size));
        }
        private void ZoomOut(object sender, EventArgs e)
        {
            _textBox.Font = new Font(_textBox.Font.FontFamily, (float)_viewManager.ZoomOut(_textBox.Font.Size));
        }
        private void ResetZoom(object sender, EventArgs e)
        {
            _textBox.Font = new Font(_textBox.Font.FontFamily, (float)_viewManager.ResetZoom());
        }
    }
}