using System.Windows.Forms;
using System;

namespace NotePadAdapter
{
    public class FontManagerAdapter : IAdapter
    {
        private TextBox _textBox;
        private ToolStripMenuItem menuitemFormatWordWrap;
        public bool WordWrap
        {
            get
            {
                return _textBox.WordWrap;
            }
            set
            {
                menuitemFormatWordWrap.Checked = _textBox.WordWrap = value;
            }
        }
        public FontManagerAdapter(TextBox textBox) 
        {
            _textBox = textBox;
        }
        public void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler)
        {
            switch (eventHandler)
            {
                case Event.Font:
                    item.Click += CreateFontDailog;
                    break;
                case Event.WordWrap:
                    menuitemFormatWordWrap = item;
                    item.Click += OnClickToggleWordWrap;
                    item.CheckedChanged += OnCheckToggleWordWrap;
                    break;
            }
        }
        private void CreateFontDailog(object sender, EventArgs e)
        {
            FontDialog fontDialogue = new FontDialog();
            if (fontDialogue.ShowDialog() == DialogResult.OK)
            {
                _textBox.Font = fontDialogue.Font;
            }
        }
        private void OnClickToggleWordWrap(object sender, EventArgs e)
        {
            WordWrap = !WordWrap;
        }
        private void OnCheckToggleWordWrap(object sender, EventArgs e)
        {
            WordWrap = ((ToolStripMenuItem)sender).Checked;
        }
    }
}