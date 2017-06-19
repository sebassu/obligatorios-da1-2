using System;
using Domain;
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
        private static User mundstock;
        private static User cortes;
        private static User maronna;
        private static User rabinovich;

        private static Team lesLuthiers;

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
            mundstock = UserRepository.AddNewAdministrator("Marcos", "Mundstock",
                "mundstock@lesluthiers.com.ar", DateTime.Today, "versiculoLIX");
            maronna = UserRepository.AddNewUser("Jorge Luis", "Maronna",
                "maronna@lesluthiers.com.ar", DateTime.Today, "laNocheEstabaOscura");
            cortes = UserRepository.AddNewUser("Carlos Nuñez", "Cortes",
                "cortes@lesluthiers.com.ar", DateTime.Today, "YoEraUnInfeliz");
            rabinovich = UserRepository.AddNewUser("Daniel Abraham", "Rabinovich",
                "rabinovich@lesluthiers.com.ar", DateTime.Today, "achicoria");
            UserRepository.AddNewUser("Carlos", "Lopez Puccio",
                "lopezpuccio@lesluthiers.com.ar", DateTime.Today, "horizontal4Letras");
        }

        public static void AddTeamDataTest()
        {
            ChangeActiveUser("mundstock@lesluthiers.com.ar", "versiculoLIX");
            string descriptionToSet = "Grupo de seguidores de Johann Sebastian Mastropiero.";
            lesLuthiers = TeamRepository.AddNewTeam("Les Luthiers", descriptionToSet, 19);
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
            User someUser = Session.ActiveUser();
            Team teamToVerify = TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 20);
            CollectionAssert.Contains(TeamRepository.Elements.ToList(), teamToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
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
            Team teamToVerify = TeamRepository.AddNewTeam("Equipo 9", "Desc.", 12);
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
            Team teamToVerify = TeamRepository.Elements.First();
            TeamRepository.LoadMembers(teamToVerify);
            var membersBeforeModification = teamToVerify.Members.ToList();
            TeamRepository.ModifyTeam(teamToVerify, "The A Team", "Crack Commando Unit.", 8);
            CollectionAssert.AreEqual(membersBeforeModification, teamToVerify.Members.ToList());
            Assert.AreEqual("The A Team", teamToVerify.Name);
            Assert.AreEqual("Crack Commando Unit.", teamToVerify.Description);
            Assert.AreEqual(8, teamToVerify.MaximumMembers);
        }

        [TestMethod]
        public void TRepositoryModifyTeamSetSameDataValidTest()
        {
            Team teamToVerify = TeamRepository.Elements.First();
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
            Team notAddedTeam = Team.InstanceForTestingPurposes();
            TeamRepository.ModifyTeam(notAddedTeam, "Ultimate Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidNameTest()
        {
            Team addedTeam = TeamRepository.Elements.First();
            TeamRepository.ModifyTeam(addedTeam, "#1&*$ 565*a -^$^&", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidDescriptionTest()
        {
            Team addedTeam = TeamRepository.Elements.First();
            TeamRepository.ModifyTeam(addedTeam, "C Team", "  \n \t ", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidMaximumMembersTest()
        {
            Team addedTeam = TeamRepository.Elements.First();
            TeamRepository.ModifyTeam(addedTeam, "D Team", "Crack Commando Unit.", -2112);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyTeamCausesRepeatedNameInvalidTest()
        {
            TeamRepository.AddNewTeam("Another Team", "Some description.", 9);
            Team addedTeam = TeamRepository.AddNewTeam("E Team", "Crack Commando Unit.", 4);
            TeamRepository.ModifyTeam(addedTeam, "Another Team", "Otra descripción.", 115);
        }

        [TestMethod]
        public void TRepositoryAddMemberValidTest()
        {
            Team teamToAddTo = TeamRepository.Elements.First();
            TeamRepository.AddMemberToTeam(teamToAddTo, rabinovich);
            CollectionAssert.Contains(teamToAddTo.Members.ToList(), rabinovich);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddMemberToNotAddedTeamTest()
        {
            Team teamToAddTo = Team.InstanceForTestingPurposes();
            TeamRepository.AddMemberToTeam(teamToAddTo, cortes);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddRepeatedMemberTest()
        {
            TeamRepository.AddMemberToTeam(lesLuthiers, mundstock);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddNullMemberTest()
        {
            Team teamToAddTo = TeamRepository.Elements.First();
            TeamRepository.AddMemberToTeam(teamToAddTo, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddMoreThanMaximumMembersTest()
        {
            Team teamToAddTo = TeamRepository.AddNewTeam("Equipo Rocket",
                "Meowth", 1);
            TeamRepository.AddMemberToTeam(teamToAddTo, cortes);
        }

        [TestMethod]
        public void TRepositoryRemoveMemberValidTest()
        {
            Team teamToRemoveFrom = TeamRepository.Elements.First();
            TeamRepository.AddMemberToTeam(teamToRemoveFrom, cortes);
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, cortes);
            CollectionAssert.DoesNotContain(teamToRemoveFrom.Members.ToList(), cortes);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryRemoveMemberFromNotAddedTeamInvalidTest()
        {
            User userToRemove = User.InstanceForTestingPurposes();
            Team teamToRemoveFrom = Team.InstanceForTestingPurposes();
            teamToRemoveFrom.AddMember(userToRemove);
            teamToRemoveFrom.AddMember(rabinovich);
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
            Team teamToRemoveFrom = TeamRepository.Elements.First();
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryRemoveLastMemberInvalidTest()
        {
            Team teamToRemoveFrom = TeamRepository.AddNewTeam("Natascha", "Sandvich", 2);
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, mundstock);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UTRepositoryRemoveLastMemberWhenRemovingUserInvalidTest()
        {
            User onlyMember = UserRepository.AddNewAdministrator("Marcos", "Mundstock",
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
            TeamRepository.AddMemberToTeam(teamToVerify, maronna);
            UserRepository.Remove(maronna);
            CollectionAssert.DoesNotContain(teamToVerify.Members.ToList(), maronna);
        }
    }
}