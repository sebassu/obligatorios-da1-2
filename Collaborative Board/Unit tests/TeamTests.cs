using Domain;
using System;
using Exceptions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TeamTests
    {
        private static Team testingTeam;

        [TestInitialize]
        public void TestSetUp()
        {
            testingTeam = Team.TeamForTestingPurposes();
        }

        [TestMethod]
        public void TeamForTestingPurposesTest()
        {
            Assert.AreEqual("Nombre inválido.", testingTeam.Name);
            Assert.AreEqual("Descripción inválida.", testingTeam.Description);
            Assert.AreEqual(0, testingTeam.MaximumMembers);
        }

        [TestMethod]
        public void TeamSetValidNameTest()
        {
            testingTeam.Name = "Equipo1";
            Assert.AreEqual("Equipo1", testingTeam.Name);
        }

        [TestMethod]
        public void TeamSetValidNameTest2()
        {
            testingTeam.Name = "EquipoNuevo";
            Assert.AreEqual("EquipoNuevo", testingTeam.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNamePunctuationTest()
        {
            testingTeam.Name = "Equipo.#/!";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNameEmptyTest()
        {
            testingTeam.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNameNullTest()
        {
            testingTeam.Name = null;
        }

        [TestMethod]
        public void TeamValidCreationDateTest()
        {
            Assert.AreEqual(DateTime.Today, testingTeam.CreationDate.Date);
        }

        [TestMethod]
        public void TeamSetValidDescriptionTest()
        {
            testingTeam.Description = "Esto es una breve descripción del equipo.";
            Assert.AreEqual("Esto es una breve descripción del equipo.", testingTeam.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidDescriptionEmptyTest()
        {
            testingTeam.Description = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidDescriptionNullTest()
        {
            testingTeam.Description = null;
        }

        [TestMethod]
        public void TeamSetValidMaximumMembersTest()
        {
            testingTeam.MaximumMembers = 35;
            Assert.AreEqual(35, testingTeam.MaximumMembers);
        }

        [TestMethod]
        public void TeamSetValidOnlyOneMemberTest()
        {
            testingTeam.MaximumMembers = 1;
            Assert.AreEqual(1, testingTeam.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidZeroMemberTest()
        {
            testingTeam.MaximumMembers = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNegativeMembersTest()
        {
            testingTeam.MaximumMembers = -10;
        }

        [TestMethod]
        public void TeamParameterFactoryMethodValidTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            Assert.AreEqual("Equipo1", testingTeam.Name);
            Assert.AreEqual(DateTime.Today, testingTeam.CreationDate.Date);
            Assert.AreEqual("No hace tareas.", testingTeam.Description);
            Assert.AreEqual(10, testingTeam.MaximumMembers);
            CollectionAssert.Contains(testingTeam.Members, creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidNameTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo#11.32!", "Tareas:", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidMaximumNumberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo2", "Tareas:", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidDescriptionTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo3", "", 5);
        }

        [TestMethod]
        public void TeamToStringTest1()
        {
            Assert.AreEqual("Nombre inválido.", testingTeam.ToString());
        }

        [TestMethod]
        public void TeamToStringTest2()
        {
            testingTeam.Name = "Equipo10";
            Assert.AreEqual("Equipo10", testingTeam.ToString());
        }

        [TestMethod]
        public void TeamToStringTest3()
        {
            testingTeam.Name = "Equipo15";
            Assert.AreEqual(testingTeam.Name, testingTeam.ToString());
        }

        [TestMethod]
        public void TeamAddValidMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            CollectionAssert.Contains(testingTeam.Members, aUser);
        }

        [TestMethod]
        public void TeamAddValidMembersTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            User bUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido", "mail@usuario.com", aBirthdate, "password123");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
            CollectionAssert.Contains(testingTeam.Members, aUser);
            CollectionAssert.Contains(testingTeam.Members, bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddSameMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido", "mail@usuario.com", aBirthdate, "password123");
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddTooManyMembersTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 1);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido", "mail@usuario.com", aBirthdate, "password123");
            testingTeam.AddMember(aUser);
        }

        [TestMethod]
        public void TeamRemoveMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(aUser);
            CollectionAssert.DoesNotContain(testingTeam.Members, aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveUniqueMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            testingTeam.RemoveMember(creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveNotAMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuari.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(bUser);
        }
    }
}