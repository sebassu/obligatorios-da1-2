using Domain;
using System;
using Exceptions;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserDirectoryInMemoryTests
    {
        private static User secondAdministrator;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            secondAdministrator = UserRepository.AddNewAdministrator("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            UserRepository.AddNewUser("Emilio", "Ravenna", "ravenna@simuladores.com",
                 DateTime.Today, "HablarUnasPalabritas");
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("santos@simuladores.com", "DisculpeFuegoTiene");
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Pablo", "Lamponne ",
                "lamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserReturnsAddedUserValidTest()
        {
            User addedUser = UserRepository.AddNewUser("Pablo", "Lamponne ",
                "segundolamponne@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserNotEnoughPrivilegesInvalidTest()
        {
            ChangeActiveUser("ravenna@simuladores.com", "HablarUnasPalabritas");
            UserRepository.AddNewUser("Pablo", "Lamponne ",
                "tercerlamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyEmailsMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Email = "lamponne@simuladores.com";
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "cuartolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedUserInvalidTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "quintolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "quintolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserRepeatedMailInvalidTest()
        {
            UserRepository.AddNewUser("Pablo", "Lamponne",
                "mail@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewUser("Gabriel David", "Medina",
                "mail@simuladores.com", DateTime.Now, "MusicaSuperDivertida");
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
            UserRepository.AddNewUser("Gabriel David", "*$ 563a%7*//*0&d!@",
                "xyz@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
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
                "Lamponne", "septimolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewAdministrator("Pablo", "Lamponne ",
                "septimolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorReturnsAddedAdministratorValidTest()
        {
            User addedAdministrator = UserRepository.AddNewAdministrator("Pablo",
                "Lamponne ", "octavolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), addedAdministrator);
        }

        [TestMethod]
        public void URepositoryAddNewAdministratorOnlyEmailsMatchValidTest()
        {
            User administratorToVerify = User.InstanceForTestingPurposes();
            administratorToVerify.Email = "lamponne@simuladores.com";
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "novenolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            CollectionAssert.Contains(UserRepository.Elements.ToList(),
                administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedAdministratorInvalidTest()
        {
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "decimolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            Thread.Sleep(200);
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "decimolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewAdministratorRepeatedMailInvalidTest()
        {
            UserRepository.AddNewAdministrator("Pablo", "Lamponne",
                "mail2@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "mail2@simuladores.com", DateTime.Now, "MusicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidFirstNameTest()
        {
            UserRepository.AddNewAdministrator("1d2@#!9 #(", "Medina",
                "gmedina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidLastNameTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "*$ 563a%7*//*0&d!@",
                "gdmedina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
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
                "anidem@simuladores.com", DateTime.MaxValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewAdministratorInvalidPasswordTest()
        {
            UserRepository.AddNewAdministrator("Gabriel David", "Medina",
                "anidemg@simuladores.com", DateTime.Today, "*#1/-asd$ !@^9");
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = UserRepository.AddNewUser("Gabriel David", "Medina",
                "medina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.Remove(userToVerify);
            CollectionAssert.DoesNotContain(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveUserAdministratorValidTest()
        {
            User administratorToVerify = UserRepository.AddNewAdministrator("Gabriel David",
                "Medina", "segundomedina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
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
        public void URepositoryRemoveUserNotInRepositoryInvalidTest()
        {
            User userToVerify = User.CreateNewCollaborator("Gabriel David", "Medina",
                "tercermedina@simuladores.com", DateTime.Today, "MúsicaSuperDivertida");
            UserRepository.Remove(userToVerify);
        }

        [TestMethod]
        public void URepositoryRemoveAdministratorLeavingOnlyOneLeftTest()
        {
            UserRepository.Remove(secondAdministrator);
            CollectionAssert.DoesNotContain(UserRepository.Elements, secondAdministrator);
            UserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryTryToRemoveAllAdministratorsTest()
        {
            var users = UserRepository.Elements;
            UserRepository.Remove(users.Last());
            UserRepository.AddNewAdministrator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
        }

        [TestMethod]
        public void URepositoryModifyUserValidTest()
        {
            User userToVerify = UserRepository.Elements.First();
            UserRepository.ModifyUser(userToVerify, "Gabriel David", "Medina",
             "algunmail@simuladores.com", new DateTime(1990, 11, 25), "MúsicaSuperDivertida");
            Assert.AreEqual("Gabriel David", userToVerify.FirstName);
            Assert.AreEqual("Medina", userToVerify.LastName);
            Assert.AreEqual("algunmail@simuladores.com", userToVerify.Email);
            Assert.AreEqual(new DateTime(1990, 11, 25), userToVerify.Birthdate);
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
                "quintomedina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNotAddedUserInvalidTest()
        {
            User notAddedUser = User.CreateNewCollaborator("Pablo", "Lamponne",
                "plamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.ModifyUser(notAddedUser, "Gabriel David", "Medina",
               "algunMedina@simuladores.com", DateTime.MinValue, "MúsicaSuperDivertida");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidFirstNameTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, "4%# !sf*!@#9", addedUser.LastName,
                addedUser.Email, addedUser.Birthdate, addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidLastNameTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, addedUser.FirstName, "a#$%s 9 $^!!12",
                addedUser.Email, addedUser.Birthdate, addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidEmailTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, addedUser.FirstName, addedUser.LastName,
                "!!12345 6789!!", addedUser.Birthdate, addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidBirthdateTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, addedUser.FirstName, addedUser.LastName,
                 addedUser.Email, DateTime.MaxValue, addedUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryModifyUserInvalidPasswordTest()
        {
            User addedUser = UserRepository.Elements.First();
            UserRepository.ModifyUser(addedUser, addedUser.FirstName, addedUser.LastName,
                 addedUser.Email, addedUser.Birthdate, "a &#^ 12&$!!/*- ");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyUserCausesRepeatedEmailInvalidTest()
        {
            User userToModify = UserRepository.AddNewUser("Pablo", "Lamponne",
                "algunlamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.ModifyUser(userToModify, "Mario", "Santos",
                "santos@simuladores.com", DateTime.MinValue, "DisculpeFuegoTiene");
        }

        [TestMethod]
        public void URepositoryResetUsersPasswordValidTest()
        {
            User addedUser = UserRepository.AddNewUser("Pablo", "Lamponne ",
                "algunotrolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
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
                "ultimolamponne@simuladores.com", DateTime.Today, "NoHaceFaltaSaleSolo");
            UserRepository.ResetUsersPassword(addedUser);
        }
    }
}