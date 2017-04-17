using Domain;
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
            testingUser.Name = "Mario";
            Assert.AreEqual("Mario", testingUser.Name);
        }

        [TestMethod]
        public void SetValidName2Test()
        {
            testingUser.Name = "Gabriel";
            Assert.AreEqual("Gabriel", testingUser.Name);
        }
    }
}
