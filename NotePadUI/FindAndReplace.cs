using NotePadAdapter;
using NotePadUI.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotePadUI
{
    public partial class FindAndReplace : Form
    {
        private SearchManagerAdapter _adapter;
        private Button _findNext;
        private Button _replace;
        private Button _replaceAll;
        private Button _cancel;
        private Label _findWhat;
        private Label _replaceWith;
        private TextBox _findWhatText;
        private TextBox _replaceWhatText;
        private CheckBox _matchCaseCheckBox;

        public FindAndReplace(TextBox _textbox)
        {
            InitializeFindComponent();
            _findNext.Click += FindNext;
            _replace.Click += Replace;
            _replaceAll.Click += ReplaceAll;
            _adapter = new SearchManagerAdapter(_textbox, _matchCaseCheckBox);
            _cancel.Click += OnCancel;
        }
        private void OnCancel(object sender, EventArgs e)
        {
            Close();
        }
        private void FindNext(object sender, EventArgs e)
        {
            try
            {
                string target = _findWhatText.Text;
                _adapter.FindNext(target);
            }
            catch { }
        }
        private void Replace(object sender, EventArgs e)
        {
            try
            {
                string targetText = _findWhatText.Text;
                string newText = _replaceWhatText.Text;
                _adapter.Replace(targetText, newText);
            }
            catch { }
        }
        private void ReplaceAll(object sender, EventArgs e)
        {
            try
            {
                string targetText = _findWhatText.Text;
                string newText = _replaceWhatText.Text;
                _adapter.ReplaceAll(targetText, newText);
            }
            catch { }
        }
        private void InitializeFindComponent()
        {
            _findNext = new Button
            {
                Location = new Point(253, 8),
                Name = Resources.FindNext,
                Size = new Size(75, 23),
                TabIndex = 0,
                Text = Resources.FindNextText,
            };
            _replace = new Button
            {
                Location = new Point(253, 37),
                Name = Resources.ReplaceButton,
                Size = new Size(75, 23),
                TabIndex = 0,
                Text = Resources.ReplaceText,
            };
            _replaceAll = new Button
            {
                Location = new Point(253, 66),
                Name = Resources.ReplaceAll,
                Size = new Size(75, 23),
                TabIndex = 0,
                Text = Resources.ReplaceAll,
            };
            _cancel = new Button
            {
                Location = new Point(253, 95),
                Name = Resources.Cancel,
                Size = new Size(75, 23),
                TabIndex = 0,
                Text = Resources.Cancel,
            };

            _findWhat = new Label
            {
                Location = new Point(4, 16),
                Name = Resources.FindWhat,
                Size = new Size(56, 13),
                TabIndex = 1,
                Text = Resources.FindWhatText
            };
            _findWhatText = new TextBox
            {
                Location = new Point(82, 12),
                Name = Resources.FindWhatTextBox,
                Size = new Size(165, 20),
                TabIndex = 2,
            };
            _replaceWhatText = new TextBox
            {
                Location = new Point(82, 42),
                Name = Resources.ReplaceWhatText,
                Size = new Size(165, 20),
                TabIndex = 4,
            };
            _replaceWith = new Label
            {
                Location = new Point(4, 45),
                Name = Resources.ReplaceWith,
                Size = new Size(72, 13),
                TabIndex = 3,
                Text = Resources.ReplaceWithText
            };
            _matchCaseCheckBox = new CheckBox
            {
                AutoSize = true,
                Location = new Point(7, 108),
                Name = Resources.matchCaseCheckBox,
                Size = new Size(82, 17),
                TabIndex = 5,
                Text = Resources.MatchCase,
                UseVisualStyleBackColor = true,
            };

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _cancel;
            ClientSize = new Size(337, 155);
            Controls.Add(_replaceWhatText);
            Controls.Add(_replaceWith);
            Controls.Add(_findWhatText);
            Controls.Add(_findWhat);
            Controls.Add(_cancel);
            Controls.Add(_replaceAll);
            Controls.Add(_replace);
            Controls.Add(_findNext);
            Controls.Add(_matchCaseCheckBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = Resources.FindReplace;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = Resources.FindReplace;
        }

    }
}
