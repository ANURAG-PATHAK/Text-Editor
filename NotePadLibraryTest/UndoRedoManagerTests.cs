using NUnit.Framework;
using NotePadLibrary;
using System.Drawing;

namespace NotePadLibrary.Tests
{
    public class UndoRedoManagerTests
    {
        private UndoRedoManager _undoRedoManager;
        [SetUp]
        public void Setup()
        {
            _undoRedoManager = new UndoRedoManager();
            _undoRedoManager.Push(new TextBoxState("loremaIpsumium", new Font("Arial", 11F)));
            _undoRedoManager.Push(new TextBoxState("loremaIpsumium is bad bacteria", new Font("Arial", 11F)));
            _undoRedoManager.Push(new TextBoxState("loremaIpsumium is bad bacteria, killed many", new Font("Arial", 11F)));
        }
        [TestCase()]
        public void UndoTests()
        {
            Assert.AreEqual("loremaIpsumium is bad bacteria", _undoRedoManager.Undo().Text);
        }
        [TestCase()]
        public void RedoTests()
        {
            _undoRedoManager.Undo();
            _undoRedoManager.Undo();
            Assert.AreEqual("loremaIpsumium is bad bacteria", _undoRedoManager.Redo().Text);
        }
    }
}
