using System.Drawing;
using System.Windows.Forms;
using NotePadUI.Properties;
using NotePadAdapter;
using System;

namespace NotePadUI
{
    public partial class Notepad : Form
    {
        private MenuStrip _menuStrip;
        private ToolStripMenuItem _fileToolStripMenuItem;
        private TextBox _textBox;
        private ToolStripMenuItem _newToolStripMenuItem;
        private ToolStripMenuItem _openToolStripMenuItem;
        private ToolStripMenuItem _saveToolStripMenuItem;
        private ToolStripMenuItem _saveAsToolStripMenuItem;
        private ToolStripMenuItem _printToolStripMenuItem;
        private ToolStripMenuItem _exitToolStripMenuItem;
        private ToolStripMenuItem _editToolStripMenuItem;
        private ToolStripMenuItem _undoToolStripMenuItem;
        private ToolStripMenuItem _redoToolStripMenuItem;
        private ToolStripMenuItem _cutToolStripMenuItem;
        private ToolStripMenuItem _copyToolStripMenuItem;
        private ToolStripMenuItem _pasteToolStripMenuItem;
        private ToolStripMenuItem _deleteToolStripMenuItem;
        private ToolStripMenuItem _searchAndReplaceToolStripMenuItem;
        private ToolStripMenuItem _formatToolStripMenuItem;
        private ToolStripMenuItem _viewToolStripMenuItem;
        private ToolStripMenuItem _fontToolStripMenuItem;
        private ToolStripMenuItem _zoomInToolStripMenuItem;
        private ToolStripMenuItem _zoomOutToolStripMenuItem;
        private ToolStripMenuItem _resetZoomToolStripMenuItem;
        private ToolStripMenuItem _wordWrapToolStripMenuItem;
        public Notepad()
        {
            InitializeTextBox();
            InitializeMenuButtons();
            InitializeTextComponent();

            IAdapter _editManagerAdapter = new EditManagerAdapter(_textBox);
            IAdapter _fileManagerAdapter = new FileManagerAdapter(_textBox);
            IAdapter _fontManagerAdapter = new FontManagerAdapter(_textBox);
            IAdapter _undoRedoManagerAdapter = new UndoRedoManagerAdapter(_textBox);
            IAdapter _viewManagerAdapter = new ViewManagerAdapter(_textBox);

            _fileManagerAdapter.RegisterClickHandler(_newToolStripMenuItem, Event.New);
            _fileManagerAdapter.RegisterClickHandler(_openToolStripMenuItem, Event.Open);
            _fileManagerAdapter.RegisterClickHandler(_saveToolStripMenuItem, Event.Save);
            _fileManagerAdapter.RegisterClickHandler(_saveAsToolStripMenuItem, Event.SaveAs);
            _fileManagerAdapter.RegisterClickHandler(_printToolStripMenuItem, Event.Print);
            _fileManagerAdapter.RegisterClickHandler(_exitToolStripMenuItem, Event.Exit);

            _undoRedoManagerAdapter.RegisterClickHandler(_undoToolStripMenuItem, Event.Undo);
            _undoRedoManagerAdapter.RegisterClickHandler(_redoToolStripMenuItem, Event.Redo);

            _editManagerAdapter.RegisterClickHandler(_cutToolStripMenuItem, Event.Cut);
            _editManagerAdapter.RegisterClickHandler(_copyToolStripMenuItem, Event.Copy);
            _editManagerAdapter.RegisterClickHandler(_pasteToolStripMenuItem, Event.Paste);
            _editManagerAdapter.RegisterClickHandler(_deleteToolStripMenuItem, Event.Delete);

            _searchAndReplaceToolStripMenuItem.Click += OnSearchAndReplaceClick;

            _fontManagerAdapter.RegisterClickHandler(_fontToolStripMenuItem, Event.Font);
            _fontManagerAdapter.RegisterClickHandler(_wordWrapToolStripMenuItem, Event.WordWrap);
            _viewManagerAdapter.RegisterClickHandler(_zoomInToolStripMenuItem, Event.ZoomIn);
            _viewManagerAdapter.RegisterClickHandler(_zoomOutToolStripMenuItem, Event.ZoomOut);
            _viewManagerAdapter.RegisterClickHandler(_resetZoomToolStripMenuItem, Event.ResetZoom);

        }
        private void OnSearchAndReplaceClick(object sender, EventArgs e)
        {
            new FindAndReplace(_textBox).Show();
        }
        private void InitializeTextBox()
        {
            _textBox = new TextBox
            {
                AcceptsReturn = true,
                AcceptsTab = true,
                Dock = DockStyle.Fill,
                HideSelection = false,
                Location = new Point(0, 24),
                Multiline = true,
                Margin = new Padding(10),
                MaxLength = 0,
                Size = new Size(632, 369),
                ScrollBars = ScrollBars.Both,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font(Font.FontFamily, 15f),
                TabIndex = 0
            };
        }
        private void InitializeTextComponent()
        {
            ClientSize = new Size(632, 393);
            Controls.Add(_textBox);
            Controls.Add(_menuStrip);
            MainMenuStrip = _menuStrip;
            Name = Resources.Main;
            Text = Resources.Text;
        }
        private void InitializeMenuButtons()
        {
            _menuStrip = new MenuStrip
            {
                Padding = new Padding(1),
                Name = Resources.menuStrip1,
                Size = new Size(632, 24),
                TabIndex = 1,
                Text = Resources.menuStrip1
            };
            _fileToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.fileToolStripMenuItem,
                Size = new Size(37, 24),
                Text = Resources.File,
            };
            _newToolStripMenuItem = new ToolStripMenuItem
            {
                ShortcutKeys = Keys.Control | Keys.N,
                Name = Resources.newToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.New,
            };
            _openToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.openToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.Open,
            };
            _saveToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.saveToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.Save,
            };
            _saveAsToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.saveAsToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.Saveas,
            };
            _printToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.printToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.Print,
            };
            _exitToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.exitToolStripMenuItem,
                Size = new Size(171, 22),
                Text = Resources.Exit,
            };
            _fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    _newToolStripMenuItem,
                    _openToolStripMenuItem,
                    _saveToolStripMenuItem,
                    _saveAsToolStripMenuItem,
                    _printToolStripMenuItem,
                    _exitToolStripMenuItem
                });

            _editToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.editToolStripMenuItem,
                Size = new Size(39, 24),
                Text = Resources.Edit,
            };
            _undoToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.undoToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Undo,
            };
            _redoToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.redoToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Redo,
            };
            _cutToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.cutToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Cut,
            };
            _copyToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.copyToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Copy,
            };
            _pasteToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.pasteToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Paste,
            };
            _deleteToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.deleteToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.Delete,
            };
            _searchAndReplaceToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.searchAndReplaceToolStripMenuItem,
                Size = new Size(167, 22),
                Text = Resources.SearchAndReplace,
            };
            _editToolStripMenuItem.DropDownItems.AddRange(
                new ToolStripItem[] {
                    _undoToolStripMenuItem,
                    _redoToolStripMenuItem,
                    _cutToolStripMenuItem,
                    _copyToolStripMenuItem,
                    _pasteToolStripMenuItem,
                    _deleteToolStripMenuItem,
                    _searchAndReplaceToolStripMenuItem,
                });

            _formatToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.formatToolStripMenuItem,
                Size = new Size(57, 24),
                Text = Resources.Format,
            };
            _wordWrapToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.wordWrapToolStripMenuItem,
                Size = new Size(134, 22),
                Text = Resources.WordWrap,
                Checked = _textBox.WordWrap,
            };
            _fontToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.fontToolStripMenuItem,
                Size = new Size(134, 22),
                Text = Resources.Font,
            };
            _formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _fontToolStripMenuItem, _wordWrapToolStripMenuItem });

            _viewToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.viewToolStripMenuItem,
                Size = new Size(44, 24),
                Text = Resources.View,
            };
            _zoomInToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.zoomInToolStripMenuItem,
                Size = new Size(126, 22),
                Text = Resources.ZoomIn,
            };
            _zoomOutToolStripMenuItem = new ToolStripMenuItem
            {
                Name = Resources.zoomOutToolStripMenuItem,
                Size = new Size(126, 22),
                Text = Resources.ZoomOut,
            };
            _resetZoomToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = Resources.resetZoomToolStripMenuItem,
                Size = new Size(126, 22),
                Text = Resources.ResetZoom,
            };

            _viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _zoomInToolStripMenuItem, _zoomOutToolStripMenuItem, _resetZoomToolStripMenuItem });

            _menuStrip.Items.AddRange(new ToolStripItem[] { _fileToolStripMenuItem, _editToolStripMenuItem, _formatToolStripMenuItem, _viewToolStripMenuItem });
        }
    }
}