using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AdministratorTests
    {
        private static Administrator testingAdministrator;

        [TestInitialize]
        public void TestSetUp()
        {
            testingAdministrator = Administrator.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void AdministratorForTestingPurposesTest()
        {
            Assert.AreEqual("Nombre inválido.", testingAdministrator.FirstName);
            Assert.AreEqual("Apellido inválido.", testingAdministrator.LastName);
            Assert.AreEqual("mailInvalido@usuarioInvalido", testingAdministrator.Email);
            Assert.AreEqual("Contraseña inválida.", testingAdministrator.Password);
        }

        [TestMethod]
        public void ParameterFactoryMethodValidTest()
        {
            DateTime birthdateToSet = DateTime.Now.Date;
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com",
                birthdateToSet, "contraseñaValida123");
            Assert.AreEqual("Emilio", testingAdministrator.FirstName);
            Assert.AreEqual("Ravenna", testingAdministrator.LastName);
            Assert.AreEqual("ravenna@simuladores.com", testingAdministrator.Email);
            Assert.AreEqual(birthdateToSet, testingAdministrator.Birthdate);
            Assert.AreEqual("contraseñaValida123", testingAdministrator.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidFirstNameTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("1&6 1a2-*!3", "Ravenna", "ravenna@simuladores.com",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidLastNameTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", ";#d1 -($!#", "ravenna@simuladores.com.ar",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidEmailTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna", "12! $^#&",
                DateTime.Now, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void ParameterFactoryMethodInvalidBirthdateTest()
        {
            DateTime birthdateToSet = new DateTime(2112, 7, 31);
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com.ar",
                birthdateToSet, "contraseñaValida123");
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordException))]
        public void ParameterFactoryMethodInvalidPasswordTest()
        {
            testingAdministrator = Administrator.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com.ar",
                DateTime.Now, "@%^# 521D(%$");
        }
    }
}
