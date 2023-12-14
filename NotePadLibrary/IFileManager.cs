namespace NotePadLibrary
{
    public interface IFileManager
    {
        /// <summary>
        /// Open the file at the specified path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="textContent"></param>
        /// <returns>returns the textcontent in the file</returns>
        string Open(string path);
        /// <summary>
        /// Save a file at a particular path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="textContent"></param>
        void Save(string path, string textContent);
    }
}