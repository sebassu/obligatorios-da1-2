﻿using Domain;
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
            UserRepository globalUsers = UserRepository.GetInstance();
            Session.Start("administrator@tf2.com", "Victory");
            AddTestData(globalUsers);
            Session.End();
        }

        private static void AddTestData(UserRepository globalUsers)
        {
            globalUsers.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            SwitchToTestingAdministrator();
            User anotherRegularUser = globalUsers.AddNewUser("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "password123");
            TeamRepository globalTeams = TeamRepository.GetInstance();
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            Team testingTeam = globalTeams.AddNewTeam("Los Simuladores", descriptionToSet, 4);
            globalTeams.AddMemberToTeam(testingTeam, anotherRegularUser);
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingUserRepository = new UserRepositoryInMemory();
            SwitchToTestingAdministrator();
        }

        private static void SwitchToTestingAdministrator()
        {
            Session.End();
            Session.Start("santos@simuladores.com", "contraseñaValida123");
        }

        [ClassCleanup]
        public static void ClassTeardown()
        {
            Session.End();
        }

        [TestMethod]
        public void URepositoryNewDirectoryHasOnlyOriginalAdministratorTest()
        {
            Administrator expectedMember = Administrator.NamesEmailBirthdatePassword("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            var users = testingUserRepository.Elements;
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(expectedMember, users.Single());
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword(" Pablo ", " Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserReturnsAddedUserValidTest()
        {
            User addedUser = testingUserRepository.AddNewUser(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserNotEnoughPrivilegesInvalidTest()
        {
            Session.End();
            Session.Start("ravenna@simuladores.com", "password123");
            testingUserRepository.AddNewUser(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "lamponne@simuladores.com";
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedUserInvalidTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserRepeatedMailInvalidTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "otraContraseñaValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidFirstNameTest()
        {
            testingUserRepository.AddNewUser("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidLastNameTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidEmailTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidBirthdateTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidPasswordTest()
        {
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorValidTest()
        {
            Administrator administratorToVerify = Administrator.NamesEmailBirthdatePassword(" Pablo ",
                " Lamponne ", "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator(" Pablo ", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorReturnsAddedAdministratorValidTest()
        {
            Administrator addedAdministrator = testingUserRepository.AddNewAdministrator(" Pablo ",
                "Lamponne ", "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), addedAdministrator);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorOnlyEmailsMatchValidTest()
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
        public void URepositoryAddRepeatedAdministratorInvalidTest()
        {
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewAdministratorRepeatedMailInvalidTest()
        {
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "otraContraseñaValida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidFirstNameTest()
        {
            testingUserRepository.AddNewAdministrator("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidLastNameTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidEmailTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidBirthdateTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidPasswordTest()
        {
            testingUserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveUserAdministratorValidTest()
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
        public void URepositoryRemoveUserNotInDirectoryInvalidTest()
        {
            User userToVerify = User.NamesEmailBirthdatePassword("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.Remove(userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveOriginalAdministratorLeavingOnlyOneLeftTest()
        {
            testingUserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            Administrator originalAdministrator = Administrator.NamesEmailBirthdatePassword("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            testingUserRepository.Remove(originalAdministrator);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryTryToRemoveAllAdministratorsTest()
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
        public void URepositoryModifyUserValidTest()
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
        public void URepositoryModifyUserSetSameDataValidTest()
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
        public void URepositoryModifyNullUserInvalidTest()
        {
            testingUserRepository.ModifyUser(null, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyUnaddedUserInvalidTest()
        {
            User unaddedUser = User.NamesEmailBirthdatePassword("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.ModifyUser(unaddedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidFirstNameTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "4%# !sf*!@#9", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidLastNameTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "a#$%s 9 $^!!12",
                "medina@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidEmailTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "!!12345 6789!!", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidBirthdateTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidPasswordTest()
        {
            User addedUser = testingUserRepository.Elements.First();
            testingUserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        public void URepositoryHasElementsOneElementTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void URepositoryHasElementsTwoElementsTest()
        {
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingUserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaValida123");
            Assert.IsTrue(testingUserRepository.HasElements());
        }

        [TestMethod]
        public void URepositoryGetInstanceTest()
        {
            testingUserRepository = UserRepository.GetInstance();
            UserRepository anotherUserRepository = UserRepository.GetInstance();
            Assert.AreSame(testingUserRepository, anotherUserRepository);
        }
    }
}