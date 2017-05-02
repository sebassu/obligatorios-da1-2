using System;
using Domain;
using System.IO;
using Exceptions;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ImageWhiteboardTests
    {
        private static ImageWhiteboard testingImage;

        [TestInitialize]
        public void TestSetUp()
        {
            testingImage = ImageWhiteboard.InstanceForTestingPurposes();
        }

        private Whiteboard GenerateNonGenericTestSituation()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources\\TestImage.jpg";
            User creator = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team ownerTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3", "Descripción.", 5);
            Whiteboard imageContainer = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarrón de prueba", "Descripción.", ownerTeam, 900, 300);
            testingImage = ImageWhiteboard.CreateWithContainerSource(imageContainer, testImageLocation);
            return imageContainer;
        }

        [TestMethod]
        public void ImageForTestingPurposesTest()
        {
            Whiteboard imageContainer = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(0, testingImage.Width);
            Assert.AreEqual(0, testingImage.Height);
            Assert.AreEqual(0, testingImage.RelativeX);
            Assert.AreEqual(0, testingImage.RelativeY);
            Whiteboard containerAttribute = testingImage.Container;
            Assert.AreEqual(imageContainer, containerAttribute);
            Assert.AreEqual(DateTime.Today, containerAttribute.LastModification.Date);
        }

        [TestMethod]
        public void ImageSetValidWidthTest()
        {
            int widthToSet = 1532;
            testingImage.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingImage.Width);
        }

        [TestMethod]
        public void ImageSetValidMinimumWidthOneTest()
        {
            int widthToSet = 1;
            testingImage.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingImage.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumWidthZeroTest()
        {
            testingImage.Width = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeWidthTest()
        {
            testingImage.Width = -10;
        }

        [TestMethod]
        public void ImageSetValidHeightTest()
        {
            int heightToSet = 2500;
            testingImage.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingImage.Height);
        }

        [TestMethod]
        public void ImageSetValidMinimumHeightOneTest()
        {
            int heightToSet = 1;
            testingImage.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingImage.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidMinimumHeightZeroTest()
        {
            testingImage.Height = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidNegativeHeightTest()
        {
            testingImage.Width = -10;
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

        [TestMethod]
        public void ImageSetWidthConsideringContainerValidTest()
        {
            int widthToSet = 100;
            GenerateNonGenericTestSituation();
            testingImage.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingImage.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetWidthConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingImage.Width = 1000;
        }

        [TestMethod]
        public void ImageSetHeightConsideringContainerValidTest()
        {
            int heightToSet = 125;
            GenerateNonGenericTestSituation();
            testingImage.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingImage.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetHeightConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingImage.Height = 3000;
        }

        [TestMethod]
        public void ImageSetOriginPointConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingImage.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingImage.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingImage.RelativeY);
        }

        [TestMethod]
        public void ImageSetOriginPointLimitRightCornerOfContainerTest()
        {
            Point newOrigin = new Point(250, 200);
            GenerateNonGenericTestSituation();
            testingImage.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingImage.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingImage.RelativeY);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidXConsideringContainerTest()
        {
            Point newOrigin = new Point(1200, 10);
            GenerateNonGenericTestSituation();
            testingImage.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidYConsideringContainerTest()
        {
            Point newOrigin = new Point(200, 9000);
            GenerateNonGenericTestSituation();
            testingImage.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidOriginPointConsideringContainerTest()
        {
            Point newOrigin = new Point(3000, 3000);
            GenerateNonGenericTestSituation();
            testingImage.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        public void ImageParameterFactoryMethodValidTest()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources\\TestImage.jpg";
            Image testImageObject = Image.FromFile(testImageLocation);
            Whiteboard imageContainer = GenerateNonGenericTestSituation();
            Assert.AreEqual(300, testingImage.Width);
            Assert.AreEqual(100, testingImage.Height);
            Assert.AreEqual(300, testingImage.RelativeX);
            Assert.AreEqual(100, testingImage.RelativeY);
            Assert.AreEqual(testImageObject.PhysicalDimension,
                testingImage.ActualImage.PhysicalDimension);
            Whiteboard containerAttribute = testingImage.Container;
            Assert.AreEqual(imageContainer, containerAttribute);
            Assert.AreEqual(DateTime.Today, containerAttribute.LastModification.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageParameterFactoryMethodNullWhiteboardTest()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources\\TestImage.jpg";
            testingImage = ImageWhiteboard.CreateWithContainerSource(null, testImageLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageParameterFactoryMethodInvalidImageSourceRandomStringTest()
        {
            string testImageLocation = "En el habitual espacio lírico de Les Luthiers";
            Whiteboard imageContainer = GenerateNonGenericTestSituation();
            testingImage = ImageWhiteboard.CreateWithContainerSource(imageContainer, testImageLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageParameterFactoryMethodInvalidImageSourceNotAFileTest()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources";
            Whiteboard imageContainer = GenerateNonGenericTestSituation();
            testingImage = ImageWhiteboard.CreateWithContainerSource(imageContainer, testImageLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageParameterFactoryMethodInvalidImageSourceNotAnImageTest()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources\\TestTextFile.txt";
            Whiteboard imageContainer = GenerateNonGenericTestSituation();
            testingImage = ImageWhiteboard.CreateWithContainerSource(imageContainer, testImageLocation);
        }
    }
}