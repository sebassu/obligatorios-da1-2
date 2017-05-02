using Domain;
using System;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    public class UserDirectoryTests
    {
        private static UserDirectory testingUserDirectory;

        [TestInitialize]
        public void TestSetUp()
        {
            testingUserDirectory = new UserDirectoryInMemory();
        }

        [TestMethod]
        public void UDirectoryAddNewUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword(" Emilio ", " Ravenna ",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser(" Emilio ", "Ravenna ",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserDirectory.Elements, userToVerify);
        }

        [TestMethod]
        public void UDirectoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "ravenna@simuladores.com";
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserDirectory.Elements, userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void UDirectoryAddRepeatedUserInvalidTest()
        {
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void UDirectoryAddNewUserRepeatedMailInvalidTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "otraContraseñaValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidFirstNameTest()
        {
            testingUserDirectory.AddNewUser("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidLastNameTest()
        {
            testingUserDirectory.AddNewUser("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidEmailTest()
        {
            testingUserDirectory.AddNewUser("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidBirthdateTest()
        {
            testingUserDirectory.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidPasswordTest()
        {
            testingUserDirectory.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }
    }
}
