using NUnit.Framework;
using NotePadLibrary;
using System;

namespace NotePadLibrary.Tests
{
    public class SearchManagerTests
    {
        private SearchManager _searchManager;

        [SetUp]
        public void Setup()
        {
            _searchManager = new SearchManager();
        }

        [TestCase(false, "This is also a test text", "a", 8)]
        [TestCase(false, "This is also a test text", "l", 9)]
        [TestCase(true, "This is also A test text", "A", 13)]
        public void FindTests(bool isCaseMatched, string sourceText, string targetText, int expected)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            int startingIndex = _searchManager.Find(sourceText, targetText);
            Assert.AreEqual(expected, startingIndex);
        }

        [TestCase(false, "This is also a test text", "a", 10, 13)]
        [TestCase(false, "This is also a test text", "l", 0, 9)]
        [TestCase(true, "This is also a test text", "A", 11, -1)]
        [TestCase(true, "This is also a test text", "a", 10, 13)]
        public void FindNextTests(bool isCaseMatched, string sourceText, string targetText, int startIndex, int expected)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            int startingIndex = _searchManager.FindNext(sourceText, targetText, startIndex);
            Assert.AreEqual(expected, startingIndex);
        }

        [TestCase(false, "This is also A test text", "a", "bbu", 10, "This is also bbu test text")]
        [TestCase(true, "This is also A test text a", "a", "bbu", 10, "This is also A test text bbu")]
        public void ReplaceTests(bool isCaseMatched, string sourceText, string targetText, string newText, int startIndex, string expected)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            string replacedString = _searchManager.Replace(sourceText, targetText, newText, startIndex);
            Assert.AreEqual(expected, replacedString);
        }

        [TestCase(false, "This is also a test text", "y", "bbu", 0)]
        [TestCase(true, "This is also a test text", "A", "bbu", 12)]
        public void ReplaceTests(bool isCaseMatched, string sourceText, string targetText, string newText, int startIndex)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            Assert.Throws<Exception>(delegate { _searchManager.Replace(sourceText, targetText, newText, startIndex); });
        }

        [TestCase(false, "LoremaIpsumium", "a", "bbu", "LorembbuIpsumium")]
        [TestCase(true, "A loremaIpsumium", "A", "bbu", "bbu loremaIpsumium")]
        public void ReplaceAllTests(bool isCaseMatched, string sourceText, string targetText, string newText, string expected)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            string replacedString = _searchManager.ReplaceAll(sourceText, targetText, newText);
            Assert.AreEqual(expected, replacedString);
        }

        [TestCase(false, "This is also A test text", "L", "bbu")]
        public void ReplaceAllTests(bool isCaseMatched, string sourceText, string targetText, string newText)
        {
            _searchManager.IsCaseMatched = isCaseMatched;
            Assert.Throws<Exception>(delegate { _searchManager.ReplaceAll(sourceText, targetText, newText); });
        }
    }
}
