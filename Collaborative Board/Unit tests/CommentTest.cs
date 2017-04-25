using Domain;
using Exceptions;
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
            testingComment = Comment.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void CommentForTestingPurposesTest()
        {
            Assert.AreEqual("Comentario inválido.", testingComment.Text);
        }

        [TestMethod]
        public void CommentSetValidTextTest()
        {
            string validTextContent = "TODO: Crear la interfaz gráfica.";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        public void CommentSetValidTextNumbersTest()
        {
            string validTextContent = "123456";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        public void CommentSetValidTextPunctuationTest()
        {
            string validTextContent = "!@.$#% *-/)(#&^$%^@ !@#";
            testingComment.Text = validTextContent;
            Assert.AreEqual(validTextContent, testingComment.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentSetInvalidTextSpacesTest()
        {
            testingComment.Text = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentSetInvalidTextEmptyTest()
        {
            testingComment.Text = "";
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentSetInvalidTextNullTest()
        {
            testingComment.Text = null;
        }
    }
}
