using System;
using Domain;
using Exceptions;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserTests
    {
        private static User testingUser;

        [TestInitialize]
        public void TestSetUp()
        {
            testingUser = User.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void UserForTestingPurposesTest()
        {
            Assert.AreEqual("Nombre inválido.", testingUser.FirstName);
            Assert.AreEqual("Apellido inválido.", testingUser.LastName);
            Assert.AreEqual("mailInvalido@usuarioInvalido", testingUser.Email);
            Assert.AreEqual("Contraseña inválida.", testingUser.Password);
        }

        [TestMethod]
        public void UserSetValidFirstNameTest()
        {
            testingUser.FirstName = "Mario";
            Assert.AreEqual("Mario", testingUser.FirstName);
        }

        [TestMethod]
        public void UserSetValidFirstNameCompoundTest()
        {
            testingUser.FirstName = "  Juan Martín  ";
            Assert.AreEqual("Juan Martín", testingUser.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameNumbersTest()
        {
            testingUser.FirstName = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNamePunctuationTest()
        {
            testingUser.FirstName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameSpacesTest()
        {
            testingUser.FirstName = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameEmptyTest()
        {
            testingUser.FirstName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameNullTest()
        {
            testingUser.FirstName = null;
        }

        [TestMethod]
        public void UserSetValidLastNameTest()
        {
            testingUser.LastName = "Santos";
            Assert.AreEqual("Santos", testingUser.LastName);
        }

        [TestMethod]
        public void UserSetValidLastNameCompoundTest()
        {
            testingUser.LastName = "  García Morales  ";
            Assert.AreEqual("García Morales", testingUser.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameNumbersTest()
        {
            testingUser.LastName = "5678";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNamePunctuationTest()
        {
            testingUser.LastName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameEmptyTest()
        {
            testingUser.LastName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameNullTest()
        {
            testingUser.LastName = null;
        }

        [TestMethod]
        public void UserSetValidEmailTest()
        {
            testingUser.Email = "sebastian.uriarteg@gmail.com";
            Assert.AreEqual("sebastian.uriarteg@gmail.com", testingUser.Email);
        }

        [TestMethod]
        public void UserSetValidEmailTrimTest()
        {
            testingUser.Email = "  sdelfinoh@gmail.com  ";
            Assert.AreEqual("sdelfinoh@gmail.com", testingUser.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidEmailWordsTest()
        {
            testingUser.Email = "Universidad ORT Uruguay";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidEmailNoHostTest()
        {
            testingUser.Email = "valid_Beginning@";
        }

        [TestMethod]
        public void UserSetValidEmailNoDotComTest()
        {
            testingUser.Email = "zaphod@slartibartfast";
            Assert.AreEqual("zaphod@slartibartfast", testingUser.Email);
        }

        [TestMethod]
        public void UserSetValidEmailNoLettersTest()
        {
            testingUser.Email = "123@$789";
            Assert.AreEqual("123@$789", testingUser.Email);
        }

        [TestMethod]
        public void UserSetValidEmailUnexpectedCharactersTest()
        {
            testingUser.Email = "!$A_b.%c=d*-ef@ex^am#pl-e.com";
            Assert.AreEqual("!$A_b.%c=d*-ef@ex^am#pl-e.com", testingUser.Email);
        }

        [TestMethod]
        public void UserSetValidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(1995, 10, 27);
            testingUser.Birthdate = birthdateToSet;
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
        }

        [TestMethod]
        public void UserSetValidBirthdateCloseTest()
        {
            DateTime birthdateToSet = new DateTime(2017, 4, 17);
            testingUser.Birthdate = birthdateToSet;
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 3, 31);
            testingUser.Birthdate = birthdateToSet;
        }

        [TestMethod]
        public void UserSetOnlyLettersPasswordTest()
        {
            testingUser.Password = "holaChau";
            Assert.AreEqual("holaChau", testingUser.Password);
        }

        [TestMethod]
        public void UserSetValidPasswordTest()
        {
            testingUser.Password = "pS8a11";
            Assert.AreEqual("pS8a11", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordTest()
        {
            testingUser.Password = "pS8a11#.!";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordEmptyTest()
        {
            testingUser.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordNullTest()
        {
            testingUser.Password = null;
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordTooShortTest()
        {
            testingUser.Password = "pass2";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordTooLongTest()
        {
            testingUser.Password = "password201543sdre#ts";
        }

        [TestMethod]
        public void UserParameterFactoryMethodValidTest()
        {
            DateTime birthdateToSet = DateTime.Today;
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", birthdateToSet, "contraseñaValida123");
            Assert.AreEqual("Emilio", testingUser.FirstName);
            Assert.AreEqual("Ravenna", testingUser.LastName);
            Assert.AreEqual("ravenna@simuladores.com", testingUser.Email);
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
            Assert.AreEqual("contraseñaValida123", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidFirstNameTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("1&6 1a2-*!3", "Ravenna",
                "ravenna@simuladores.com", DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidLastNameTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", ";#d1 -($!#",
                "ravenna@simuladores.com", DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidEmailTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "12! $^#&",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 7, 31);
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", birthdateToSet, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidPasswordTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Now, "@%^# 521D(%$");
        }

        [TestMethod]
        public void UserToStringTest1()
        {
            Assert.AreEqual("Nombre inválido. Apellido inválido. <mailInvalido@usuarioInvalido>",
                testingUser.ToString());
        }

        [TestMethod]
        public void UserToStringTest2()
        {
            testingUser.FirstName = "Mario";
            testingUser.LastName = "Santos";
            testingUser.Email = "santos@simuladores.com";
            Assert.AreEqual("Mario Santos <santos@simuladores.com>", testingUser.ToString());
        }

        [TestMethod]
        public void UserToStringTest3()
        {
            testingUser.FirstName = "Gabriel";
            testingUser.LastName = "Medina";
            testingUser.Email = "medina@simuladores.com";
            Assert.AreEqual(testingUser.FirstName + " " + testingUser.LastName + " <"
                + testingUser.Email + ">", testingUser.ToString());
        }

        [TestMethod]
        public void UserEqualsReflexiveTest()
        {
            Assert.AreEqual(testingUser, testingUser);
        }

        [TestMethod]
        public void UserEqualsSymmetricTest()
        {
            User secondTestingUser = User.InstanceForTestingPurposes();
            Assert.AreEqual(testingUser, secondTestingUser);
            Assert.AreEqual(secondTestingUser, testingUser);
        }

        [TestMethod]
        public void UserEqualsTransitiveTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("A", "B", "mail@example.com",
                DateTime.Now, "Password1");
            User secondTestingUser = User.NamesEmailBirthdatePassword("D", "E", "mail@example.com",
                DateTime.Now, "Password2");
            User thirdTestingUser = User.NamesEmailBirthdatePassword("G", "H", "mail@example.com",
                    DateTime.Now, "Password3");
            Assert.AreEqual(testingUser, secondTestingUser);
            Assert.AreEqual(secondTestingUser, thirdTestingUser);
            Assert.AreEqual(testingUser, thirdTestingUser);
        }

        [TestMethod]
        public void UserEqualsDifferentUsersTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Same first name",
                "Same last name", "first@different.com",
                DateTime.Now, "SamePassword");
            User secondTestingUser = User.NamesEmailBirthdatePassword("Same first name",
                "Same last name", "second@different.com",
                DateTime.Now, "SamePassword");
            Assert.AreNotEqual(testingUser, secondTestingUser);
        }

        [TestMethod]
        public void UserEqualsNullTest()
        {
            Assert.AreNotEqual(testingUser, null);
        }

        [TestMethod]
        public void UserEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingUser, someRandomObject);
        }

        [TestMethod]
        public void UserGetHashCodeTest()
        {
            object testingUserAsObject = testingUser;
            Assert.AreEqual(testingUserAsObject.GetHashCode(), testingUser.GetHashCode());
        }

        [TestMethod]
        public void UserHasAdministratorPrivilegesDefaultTest()
        {
            Assert.IsFalse(testingUser.HasAdministrationPrivileges);
        }

        [TestMethod]
        public void UserHasAdministratorPrivilegesParametersTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Now, "contraseñaValida123");
            Assert.IsFalse(testingUser.HasAdministrationPrivileges);
        }

        [TestMethod]
        public void UserResetPasswordModificationTest()
        {
            string resultObtained = testingUser.ResetPassword();
            Assert.AreEqual(resultObtained, testingUser.Password);
        }

        [TestMethod]
        public void UserResetPasswordRandomnessTest()
        {
            string firstResultObtained = testingUser.ResetPassword();
            Thread.Sleep(15);
            string secondResultObtained = testingUser.ResetPassword();
            Assert.AreNotEqual(firstResultObtained, secondResultObtained);
        }
    }
}