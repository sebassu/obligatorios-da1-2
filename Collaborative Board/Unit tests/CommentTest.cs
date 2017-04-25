using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CommentTest
    {
        private static Comment testingComment;

        [TestInitialize]
        public void TestSetUp()
        {
            testingComment = CommentTest.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void CommentSetTextValid()
        {
            string validTextContent = "TODO: Crear la interfaz gráfica.";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        public void UserSetInvalidFirstNameNumbersTest()
        {
            string validTextContent = "123456";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        public void UserSetInvalidFirstNamePunctuationTest()
        {
            string validTextContent = "!@.$#% *-/)(#&^$%^@ !@#";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void UserSetInvalidLastNameEmptyTest()
        {
            testingComment.Text = "";
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void UserSetInvalidLastNameNullTest()
        {
            testingComment.Text = null;
        }
    }
}
