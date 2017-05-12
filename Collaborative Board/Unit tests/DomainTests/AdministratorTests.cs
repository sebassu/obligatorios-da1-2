﻿using System;
using Domain;
using Exceptions;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AdministratorTests
    {
        private static Administrator testingAdministrator;

        [TestInitialize]
        public void TestSetup()
        {
            testingAdministrator = Administrator.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void AdministratorForTestingPurposesTest()
        {
            Assert.AreEqual("Usuario", testingAdministrator.FirstName);
            Assert.AreEqual("inválido.", testingAdministrator.LastName);
            Assert.AreEqual("mailInvalido@usuarioInvalido", testingAdministrator.Email);
            Assert.AreEqual("Contraseña inválida.", testingAdministrator.Password);
        }

        [TestMethod]
        public void AdministratorParameterFactoryMethodValidTest()
        {
            DateTime birthdateToSet = DateTime.Today;
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", birthdateToSet, "contraseñaVálida123");
            Assert.AreEqual("Emilio", testingAdministrator.FirstName);
            Assert.AreEqual("Ravenna", testingAdministrator.LastName);
            Assert.AreEqual("ravenna@simuladores.com", testingAdministrator.Email);
            Assert.AreEqual(birthdateToSet, testingAdministrator.Birthdate);
            Assert.AreEqual("contraseñaVálida123", testingAdministrator.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void AdministratorParameterFactoryMethodInvalidFirstNameTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("1&6 1a2-*!3", "Ravenna",
                "ravenna@simuladores.com", DateTime.Now, "contraseñaVálida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void AdministratorParameterFactoryMethodInvalidLastNameTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", ";#d1 -($!#",
                "ravenna@simuladores.com", DateTime.Now, "contraseñaVálida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void AdministratorParameterFactoryMethodInvalidEmailTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio",
                "Ravenna", "12! $^#&", DateTime.Now, "contraseñaVálida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void AdministratorParameterFactoryMethodInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 7, 31);
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", birthdateToSet, "contraseñaVálida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void AdministratorParameterFactoryMethodInvalidPasswordTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Now, "@%^# 521D(%$");
        }

        [TestMethod]
        public void AdministratorHasAdministratorPrivilegesDefaultTest()
        {
            Assert.IsTrue(testingAdministrator.HasAdministrationPrivileges);
        }

        [TestMethod]
        public void AdministratorHasAdministratorPrivilegesParametersTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Now, "contraseñaVálida123");
            Assert.IsTrue(testingAdministrator.HasAdministrationPrivileges);
        }

        [TestMethod]
        public void AdministratorToStringTest1()
        {
            Assert.AreEqual("Usuario inválido. <mailInvalido@usuarioInvalido> (Admin.)",
                testingAdministrator.ToString());
        }

        [TestMethod]
        public void AdministratorToStringTest2()
        {
            testingAdministrator.FirstName = "Mario";
            testingAdministrator.LastName = "Santos";
            testingAdministrator.Email = "santos@simuladores.com";
            Assert.AreEqual("Mario Santos <santos@simuladores.com> (Admin.)", testingAdministrator.ToString());
        }

        [TestMethod]
        public void AdministratorToStringTest3()
        {
            testingAdministrator.FirstName = "Gabriel";
            testingAdministrator.LastName = "Medina";
            testingAdministrator.Email = "medina@simuladores.com";
            Assert.AreEqual(testingAdministrator.FirstName + " " + testingAdministrator.LastName + " <"
                + testingAdministrator.Email + "> (Admin.)", testingAdministrator.ToString());
        }

        [TestMethod]
        public void AdministratorResetPasswordTest()
        {
            string resultObtained = testingAdministrator.ResetPassword();
            Assert.AreEqual(resultObtained, testingAdministrator.Password);
        }

        [TestMethod]
        public void AdministratorResetPasswordRandomnessTest()
        {
            string firstResultObtained = testingAdministrator.ResetPassword();
            Thread.Sleep(15);
            string secondResultObtained = testingAdministrator.ResetPassword();
            Assert.AreNotEqual(firstResultObtained, secondResultObtained);
        }
    }
}