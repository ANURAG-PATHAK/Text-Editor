using System.IO;
using System;
using NotePadLibrary.Properties;

namespace NotePadLibrary
{
    public class FileManager : IFileManager
    {
        public string Open(string path)
        {
            if (File.Exists(path))
            {
                string textContent;
                using (StreamReader sr = new StreamReader(path))
                {
                    textContent = sr.ReadToEnd();
                }
                return textContent;
            }
            else
            {
                throw new Exception(Resources.InvalidPath);
            }
        }
        public void Save(string path, string textContent)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sr = new StreamWriter(path, true))
                {
                    sr.WriteLine(textContent);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sr = new StreamWriter(path))
                    {
                        sr.WriteLine(textContent);
                    }
                }
                catch
                {
                    throw new Exception(Resources.InvalidPath);
                }
            }
        }
    }
}