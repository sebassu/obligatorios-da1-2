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
        [TestInitialize]
        public void ClassSetup()
        {
            AddUserDataTest();
            AddTeamDataTest();
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
                string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
                TeamRepository.AddNewTeam("Los Simuladores", descriptionToSet, 4);
            }
        }

        private void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            UserRepository.RemoveAllUsers();
            TeamRepository.RemoveAllTeams();
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
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddExistingTeamTest()
        {
            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 25);
            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo 2.", 30);
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
            TeamRepository.AddNewTeam("Equipo 2", "", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNullDescriptionTest()
        {
            TeamRepository.AddNewTeam("Equipo 2", null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryOnlySpacesDescriptionTest()
        {
            TeamRepository.AddNewTeam("Equipo 2", "            ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryInvalidMembersTest()
        {

            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryNegativeMembersTest()
        {
            TeamRepository.AddNewTeam("Equipo 1", "Descripción de equipo.", -1);
        }

        [TestMethod]
        public void TRepositoryRemoveTeamValidTest()
        {
            User aUser = Session.ActiveUser();
            Team teamToVerify = Team.CreatorNameDescriptionMaximumMembers(aUser,
                "Equipo 1", "Desc.", 10);
            TeamRepository.AddNewTeam("Equipo 1", "Desc.", 10);
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
            TeamRepository.ModifyTeam(null, "The A Team", "Crack Commando Unit.", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyNotAddedTeamInvalidTest()
        {
            Team NotAddedTeam = Team.InstanceForTestingPurposes();
            TeamRepository.ModifyTeam(NotAddedTeam, "The A Team", "Crack Commando Unit.", 4);
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
            TeamRepository.ModifyTeam(addedTeam, "The A Team", "  \n \t ", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryModifyTeamInvalidMaximumMembersTest()
        {
            Team addedTeam = TeamRepository.Elements.Single();
            TeamRepository.ModifyTeam(addedTeam, "The A Team", "Crack Commando Unit.", -2112);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyTeamCausesRepeatedNameInvalidTest()
        {
            Team addedTeam = TeamRepository.AddNewTeam("The A Team", "Crack Commando Unit.", 4);
            TeamRepository.ModifyTeam(addedTeam, "Los Simuladores", "Otra descripción.", 115);
        }

        [TestMethod]
        public void TRepositoryAddMemberValidTest()
        {
            User userToAdd = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            Team teamToAddTo = TeamRepository.Elements.Single();
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
            CollectionAssert.Contains(teamToAddTo.Members.ToList(), userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddMemberToNotAddedTeamTest()
        {
            User userToAdd = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            Team teamToAddTo = Team.InstanceForTestingPurposes();
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TRepositoryAddRepeatedMemberTest()
        {
            User repeatedUser = User.CreateNewAdministrator("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
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
            User userToAdd = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            Team teamToAddTo = TeamRepository.Elements.Single();
            teamToAddTo.MaximumMembers = 1;
            TeamRepository.AddMemberToTeam(teamToAddTo, userToAdd);
        }

        [TestMethod]
        public void TRepositoryRemoveMemberValidTest()
        {
            User userToRemove = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
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
            User onlyMember = User.CreateNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            Team teamToRemoveFrom = TeamRepository.Elements.Single();
            TeamRepository.RemoveMemberFromTeam(teamToRemoveFrom, onlyMember);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UTRepositoryRemoveLastMemberWhenRemovingUserInvalidTest()
        {
            User onlyMember = User.CreateNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
            string descriptionToSet = "Una estupidez de Videomatch.";
            TeamRepository.AddNewTeam("Los Disimuladores", descriptionToSet, 4);
            UserRepository.Remove(onlyMember);
        }

        [TestMethod]
        public void UTRepositoryRemoveMemberWhenRemovingUserValidTest()
        {
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
            string descriptionToSet = "Ha sido catalogado con triple X.";
            Team teamToVerify = TeamRepository.AddNewTeam("Equipo X", descriptionToSet, 5);
            User memberToAddAndRemove = User.CreateNewCollaborator("José", "Feller",
                "feller@brigadab.com", DateTime.Today, "puntaPariñas");
            TeamRepository.AddMemberToTeam(teamToVerify, memberToAddAndRemove);
            UserRepository.Remove(memberToAddAndRemove);
            CollectionAssert.DoesNotContain(teamToVerify.Members.ToList(), memberToAddAndRemove);
        }
    }
}