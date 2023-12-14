using NotePadLibrary;
using System;
using NotePadAdapter.Properties;
using System.Windows.Forms;

namespace NotePadAdapter
{
    public class UndoRedoManagerAdapter : IAdapter
    {
        private Timer _timer;
        private TextBox _textBox;
        private UndoRedoManager _undoRedoManager;
        public UndoRedoManagerAdapter(TextBox textBox)
        {
            _timer = new Timer
            {
                Interval = 350,
            };
            _timer.Tick += OnTick;
            _textBox = textBox;
            _undoRedoManager = new UndoRedoManager
            {
                StackLimit = 100
            };
            _textBox.TextChanged += OnTextChange;
            _textBox.FontChanged += OnFontChange;
        }
        public void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler)
        {
            switch (eventHandler)
            {
                case Event.Undo:
                    item.Click += Undo;
                    break;
                case Event.Redo:
                    item.Click += Redo;
                    break;
            }
        }
        private void OnTick(object sender, EventArgs e)
        {
            _timer.Stop();
            Push(_textBox);
        }
        private void OnTextChange(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Start();
        }
        private void OnFontChange(object sender, EventArgs e)
        {
            Push(_textBox);
        }
        private void Undo(object sender, EventArgs e)
        {
            try
            {
                TextBoxState state = _undoRedoManager.Undo();
                _textBox.Text = state.Text;
                _textBox.Font = state.Font;
            }
            catch
            {
                MessageBox.Show(Resources.UndoException);
            }
        }
        private void Redo(object sender, EventArgs e)
        {
            try
            {
                TextBoxState state = _undoRedoManager.Redo();
                _textBox.Text = state.Text;
                _textBox.Font = state.Font;
            }
            catch
            {
                MessageBox.Show(Resources.RedoException);
            }
        }
        public void Push(TextBox textbox)
        {
            _undoRedoManager.Push(new TextBoxState(textbox.Text, textbox.Font));
        }
    }
}