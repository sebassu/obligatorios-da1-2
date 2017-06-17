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
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            AddUserDataTest();
            AddTeamDataTest();
        }

        private static void AddUserDataTest()
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            UserRepository.AddNewAdministrator("Marcos", "Mundstock",
                "mundstock@lesluthiers.com.ar", DateTime.Today, "versiculoLIX");
            UserRepository.AddNewUser("Jorge Luis", "Maronna",
                "maronna@lesluthiers.com.ar", DateTime.Today, "laNocheEstabaOscura");
            UserRepository.AddNewUser("Carlos Nuñez", "Cortes",
                "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            UserRepository.AddNewUser("Daniel Abraham", "Rabinovich",
                "rabinovich@lesluthiers.com.ar", DateTime.Today, "achicoria");
            UserRepository.AddNewUser("Carlos", "Lopez Puccio",
                "lopezpuccio@lesluthiers.com.ar", DateTime.Today, "horizontal4Letras");
        }

        public static void AddTeamDataTest()
        {
            ChangeActiveUser("mundstock@lesluthiers.com.ar", "versiculoLIX");
            string descriptionToSet = "Grupo de seguidores de Johann Sebastian Maestropiero.";
            TeamRepository.AddNewTeam("Les Luthiers", descriptionToSet, 5);
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("mundstock@lesluthiers.com.ar", "versiculoLIX");
        }

        [TestMethod]
        public void TRepositoryAddNewTeamValidTest()
        {
            User aUser = Session.ActiveUser();
           Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser, "Equipo 1",
                "Descripción de equipo.", 20);
            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(TeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddNewTeamNotEnoughPrivilegesInvalidTest()
        {
            ChangeActiveUser("rabinovich@lesluthiers.com.ar", "achicoria");
            TeamRepository.AddNewTeam("Equipo 2", "Descripción de equipo.", 25);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddExistingTeamTest()
        {
            TeamRepository.AddNewTeam("Equipo 3", "Descripción de equipo.", 25);
            TeamRepository.AddNewTeam("Equipo 3", "Descripción de equipo 2.", 30);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryInvalidNameTest()
        {
            TeamRepository.AddNewTeam("1#4s!sd?", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNullNameTest()
        {
            TeamRepository.AddNewTeam(null, "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryEmptyNameTest()
        {
            TeamRepository.AddNewTeam("", "Descripción de equipo.", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryEmptyDescriptionTest()
        {
            TeamRepository.AddNewTeam("Equipo 4", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNullDescriptionTest()
        {
            TeamRepository.AddNewTeam("Equipo 5", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryOnlySpacesDescriptionTest()
        {
            TeamRepository.AddNewTeam("Equipo 6", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryInvalidMembersTest()
        {

            TeamRepository.AddNewTeam("Equipo 7", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNegativeMembersTest()
        {
            TeamRepository.AddNewTeam("Equipo 8", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TRepositoryRemoveTeamValidTest()
        {
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser,
                "Equipo 9", "Desc.", 10);
            TeamRepository.AddNewTeam("Equipo 9", "Desc.", 10);
            TeamRepository.Remove(teamToVerify);
            CollectionAssert.DoesNotContain(TeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveNotAddedTeamInvalidTest()
        {
            Team NotAddedTeam = Team.InstanceForTestingPurposes();
            TeamRepository.Remove(NotAddedTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveNullTeamInvalidTest()
        {
            TeamRepository.Remove(null);
        }

        [TestMethod]
        public void TRepositoryModifyTeamValidTest()
        {
            Team teamToVerify = TeamRepository.Elements.Single();
            var membersBeforeModification = teamToVerify.Members.ToList();
            TeamRepository.ModifyTeam(teamToVerify, "The A Team", "Crack Commando Unit.", 4);
            CollectionAssert.AreEqual(membersBeforeModification, teamToVerify.Members.ToList());
            Assert.AreEqual("The A Team", teamToVerify.Name);
            Assert.AreEqual("Crack Commando Unit.", teamToVerify.Description);
            Assert.AreEqual(4, teamToVerify.MaximumMembers);
        }

        [TestMethod]
        public void TRepositoryModifyTeamSetSameDataValidTest()
        {
            Team teamToVerify = TeamRepository.Elements.Single();
            var previousName = teamToVerify.Name;
            var previousDescription = teamToVerify.Description;
            var previousMaximumMembers = teamToVerify.MaximumMembers;
            TeamRepository.ModifyTeam(teamToVerify, previousName,
                previousDescription, previousMaximumMembers);
            Assert.AreEqual(previousName, teamToVerify.Name);
            Assert.AreEqual(previousDescription, teamToVerify.Description);
            Assert.AreEqual(previousMaximumMembers, teamToVerify.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyNullTeamInvalidTest()
        {
            TeamRepository.ModifyTeam(null, "A Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyNotAddedTeamInvalidTest()
        {
            Team NotAddedTeam = Team.InstanceForTestingPurposes();
            TeamRepository.ModifyTeam(NotAddedTeam, "Ultimate Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidNameTest()
        {
            Team addedTeam = TeamRepository.Elements.Single();
            TeamRepository.ModifyTeam(addedTeam, "#1&*$ 565*a -^$^&", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidDescriptionTest()
        {
            Team addedTeam = TeamRepository.Elements.Single();
            TeamRepository.ModifyTeam(addedTeam, "C Team", "  \n \t ", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidMaximumMembersTest()
        {
            Team addedTeam = TeamRepository.Elements.Single();
            TeamRepository.ModifyTeam(addedTeam, "D Team", "Crack Commando Unit.", -2112);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyTeamCausesRepeatedNameInvalidTest()
        {
            Team addedTeam = TeamRepository.AddNewTeam("E Team", "Crack Commando Unit.", 4);
            TeamRepository.ModifyTeam(addedTeam, "Another Team", "Otra descripción.", 115);
        }

        [TestMethod]
        public void TRepositoryAddMemberValidTest()
        {
            User userToAdd = User.CreateNewCollaborator("Carlos Nuñez", "Cortes",
                    "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            Team teamToAddTo = TeamRepository.Elements.Single();
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
            CollectionAssert.Contains(teamToAddTo.Members.ToList(), userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddMemberToNotAddedTeamTest()
        {
            User userToAdd = User.CreateNewCollaborator("Carlos Nuñez", "Cortes",
                    "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            Team teamToAddTo = Team.InstanceForTestingPurposes();
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddRepeatedMemberTest()
        {//ACAAAAAAAAAAAAAAAAAAAAAAAA
            User repeatedUser = User.CreateNewAdministrator("Marcos", "Mundstock",
                    "otromundstock@lesluthiers.com.ar", DateTime.Today, "versiculoLIX");
            Team teamToAddTo = TeamRepository.Elements.Single();
            TeamRepository.AddMemberToTeam(teamToAddTo, repeatedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddNullMemberTest()
        {
            Team teamToAddTo = TeamRepository.Elements.Single();
            TeamRepository.AddMemberToTeam(teamToAddTo, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddMoreThanMaximumMembersTest()
        {
            User userToAdd = User.CreateNewCollaborator("Carlos Nuñez", "Cortes",
                    "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            Team teamToAddTo = TeamRepository.Elements.Single();
            teamToAddTo.MaximumMembers = 1;
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        public void TRepositoryRemoveMemberValidTest()
        {
            User userToRemove = User.CreateNewCollaborator("Carlos Nuñez", "Cortes",
                    "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            Team teamToRemoveFrom = TeamRepository.Elements.Single();
            TeamRepository.AddMemberToTeam(teamToRemoveFrom, userToRemove);
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, userToRemove);
            CollectionAssert.DoesNotContain(teamToRemoveFrom.Members.ToList(), userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveMemberFromNotAddedTeamInvalidTest()
        {
            User userToRemove = User.InstanceForTestingPurposes();
            Team teamToRemoveFrom = Team.InstanceForTestingPurposes();
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveMemberFromNullTeamInvalidTest()
        {
            User userToRemove = User.InstanceForTestingPurposes();
            TeamRepository.RemoveMemberFromTeam(null, userToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryRemoveNullMemberInvalidTest()
        {
            Team teamToRemoveFrom = TeamRepository.Elements.Single();
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryRemoveLastMemberInvalidTest()
        {
            User onlyMember = User.CreateNewAdministrator("Marcos", "Mundstock",
                    "dosmundstock@lesluthiers.com.ar", DateTime.Today, "versiculoLIX");
            Team teamToRemoveFrom = TeamRepository.Elements.Single();
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, onlyMember);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UTRepositoryRemoveLastMemberWhenRemovingUserInvalidTest()
        {
            User onlyMember = User.CreateNewAdministrator("Marcos", "Mundstock",
                    "tresmundstock@lesluthiers.com.ar", DateTime.Today, "versiculoLIX");
            ChangeActiveUser("tresmundstock@lesluthiers.com.ar", "versiculoLIX");
            string descriptionToSet = "Falsos luthiers descripción.";
            TeamRepository.AddNewTeam("Falsos Luthiers", descriptionToSet, 4);
            UserRepository.Remove(onlyMember);
        }

        [TestMethod]
        public void UTRepositoryRemoveMemberWhenRemovingUserValidTest()
        {
            ChangeActiveUser("mundstock@lesluthiers.com.ar", "versiculoLIX");
            string descriptionToSet = "Ha sido catalogado con triple Y.";
            Team teamToVerify = TeamRepository.AddNewTeam("Equipo Y", descriptionToSet, 5);
            User memberToAddAndRemove = User.CreateNewCollaborator("Jorge Luis", "Maronna",
                    "maronna@lesluthiers.com.ar", DateTime.Today, "laNocheEstabaOscura");
            TeamRepository.AddMemberToTeam(teamToVerify, memberToAddAndRemove);
            UserRepository.Remove(memberToAddAndRemove);
            CollectionAssert.DoesNotContain(teamToVerify.Members.ToList(), memberToAddAndRemove);
        }
    }
}