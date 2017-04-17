using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    public class UserTests
    {
        private static User testingUser;

        [ClassInitialize]
        public void TestSetUp()
        {
            testingUser = new User();
        }

        [TestMethod]
        public void SetValidNameTest()
        {
            testingUser.Name = "Mario";
            Assert.AreEqual("Mario", testingUser.Name);
        }
    }
}
