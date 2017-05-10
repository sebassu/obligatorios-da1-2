using Domain;
using Exceptions;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteboardRepositoryTests
    {
        private static WhiteboardRepository testingWhiteboardRepository;
        private static Team testingOwnerTeam;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            TeamRepository globalTeams = TeamRepository.GetInstance();
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            testingOwnerTeam = globalTeams.AddNewTeam("Los Simuladores", descriptionToSet, 4);
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingWhiteboardRepository = new WhiteboardRepositoryInMemory();
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            UserRepository users = UserRepository.GetInstance();
        }

        [ClassCleanup]
        public static void ClassTeardown()
        {
            Session.End();
        }

        [TestMethod]
        public void URepositoryGetInstanceTest()
        {
            testingWhiteboardRepository = WhiteboardRepository.GetInstance();
            WhiteboardRepository anotherWhiteboardRepository = WhiteboardRepository.GetInstance();
            Assert.AreSame(testingWhiteboardRepository, anotherWhiteboardRepository);
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(Session.ActiveUser(),
                "Pizarrón", "Una descripción válida.", testingOwnerTeam, 240, 240);
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(testingWhiteboardRepository.Elements.ToList(), whiteboardToVerify);
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardReturnsWhiteboardValidTest()
        {
            Whiteboard addedWhiteboard = testingWhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(testingWhiteboardRepository.Elements.ToList(), addedWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryAddNewWhiteboardNotEnoughPrivilegesInvalidTest()
        {
            Session.End();
            Session.Start("ravenna@simuladores.com", "password123");
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidNameTest()
        {
            testingWhiteboardRepository.AddNewWhiteboard("84%!^#^ ! /*/*^#", "Una descripción válida.",
                testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidDescriptionTest()
        {
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón", "      \n \t\t\n     ",
                testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidWidthTest()
        {
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, -2112, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidHeightTest()
        {
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, 240, -300);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardPrivilegedCreatorNotInTeamInvalidTest()
        {
            Session.End();
            Session.Start("administrator@tf2.com", "Victory");
            testingWhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }
    }
}