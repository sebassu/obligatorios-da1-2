using Domain;
using System;
using Exceptions;
using System.Linq;
using Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    public class TeamDirectoryTests
    {
        private static TeamDirectory testingTeamDirectory;

        [ClassInitialize]
        public static void ClassSetUp(TestContext context)
        {
            UserDirectory testingUserDirectory = UserDirectory.GetInstance();
            testingUserDirectory.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "password123");
        }

        [TestInitialize]
        public void TestSetUp()
        {
            testingTeamDirectory = new TeamDirectoryInMemory();
            Session.Finalize();
        }

        [TestMethod]
        public void TDirectoryAddNewTeamValidTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.LoggedUser;
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1", "Descripción de equipo.", 20);
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(testingTeamDirectory.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException), 
        "El usuario no tiene los permisos para realizar la acción.")]
        public void TDirectoryAddNewTeamWithUserTest()
        {
            Session.Start("ravenna@simuladores.com", "password123");
            User aUser = Session.LoggedUser;
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1", "Descripción de equipo.", 25);
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException),
        "Ya existe un equipo registrado con ese nombre.")]
        public void TDirectoryAddExistingTeamTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.LoggedUser;
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo 2.", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryInvalidNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("1#4s!sd?", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryNullNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam(null, "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryEmptyNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryEmptyDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("Equipo 2", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryNullDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("Equipo 2", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryOnlySpacesDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("Equipo 2", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryInvalidMembersTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void TDirectoryNegativeMembersTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamDirectory.AddNewTeam("Equipo 1", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TDirectoryRemoveTeamValidTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.LoggedUser;
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser,"Equipo 1", "Desc.", 10);
            testingTeamDirectory.AddNewUser("Equipo 1", "Desc.", 10);
            testingTeamDirectory.Remove(teamToVerify);
            CollectionAssert.DoesNotContain(testingTeamDirectory.Elements.ToList(), teamToVerify);
        }
}
