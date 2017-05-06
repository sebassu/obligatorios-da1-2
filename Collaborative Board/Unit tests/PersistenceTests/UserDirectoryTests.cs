using Domain;
using System;
using Exceptions;
using System.Linq;
using Persistence;
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
            CollectionAssert.Contains(testingUserDirectory.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void UDirectoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "ravenna@simuladores.com";
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserDirectory.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException),
        "El elemento recibido ya existe en el sistema.")]
        public void UDirectoryAddRepeatedUserInvalidTest()
        {
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException),
        "El elemento recibido ya existe en el sistema.")]
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

        [TestMethod]
        public void UDirectoryRemoveUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.Remove(userToVerify);
            CollectionAssert.DoesNotContain(testingUserDirectory.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException),
        "Elemento inválido recibido: no se encuentra registrado en el sistema.")]
        public void UDirectoryRemoveUserNotInDirectoryInvalidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.Remove(userToVerify);
        }

        [TestMethod]
        public void UDirectoryModifyUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            Assert.AreEqual(userToVerify, addedUser);
            testingUserDirectory.ModifyUser(addedUser, " Mario ", " Santos ",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
            Assert.AreEqual("Mario", addedUser.FirstName);
            Assert.AreEqual("Santos", addedUser.LastName);
            Assert.AreEqual("santos@simuladores.com", addedUser.Email);
            Assert.AreEqual(DateTime.MinValue, addedUser.Birthdate);
            Assert.AreEqual("DisculpeFuegoTiene", addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void UDirectoryModifyNullUserInvalidTest()
        {
            testingUserDirectory.ModifyUser(null, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryException))]
        public void UDirectoryModifyUnaddedUserInvalidTest()
        {
            User unaddedUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.ModifyUser(unaddedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidFirstNameTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            testingUserDirectory.ModifyUser(addedUser, "4%# !sf*!@#9", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidLastNameTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            testingUserDirectory.ModifyUser(addedUser, "Mario", "a#$%s 9 $^!!12",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidEmailTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            testingUserDirectory.ModifyUser(addedUser, "Mario", "Santos",
                "!!12345 6789!!", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidBirthdateTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            testingUserDirectory.ModifyUser(addedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MaxValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidPasswordTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserDirectory.Elements.Single();
            testingUserDirectory.ModifyUser(addedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MaxValue, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        public void UDirectoryHasElementsEmptyTest()
        {
            Assert.IsFalse(testingUserDirectory.HasElements());
        }

        [TestMethod]
        public void UDirectoryHasElementsOneElementTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserDirectory.HasElements());
        }

        [TestMethod]
        public void UDirectoryHasElementsOneElementTest()
        {
            testingUserDirectory.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserDirectory.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserDirectory.HasElements());
        }
    }
}