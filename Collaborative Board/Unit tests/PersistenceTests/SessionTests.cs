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
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            UserRepository.AddNewAdministrator("John Hannibal", "Smith",
                "smith@theateam.com", DateTime.Today, "APlanWorksOut");
            UserRepository.AddNewUser("Templeton Face", "Peck",
                "peck@theateam.com", DateTime.Today, "Faceman");
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            Session.End();
        }

        [TestMethod]
        public void SessionStartUserValidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Templeton Face", "Peck",
                "peck@theateam.com", DateTime.Today, "Faceman");
            Session.Start("peck@theateam.com", "Faceman");
            Assert.AreEqual(userToVerify, Session.ActiveUser());
            Assert.IsFalse(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        public void SessionStartAdministratorValidTest()
        {
            User administratorToVerify = User.CreateNewAdministrator("John Hannibal", "Smith",
                "smith@theateam.com", DateTime.Today, "APlanWorksOut");
            Session.Start("smith@theateam.com", "APlanWorksOut");
            Assert.AreEqual(administratorToVerify, Session.ActiveUser());
            Assert.IsTrue(Session.HasAdministrationPrivileges());
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidEmailTest()
        {
            Session.Start("wololo@theateam.com", "APlanWorksOut");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidPasswordTest()
        {
            Session.Start("smith@theateam.com", "passwordIncorrecta");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartInvalidEmailAndPasswordTest()
        {
            Session.Start("wololo@theateam.com", "passwordIncorrecta");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartNullEmailTest()
        {
            Session.Start(null, "APlanWorksOut");
        }

        [TestMethod]
        [ExpectedException(typeof(SessionException))]
        public void SessionStartNullPasswordTest()
        {
            Session.Start("smith@theateam.com", null);
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
            Session.Start("smith@theateam.com", "APlanWorksOut");
            Session.Start("peck@theateam.com", "Faceman");
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
            Session.Start("peck@theateam.com", "Faceman");
            Session.End();
            Assert.IsFalse(Session.IsActive());
        }

        [TestMethod]
        public void SessionFinalizeAdministratorValidTest()
        {
            Session.Start("smith@theateam.com", "APlanWorksOut");
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