using Domain;
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
            Directory.GetCurrentDirectory()).Parent.FullName + "\\..\\Resources\\TestImage.jpg";

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
                testImageLocation);
            CollectionAssert.Contains(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        public void ERepositoryAddNewTextboxValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextbox(testingContainer);
            CollectionAssert.Contains(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryAddNewImageInvalidNullContainerTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(null,
                testImageLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ERepositoryAddNewTextboxInvalidNullContainerTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextbox(null);
        }

        [TestMethod]
        public void ERepositoryRemoveElementImageValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewImage(testingContainer,
                testImageLocation);
            ElementRepository.Remove(addedElement);
            CollectionAssert.DoesNotContain(testingContainer.Contents, addedElement);
        }

        [TestMethod]
        public void ERepositoryRemoveElementTextboxValidTest()
        {
            ElementWhiteboard addedElement = ElementRepository.AddNewTextbox(testingContainer);
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
                testImageLocation);
            Assert.AreNotEqual(newPosition, addedElement.Position);
            Assert.AreNotEqual(newDimensions, addedElement.Dimensions);
            ElementRepository.UpdateElementPositionAndSize(addedElement,
                newDimensions, newPosition);
            Assert.AreEqual(newPosition, addedElement.Position);
            Assert.AreEqual(newDimensions, addedElement.Dimensions);
        }

        [TestMethod]
        public void ERepositoryModifyElementPositionAndSizeTextboxValidTest()
        {
            Point newPosition = new Point(150, 150);
            Size newDimensions = new Size(370, 219);
            ElementWhiteboard addedElement = ElementRepository.AddNewTextbox(testingContainer);
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
            ElementWhiteboard addedElement = ElementRepository.AddNewTextbox(testingContainer);
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
                testImageLocation);
            ElementRepository.UpdateElementPositionAndSize(addedElement, newDimensions,
                newPosition);
        }
    }
}
