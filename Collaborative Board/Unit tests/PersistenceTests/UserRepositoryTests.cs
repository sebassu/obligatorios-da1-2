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

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext context)
        {
            testingUserRepository = UserRepository.GetInstance();
            Session.Start("administrator@tf2.com", "Victory");
            testingUserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "password123");
            Session.End();
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingUserRepository = new UserRepositoryInMemory();
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
        }

        [ClassCleanup]
        public static void ClassTeardown()
        {
            Session.End();
        }

        [TestMethod]
        public void UDirectoryNewDirectoryHasOnlyOriginalAdministratorTest()
        {
            Administrator expectedMember = Administrator.NamesEmailBirthdatePassword("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            var users = testingUserRepository.Elements;
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(expectedMember, users.Single());
        }

        [TestMethod]
        public void UDirectoryAddNewUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryAddNewUserNotEnoughPrivilegesInvalidTest()
        {
            Session.End();
            Session.Start("ravenna@simuladores.com", "password123");
            testingUserRepository.AddNewUser(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        public void UDirectoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "lamponne@simuladores.com";
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
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
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
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
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword(" Pablo ",
                " Lamponne ", "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        public void UDirectoryAddNewAdministratorOnlyEmailsMatchValidTest()
        {
            Administrator administratorToVerify = Administrator.InstanceForTestingPurposes();
            administratorToVerify.Email = "lamponne@simuladores.com";
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(),
                administratorToVerify);
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
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
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
            User userToVerify = User.NamesEmailBirthdatePassword("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void UDirectoryRemoveUserAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword("Gabriel David",
                "Medina", "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(administratorToVerify);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryRemoveUserNotInDirectoryInvalidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
        }

        [TestMethod]
        public void UDirectoryRemoveOriginalAdministratorLeavingOnlyOneLeftTest()
        {
            testingUserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            Administrator originalAdministrator = Administrator.NamesEmailBirthdatePassword("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            testingUserRepository.Remove(originalAdministrator);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryTryToRemoveAllAdministratorsTest()
        {
            testingUserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            var users = testingUserRepository.Elements;
            var administrators = users.Where(u => u.HasAdministrationPrivileges).ToList();
            foreach (var administrator in administrators)
            {
                testingUserRepository.Remove(administrator);
            }
        }

        [TestMethod]
        public void UDirectoryModifyUserValidTest()
        {
            User userToVerify = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(userToVerify, " Gabriel David ", " Medina ",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
            Assert.AreEqual("Gabriel David", userToVerify.FirstName);
            Assert.AreEqual("Medina", userToVerify.LastName);
            Assert.AreEqual("medina@simuladores.com", userToVerify.Email);
            Assert.AreEqual(DateTime.MinValue, userToVerify.Birthdate);
            Assert.AreEqual("DisculpeFuegoTiene", userToVerify.Password);
        }

        [TestMethod]
        public void UDirectoryModifyUserSetSameDataValidTest()
        {
            User userToVerify = testingUserRepository.Elements.First();
            var previousFirstName = userToVerify.FirstName;
            var previousLastName = userToVerify.LastName;
            var previousEmail = userToVerify.Email;
            var previousBirthdate = userToVerify.Birthdate;
            var previousPassword = userToVerify.Password;
            testingUserRepository.ModifyUser(userToVerify, previousFirstName,
                previousLastName, previousEmail, previousBirthdate, previousPassword);
            Assert.AreEqual(previousFirstName, userToVerify.FirstName);
            Assert.AreEqual(previousLastName, userToVerify.LastName);
            Assert.AreEqual(previousEmail, userToVerify.Email);
            Assert.AreEqual(previousBirthdate, userToVerify.Birthdate);
            Assert.AreEqual(previousPassword, userToVerify.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryModifyNullUserInvalidTest()
        {
            testingUserRepository.ModifyUser(null, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UDirectoryModifyUnaddedUserInvalidTest()
        {
            User unaddedUser = User.NamesEmailBirthdatePassword("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.ModifyUser(unaddedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidFirstNameTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "4%# !sf*!@#9", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidLastNameTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "a#$%s 9 $^!!12",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidEmailTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "!!12345 6789!!", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidBirthdateTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UDirectoryModifyUserInvalidPasswordTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        public void UDirectoryHasElementsOneElementTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void UDirectoryHasElementsTwoElementsTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
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