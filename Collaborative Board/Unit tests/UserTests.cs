using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_tests
{
    [TestClass]
    public class UserTests
    {
        private static User testingUser;

        [TestInitialize]
        public void TestSetUp()
        {
            testingUser = User.UserForTestingPurposes();
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
        public void SetValidFirstNameTest()
        {
            testingUser.FirstName = "Mario";
            Assert.AreEqual("Mario", testingUser.FirstName);
        }

        [TestMethod]
        public void SetValidFirstNameCompoundTest()
        {
            testingUser.FirstName = "  Juan Martín  ";
            Assert.AreEqual("Juan Martín", testingUser.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidFirstNameNumbersTest()
        {
            testingUser.FirstName = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidFirstNamePunctuationTest()
        {
            testingUser.FirstName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidFirstNameEmptyTest()
        {
            testingUser.FirstName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidFirstNameNullTest()
        {
            testingUser.FirstName = null;
        }

        [TestMethod]
        public void SetValidLastNameTest()
        {
            testingUser.LastName = "Santos";
            Assert.AreEqual("Santos", testingUser.LastName);
        }

        [TestMethod]
        public void SetValidLastNameCompoundTest()
        {
            testingUser.LastName = "  García Morales  ";
            Assert.AreEqual("García Morales", testingUser.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidLastNameNumbersTest()
        {
            testingUser.LastName = "5678";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidLastNamePunctuationTest()
        {
            testingUser.LastName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidLastNameEmptyTest()
        {
            testingUser.LastName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidLastNameNullTest()
        {
            testingUser.LastName = null;
        }

        [TestMethod]
        public void SetValidEmailTest()
        {
            testingUser.Email = "sebastian.uriarteg@gmail.com";
            Assert.AreEqual("sebastian.uriarteg@gmail.com", testingUser.Email);
        }

        [TestMethod]
        public void SetValidEmailTrimTest()
        {
            testingUser.Email = "  sdelfinoh@gmail.com  ";
            Assert.AreEqual("sdelfinoh@gmail.com", testingUser.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidEmailWordsTest()
        {
            testingUser.Email = "Universidad ORT Uruguay";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidEmailNoHostTest()
        {
            testingUser.Email = "valid_Beginning@";
        }

        [TestMethod]
        public void SetValidEmailNoDotComTest()
        {
            testingUser.Email = "zaphod@slartibartfast";
            Assert.AreEqual("zaphod@slartibartfast", testingUser.Email);
        }

        [TestMethod]
        public void SetValidEmailNoLettersTest()
        {
            testingUser.Email = "123@$789";
            Assert.AreEqual("123@$789", testingUser.Email);
        }

        [TestMethod]
        public void SetValidEmailUnexpectedCharactersTest()
        {
            testingUser.Email = "!$A_b.%c=d*-ef@ex^am#pl-e.com";
            Assert.AreEqual("!$A_b.%c=d*-ef@ex^am#pl-e.com", testingUser.Email);
        }

        [TestMethod]
        public void SetValidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(1995, 10, 27);
            testingUser.Birthdate = birthdateToSet;
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
        }

        [TestMethod]
        public void SetValidBirthdateCloseTest()
        {
            DateTime birthdateToSet = new DateTime(2017, 4, 17);
            testingUser.Birthdate = birthdateToSet;
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 3, 31);
            testingUser.Birthdate = birthdateToSet;
        }

        [TestMethod]
        public void SetOnlyLettersPasswordTest()
        {
            testingUser.Password = "holaChau";
            Assert.AreEqual("holaChau", testingUser.Password);
        }

        [TestMethod]
        public void SetValidPasswordTest()
        {
            testingUser.Password = "pS8a11";
            Assert.AreEqual("pS8a11", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void SetInvalidPasswordTest()
        {
            testingUser.Password = "pS8a11#.!";
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void SetInvalidPasswordEmptyTest()
        {
            testingUser.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void SetInvalidPasswordNullTest()
        {
            testingUser.Password = null;
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void SetInvalidPasswordTooShortTest()
        {
            testingUser.Password = "pass2";
            Assert.AreEqual("pass2", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void SetInvalidPasswordTooLongTest()
        {
            testingUser.Password = "password201543sdre#ts";
            Assert.AreEqual("password201543sdre#ts", testingUser.Password);
        }

        [TestMethod]
        public void ParameterFactoryMethodValidTest()
        {
            DateTime birthdateToSet = DateTime.Now.Date;
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com",
                birthdateToSet, "contraseñaValida123");
            Assert.AreEqual("Emilio", testingUser.FirstName);
            Assert.AreEqual("Ravenna", testingUser.LastName);
            Assert.AreEqual("ravenna@simuladores.com", testingUser.Email);
            Assert.AreEqual(birthdateToSet, testingUser.Birthdate);
            Assert.AreEqual("contraseñaValida123", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidFirstNameTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("1&6 1a2-*!3", "Ravenna", "ravenna@simuladores.com",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidLastNameTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", ";#d1 -($!#", "ravenna@simuladores.com.ar",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidEmailTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "12! $^#&",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 7, 31);
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com.ar",
                birthdateToSet, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void ParameterFactoryMethodInvalidPasswordTest()
        {
            testingUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com.ar",
                DateTime.Now, "@%^# 521D(%$");
        }

        [TestMethod]
        public void ToStringTest1()
        {
            Assert.AreEqual("Nombre inválido. Apellido inválido. <mailInvalido@usuarioInvalido>",
                testingUser.ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            testingUser.FirstName = "Mario";
            testingUser.LastName = "Santos";
            testingUser.Email = "santos@simuladores.com.ar";
            Assert.AreEqual("Mario Santos <santos@simuladores.com.ar>", testingUser.ToString());
        }

        [TestMethod]
        public void ToStringTest3()
        {
            testingUser.FirstName = "Gabriel";
            testingUser.LastName = "Medina";
            testingUser.Email = "medina@simuladores.com.ar";
            Assert.AreEqual(testingUser.FirstName + " " + testingUser.LastName + " <"
                + testingUser.Email + ">", testingUser.ToString());
        }
    }
}