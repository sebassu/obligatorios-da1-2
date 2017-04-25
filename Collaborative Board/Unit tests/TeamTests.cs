using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Exceptions;
using System;

namespace Unit_tests
{
    [TestClass]
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
            DateTime creationDate = new DateTime();
            testingTeam.CreationDate = creationDate;
            Assert.AreEqual(DateTime.Now.Date, testingTeam.CreationDate.Date);
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
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            Assert.AreEqual("Equipo1", testingTeam.Name);
            Assert.AreEqual(DateTime.Now.Date, testingTeam.CreationDate.Date);
            Assert.AreEqual("No hace tareas.", testingTeam.Description);
            Assert.AreEqual(10, testingTeam.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidNameTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo#11.32!", "Tareas:", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidMaximumNumberTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo2", "Tareas:", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidDescriptionTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo3", "", 5);
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
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            CollectionAssert.Contains(testingTeam.Members, aUser);
        }

        [TestMethod]
        public void TeamAddValidMembersTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            DateTime aBirthdate = new DateTime(1990, 05, 05);
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
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido", "mail@usuario.com", aBirthdate, "password123");
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddTooManyMembersTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 1);
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido", "mail@usuario.com", aBirthdate, "password123");
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
        }

        [TestMethod]
        public void TeamRemoveMemberTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
            testingTeam.RemoveMember(aUser);
            CollectionAssert.DoesNotContain(testingTeam.Members, aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveUniqueMemberTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveNotAMemberTest()
        {
            testingTeam = Team.NameDescriptionMaximumMembers("Equipo1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName", "mail@usuari.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(bUser);
        }






    }
}
