using NotePadLibrary;
using System;
using System.Windows.Forms;

namespace NotePadAdapter
{
    public class SearchManagerAdapter
    {
        private ISearchMananger _searchManager;
        private TextBox _textBox;
        private CheckBox _checkBox;
        private int _lastLocation;
        public SearchManagerAdapter(TextBox textBox, CheckBox caseMatch)
        {
            _checkBox = caseMatch;
            _checkBox.CheckedChanged += OnCheckChanged;
            _searchManager = new SearchManager();
            _textBox = textBox;
            _lastLocation = -1;
        }
        private void OnCheckChanged(object sender, EventArgs e)
        {
            _searchManager.IsCaseMatched = _checkBox.Checked;
        }
        /// <summary>
        /// Find the next occurence of the target string
        /// </summary>
        /// <param name="target">target string</param>
        public void FindNext(string target)
        {
            try
            {
                if(_lastLocation == -1)
                {
                    int start = _searchManager.Find(_textBox.Text, target);
                    _textBox.Select(start, target.Length);
                    _lastLocation = start;
                }
                else
                {
                    int start = _searchManager.FindNext(_textBox.Text, target, _lastLocation);
                    _textBox.Select(start, target.Length);
                    _lastLocation = start;
                }
            }
            catch
            {
                int start = _searchManager.Find(_textBox.Text, target);
                _textBox.Select(start, target.Length);
                _lastLocation = start;
            }
        }
        /// <summary>
        /// Replaces the a single occurence of the target text with the new text
        /// </summary>
        /// <param name="targetText">targetText</param>
        /// <param name="newText">newText</param>
        public void Replace(string targetText, string newText)
        {
            _textBox.Text = _searchManager.Replace(_textBox.Text, targetText, newText, _lastLocation);
            _lastLocation = _searchManager.FindNext(_textBox.Text, targetText, _lastLocation);
        }
        /// <summary>
        /// Replaces every occurence of the the target into new text
        /// </summary>
        /// <param name="targetText">targetText</param>
        /// <param name="newText">newText</param>
        public void ReplaceAll(string targetText, string newText)
        {
            _textBox.Text = _searchManager.ReplaceAll(_textBox.Text, targetText, newText);
        }
    }
}