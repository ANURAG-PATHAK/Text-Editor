namespace NotePadLibrary
{
    public interface ISearchMananger
    {
        /// <summary>
        /// If set to true case will be ignored during search.
        /// </summary>
        bool IsCaseMatched { get; set; }
        /// <summary>
        /// Finds the target string in the textbox
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="targetText"></param>
        /// <returns>return the first index of the occurence of the target or -1 if not found</returns>
        int Find(string sourceText, string targetText);
        /// <summary>
        /// Finds the next occurence of the target string in the textbox
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="targetText"></param>
        /// <returns>return the index of the occurence of the target string or -1 if not found</returns>
        int FindNext( string sourceText, string targetText, int startIndex);
        /// <summary>
        /// Replaces the text from the textbox to some other text
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="targetText"></param>
        /// <param name="newText"></param>
        /// <returns>returns the updated textbox</returns>
        string Replace(string sourceText, string targetText, string newText, int startIndex);
        /// <summary>
        /// Replaces all the occurence of the target text
        /// </summary>
        /// <param name="sourceText"></param>
        /// <param name="targetText"></param>
        /// <param name="newText"></param>
        /// <returns>returns the updated text</returns>
        string ReplaceAll(string sourceText, string targetText, string newText);
    }
}