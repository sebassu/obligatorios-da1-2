using Domain;
using System;
using Exceptions;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserDirectoryInMemoryTests
    {
        private static UserRepository testingUserRepository;

        [TestInitialize]
        public void TestSetUp()
        {
            testingUserRepository = new UserRepositoryInMemory();
        }

        [TestMethod]
        public void UDirectoryAddNewUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword(" Emilio ", " Ravenna ",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser(" Emilio ", "Ravenna ",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void UDirectoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "ravenna@simuladores.com";
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryAddRepeatedUserInvalidTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryAddNewUserRepeatedMailInvalidTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "otraContraseñaValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidFirstNameTest()
        {
            testingUserRepository.AddNewUser("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidLastNameTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidEmailTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidBirthdateTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewUserInvalidPasswordTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void UDirectoryAddNewAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword(" Emilio ",
                " Ravenna ", "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator(" Emilio ", "Ravenna ",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), administratorToVerify);
        }

        [TestMethod]
        public void UDirectoryAddNewAdministratorOnlyEmailsMatchValidTest()
        {
            Administrator administratorToVerify = Administrator.InstanceForTestingPurposes();
            administratorToVerify.Email = "ravenna@simuladores.com";
            testingUserRepository.AddNewAdministrator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryAddRepeatedAdministratorInvalidTest()
        {
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryAddNewAdministratorRepeatedMailInvalidTest()
        {
            testingUserRepository.AddNewAdministrator("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "otraContraseñaValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewAdministratorInvalidFirstNameTest()
        {
            testingUserRepository.AddNewAdministrator("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewAdministratorInvalidLastNameTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewAdministratorInvalidEmailTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewAdministratorInvalidBirthdateTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryAddNewAdministratorInvalidPasswordTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void UDirectoryRemoveUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void UDirectoryRemoveUserAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(administratorToVerify);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryRemoveUserNotInDirectoryInvalidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
        }

        [TestMethod]
        public void UDirectoryModifyUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            Assert.AreEqual(userToVerify, addedUser);
            testingUserRepository.ModifyUser(addedUser, " Mario ", " Santos ",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
            Assert.AreEqual("Mario", addedUser.FirstName);
            Assert.AreEqual("Santos", addedUser.LastName);
            Assert.AreEqual("santos@simuladores.com", addedUser.Email);
            Assert.AreEqual(DateTime.MinValue, addedUser.Birthdate);
            Assert.AreEqual("DisculpeFuegoTiene", addedUser.Password);
        }

        [TestMethod]
        public void UDirectoryModifyUserAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword("Emilio",
                "Ravenna", "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedAdminstrator = testingUserRepository.Elements.Single();
            Assert.AreEqual(administratorToVerify, addedAdminstrator);
            testingUserRepository.ModifyUser(addedAdminstrator, " Mario ", " Santos ",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
            Assert.AreEqual("Mario", addedAdminstrator.FirstName);
            Assert.AreEqual("Santos", addedAdminstrator.LastName);
            Assert.AreEqual("santos@simuladores.com", addedAdminstrator.Email);
            Assert.AreEqual(DateTime.MinValue, addedAdminstrator.Birthdate);
            Assert.AreEqual("DisculpeFuegoTiene", addedAdminstrator.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryModifyNullUserInvalidTest()
        {
            testingUserRepository.ModifyUser(null, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryModifyUnaddedUserInvalidTest()
        {
            User unaddedUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.ModifyUser(unaddedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidFirstNameTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            testingUserRepository.ModifyUser(addedUser, "4%# !sf*!@#9", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidLastNameTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            testingUserRepository.ModifyUser(addedUser, "Mario", "a#$%s 9 $^!!12",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidEmailTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            testingUserRepository.ModifyUser(addedUser, "Mario", "Santos",
                "!!12345 6789!!", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidBirthdateTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            testingUserRepository.ModifyUser(addedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MaxValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidPasswordTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            User addedUser = testingUserRepository.Elements.Single();
            testingUserRepository.ModifyUser(addedUser, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MaxValue, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        public void UDirectoryHasElementsEmptyTest()
        {
            Assert.IsFalse(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void UDirectoryHasElementsOneElementTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void UDirectoryHasElementsTwoElementsTest()
        {
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void UDirectoryGetInstanceTest()
        {
            testingUserRepository = UserRepository.GetInstance();
            UserRepository anotherUserRepository = UserRepository.GetInstance();
            Assert.AreSame(testingUserRepository, anotherUserRepository);
        }
    }
}