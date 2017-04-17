using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    public class UserTests
    {
        private static User testingUser;

        [TestInitialize]
        public void TestSetUp()
        {
            testingUser = new User();
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
            testingUser.FirstName = "!@.$#%   *-/";
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
            testingUser.LastName = "!@.$#%   *-/";
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
    }
}
