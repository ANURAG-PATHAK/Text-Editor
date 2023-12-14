using System;
using NotePadAdapter.Properties;
using System.Windows.Forms;
using NotePadLibrary;

namespace NotePadAdapter
{
    public class FileManagerAdapter : IAdapter
    {
        private IFileManager _fileManager;
        private TextBox _textbox;
        private string _fileName;
        public FileManagerAdapter(TextBox textbox)
        {
            _fileManager = new FileManager();
            _textbox = textbox;
            _fileName = string.Empty;
        }
        public void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler)
        {
            switch (eventHandler)
            {
                case Event.Print:
                    item.Click += Print;
                    break;
                case Event.New:
                    item.Click += New;
                    break;
                case Event.Open:
                    item.Click += Open;
                    break;
                case Event.Save:
                    item.Click += Save;
                    break;
                case Event.SaveAs:
                    item.Click += SaveAs;
                    break;
                case Event.Exit:
                    item.Click += Exit;
                    break;
            }
        }
        private void New(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Title = Resources.New,
                AddExtension = true,
                Filter = Resources.Extension
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                _fileManager.Save(saveFile.FileName, _textbox.Text);
            }
        }
        private void Open(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _fileName = openFile.FileName;
                _textbox.Text = _fileManager.Open(_fileName);
            }
        }
        private void Save(object sender, EventArgs e)
        {
            if (_fileName != string.Empty)
            {
                _fileManager.Save(_fileName, _textbox.Text);
            }
            else
            {
                SaveAs(sender, e);
            }
        }
        private void SaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Title = Resources.SaveAs,
                AddExtension = true,
                Filter = Resources.Extension
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                _fileManager.Save(saveFile.FileName, _textbox.Text);
            }
        }
        private void Print(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.ShowDialog();
        }
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}