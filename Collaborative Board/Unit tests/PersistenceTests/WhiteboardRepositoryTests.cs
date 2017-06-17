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

        [TestInitialize]
        public void TestSetup()
        {
            AddUserDataTest();
            AddTeamDataTest();
            AddTestingWhiteboardsAsRegularUser();
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
        }
        private void AddUserDataTest()
        {
            if (!UserRepository.HasElements())
            {
                UserRepository.InsertOriginalSystemAdministrator();
                ChangeActiveUser("administrator@tf2.com", "Victory");
                UserRepository.AddNewAdministrator("Mario", "Santos",
                    "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
                UserRepository.AddNewUser("Emilio", "Ravenna",
                    "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
                UserRepository.AddNewUser("Pablo", "Lamponne",
                    "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
                UserRepository.AddNewUser("Martín", "Vanegas",
                    "vanegas@brigadab.com", DateTime.Today, "tipoONegativo");
                UserRepository.AddNewUser("José", "Feller",
                    "feller@brigadab.com", DateTime.Today, "puntaPariñas");
            }
        }

        public void AddTeamDataTest()
        {
            if (!TeamRepository.HasElements())
            {
                ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
                AddNewTestingOwnerTeamInstance();
                TeamRepository.AddNewTeam("Brigada B", "Para casos menores, más sencillos.", 4);
            }
        }

        private static void AddNewTestingOwnerTeamInstance()
        {
            User userToAdd = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            testingOwnerTeam = TeamRepository.AddNewTeam("Los Simuladores", descriptionToSet, 4);
            TeamRepository.AddMemberToTeam(testingOwnerTeam, userToAdd);
        }

        private static void AddTestingWhiteboardsAsRegularUser()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
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

        private void RemoveAndUnsetTestingOwnerTeam()
        {
            TeamRepository.Remove(testingOwnerTeam);
            testingOwnerTeam = null;
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardValidTest()
        {
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                addedWhiteboard);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            WhiteboardRepository.RemoveAllWhiteboards();
            TeamRepository.RemoveAllTeams();
            UserRepository.RemoveAllUsers();
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardNonAdministratorValidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Some whiteboard",
                "Some valid description", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                addedWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidNameTest()
        {
            WhiteboardRepository.AddNewWhiteboard("84%!^#^ ! /*/*^#",
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
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarrón",
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
            Whiteboard NotAddedWhiteboard = Whiteboard.InstanceForTestingPurposes();
            WhiteboardRepository.Remove(NotAddedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryRemoveRemovedFromOwnerTeamTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
            WhiteboardRepository.Remove(whiteboardToVerify);
            CollectionAssert.DoesNotContain(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        public void TWRepositoriesRemoveAllCreatedWhiteboardsOnTeamDeletionTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(),
                whiteboardToVerify);
            RemoveAndUnsetTestingOwnerTeam();
            CollectionAssert.DoesNotContain(WhiteboardRepository.Elements.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Pizarrón", whiteboardToVerify.Name);
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
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "3- */!!$#&1a@! ,.",
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
            Team anotherOwnerTeam = TeamRepository.Elements.First();
            Whiteboard addedWhiteboard = WhiteboardRepository.AddNewWhiteboard("Whiteboard",
                "Valid description.", anotherOwnerTeam, 240, 240);
            CollectionAssert.Contains(WhiteboardRepository.Elements.ToList(), addedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardDifferentTeamSameNameValidTest()
        {
            Team anotherOwnerTeam = TeamRepository.Elements.First();
            Whiteboard whiteboardToVerify = WhiteboardRepository.AddNewWhiteboard("Algún otro pizarrón",
                "La descripción va aquí.", anotherOwnerTeam, 500, 500);
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Another whiteboard",
                "Another valid description.", 121, 323);
            Assert.AreEqual("Another whiteboard", whiteboardToVerify.Name);
            Assert.AreEqual("Another valid description.", whiteboardToVerify.Description);
            Assert.AreEqual(121, whiteboardToVerify.Width);
            Assert.AreEqual(323, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardAsCreatorValidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.Last();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Pizarrón", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardAsAdministratorNotInTeamValidTest()
        {
            ChangeActiveUser("administrator@tf2.com", "Victory");
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Pizarrón", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyWhiteboardAsUserNotInTeamInvalidTest()
        {
            ChangeActiveUser("vanegas@brigadab.com", "tipoONegativo");
            Whiteboard whiteboardToVerify = WhiteboardRepository.Elements.First();
            WhiteboardRepository.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UWRepositoryAttemptToRemoveWhiteboardCreatorUserInvalidTest()
        {
            User userToFailRemoving = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            UserRepository.Remove(userToFailRemoving);
        }
    }
}