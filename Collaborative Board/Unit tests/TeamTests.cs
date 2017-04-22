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
    }
}
