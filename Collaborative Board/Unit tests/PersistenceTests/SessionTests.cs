using Domain;
using System;
using Exceptions;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SessionTests
    {
        [TestInitialize]
        public void TestSetUp()
        {
            Session.End();
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            Session.End();
        }

        [TestMethod]
        public void SessionStartUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "password123");
            Session.Start("ravenna@simuladores.com", "password123");
            Assert.AreEqual(userToVerify, Session.ActiveUser());
            Assert.IsFalse(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        public void SessionStartAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            Assert.AreEqual(administratorToVerify, Session.ActiveUser());
            Assert.IsTrue(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidEmailTest()
        {
            Session.Start("lamponne@simuladores.com", "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidPasswordTest()
        {
            Session.Start("ravenna@simuladores.com", "passwordIncorrecta");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidEmailAndPasswordTest()
        {
            Session.Start("lamponne@simuladores.com", "passwordIncorrecta");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartNullEmailTest()
        {
            Session.Start(null, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartNullPasswordTest()
        {
            Session.Start("santos@simuladores.com", null);
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartNullEmailAndPasswordTest()
        {
            Session.Start(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartAlreadyStartedTest()
        {
            Session.Start("santos@simuladores.com", "contraseñaValida123");
            Session.Start("ravenna@simuladores.com", "password123");
        }

        [TestMethod]
        public void SessionHasAdministrationPrivilegesNotInitializedTest()
        {
            Session.End();
            Assert.IsFalse(Session.IsActive());
            Assert.IsFalse(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        public void SessionFinalizeUserValidTest()
        {
            Session.Start("ravenna@simuladores.com", "password123");
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        public void SessionFinalizeAdministratorValidTest()
        {
            Session.Start("ravenna@simuladores.com", "password123");
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        public void SessionFinalizeUnstartedValidTest()
        {
            Session.End();
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionActiveUserNotInitializedInvalidTest()
        {
            Session.ActiveUser();
        }
    }
}