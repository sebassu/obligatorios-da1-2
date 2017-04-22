using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    public class TeamTests
    {
        private static Team testingTeam;

        [ClassInitialize]
        public void TestSetUp()
        {
            testingTeam = new Team();
        }

        private TestContext testContextInstance;

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
    }
}
