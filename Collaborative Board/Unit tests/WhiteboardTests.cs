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
    }
}
