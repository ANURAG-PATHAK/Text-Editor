using NotePadLibrary.Properties;
using System;

namespace NotePadLibrary
{
    public class EditManager : IEditManager
    {
        public string Copy(string sourceText, int selectedTextStartIndex, string selectedText)
        {
            if (sourceText.Contains(selectedText) && sourceText[selectedTextStartIndex] == selectedText[0])
            {
                return selectedText;
            }
            else
            {
                throw new Exception(Resources.CopyException);
            }
        }
        public string Cut(string sourceText, int selectedTextStartIndex, string selectedText)
        {
            if (sourceText.Contains(selectedText) && sourceText[selectedTextStartIndex] == selectedText[0])
            {
                return sourceText.Remove(selectedTextStartIndex, selectedText.Length);
            }
            else
            {
                throw new Exception(Resources.CutException);
            }
        }
        public string Paste(string sourceText, int position, string selectedText)
        {
            return sourceText.Insert(position, selectedText);
        }
        public string Delete(string sourceText, int selectedTextStartIndex, string selectedText)
        {
            if (sourceText.Contains(selectedText) && sourceText[selectedTextStartIndex] == selectedText[0])
            {
                return Cut(sourceText, selectedTextStartIndex, selectedText);
            }
            else
            {
                throw new Exception(Resources.DeleteException);
            }
        }
    }
}