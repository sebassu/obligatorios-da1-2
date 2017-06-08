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
        private static TeamRepository globalTeams;
        private static WhiteboardRepository globalWhiteboards;
        private static Team testingOwnerTeam;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
            globalTeams = TeamRepository.GetInstance();
            globalTeams.AddNewTeam("Brigada B",
                "Para casos menores, más sencillos.", 4);
        }

        [TestInitialize]
        public void TestSetup()
        {
            AttemptToResetTestingOwnerTeam();
            AddTestingWhiteboardsAsRegularUser();
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
        }

        private static void AttemptToResetTestingOwnerTeam()
        {
            ResetTestingOwnerTeam();
        }

        private static void ResetTestingOwnerTeam()
        {
            if (Utilities.IsNotNull(testingOwnerTeam))
            {
                RemoveAndUnsetTestingOwnerTeam();
            }
            AddNewInstanceOfRemovedTeam();
        }

        private static void RemoveAndUnsetTestingOwnerTeam()
        {
            globalTeams.Remove(testingOwnerTeam);
            testingOwnerTeam = null;
        }

        private static void AddNewInstanceOfRemovedTeam()
        {
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
            User userToAdd = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            testingOwnerTeam = globalTeams.AddNewTeam("Los Simuladores", descriptionToSet, 4);
            globalTeams.AddMemberToTeam(testingOwnerTeam, userToAdd);
        }

        private static void AddTestingWhiteboardsAsRegularUser()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            globalWhiteboards = WhiteboardRepository.GetInstance();
            globalWhiteboards.AddNewWhiteboard("Whiteboard",
                "Valid description.", testingOwnerTeam, 240, 240);
            globalWhiteboards.AddNewWhiteboard("Another whiteboard",
                "Another valid description.", testingOwnerTeam, 121, 323);
        }
        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestMethod]
        public void URepositoryGetInstanceTest()
        {
            globalWhiteboards = WhiteboardRepository.GetInstance();
            WhiteboardRepository anotherWhiteboardRepository = WhiteboardRepository.GetInstance();
            Assert.AreSame(globalWhiteboards, anotherWhiteboardRepository);
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardValidTest()
        {
            Whiteboard addedWhiteboard = globalWhiteboards.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(globalWhiteboards.Elements.ToList(),
                addedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryAddNewWhiteboardNonAdministratorValidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            Whiteboard addedWhiteboard = globalWhiteboards.AddNewWhiteboard("Some whiteboard",
                "Some valid description", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(globalWhiteboards.Elements.ToList(),
                addedWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidNameTest()
        {
            globalWhiteboards.AddNewWhiteboard("84%!^#^ ! /*/*^#",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidDescriptionTest()
        {
            globalWhiteboards.AddNewWhiteboard("Pizarrón", "  \n \t\t\n ",
                testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidWidthTest()
        {
            globalWhiteboards.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, -2112, 240);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardInvalidHeightTest()
        {
            globalWhiteboards.AddNewWhiteboard("Pizarrón", "Una descripción válida.",
                testingOwnerTeam, 240, -300);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryAddNewWhiteboardPrivilegedCreatorNotInTeamInvalidTest()
        {
            ChangeActiveUser("administrator@tf2.com", "Victory");
            globalWhiteboards.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
        }

        [TestMethod]
        public void WRepositoryRemoveWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            globalWhiteboards.Remove(whiteboardToVerify);
            CollectionAssert.DoesNotContain(globalWhiteboards.Elements.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryRemoveUnregisteredWhiteboardInvalidTest()
        {
            Whiteboard whiteboardToFailRemoving = Whiteboard.InstanceForTestingPurposes();
            globalWhiteboards.Remove(whiteboardToFailRemoving);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryRemoveNullUserInvalidTest()
        {
            globalWhiteboards.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInDirectoryInvalidTest()
        {
            Whiteboard NotAddedWhiteboard = Whiteboard.InstanceForTestingPurposes();
            globalWhiteboards.Remove(NotAddedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryRemoveRemovedFromOwnerTeamTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
            globalWhiteboards.Remove(whiteboardToVerify);
            CollectionAssert.DoesNotContain(testingOwnerTeam.CreatedWhiteboards.ToList(),
                whiteboardToVerify);
        }

        [TestMethod]
        public void TWRepositoriesRemoveAllCreatedWhiteboardsOnTeamDeletionTest()
        {
            globalWhiteboards = WhiteboardRepository.GetInstance();
            Whiteboard whiteboardToVerify = globalWhiteboards.AddNewWhiteboard("Pizarrón",
                "Una descripción válida.", testingOwnerTeam, 240, 240);
            CollectionAssert.Contains(globalWhiteboards.Elements.ToList(),
                whiteboardToVerify);
            RemoveAndUnsetTestingOwnerTeam();
            CollectionAssert.DoesNotContain(globalWhiteboards.Elements.ToList(),
                whiteboardToVerify);
        }


        [TestMethod]
        public void WRepositoryModifyWhiteboardValidTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
            Assert.AreEqual("Pizarrón", whiteboardToVerify.Name);
            Assert.AreEqual("Una descripción válida.", whiteboardToVerify.Description);
            Assert.AreEqual(500, whiteboardToVerify.Width);
            Assert.AreEqual(700, whiteboardToVerify.Height);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardSetSameDataValidTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            var previousName = whiteboardToVerify.Name;
            var previousDescription = whiteboardToVerify.Description;
            var previousWidth = whiteboardToVerify.Width;
            var previousHeight = whiteboardToVerify.Height;
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, previousName,
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
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyNullWhiteboardValidTest()
        {
            globalWhiteboards.ModifyWhiteboard(null, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidNameTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "3- */!!$#&1a@! ,.",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidDescriptionTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "   \n\n\n \t   \t    ", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidWidthTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", -2112, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WRepositoryModifyWhiteboardInvalidHeightTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void WRepositoryModifyWhiteboardCausesSameNameAndTeamInvalidTest()
        {
            Whiteboard whiteboardToVerify = globalWhiteboards.AddNewWhiteboard("Nombre único",
                "Una descripción válida.", testingOwnerTeam, 500, 700);
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Whiteboard",
                "Otra descripción.", 1200, 2400);
        }

        [TestMethod]
        public void WRepositoryAddWhiteboardDifferentTeamSameNameValidTest()
        {
            Team anotherOwnerTeam = globalTeams.Elements.First();
            Whiteboard addedWhiteboard = globalWhiteboards.AddNewWhiteboard("Whiteboard",
                "Valid description.", anotherOwnerTeam, 240, 240);
            CollectionAssert.Contains(globalWhiteboards.Elements.ToList(), addedWhiteboard);
        }

        [TestMethod]
        public void WRepositoryModifyWhiteboardDifferentTeamSameNameValidTest()
        {
            Team anotherOwnerTeam = globalTeams.Elements.First();
            Whiteboard whiteboardToVerify = globalWhiteboards.AddNewWhiteboard("Algún otro pizarrón",
                "La descripción va aquí.", anotherOwnerTeam, 500, 500);
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Another whiteboard",
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
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.Last();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
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
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
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
            Whiteboard whiteboardToVerify = globalWhiteboards.Elements.First();
            globalWhiteboards.ModifyWhiteboard(whiteboardToVerify, "Pizarrón",
                "Una descripción válida.", 500, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UWRepositoryAttemptToRemoveWhiteboardCreatorUserInvalidTest()
        {
            User userToFailRemoving = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            UserRepository.GetInstance().Remove(userToFailRemoving);
        }
    }
}