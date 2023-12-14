using System;
using System.Windows.Forms;
using NotePadLibrary;
using NotePadAdapter.Properties;

namespace NotePadAdapter
{
    public class EditManagerAdapter : IAdapter
    {
        private IEditManager _editManager;
        private TextBox _textBox; 
        public EditManagerAdapter(TextBox textbox)
        {
            _editManager = new EditManager();
            _textBox = textbox;
        }
        public void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler)
        {
            switch (eventHandler)
            {
                case Event.Copy:
                    item.Click += Copy;
                    break;
                case Event.Paste:
                    item.Click += Paste;
                    break;
                case Event.Cut:
                    item.Click += Cut;
                    break;
                case Event.Delete:
                    item.Click += Delete;
                    break;
            }
        }
        private void Copy(object sender, EventArgs e)
        {
            try
            {
                int selectedTextIndex = _textBox.SelectionStart;
                string selectedText = _textBox.SelectedText;
                Clipboard.SetText(_editManager.Copy(_textBox.Text, selectedTextIndex, selectedText));
            }
            catch
            {
                MessageBox.Show(Resources.CopyException);
            }
        }
        private void Cut(object sender, EventArgs e)
        {
            try
            {
                int selectedTextIndex = _textBox.SelectionStart;
                string selectedText = _textBox.SelectedText;
                Clipboard.SetText(selectedText);
                _textBox.Text = _editManager.Cut(_textBox.Text, selectedTextIndex, selectedText);
            }
            catch 
            {
                MessageBox.Show(Resources.CutException);
            }
        }
        private void Paste(object sender, EventArgs e)
        {
            try
            {
                string selectedText = Clipboard.GetText();
                _textBox.Text = _editManager.Paste(_textBox.Text, _textBox.Text.Length, selectedText);
            }
            catch 
            {
                MessageBox.Show(Resources.PasteException);
            }

        }
        private void Delete(object sender, EventArgs e)
        {
            int selectedTextIndex = _textBox.SelectionStart;
            string selectedText = _textBox.SelectedText;
            _textBox.Text = _editManager.Delete(_textBox.Text, selectedTextIndex, selectedText);
        }
    }
}