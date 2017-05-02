using System;
using Domain;
using Exceptions;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TextBoxWhiteboardTests
    {
        private static TextBoxWhiteboard testingTextBox;

        [TestInitialize]
        public void TestSetUp()
        {
            testingTextBox = TextBoxWhiteboard.InstanceForTestingPurposes();
        }

        private static Whiteboard GenerateNonGenericTestSituation()
        {
            User creator = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team ownerTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3",
                "Descripción.", 5);
            Whiteboard container = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarrón de prueba", "Descripción.", ownerTeam, 1200, 600);
            testingTextBox = TextBoxWhiteboard.CreateWithContainer(container);
            return container;
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
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumWidthZeroTest()
        {
            testingTextBox.Width = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidNegativeWidthTest()
        {
            testingTextBox.Width = -10;
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
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidMinimumHeightZeroTest()
        {
            testingTextBox.Height = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidNegativeHeightTest()
        {
            testingTextBox.Width = -10;
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

        [TestMethod]
        public void TextBoxSetWidthConsideringContainerValidTest()
        {
            int widthToSet = 100;
            GenerateNonGenericTestSituation();
            testingTextBox.Width = widthToSet;
            Assert.AreEqual(widthToSet, testingTextBox.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetWidthConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingTextBox.Width = 1000;
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
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetHeightConsideringContainerInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingTextBox.Height = 3000;
        }

        [TestMethod]
        public void TextBoxSetOriginPointConsideringContainerValidTest()
        {
            Point newOrigin = new Point(250, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingTextBox.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingTextBox.RelativeY);
        }

        [TestMethod]
        public void TextBoxSetOriginPointLimitRightCornerOfContainerTest()
        {
            Point newOrigin = new Point(250, 200);
            GenerateNonGenericTestSituation();
            testingTextBox.SetOriginPoint(newOrigin);
            Assert.AreEqual(newOrigin.X, testingTextBox.RelativeX);
            Assert.AreEqual(newOrigin.Y, testingTextBox.RelativeY);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidXConsideringContainerTest()
        {
            Point newOrigin = new Point(1200, 10);
            GenerateNonGenericTestSituation();
            testingTextBox.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetOriginPointInvalidYConsideringContainerTest()
        {
            Point newOrigin = new Point(200, 9000);
            GenerateNonGenericTestSituation();
            testingTextBox.SetOriginPoint(newOrigin);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void TextBoxSetInvalidOriginPointConsideringContainerTest()
        {
            Point newOrigin = new Point(3000, 3000);
            GenerateNonGenericTestSituation();
            testingTextBox.SetOriginPoint(newOrigin);
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
    }
}