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
            testingTeam = new Team();
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
    }
}
