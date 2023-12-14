using NUnit.Framework;
using NotePadLibrary;
using System;

namespace NotePadLibrary.Tests
{
    public class EditManagerTests
    {
        private EditManager _editManager;
        [SetUp]
        public void Setup()
        {
            _editManager = new EditManager();
        }
        [TestCase("Lorem Ipsu joker sstt uuo injury", "joker", 11, "joker")]
        public void CopyTests(string source, string selectedText, int startIndex, string expected)
        {
            string copiedText = _editManager.Copy(source, startIndex, selectedText);
            Assert.AreEqual(expected, copiedText);
        }
        [TestCase("Stock android, kite jjitsu on the edge", "booo", 1)]
        [TestCase("LoremIpsum ipsum lorem ghghgh", "orange", 10)]
        public void CopyTests(string source, string selectedText, int startIndex)
        {
            Assert.Throws<Exception>(delegate { _editManager.Copy(source, startIndex, selectedText); });
        }

        [TestCase("Lorem Ipsu joker sstt uuo injury", "joker", 11, "Lorem Ipsu  sstt uuo injury")]
        public void CutTests(string source, string selectedText, int startIndex, string expected)
        {
            string cutText = _editManager.Cut(source, startIndex, selectedText);
            Assert.AreEqual(expected, cutText);
        }

        [TestCase("Stock android, kite jjitsu on the edge", "booo", 1)]
        [TestCase("LoremIpsum ipsum lorem ghghgh", "orange", 10)]
        public void CutTests(string source, string selectedText, int startIndex)
        {
            Assert.Throws<Exception>(delegate { _editManager.Cut(source, startIndex, selectedText); });
        }

        [TestCase("Lorem Ipsu joker sstt uuo injury", "joker", 11, "Lorem Ipsu jokerjoker sstt uuo injury")]
        [TestCase("Stock android, kite jjitsu on the edge", "booo", 1, "Sboootock android, kite jjitsu on the edge")]
        [TestCase("LoremIpsum ipsum lorem ghghgh", "orange", 10, "LoremIpsumorange ipsum lorem ghghgh")]
        public void PasteTests(string source, string selectedText, int startIndex, string expected)
        {
            string pasteText = _editManager.Paste(source, startIndex, selectedText);
            Assert.AreEqual(expected, pasteText);
        }

        [TestCase("Lorem Ipsu joker sstt uuo injury", "joker", 11, "Lorem Ipsu  sstt uuo injury")]
        public void DeleteTests(string source, string selectedText, int startIndex, string expected)
        {
            string deletedText = _editManager.Delete(source, startIndex, selectedText);
            Assert.AreEqual(expected, deletedText);
        }

        [TestCase("Lorem Ipsu joker sstt uuo injury", "booo", 1)]
        [TestCase("LoremIpsum ipsum lorem ghghgh", "lorem", 10)]
        public void DeleteTests(string source, string selectedText, int startIndex)
        {
            Assert.Throws<Exception>(delegate { _editManager.Delete(source, startIndex, selectedText); });
        }
    }
}
