using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Exceptions;

namespace Unit_tests
{
    [TestClass]
    public class WhiteboardTests
    {
        private static Whiteboard testingWhiteboard;

        [TestInitialize]
        public void TestSetUp()
        {
            testingWhiteboard = Whiteboard.WhiteboardForTestingPurposes();
        }

        [TestMethod]
        public void WhiteboradForTestingPurposesTest()
        {
            Assert.AreEqual("Nombre inválido", testingWhiteboard.Name);
            Assert.AreEqual("Descripción inválida.", testingWhiteboard.Description);
        }

        [TestMethod]
        public void WhiteboardSetValidNameTest1()
        {
            testingWhiteboard.Name = "Pizarron1";
            Assert.AreEqual("Pizarron1", testingWhiteboard.Name);
        }

        public void WhiteboardSetValidNameTest2()
        {
            testingWhiteboard.Name = "PizarronNuevo";
            Assert.AreEqual("PizarronNuevo", testingWhiteboard.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidName()
        {
            testingWhiteboard.Name = "Equipo!.-";
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNameEmptyTest()
        {
            testingWhiteboard.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNameNullTest()
        {
            testingWhiteboard.Name = null;
        }

        [TestMethod]
        public void WhiteboardSetValidDescriptionTest()
        {
            testingWhiteboard.Description = "Esto es una breve descripción del pizarrón.";
            Assert.AreEqual("Esto es una breve descripción del pizarrón.", testingWhiteboard.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidDescriptionNullTest()
        {
            testingWhiteboard.Description = null;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidDescriptionEmptyTest()
        {
            testingWhiteboard.Description = "";
        }

        [TestMethod]
        public void WhiteboardSetValidOwnerTeamTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team", "creador@usuario.com", aBirthdate, "password125");
            Team owner = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo1", "No hace tareas.", 10);
            testingWhiteboard.OwnerTeam = owner;
            Assert.AreEqual(owner, testingWhiteboard.OwnerTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetOwnerTeamNullTest()
        {
            testingWhiteboard.OwnerTeam = null;
        }

        [TestMethod]
        public void WhiteboardSetValidWidhtTest()
        {
            testingWhiteboard.Width = 1532;
            Assert.AreEqual(1532, testingWhiteboard.Width);
        }

        [TestMethod]
        public void WhiteboardSetValidMinimumWidthTest()
        {
            testingWhiteboard.Width = 1;
            Assert.AreEqual(1, testingWhiteboard.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidWidthTest()
        {
            testingWhiteboard.Width = -40;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidMinimumWidthTest()
        {
            testingWhiteboard.Width = 0;
        }

        [TestMethod]
        public void WhiteboardSetValidHeightTest()
        {
            testingWhiteboard.Height = 2500;
            Assert.AreEqual(2500, testingWhiteboard.Height);
        }

        [TestMethod]
        public void WhiteboardSetValidMinimumHeightTest()
        {
            testingWhiteboard.Height = 1;
            Assert.AreEqual(1, testingWhiteboard.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidHeightTest()
        {
            testingWhiteboard.Height = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidMinimumHeightTest()
        {
            testingWhiteboard.Height = 0;
        }
    }
}
