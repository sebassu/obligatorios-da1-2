﻿using Domain;
using Exceptions;
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
        public void ImageSetValidRelativeXTest()
        {
            testingImage.RelativeX = 45;
            Assert.AreEqual(45, testingImage.RelativeX);
        }

        [TestMethod]
        public void ImageSetValidMinimumRelativeXZeroTest()
        {
            testingImage.RelativeX = 0;
            Assert.AreEqual(0, testingImage.RelativeX);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeRelativeXTest()
        {
            testingImage.RelativeX = -40;
        }

        [TestMethod]
        public void ImageSetValidRelativeYTest()
        {
            testingImage.RelativeY = 90;
            Assert.AreEqual(45, testingImage.RelativeX);
        }

        [TestMethod]
        public void ImageSetValidMinimumRelativeYZeroTest()
        {
            testingImage.RelativeY = 0;
            Assert.AreEqual(0, testingImage.RelativeX);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeRelativeYTest()
        {
            testingImage.RelativeY = -2112;
        }
    }
}
