using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
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
        }
    }
}
