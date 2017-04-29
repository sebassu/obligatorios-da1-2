using Domain;
using Exceptions;
using System.Windows;
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
        public void TextBoxForTestingPurposesTest()
        {
            Whiteboard testingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(0, testingTextBox.Width);
            Assert.AreEqual(0, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetValidWidthTest()
        {
            testingTextBox.Width = 1532;
            Assert.AreEqual(1532, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetValidMinimumWidthOneTest()
        {
            testingTextBox.Width = 1;
            Assert.AreEqual(1, testingTextBox.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidNegativeWidthTest()
        {
            testingTextBox.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumWidthZeroTest()
        {
            testingTextBox.Width = 0;
        }

        [TestMethod]
        public void TextBoxSetValidHeightTest()
        {
            testingTextBox.Height = 2500;
            Assert.AreEqual(2500, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetValidMinimumHeightOneTest()
        {
            testingTextBox.Height = 1;
            Assert.AreEqual(1, testingTextBox.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidNegativeHeightTest()
        {
            testingTextBox.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumHeightZeroTest()
        {
            testingTextBox.Height = 0;
        }

        [TestMethod]
        public void TextBoxSetValidOriginPointTest()
        {
            Point newOrigin = new Point(23, 37);
            testingTextBox.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingTextBox.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingTextBox.RelativeY);
        }

        [TestMethod]
        public void TextBoxSetMinimumValidOriginPointTest()
        {
            Point newOrigin = new Point(0, 0);
            testingTextBox.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingTextBox.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingTextBox.RelativeY);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidXTest()
        {
            Point newOrigin = new Point(-100, 10);
            testingTextBox.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidYTest()
        {
            Point newOrigin = new Point(200, -99);
            testingTextBox.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidOriginPointTest()
        {
            Point newOrigin = new Point(-2112, -1000);
            testingTextBox.SetOriginPoint(newOrigin);
        }
    }
}
