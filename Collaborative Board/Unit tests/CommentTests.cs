using System;
using Domain;
using Exceptions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CommentTests
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
            Assert.IsNull(testingComment.Creator);
            Assert.AreEqual("Comentario inválido.", testingComment.Text);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest1()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorText(creator, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest2()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.NamesEmailBirthdatePassword("Emilio", "Ravenna", "ravenna@simuladores.com",
                DateTime.Now.Date, "contraseñaValida123");
            testingComment = Comment.CreatorText(creator, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodInvalidTextTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorText(creator, " \n\n  \t\t \n\t  ");
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodNullTextTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorText(creator, null);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodNullCreatorTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            testingComment = Comment.CreatorText(null, someText);
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

        [TestMethod]
        public void CommentCreationDateTest()
        {
            DateTime todaysDate = DateTime.Now.Date;
            Assert.AreEqual(todaysDate, testingComment.CreationDate.Date);
        }
    }
}