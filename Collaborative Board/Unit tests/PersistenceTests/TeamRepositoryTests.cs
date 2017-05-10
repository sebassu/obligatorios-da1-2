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
    public class TeamRepositoryTests
    {
        private static TeamRepository testingTeamRepository;
        private static UserRepository globalUsers;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            globalUsers = UserRepository.GetInstance();
            globalUsers.AddNewUser(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");

        }

        [TestInitialize]
        public void TestSetup()
        {
            testingTeamRepository = new TeamRepositoryInMemory();
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            testingTeamRepository.AddNewTeam("Los Simuladores", descriptionToSet, 4);
        }

        [ClassCleanup]
        public static void ClassTeardown()
        {
            Session.End();
        }

        [TestMethod]
        public void TRepositoryAddNewTeamValidTest()
        {
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1",
                "Descripción de equipo.", 20);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(testingTeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddNewTeamNotEnoughPrivilegesInvalidTest()
        {
            Session.End();
            Session.Start("ravenna@simuladores.com", "password123");
            User aUser = Session.ActiveUser();
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddExistingTeamTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo 2.", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryInvalidNameTest()
        {
            testingTeamRepository.AddNewTeam("1#4s!sd?", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNullNameTest()
        {
            testingTeamRepository.AddNewTeam(null, "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryEmptyNameTest()
        {
            testingTeamRepository.AddNewTeam("", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryEmptyDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNullDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryOnlySpacesDescriptionTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 2", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryInvalidMembersTest()
        {

            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNegativeMembersTest()
        {
            testingTeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TRepositoryRemoveTeamValidTest()
        {
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser,
                "Equipo 1", "Desc.", 10);
            testingTeamRepository.AddNewTeam("Equipo 1", "Desc.", 10);
            testingTeamRepository.Remove(teamToVerify);
            CollectionAssert.DoesNotContain(testingTeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveUnaddedTeamInvalidTest()
        {
            Team unaddedTeam = Team.InstanceForTestingPurposes();
            testingTeamRepository.Remove(unaddedTeam);
        }

        [TestMethod]
        public void UDirectoryGetInstanceTest()
        {
            testingTeamRepository = TeamRepository.GetInstance();
            TeamRepository anotherTeamRepository = TeamRepository.GetInstance();
            Assert.AreSame(testingTeamRepository, anotherTeamRepository);
        }

        [TestMethod]
        public void TRepositoryModifyTeamValidTest()
        {
            Team teamToVerify = testingTeamRepository.Elements.Single();
            var membersBeforeModification = teamToVerify.Members.ToList();
            testingTeamRepository.ModifyTeam(teamToVerify, "The A Team", "Crack Commando Unit.", 4);
            CollectionAssert.AreEqual(membersBeforeModification, teamToVerify.Members.ToList());
            Assert.AreEqual("The A Team", teamToVerify.Name);
            Assert.AreEqual("Crack Commando Unit.", teamToVerify.Description);
            Assert.AreEqual(4, teamToVerify.MaximumMembers);
        }

        [TestMethod]
        public void TRepositoryModifyTeamSetSameDataValidTest()
        {
            Team teamToVerify = testingTeamRepository.Elements.Single();
            var previousName = teamToVerify.Name;
            var previousDescription = teamToVerify.Description;
            var previousMaximumMembers = teamToVerify.MaximumMembers;
            testingTeamRepository.ModifyTeam(teamToVerify, previousName,
                previousDescription, previousMaximumMembers);
            Assert.AreEqual(previousName, teamToVerify.Name);
            Assert.AreEqual(previousDescription, teamToVerify.Description);
            Assert.AreEqual(previousMaximumMembers, teamToVerify.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyNullTeamInvalidTest()
        {
            testingTeamRepository.ModifyTeam(null, "The A Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyUnaddedTeamInvalidTest()
        {
            Team unaddedTeam = Team.InstanceForTestingPurposes();
            testingTeamRepository.ModifyTeam(unaddedTeam, "The A Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidNameTest()
        {
            Team addedTeam = testingTeamRepository.Elements.Single();
            testingTeamRepository.ModifyTeam(addedTeam, "#1&*$ 565*a -^$^&", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidDescriptionTest()
        {
            User userToAdd = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team addedTeam = testingTeamRepository.Elements.Single();
            testingTeamRepository.ModifyTeam(addedTeam, "The A Team", "         \n \t ", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidMaximumMembersTest()
        {
            Team addedTeam = testingTeamRepository.Elements.Single();
            testingTeamRepository.ModifyTeam(addedTeam, "The A Team", "Crack Commando Unit.", -2112);
        }

        [TestMethod]
        public void TRepositoryAddMemberValidTest()
        {
            User userToAdd = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToAddTo = testingTeamRepository.Elements.Single();
            testingTeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
            CollectionAssert.Contains(teamToAddTo.Members.ToList(), userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddMemberToUnaddedTeamTest()
        {
            User userToAdd = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToAddTo = Team.InstanceForTestingPurposes();
            testingTeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddRepeatedMemberTest()
        {
            Administrator repeatedUser = Administrator.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToAddTo = testingTeamRepository.Elements.Single();
            testingTeamRepository.AddMemberToTeam(teamToAddTo, repeatedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddNullMemberTest()
        {
            Team teamToAddTo = testingTeamRepository.Elements.Single();
            testingTeamRepository.AddMemberToTeam(teamToAddTo, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddMoreThanMaximumMembersTest()
        {
            User userToAdd = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToAddTo = testingTeamRepository.Elements.Single();
            teamToAddTo.MaximumMembers = 1;
            testingTeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        public void TRepositoryRemoveMemberValidTest()
        {
            User userToRemove = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToRemoveFrom = testingTeamRepository.Elements.Single();
            testingTeamRepository.AddMemberToTeam(teamToRemoveFrom, userToRemove);
            testingTeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, userToRemove);
            CollectionAssert.DoesNotContain(teamToRemoveFrom.Members.ToList(), userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveMemberFromUnaddedTeamInvalidTest()
        {
            User userToRemove = User.InstanceForTestingPurposes();
            Team teamToRemoveFrom = Team.InstanceForTestingPurposes();
            testingTeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveMemberFromNullTeamInvalidTest()
        {
            User userToRemove = User.InstanceForTestingPurposes();
            testingTeamRepository.RemoveMemberFromTeam(null, userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryRemoveNullMemberInvalidTest()
        {
            Team teamToRemoveFrom = testingTeamRepository.Elements.Single();
            testingTeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryRemoveLastMemberInvalidTest()
        {
            Administrator onlyMember = Administrator.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            Team teamToRemoveFrom = testingTeamRepository.Elements.Single();
            testingTeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, onlyMember);
        }
    }
}