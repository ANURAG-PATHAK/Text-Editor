namespace NotePadLibrary
{
    public interface IEditManager
    {
        /// <summary>
        /// Cut the selected text to clipboard
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="selectedTextStartIndex"></param>
        /// <param name="selectedText"></param>
        /// <returns>Returns the selected which was cut</returns>
        string Cut(string sourceText,  int selectedTextStartIndex, string selectedText);
        /// <summary>
        /// Copy the selected text to clipboard
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="selectedTextStartIndex"></param>
        /// <param name="selectedText"></param>
        /// <returns>Returns the selected which was copied</returns>
        string Copy(string sourceText, int selectedTextStartIndex, string selectedText);
        /// <summary>
        /// Paste the string from clipboard
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="position"></param>
        /// <param name="selectedText"></param>
        /// <returns>Returns the text which was pasted</returns>
        string Paste(string sourceText, int position, string selectedText);
        /// <summary>
        /// Delete the selected Text
        /// </summary>
        /// <param name="sourceTex"></param>
        /// <param name="selectedTextStartIndext"></param>
        /// <param name="selectedText"></param>
        /// <returns>return the strign which was deleted</returns>
        string Delete(string sourceTex, int selectedTextStartIndext, string selectedText);
    }
}