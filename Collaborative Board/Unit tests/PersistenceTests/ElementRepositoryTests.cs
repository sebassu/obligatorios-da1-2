﻿using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
using System.Drawing;
using System.IO;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    public class ElementRepositoryTests
    {
        private static Whiteboard testingContainer;
        private static readonly string testImageLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + "\\..\\Resources\\";

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            AddTestingContainer();
        }

        private static void AddTestingContainer()
        {
            UserRepository.AddNewAdministrator("Graham", "Chapman",
                "chapman@python.com", DateTime.Today, "LemonCurry");
            User cleese = UserRepository.AddNewAdministrator("John", "Cleese",
                "cleese@python.com", DateTime.Today, "SillyWalks");
            Team montypython = TeamRepository.AddNewTeam("Monty Pythons Flying Circus",
                "Silly, silly.", 19);
            TeamRepository.AddMemberToTeam(montypython, cleese);
            testingContainer = WhiteboardRepository.AddNewWhiteboard("Holy grail",
                "Hate it when people rubble.", montypython, 1250, 1250);
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("chapman@python.com", "LemonCurry");
        }

        [TestMethod]
        public void ERepositoryAddNewImageValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            CollectionAssert.Contains(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        public void ERepositoryAddNewTextBoxValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            CollectionAssert.Contains(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryAddNewImageInvalidNullContainerTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(null,
                testImageLocation + "TestImage.jpg");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryAddNewTextBoxInvalidNullContainerTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextBox(null);
        }

        [TestMethod]
        public void ERepositoryRemoveElementImageValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            ElementRepository.Remove(addedElement);
            CollectionAssert.DoesNotContain(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        public void ERepositoryRemoveElementTextBoxValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            ElementRepository.Remove(addedElement);
            CollectionAssert.DoesNotContain(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryRemoveElementNullInvalidTest()
        {
            ElementRepository.Remove(null);
        }

        [TestMethod]
        public void ERepositoryModifyElementPositionAndSizeImageValidTest()
        {
            Point newPosition = new Point(280, 350);
            Size newDimensions = new Size(100, 100);
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            Assert.AreNotEqual(newPosition, addedElement.Position);
            Assert.AreNotEqual(newDimensions, addedElement.Dimensions);
            ElementRepository.UpdateElementPositionAndSize(addedElement,
                newDimensions, newPosition);
            Assert.AreEqual(newPosition, addedElement.Position);
            Assert.AreEqual(newDimensions, addedElement.Dimensions);
        }

        [TestMethod]
        public void ERepositoryModifyElementPositionAndSizeTextBoxValidTest()
        {
            Point newPosition = new Point(150, 150);
            Size newDimensions = new Size(370, 219);
            ElementWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            Assert.AreNotEqual(newPosition, addedElement.Position);
            Assert.AreNotEqual(newDimensions, addedElement.Dimensions);
            ElementRepository.UpdateElementPositionAndSize(addedElement,
                newDimensions, newPosition);
            Assert.AreEqual(newPosition, addedElement.Position);
            Assert.AreEqual(newDimensions, addedElement.Dimensions);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryModifyElementPositionAndSizeNullElementInvalidTest()
        {
            Point newPosition = new Point(200, 156);
            Size newDimensions = new Size(651, 200);
            ElementRepository.UpdateElementPositionAndSize(null,
                newDimensions, newPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ERepositoryModifyElementPositionAndSizeInvalidPositionTest()
        {
            Point newPosition = new Point(0, -333);
            Size newDimensions = new Size(651, 200);
            ElementWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            ElementRepository.UpdateElementPositionAndSize(addedElement, newDimensions,
                newPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ERepositoryModifyElementPositionAndSizeInvalidDimensionsTest()
        {
            Point newPosition = new Point(200, 156);
            Size newDimensions = new Size(-121, 0);
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            ElementRepository.UpdateElementPositionAndSize(addedElement, newDimensions,
                newPosition);
        }

        /*[TestMethod]
        public void ERepositoryModifyImageValidTest()
        {
            ImageConverter converter = new ImageConverter();
            Image oldImage = Image.FromFile(testImageLocation + "TestImage.jpg");
            byte[] oldImageToCompare = converter.ConvertTo(oldImage, typeof(byte[])) as byte[];
            ImageWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            CollectionAssert.AreEqual(oldImageToCompare, addedElement.ImageToSave);
            Image newImage = Image.FromFile(testImageLocation + "Portal.jpg");
            byte[] newImageToCompare = converter.ConvertTo(newImage, typeof(byte[])) as byte[];
            ElementRepository.UpdateImage(addedElement, newImage);
            CollectionAssert.AreEqual(newImageToCompare, addedElement.ImageToSave);
        }*/

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryModifyImageNullElementInvalidTest()
        {
            Image testingImage = Image.FromFile(testImageLocation + "TestImage.jpg");
            ElementRepository.UpdateImage(null, testingImage);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ERepositoryModifyNullImageInvalidTest()
        {
            ImageWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation + "TestImage.jpg");
            ElementRepository.UpdateImage(addedElement, null);
        }

        [TestMethod]
        public void ERepositoryModifyFontValidTest()
        {
            Font fontToSet = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
            TextBoxWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            Assert.AreNotEqual(fontToSet, addedElement.TextFont);
            ElementRepository.UpdateFont(addedElement, fontToSet);
            Assert.AreEqual(fontToSet, addedElement.TextFont);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryModifyFontNullElementValidTest()
        {
            Font fontToSet = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
            ElementRepository.UpdateFont(null, fontToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementException))]
        public void ERepositoryModifyNullFontValidTest()
        {
            TextBoxWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            ElementRepository.UpdateFont(addedElement, null);
        }

        [TestMethod]
        public void ERepositoryModifyTextValidTest()
        {
            string textToSet = "En el habitual espacio lírico";
            TextBoxWhiteboard addedElement = ElementRepository.AddNewTextBox(testingContainer);
            Assert.AreNotEqual(textToSet, addedElement.TextContent);
            ElementRepository.UpdateText(addedElement, textToSet);
            Assert.AreEqual(textToSet, addedElement.TextContent);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryModifyTextNullElementValidTest()
        {
            string textToSet = "En el habitual espacio lírico";
            ElementRepository.UpdateText(null, textToSet);
        }
    }
}
