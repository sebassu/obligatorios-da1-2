using System;
using Domain;
using System.IO;
using System.Linq;
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
        private static readonly string testImageLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + "\\..\\Resources\\TestImage.jpg";

        [TestInitialize]
        public void TestSetup()
        {
            testingImage = ImageWhiteboard.InstanceForTestingPurposes();
        }

        private static Whiteboard GenerateNonGenericTestSituation()
        {
            User creator = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
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
            Assert.AreEqual(0, testingImage.WidthContainerNeeded());
            Assert.AreEqual(0, testingImage.HeightContainerNeeded());
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
        public void ImageSetInvalidMinimumWidthZeroTest()
        {
            testingImage.Width = 0;
            Assert.AreEqual(0, testingImage.Width);
        }

        [TestMethod]
        public void ImageSetInvalidNegativeWidthTest()
        {
            testingImage.Width = -10;
            Assert.AreEqual(-10, testingImage.Width);
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
        public void ImageSetInvalidMinimumHeightZeroTest()
        {
            testingImage.Height = 0;
            Assert.AreEqual(0, testingImage.Height);
        }

        [TestMethod]
        public void ImageSetInvalidNegativeHeightTest()
        {
            testingImage.Height = -10;
            Assert.AreEqual(-10, testingImage.Height);
        }


        [TestMethod]
        public void ImageSetValidOriginPointTest()
        {
            Point newOrigin = new Point(23, 37);
            testingImage.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingImage.Position);
        }

        [TestMethod]
        public void ImageSetMinimumValidOriginPointTest()
        {
            Point newOrigin = new Point(0, 0);
            testingImage.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingImage.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidXTest()
        {
            Point newOrigin = new Point(-100, 10);
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidYTest()
        {
            Point newOrigin = new Point(200, -99);
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidOriginPointTest()
        {
            Point newOrigin = new Point(-2112, -1000);
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        public void ImageSetValidDimensionsTest()
        {
            Size newSize = new Size(50, 50);
            testingImage.Dimensions = newSize;
            Assert.AreEqual(newSize, testingImage.Dimensions);
        }

        [TestMethod]
        public void ImageSetMinimumDimensionsTest()
        {
            Size newSize = new Size(1, 1);
            testingImage.Dimensions = newSize;
            Assert.AreEqual(newSize, testingImage.Dimensions);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetDimensionsInvalidWidthTest()
        {
            Size newSize = new Size(-100, 10);
            testingImage.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetDimensionsInvalidHeightTest()
        {
            Size newSize = new Size(658, -2112);
            testingImage.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidDimensionsTest()
        {
            Size newSize = new Size(-2112, -1000);
            testingImage.Dimensions = newSize;
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
        public void ImageSetWidthConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingImage.Width = 1000;
            Assert.AreEqual(1000, testingImage.Width);
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
        public void ImageSetHeightConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingImage.Height = 3000;
            Assert.AreEqual(3000, testingImage.Height);
        }

        [TestMethod]
        public void ImageSetOriginPointConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingImage.Position); ;
        }

        [TestMethod]
        public void ImageSetOriginPointLimitRightCornerOfContainerTest()
        {
            Point newOrigin = new Point(250, 200);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingImage.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidXConsideringContainerTest()
        {
            Point newOrigin = new Point(1200, 10);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetOriginPointInvalidYConsideringContainerTest()
        {
            Point newOrigin = new Point(200, 9000);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidOriginPointConsideringContainerTest()
        {
            Point newOrigin = new Point(3000, 3000);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
        }

        [TestMethod]
        public void ImageParameterFactoryMethodValidTest()
        {
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
            Assert.AreEqual(600, testingImage.WidthContainerNeeded());
            Assert.AreEqual(200, testingImage.HeightContainerNeeded());
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageParameterFactoryMethodNullWhiteboardTest()
        {
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

        [TestMethod]
        public void ImageSetDimensionsConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingImage.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingImage.Position); ;
        }

        [TestMethod]
        public void ImageSetDimensionsLimitRightCornerOfContainerTest()
        {
            Size newSize = new Size(250, 200);
            GenerateNonGenericTestSituation();
            testingImage.Dimensions = newSize;
            Assert.AreEqual(newSize, testingImage.Dimensions);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetDimensionsInvalidWidthConsideringContainerTest()
        {
            Size newSize = new Size(9000, 10);
            GenerateNonGenericTestSituation();
            testingImage.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetDimensionsInvalidHeightConsideringContainerTest()
        {
            Size newSize = new Size(10, 9000);
            GenerateNonGenericTestSituation();
            testingImage.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidDimensionsConsideringContainerTest()
        {
            Size newSize = new Size(3000, 3000);
            GenerateNonGenericTestSituation();
            testingImage.Dimensions = newSize;
        }

        [TestMethod]
        public void ImageAddCommentValidTest()
        {
            Comment testingComment = Comment.InstanceForTestingPurposes();
            testingImage.AddComment(testingComment);
            CollectionAssert.Contains(testingImage.Comments.ToList(), testingComment);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void ImageAddRepeatedCommentInvalidTest()
        {
            Comment testingComment = Comment.InstanceForTestingPurposes();
            testingImage.AddComment(testingComment);
            testingImage.AddComment(testingComment);
        }
    }
}