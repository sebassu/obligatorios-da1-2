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
        public void SetValidNameTest()
        {
            testingTeam.Name = "Equipo1";
            Assert.AreEqual("Equipo1", testingTeam.Name);
        }

        [TestMethod]
        public void SetValidNameTest2()
        {
            testingTeam.Name = "EquipoNuevo";
            Assert.AreEqual("EquipoNuevo", testingTeam.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidNamePunctuationTest()
        {
            testingTeam.Name = "Equipo.#/!";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidNameEmptyTest()
        {
            testingTeam.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidNameNullTest()
        {
            testingTeam.Name = null;
        }

        [TestMethod]
        public void ValidCreationDateTest()
        {
            DateTime creationDate = new DateTime();
            testingTeam.CreationDate = creationDate;
            Assert.AreEqual(DateTime.Now.Date, testingTeam.CreationDate.Date);
        }

        [TestMethod]
        public void SetValidDescriptionTest()
        {
            testingTeam.Description = "Esto es una breve descripción del equipo.";
            Assert.AreEqual("Esto es una breve descripción del equipo.", testingTeam.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidDescriptionEmptyTest()
        {
            testingTeam.Description = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidDescriptionNullTest()
        {
            testingTeam.Description = null;
        }

        [TestMethod]
        public void SetValidMaximumMembersTest()
        {
            testingTeam.MaximumMembers = 35;
            Assert.AreEqual(35, testingTeam.MaximumMembers);
        }

        [TestMethod]
        public void SetValidOnlyOneMemberTest()
        {
            testingTeam.MaximumMembers = 1;
            Assert.AreEqual(1, testingTeam.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidZeroMemberTest()
        {
            testingTeam.MaximumMembers = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void SetInvalidNegativeMembersTest()
        {
            testingTeam.MaximumMembers = -10;
        }

        [TestMethod]
        public void ParameterFactoryMethodValidTest()
        {
            DateTime creationDateToSet = DateTime.Now;
            testingTeam = Team.NameCreationDateDescriptionMaximumMembers("Equipo1", creationDateToSet, "No hace tareas.", 10);
            Assert.AreEqual("Equipo1", testingTeam.Name);
            Assert.AreEqual(creationDateToSet, testingTeam.CreationDate);
            Assert.AreEqual("No hace tareas.", testingTeam.Description);
            Assert.AreEqual(10, testingTeam.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void ParameterFactoryMethodInvalidNameTest()
        {
            testingTeam = Team.NameCreationDateDescriptionMaximumMembers("Equipo#11.32!", DateTime.Now, "Tareas:", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void ParameterFactoryMethodInvalidMaximumNumberTest()
        {
            testingTeam = Team.NameCreationDateDescriptionMaximumMembers("Equipo2", DateTime.Now, "Tareas:", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void ParameterFactoryMethodInvalidDescriptionTest()
        {
            testingTeam = Team.NameCreationDateDescriptionMaximumMembers("Equipo3", DateTime.Now, "", 5);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            Assert.AreEqual("Nombre inválido.", testingTeam.ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            testingTeam.Name = "Equipo10";
            Assert.AreEqual("Equipo 10", testingTeam.ToString());
        }

        [TestMethod]
        public void ToStringTest3()
        {
            testingTeam.Name = "Equipo15";
            Assert.AreEqual(testingTeam.Name, testingTeam.ToString());
        }


    }
}
