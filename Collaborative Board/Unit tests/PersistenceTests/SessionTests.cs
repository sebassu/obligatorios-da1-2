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
        public void TestSetup()
        {
            Session.End();
        }

        [TestMethod]
        public void SessionStartUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            Session.Start("ravenna@simuladores.com", "HablarUnasPalabritas");
            Assert.AreEqual(userToVerify, Session.ActiveUser());
            Assert.IsFalse(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        public void SessionStartAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            Session.Start("santos@simuladores.com", "DisculpeFuegoTiene");
            Assert.AreEqual(administratorToVerify, Session.ActiveUser());
            Assert.IsTrue(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidEmailTest()
        {
            Session.Start("lamponne@simuladores.com", "HablarUnasPalabritas");
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
            Session.Start(null, "contraseñaVálida123");
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
            Session.Start("santos@simuladores.com", "DisculpeFuegoTiene");
            Session.Start("ravenna@simuladores.com", "HablarUnasPalabritas");
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
            Session.Start("ravenna@simuladores.com", "HablarUnasPalabritas");
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        public void SessionFinalizeAdministratorValidTest()
        {
            Session.Start("santos@simuladores.com", "DisculpeFuegoTiene");
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        public void SessionFinalizeNotStartedValidTest()
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