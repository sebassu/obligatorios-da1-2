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
        [TestInitialize]
        public void TestSetup()
        {
            if (!UserRepository.HasElements())
            {
                UserRepository.InsertOriginalSystemAdministrator();
                UserRepository.AddNewAdministrator("Mario", "Santos", "santos@simuladores.com",
                    new DateTime(4, 10, 1966), "DisculpeFuegoTiene");
            }
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
        }

        [TestCleanup]
        public void TestTeardown()
        {
            UserRepository.RemoveAllUsers();
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestMethod]
        public void URepositoryNewDirectoryHasOnlyOriginalAdministratorTest()
        {
            User expectedMember = User.CreateNewAdministrator("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            var users = UserRepository.Elements;
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(expectedMember, users.Single());
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserReturnsAddedUserValidTest()
        {
            User addedUser = UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserNotEnoughPrivilegesInvalidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "lamponne@simuladores.com";
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedUserInvalidTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserRepeatedMailInvalidTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidFirstNameTest()
        {
            UserRepository.AddNewUser("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidLastNameTest()
        {
            UserRepository.AddNewUser("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidEmailTest()
        {
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidBirthdateTest()
        {
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidPasswordTest()
        {
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorValidTest()
        {
            User administratorToVerify = User.CreateNewAdministrator("Pablo",
                "Lamponne", "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewAdministrator("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorReturnsAddedAdministratorValidTest()
        {
            User addedAdministrator = UserRepository.AddNewAdministrator("Pablo",
                "Lamponne ", "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), addedAdministrator);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorOnlyEmailsMatchValidTest()
        {
            User administratorToVerify = User.InstanceForTestingPurposes();
            administratorToVerify.Email = "lamponne@simuladores.com";
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedAdministratorInvalidTest()
        {
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewAdministratorRepeatedMailInvalidTest()
        {
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Now, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidFirstNameTest()
        {
            UserRepository.AddNewAdministrator("1d2@#!9 #(", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidLastNameTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "*$ 563a%7*/0&d!@",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidEmailTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "Ceci n'est pas un email.", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidBirthdateTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidPasswordTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.Remove(userToVerify);
            CollectionAssert.DoesNotContain(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveUserAdministratorValidTest()
        {
            User administratorToVerify = User.CreateNewAdministrator("Gabriel David",
                "Medina", "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.Remove(administratorToVerify);
            CollectionAssert.DoesNotContain(UserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveNullUserInvalidTest()
        {
            UserRepository.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInDirectoryInvalidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.Remove(userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveOriginalAdministratorLeavingOnlyOneLeftTest()
        {
            UserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            User originalAdministrator = User.CreateNewAdministrator("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            UserRepository.Remove(originalAdministrator);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryTryToRemoveAllAdministratorsTest()
        {
            UserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            var users = UserRepository.Elements;
            var administrators = users.Where(u => u.HasAdministrationPrivileges).ToList();
            foreach (var administrator in administrators)
            {
                UserRepository.Remove(administrator);
            }
        }

        [TestMethod]
        public void URepositoryModifyUserValidTest()
        {
            User userToVerify = UserRepository.Elements.First();
            UserRepository.ModifyUser(userToVerify, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
            Assert.AreEqual("Gabriel David", userToVerify.FirstName);
            Assert.AreEqual("Medina", userToVerify.LastName);
            Assert.AreEqual("medina@simuladores.com", userToVerify.Email);
            Assert.AreEqual(DateTime.MinValue, userToVerify.Birthdate);
            Assert.AreEqual("MúsicaSuperDivertida", userToVerify.Password);
        }

        [TestMethod]
        public void URepositoryModifyUserSetSameDataValidTest()
        {
            User userToVerify = UserRepository.Elements.First();
            var previousFirstName = userToVerify.FirstName;
            var previousLastName = userToVerify.LastName;
            var previousEmail = userToVerify.Email;
            var previousBirthdate = userToVerify.Birthdate;
            var previousPassword = userToVerify.Password;
            UserRepository.ModifyUser(userToVerify, previousFirstName,
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
            UserRepository.ModifyUser(null, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNotAddedUserInvalidTest()
        {
            User NotAddedUser = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.ModifyUser(NotAddedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidFirstNameTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "4%# !sf*!@#9", "Medina",
                "medina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidLastNameTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "Gabriel David", "a#$%s 9 $^!!12",
                "medina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidEmailTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "!!12345 6789!!", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidBirthdateTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidPasswordTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.MaxValue, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyUserCausesRepeatedEmailInvalidTest()
        {
            UserRepository.AddNewUser("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            User userToModify = UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.ModifyUser(userToModify, "Gabriel David", "Medina",
                "santos@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        public void URepositoryHasElementsOneElementTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            Assert.IsTrue(UserRepository.HasElements());
        }

        [TestMethod]
        public void URepositoryHasElementsTwoElementsTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            Assert.IsTrue(UserRepository.HasElements());
        }

        [TestMethod]
        public void URepositoryResetUsersPasswordValidTest()
        {
            User addedUser = UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            string newPassword = UserRepository.ResetUsersPassword(addedUser);
            Assert.AreEqual(newPassword, addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryResetNullUsersPasswordInvalidTest()
        {
            UserRepository.ResetUsersPassword(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryResetUsersPasswordWithoutPrivilegesInvalidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            User addedUser = UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.ResetUsersPassword(addedUser);
        }
    }
}