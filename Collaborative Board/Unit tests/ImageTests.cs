using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
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
        public void ImageSetValidMinimumWidthTest()
        {
            testingImage.Width = 1;
            Assert.AreEqual(1, testingImage.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidWidthTest()
        {
            testingImage.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumWidthTest()
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
        public void ImageSetValidMinimumHeightTest()
        {
            testingImage.Height = 1;
            Assert.AreEqual(1, testingImage.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidHeightTest()
        {
            testingImage.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumHeightTest()
        {
            testingImage.Height = 0;
        }
    }
}
