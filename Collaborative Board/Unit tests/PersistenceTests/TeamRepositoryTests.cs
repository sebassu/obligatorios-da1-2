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
    public class TeamRepositoryTests
    {
        private static TeamRepository testingTeamRepository;

        [TestInitialize]
        public void TestSetUp()
        {
            testingTeamRepository = new TeamRepositoryInMemory();
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            Session.End();
        }

        [TestMethod]
        public void TDirectoryAddNewTeamValidTest()
        {
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1",
                "Descripción de equipo.", 20);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(testingTeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TDirectoryAddNewTeamNotEnoughPrivilegesInvalidTest()
        {
            Session.End();
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
            User aUser = Session.ActiveUser();
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo 2.", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryInvalidNameTest()
        {
            testingTeamRepository.AddNewTeam("1#4s!sd?", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNullNameTest()
        {
            testingTeamRepository.AddNewTeam(null, "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryEmptyNameTest()
        {
            testingTeamRepository.AddNewTeam("", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryEmptyDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNullDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryOnlySpacesDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryInvalidMembersTest()
        {

            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TDirectoryNegativeMembersTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TDirectoryRemoveTeamValidTest()
        {
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