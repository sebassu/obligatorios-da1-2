using Domain;
using System;
using Exceptions;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TeamRepositoryTests
    {
        private static TeamRepository testingTeamRepository;

        [ClassInitialize]
        public static void ClassSetUp(TestContext context)
        {
            UserRepository testingUserRepository = UserRepository.GetInstance();
            if (!testingUserRepository.HasElements())
            {
                AddTestingUsers(testingUserRepository);
            }
        }

        private static void AddTestingUsers(UserRepository testingUserRepository)
        {
            testingUserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "password123");
        }

        [TestInitialize]
        public void TestSetUp()
        {
            testingTeamRepository = new TeamRepositoryInMemory();
            Session.End();
        }

        [TestMethod]
        public void TDirectoryAddNewTeamValidTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1",
                "Descripción de equipo.", 20);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(testingTeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TDirectoryAddNewTeamWithUserTest()
        {
            Session.Start("ravenna@simuladores.com", "password123");
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1",
                "Descripción de equipo.", 25);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TDirectoryAddExistingTeamTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.ActiveUser();
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo 2.", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryInvalidNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("1#4s!sd?", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNullNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam(null, "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryEmptyNameTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryEmptyDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("Equipo 2", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNullDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("Equipo 2", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryOnlySpacesDescriptionTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("Equipo 2", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryInvalidMembersTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNegativeMembersTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TDirectoryRemoveTeamValidTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser,
                "Equipo 1", "Desc.", 10);
            testingTeamRepository.AddNewTeam("Equipo 1", "Desc.", 10);
            testingTeamRepository.Remove(teamToVerify);
            CollectionAssert.DoesNotContain(testingTeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        public void UDirectoryGetInstanceTest()
        {
            testingTeamRepository = TeamRepository.GetInstance();
            TeamRepository anotherTeamRepository = TeamRepository.GetInstance();
            Assert.AreSame(testingTeamRepository, anotherTeamRepository);
        }
    }
}