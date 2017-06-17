using System;
using Domain;
using Exceptions;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TextBoxWhiteboardTests
    {
        private static TextBoxWhiteboard testingTextBox;

        [TestInitialize]
        public void TestSetup()
        {
            testingTextBox = TextBoxWhiteboard.InstanceForTestingPurposes();
        }

        private static Whiteboard GenerateNonGenericTestSituation()
        {
            User creator = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            Team ownerTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3",
                "Descripción.", 5);
            Whiteboard textBoxContainer = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarrón de prueba", "Descripción.", ownerTeam, 1200, 600);
            testingTextBox = TextBoxWhiteboard.CreateWithContainer(textBoxContainer);
            return textBoxContainer;
        }

        [TestMethod]
        public void TextBoxForTestingPurposesTest()
        {
            Whiteboard textBoxContainer = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(0, testingTextBox.Width);
            Assert.AreEqual(0, testingTextBox.Height);
            Assert.AreEqual(0, testingTextBox.RelativeX);
            Assert.AreEqual(0, testingTextBox.RelativeY);
            Whiteboard containerAttribute = testingTextBox.Container;
            Assert.AreEqual(textBoxContainer, containerAttribute);
            Assert.AreEqual(DateTime.Today, containerAttribute.LastModification.Date);
            Assert.AreEqual(0, testingTextBox.WidthContainerNeeded());
            Assert.AreEqual(0, testingTextBox.HeightContainerNeeded());
        }

        [TestMethod]
        public void TextBoxSetValidWidthTest()
        {
            int widthToSet = 1532;
            testingTextBox.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetValidMinimumWidthOneTest()
        {
            int widthToSet = 1;
            testingTextBox.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetInvalidMinimumWidthZeroTest()
        {
            testingTextBox.Width = 0;
            Assert.AreEqual(0, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetInvalidNegativeWidthTest()
        {
            testingTextBox.Width = -10;
            Assert.AreEqual(-10, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetValidHeightTest()
        {
            int heightToSet = 2500;
            testingTextBox.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetValidMinimumHeightOneTest()
        {
            int heightToSet = 1;
            testingTextBox.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetInvalidMinimumHeightZeroTest()
        {
            testingTextBox.Height = 0;
            Assert.AreEqual(0, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetInvalidNegativeHeightTest()
        {
            testingTextBox.Width = -10;
            Assert.AreEqual(-10, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetValidOriginPointTest()
        {
            Point newOrigin = new Point(23, 37);
            testingTextBox.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingTextBox.Position);
        }

        [TestMethod]
        public void TextBoxSetMinimumValidOriginPointTest()
        {
            Point newOrigin = new Point(0, 0);
            testingTextBox.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingTextBox.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidXTest()
        {
            Point newOrigin = new Point(-100, 10);
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidYTest()
        {
            Point newOrigin = new Point(200, -99);
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidOriginPointTest()
        {
            Point newOrigin = new Point(-2112, -1000);
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        public void TextBoxSetWidthConsideringContainerValidTest()
        {
            int widthToSet = 100;
            GenerateNonGenericTestSituation();
            testingTextBox.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetWidthConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingTextBox.Width = 1000;
            Assert.AreEqual(1000, testingTextBox.Width);
        }

        [TestMethod]
        public void TextBoxSetHeightConsideringContainerValidTest()
        {
            int heightToSet = 125;
            GenerateNonGenericTestSituation();
            testingTextBox.Height = heightToSet;
            Assert.AreEqual(heightToSet, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetHeightConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingTextBox.Height = 3000;
            Assert.AreEqual(3000, testingTextBox.Height);
        }

        [TestMethod]
        public void TextBoxSetOriginPointConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingTextBox.Position);
        }

        [TestMethod]
        public void TextBoxSetOriginPointLimitRightCornerOfContainerTest()
        {
            Point newOrigin = new Point(250, 200);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingTextBox.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidXConsideringContainerTest()
        {
            Point newOrigin = new Point(1200, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidYConsideringContainerTest()
        {
            Point newOrigin = new Point(200, 9000);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidOriginPointConsideringContainerTest()
        {
            Point newOrigin = new Point(3000, 3000);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
        }

        [TestMethod]
        public void TextBoxSetValidDimensionsTest()
        {
            Size newSize = new Size(50, 50);
            testingTextBox.Dimensions = newSize;
            Assert.AreEqual(newSize, testingTextBox.Dimensions);
        }

        [TestMethod]
        public void TextBoxSetMinimumDimensionsTest()
        {
            Size newSize = new Size(1, 1);
            testingTextBox.Dimensions = newSize;
            Assert.AreEqual(newSize, testingTextBox.Dimensions);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetDimensionsInvalidWidthTest()
        {
            Size newSize = new Size(-100, 10);
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetDimensionsInvalidHeightTest()
        {
            Size newSize = new Size(658, -2112);
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidDimensionsTest()
        {
            Size newSize = new Size(-2112, -1000);
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        public void TextBoxParameterFactoryMethodValidTest()
        {
            Whiteboard textBoxContainer = GenerateNonGenericTestSituation();
            Assert.AreEqual(textBoxContainer, testingTextBox.Container);
            Assert.AreEqual(400, testingTextBox.Width);
            Assert.AreEqual(200, testingTextBox.Height);
            Assert.AreEqual(400, testingTextBox.RelativeX);
            Assert.AreEqual(200, testingTextBox.RelativeY);
            Assert.IsNull(testingTextBox.TextContent);
            Whiteboard containerAttribute = testingTextBox.Container;
            Assert.AreEqual(textBoxContainer, containerAttribute);
            Assert.AreEqual(DateTime.Today, containerAttribute.LastModification.Date);
            Assert.AreEqual(800, testingTextBox.WidthContainerNeeded());
            Assert.AreEqual(400, testingTextBox.HeightContainerNeeded());
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxParameterFactoryMethodNullWhiteboardTest()
        {
            testingTextBox = TextBoxWhiteboard.CreateWithContainer(null);
        }

        [TestMethod]
        public void TextBoxSetTextContentValidTest()
        {
            string contentToSet = "Lorem ipsum dolor sit amet";
            testingTextBox.TextContent = contentToSet;
            Assert.AreEqual(contentToSet, testingTextBox.TextContent);
        }

        [TestMethod]
        public void TextBoxSetTextContentNumbersValidTest()
        {
            string contentToSet = "123456789";
            testingTextBox.TextContent = contentToSet;
            Assert.AreEqual(contentToSet, testingTextBox.TextContent);
        }

        [TestMethod]
        public void TextBoxSetTextContentValidPunctuationTest()
        {
            string contentToSet = "!^#&  */$^^";
            testingTextBox.TextContent = contentToSet;
            Assert.AreEqual(contentToSet, testingTextBox.TextContent);
        }

        [TestMethod]
        public void TextBoxSetTextContentValidEmptyTest()
        {
            testingTextBox.TextContent = "";
        }

        [TestMethod]
        public void TextBoxSetTextContentValidNullTest()
        {
            testingTextBox.TextContent = null;
        }

        [TestMethod]
        public void TextBoxSetDimensionsConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.Position = newOrigin;
            Assert.AreEqual(newOrigin, testingTextBox.Position); ;
        }

        [TestMethod]
        public void TextBoxSetDimensionsLimitRightCornerOfContainerTest()
        {
            Size newSize = new Size(250, 200);
            GenerateNonGenericTestSituation();
            testingTextBox.Dimensions = newSize;
            Assert.AreEqual(newSize, testingTextBox.Dimensions);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetDimensionsInvalidWidthConsideringContainerTest()
        {
            Size newSize = new Size(9000, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetDimensionsInvalidHeightConsideringContainerTest()
        {
            Size newSize = new Size(10, 9000);
            GenerateNonGenericTestSituation();
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ImageSetInvalidDimensionsConsideringContainerTest()
        {
            Size newSize = new Size(3000, 3000);
            GenerateNonGenericTestSituation();
            testingTextBox.Dimensions = newSize;
        }

        [TestMethod]
        public void TextBoxAddCommentValidTest()
        {
            Comment testingComment = Comment.InstanceForTestingPurposes();
            testingTextBox.AddComment(testingComment);
            CollectionAssert.Contains(testingTextBox.Comments.ToList(), testingComment);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void TextBoxAddRepeatedCommentInvalidTest()
        {
            Comment testingComment = Comment.InstanceForTestingPurposes();
            testingTextBox.AddComment(testingComment);
            testingTextBox.AddComment(testingComment);
        }

        [TestMethod]
        public void TextBoxSetFontTest()
        {
            Font someFont = new Font("Times New Roman", 12.0f);
            testingTextBox.TextFont = someFont;
            Assert.AreEqual(someFont, testingTextBox.TextFont);
        }
    }
}