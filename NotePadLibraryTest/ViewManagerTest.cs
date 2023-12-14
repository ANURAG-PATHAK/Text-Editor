using NUnit.Framework;
using NotePadLibrary;
using System;

namespace NotePadLibrary.Tests
{
    public class ViewManagerTests
    {
        private ViewManager _viewManager;
        [SetUp]
        public void Setup()
        {
            _viewManager = new ViewManager(20);
        }
        [TestCase(24d, 25d)]
        public void ZoomInTests(double currentZoom, double expected)
        {
            Assert.AreEqual(expected, _viewManager.ZoomIn(currentZoom));
        }

        [TestCase(24d)]
        public void ZoomInTests(double currentZoom)
        {
            _viewManager.ZoomFactor = 200d;
            Assert.Throws<Exception>( delegate { _viewManager.ZoomIn(currentZoom); });
        }
        [TestCase(24d, 23d, ExpectedResult =23d)]
        public void ZoomOutTests(double currentZoom, double expected)
        {
            Assert.AreEqual(expected, _viewManager.ZoomOut(currentZoom));
        }
        [TestCase(20d)]
        public void ZoomOutTests(double currentZoom)
        {
            _viewManager.ZoomFactor = 200d;
            Assert.Throws<Exception>(delegate { _viewManager.ZoomIn(currentZoom); });
        }
        [TestCase(20d)]
        public void ResetZoomTest(double expected)
        {
            Assert.AreEqual(expected, _viewManager.ResetZoom());
        }
    }
}
