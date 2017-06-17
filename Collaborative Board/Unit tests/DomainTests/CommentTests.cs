using System;
using Domain;
using Exceptions;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CommentTests
    {
        private static Comment testingComment;
        private static readonly ElementWhiteboard testingElement =
            ImageWhiteboard.InstanceForTestingPurposes();

        [TestInitialize]
        public void TestSetup()
        {
            testingComment = Comment.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void CommentForTestingPurposesTest()
        {
            Assert.AreEqual(User.InstanceForTestingPurposes(),
                testingComment.Creator);
            Assert.AreEqual("Comentario inválido.", testingComment.Text);
            Assert.IsFalse(testingComment.IsResolved);
            Assert.IsNull(testingComment.Resolver);
            Assert.IsNotNull(testingComment.AssociatedElement);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest1()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
            Assert.AreEqual(testingElement, testingComment.AssociatedElement);
            Assert.AreEqual(testingElement.Container,
                testingComment.AssociatedWhiteboard);
            Assert.IsFalse(testingComment.IsResolved);
        }

        [TestMethod]
        public void CommentParameterFactoryMethodValidTest2()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.CreateNewCollaborator("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "contraseñaVálida123");
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Assert.AreEqual(creator, testingComment.Creator);
            Assert.AreEqual(someText, testingComment.Text);
            Assert.AreEqual(testingElement.Container,
                testingComment.AssociatedWhiteboard);
            Assert.IsFalse(testingComment.IsResolved);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodInvalidTextTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorElementText(creator, testingElement,
                " \n\n  \t\t \n\t  ");
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodNullTextTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorElementText(creator,
                testingElement, null);
        }

        [TestMethod]
        [ExpectedException(typeof(CommentException))]
        public void CommentParameterFactoryMethodNullCreatorTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            testingComment = Comment.CreatorElementText(null,
                testingElement, someText);
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
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate.Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
        }

        [TestMethod]
        public void CommentResolutionValidTest2()
        {
            User aUser = User.CreateNewCollaborator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate.Date);
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
        public void CommentResolveResolvedCommentSameUserInvalidTest()
        {
            User aUser = User.InstanceForTestingPurposes();
            testingComment.Resolve(aUser);
            Assert.IsTrue(testingComment.IsResolved);
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate.Date);
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
            Assert.AreEqual(DateTime.Today, testingComment.ResolutionDate.Date);
            Assert.AreEqual(testingComment.Resolver, aUser);
            CollectionAssert.Contains(aUser.CommentsResolved.ToList(), testingComment);
            User differentUser = User.CreateNewCollaborator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            testingComment.Resolve(differentUser);
        }

        [TestMethod]
        public void CommentGetHashCodeTest()
        {
            object testingCommentAsObject = testingComment;
            Assert.AreEqual(testingCommentAsObject.GetHashCode(), testingComment.GetHashCode());
        }

        [TestMethod]
        public void CommentEqualsReflexiveValidTest()
        {
            Assert.AreEqual(testingComment, testingComment);
        }

        [TestMethod]
        public void CommentEqualsDifferentTypesInvalidTest()
        {
            object differentObject = new object();
            Assert.AreNotEqual(testingComment, differentObject);
            Assert.AreNotEqual(differentObject, testingComment);
        }

        [TestMethod]
        public void CommentEqualsDifferentCreatorsInvalidTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.InstanceForTestingPurposes();
            User anotherCreator = User.CreateNewCollaborator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Comment otherTestingComment = Comment.CreatorElementText(anotherCreator,
                testingElement, someText);
            Assert.AreNotEqual(testingComment, otherTestingComment);
        }

        [TestMethod]
        public void CommentEqualsDifferentTextInvalidTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            string someOtherText = "En el habitual espacio lírico";
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Comment otherTestingComment = Comment.CreatorElementText(creator,
                testingElement, someOtherText);
            Assert.AreNotEqual(testingComment, otherTestingComment);
        }

        [TestMethod]
        public void CommentEqualsDifferentDateTimesInvalidTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.InstanceForTestingPurposes();
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Thread.Sleep(50);
            Comment otherTestingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            Assert.AreNotEqual(testingComment, otherTestingComment);
        }

        [TestMethod]
        public void CommentToStringTest()
        {
            string someText = "Falta resolver el issue 12-3.";
            User creator = User.CreateNewCollaborator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "contraseñaVálida123");
            testingComment = Comment.CreatorElementText(creator,
                testingElement, someText);
            string dateShown = DateTime.Now.ToString("d/M/yyyy, h:mm tt", CultureInfo.CurrentCulture);
            Assert.AreEqual("Falta resolver el issue 12-3. <" + dateShown + "> <santos@simuladores.com>",
                testingComment.ToString());
        }

        [TestMethod]
        public void UtilitiesGetDateToShowTest()
        {
            string expectedResult = "N/a";
            Assert.AreEqual(expectedResult, Utilities.GetDateToShow(DateTime.MinValue));
        }
    }
}