using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    public class TextBoxTests
    {
        private static TextBox testingTextBox;

        [TestInitialize]
        public void TestSetUp()
        {
            testingTextBox = TextBox.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ImageForTestingPurposesTest()
        {
            Whiteboard testingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(0, testingTextBox.Width);
            Assert.AreEqual(0, testingTextBox.Height);
        }

        [TestMethod]
        public void ImageSetValidWidthTest()
        {
            testingTextBox.Width = 1532;
            Assert.AreEqual(1532, testingTextBox.Width);
        }

        [TestMethod]
        public void ImageSetValidMinimumWidthOneTest()
        {
            testingTextBox.Width = 1;
            Assert.AreEqual(1, testingTextBox.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeWidthTest()
        {
            testingTextBox.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumWidthZeroTest()
        {
            testingTextBox.Width = 0;
        }

        [TestMethod]
        public void ImageSetValidHeightTest()
        {
            testingTextBox.Height = 2500;
            Assert.AreEqual(2500, testingTextBox.Height);
        }

        [TestMethod]
        public void ImageSetValidMinimumHeightOneTest()
        {
            testingTextBox.Height = 1;
            Assert.AreEqual(1, testingTextBox.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeHeightTest()
        {
            testingTextBox.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumHeightZeroTest()
        {
            testingTextBox.Height = 0;
        }

        [TestMethod]
        public void ImageSetValidRelativeXTest()
        {
            testingTextBox.RelativeX = 45;
            Assert.AreEqual(45, testingTextBox.RelativeX);
        }

        [TestMethod]
        public void ImageSetValidMinimumRelativeXZeroTest()
        {
            testingTextBox.RelativeX = 0;
            Assert.AreEqual(0, testingTextBox.RelativeX);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeRelativeXTest()
        {
            testingTextBox.RelativeX = -40;
        }

        [TestMethod]
        public void ImageSetValidRelativeYTest()
        {
            testingTextBox.RelativeY = 90;
            Assert.AreEqual(45, testingTextBox.RelativeX);
        }

        [TestMethod]
        public void ImageSetValidMinimumRelativeYZeroTest()
        {
            testingTextBox.RelativeY = 0;
            Assert.AreEqual(0, testingTextBox.RelativeX);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeRelativeYTest()
        {
            testingTextBox.RelativeY = -2112;
        }
    }
}
