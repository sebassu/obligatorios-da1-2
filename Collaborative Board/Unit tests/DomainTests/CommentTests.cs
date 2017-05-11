using System;
using Domain;
using Exceptions;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests
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
            Assert.IsFalse(testingComment.IsResolved);
            Assert.IsNull(testingComment.Resolver);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest1()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorText(creator, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
            Assert.IsFalse(testingComment.IsResolved);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest2()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingComment = Comment.CreatorText(creator, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
            Assert.IsFalse(testingComment.IsResolved);
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
            Assert.AreEqual(DateTime.Today, testingComment.CreationDate.Date);
        }

        [TestMethod]
        public void CommentResolutionValidTest1()
        {
            User aUser = User.InstanceForTestingPurposes();
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate().Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
        }

        [TestMethod]
        public void CommentResolutionValidTest2()
        {
            User aUser = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate().Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentResolutionNullUserInvalidTest()
        {
            testingComment.Resolve(null);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentResolutionDateOfUnresolvedInvalidTest()
        {
            testingComment.ResolutionDate();
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentResolveResolvedCommentSameUserInvalidTest()
        {
            User aUser = User.InstanceForTestingPurposes();
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate().Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
            testingComment.Resolve(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentResolveResolvedCommentDifferentUserInvalidTest()
        {
            User aUser = User.InstanceForTestingPurposes();
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate().Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
            User differentUser = User.NamesEmailBirthdatePassword("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaValida123");
            testingComment.Resolve(differentUser);
        }
    }
}