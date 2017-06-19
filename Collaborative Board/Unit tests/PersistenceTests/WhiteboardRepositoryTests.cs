using System;
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
        private static Team testingOwnerTeam;
        private static Team otherTeam;
        private static User colpocorto;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            AddUserDataTest();
            AddTeamDataTest();
            AddTestingWhiteboardsAsRegularUser();
        }

        private static void AddUserDataTest()
        {
            UserRepository.AddNewAdministrator("Johann Sebastian", "Mastropiero",
                "mastropiero@lesluthiers.com", DateTime.Today, "Condesa");
            colpocorto = UserRepository.AddNewUser("Giovanni", "Colpocorto",
                "colpocorto@lesluthiers.com", DateTime.Today, "TrepoTemoTiemblo");
            UserRepository.AddNewUser("Warren", "Sánchez",
                "sanchez@sendero.com", DateTime.Today, "YoQueSe");
        }

        public static void AddTeamDataTest()
        {
            ChangeActiveUser("mastropiero@lesluthiers.com", "Condesa");
            AddNewTestingOwnerTeamInstance();
            otherTeam = TeamRepository.AddNewTeam("Compositores",
                "Gente con alta inspiración musical.", 5);
        }

        private static void AddNewTestingOwnerTeamInstance()
        {
            string descriptionToSet = "Grupo de seguidores de Johann Sebastian Mastropiero.";
            testingOwnerTeam = TeamRepository.AddNewTeam("Les Freres Luthiers", descriptionToSet, 5);
            TeamRepository.AddMemberToTeam(testingOwnerTeam, colpocorto);
        }

        private static void AddTestingWhiteboardsAsRegularUser()
        {
            ChangeActiveUser("colpocorto@lesluthiers.com", "TrepoTemoTiemblo");
            WhiteboardRepository.AddNewWhiteboard("Whiteboard",
                "Valid description.", testingOwnerTeam, 240, 240);
            WhiteboardRepository.AddNewWhiteboard("Another whiteboard",
                "Another valid description.", testingOwnerTeam, 121, 323);
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("mastropiero@lesluthiers.com", "Condesa");
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardValidTest()
        {
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Pizarrón 1",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                addedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardNonAdministratorValidTest()
        {
            ChangeActiveUser("colpocorto@lesluthiers.com", "TrepoTemoTiemblo");
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Some whiteboard",
                "Some valid description", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                addedWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidNameTest()
        {
            WhiteboardRepository.AddNewWhiteboard("84%!^#^ ! /*//*^#",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidDescriptionTest()
        {
            WhiteboardRepository.AddNewWhiteboard("Pizarrón", "  \n \t\t\n ",
                testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidWidthTest()
        {
            WhiteboardRepository.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, -2112, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidHeightTest()
        {
            WhiteboardRepository.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, 240, -300);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardPrivilegedCreatorNotInTeamInvalidTest()
        {
            ChangeActiveUser("administrator@tf2.com", "Victory");
            WhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        public void WRepositoryRemoveWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarrón 42",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            WhiteboardRepository.Remove(whiteboardToVerify);
            CollectionAssert.DoesNotContain(WhiteboardRepository.Elements.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryRemoveUnregisteredWhiteboardInvalidTest()
        {
            Whiteboard whiteboardToFailRemoving = Whiteboard.InstanceForTestingPurposes();
            WhiteboardRepository.Remove(whiteboardToFailRemoving);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryRemoveNullUserInvalidTest()
        {
            WhiteboardRepository.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInDirectoryInvalidTest()
        {
            Whiteboard notAddedWhiteboard = Whiteboard.InstanceForTestingPurposes();
            WhiteboardRepository.Remove(notAddedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryRemoveRemovedFromOwnerTeamTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarra",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            TeamRepository.LoadCreatedWhiteboards(testingOwnerTeam);
            CollectionAssert.Contains(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
            WhiteboardRepository.Remove(whiteboardToVerify);
            CollectionAssert.DoesNotContain(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        public void TWRepositoriesRemoveAllCreatedWhiteboardsOnTeamDeletionTest()
        {
            Team otherOwnerTeam = TeamRepository.AddNewTeam("New Team",
                "Ve Make good team", 45);
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarra 2112",
                "Una descripción válida.", otherOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                whiteboardToVerify);
            TeamRepository.Remove(otherOwnerTeam);
            CollectionAssert.DoesNotContain(WhiteboardRepository.Elements.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Maria Angélica",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Maria Angélica", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardSetSameDataValidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            var previousName = whiteboardToVerify.Name;
            var previousDescription = whiteboardToVerify.Description;
            var previousWidth = whiteboardToVerify.Width;
            var previousHeight = whiteboardToVerify.Height;
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, previousName,
                previousDescription, previousWidth, previousHeight);
            Assert.AreEqual(previousName, whiteboardToVerify.Name);
            Assert.AreEqual(previousDescription, whiteboardToVerify.Description);
            Assert.AreEqual(previousWidth, whiteboardToVerify.Width);
            Assert.AreEqual(previousHeight, whiteboardToVerify.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyNotAddedWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = Whiteboard.InstanceForTestingPurposes();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyNullWhiteboardValidTest()
        {
            WhiteboardRepository.ModifyWhiteboard(null, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidNameTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "3- *//*!!$#&1a@! ,.",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidDescriptionTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "   \n\n\n \t   \t    ", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidWidthTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", -2112, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidHeightTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyWhiteboardCausesSameNameAndTeamInvalidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Nombre único",
                "Una descripción válida.", testingOwnerTeam, 500, 700);
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Whiteboard",
                "Otra descripción.", 1200, 2400);
        }

        [TestMethod]
        public void WRepositoryAddWhiteboardDifferentTeamSameNameValidTest()
        {
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Whiteboard 99",
                "Valid description.", otherTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(), addedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardDifferentTeamSameNameValidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Algún otro pizarrón",
                "La descripción va aquí.", testingOwnerTeam, 500, 500);
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Indeed another whiteboard",
                "Another valid description.", 121, 323);
            Assert.AreEqual("Indeed another whiteboard", whiteboardToVerify.Name);
            Assert.AreEqual("Another valid description.", whiteboardToVerify.Description);
            Assert.AreEqual(121, whiteboardToVerify.Width);
            Assert.AreEqual(323, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardAsCreatorValidTest()
        {
            ChangeActiveUser("colpocorto@lesluthiers.com", "TrepoTemoTiemblo");
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Avant",
                "La descripción va aquí.", testingOwnerTeam, 500, 500);
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Garde",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Garde", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardAsAdministratorNotInTeamValidTest()
        {
            ChangeActiveUser("administrator@tf2.com", "Victory");
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Felisa",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Felisa", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyWhiteboardAsUserNotInTeamInvalidTest()
        {
            ChangeActiveUser("sanchez@sendero.com", "YoQueSe");
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UWRepositoryAttemptToRemoveWhiteboardCreatorUserInvalidTest()
        {
            User userToFailRemoving = User.CreateNewCollaborator("Giovanni", "Colpocorto",
                "colpocorto@lesluthiers.com", DateTime.Today, "TrepoTemoTiemblo");
            UserRepository.Remove(userToFailRemoving);
        }
    }
}