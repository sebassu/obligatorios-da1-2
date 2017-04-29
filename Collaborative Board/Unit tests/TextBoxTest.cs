using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    public class TextBoxTest
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
        public void TextBoxSetValidMinimumWidthTest()
        {
            testingTextBox.Width = 1;
            Assert.AreEqual(1, testingTextBox.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidWidthTest()
        {
            testingTextBox.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumWidthTest()
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
        public void TextBoxSetValidMinimumHeightTest()
        {
            testingTextBox.Height = 1;
            Assert.AreEqual(1, testingTextBox.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidHeightTest()
        {
            testingTextBox.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumHeightTest()
        {
            testingTextBox.Height = 0;
        }
    }
}
