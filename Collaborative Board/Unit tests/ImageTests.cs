using Domain;
using Exceptions;
using System.Windows;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ImageTests
    {
        private static Image testingImage;

        [TestInitialize]
        public void TestSetUp()
        {
            testingImage = Image.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ImageForTestingPurposesTest()
        {
            Whiteboard testingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(0, testingImage.Width);
            Assert.AreEqual(0, testingImage.Height);
        }

        [TestMethod]
        public void ImageSetValidWidthTest()
        {
            testingImage.Width = 1532;
            Assert.AreEqual(1532, testingImage.Width);
        }

        [TestMethod]
        public void ImageSetValidMinimumWidthOneTest()
        {
            testingImage.Width = 1;
            Assert.AreEqual(1, testingImage.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeWidthTest()
        {
            testingImage.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumWidthZeroTest()
        {
            testingImage.Width = 0;
        }

        [TestMethod]
        public void ImageSetValidHeightTest()
        {
            testingImage.Height = 2500;
            Assert.AreEqual(2500, testingImage.Height);
        }

        [TestMethod]
        public void ImageSetValidMinimumHeightOneTest()
        {
            testingImage.Height = 1;
            Assert.AreEqual(1, testingImage.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeHeightTest()
        {
            testingImage.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumHeightZeroTest()
        {
            testingImage.Height = 0;
        }

        [TestMethod]
        public void ImageSetValidOriginPointTest()
        {
            Point newOrigin = new Point(23, 37);
            testingImage.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingImage.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingImage.RelativeY);
        }

        [TestMethod]
        public void ImageSetMinimumValidOriginPointTest()
        {
            Point newOrigin = new Point(0, 0);
            testingImage.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingImage.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingImage.RelativeY);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidXTest()
        {
            Point newOrigin = new Point(-100, 10);
            testingImage.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidYTest()
        {
            Point newOrigin = new Point(200, -99);
            testingImage.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidOriginPointTest()
        {
            Point newOrigin = new Point(-2112, -1000);
            testingImage.SetOriginPoint(newOrigin);
        }
    }
}
