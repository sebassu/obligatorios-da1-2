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
        public void SetValidName1Test()
        {
            testingUser.FirstName = "Mario";
            Assert.AreEqual("Mario", testingUser.FirstName);
        }

        [TestMethod]
        public void SetValidName2Test()
        {
            testingUser.FirstName = "Gabriel";
            Assert.AreEqual("Gabriel", testingUser.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidNameNumbersTest()
        {
            testingUser.FirstName = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidNamePunctuationTest()
        {
            testingUser.FirstName = "!@.$#%   *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidNameEmptyTest()
        {
            testingUser.FirstName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void SetInvalidNameNullTest()
        {
            testingUser.FirstName = null;
        }
    }
}
