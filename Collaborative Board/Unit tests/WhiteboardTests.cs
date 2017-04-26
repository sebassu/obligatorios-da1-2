﻿using System;
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
            Assert.AreEqual("EquipoInvalido", testingWhiteboard.OwnerTeam);
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
    }
}
