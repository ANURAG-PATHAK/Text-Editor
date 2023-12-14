using NUnit.Framework;
using NotePadLibrary;
using System.IO;

namespace NotePadLibrary.Tests
{
    public class FileManagerTests
    {
        private FileManager _fileManager;

        [SetUp]
        public void Setup()
        {
            _fileManager = new FileManager();
        }
        [TestCase("This is a Test file")]
        public void OpenTests(string expected)
        {
            string path = Path.GetFullPath("Open.txt");
            string textContent = _fileManager.Open(path);
            Assert.AreEqual(expected, textContent);
        }

        [TestCase("This is a new test", "This is also a test fileThis is a new test\r\n")]
        public void SaveTests(string textContent, string expected)
        {
            string path = Path.GetFullPath("Save.txt");
            _fileManager.Save(path, textContent);
            Assert.AreEqual(expected, _fileManager.Open(path));
        }
    }
}
