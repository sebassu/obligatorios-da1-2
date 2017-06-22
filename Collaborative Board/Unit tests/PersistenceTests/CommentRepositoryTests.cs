using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CommentRepositoryTests
    {
        [TestClass]
        public class ElementRepositoryTests
        {
            private static User aragorn;
            private static User gimli;
            private static User gandalf;
            private static Team fellowship;
            private static ElementWhiteboard testingElement;

            [ClassInitialize]
            public static void ClassSetup(TestContext context)
            {
                UserRepository.InsertOriginalSystemAdministrator();
                ChangeActiveUser("administrator@tf2.com", "Victory");
                AddTestingUsers();
                AddTestingTeam();
                AddTestingElement();
            }

            private static void AddTestingUsers()
            {
                aragorn = UserRepository.AddNewUser("Aragorn", "son of Arathorn",
                    "aragorn@fellowship.com", DateTime.Today, "YouHaveMySword");
                gimli = UserRepository.AddNewUser("Gimli", "son of Gloin",
                    "gimli@fellowship.com", DateTime.Today, "AndMyAxe");
                gandalf = UserRepository.AddNewAdministrator("Gandalf", "the Gray",
                    "gandalf@istari.com", DateTime.Today, "YouShallNotPass");
            }

            private static void AddTestingTeam()
            {
                fellowship = TeamRepository.AddNewTeam("Fellowship of the Ring", "One does not simply" +
                    " walk into Mordor.", 9);
                TeamRepository.AddMemberToTeam(fellowship, aragorn);
                TeamRepository.AddMemberToTeam(fellowship, gimli);
            }

            private static void AddTestingElement()
            {
                Whiteboard container = WhiteboardRepository.AddNewWhiteboard("Isengard", "Where they" +
                    " are taking the hobbits to.", fellowship, 1200, 900);
                testingElement = ElementRepository.AddNewTextBox(container);
            }

            [TestInitialize]
            public void TestSetup()
            {
                ChangeActiveUser("aragorn@fellowship.com", "YouHaveMySword");
            }

            private static void ChangeActiveUser(string email, string password)
            {
                Session.End();
                Session.Start(email, password);
            }

            [TestMethod]
            public void CRepositoryAddNewCommentValidTest()
            {
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "Evil there");
                Assert.AreEqual(aragorn.Email, addedComment.CreatorEmail);
                CollectionAssert.Contains(testingElement.Comments.ToList(), addedComment);
            }

            [TestMethod]
            public void CRepositoryAddNewCommentAsUserValidTest()
            {
                ChangeActiveUser("gimli@fellowship.com", "AndMyAxe");
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "that");
                Assert.AreEqual(gimli.Email, addedComment.CreatorEmail);
                CollectionAssert.Contains(testingElement.Comments.ToList(), addedComment);
            }

            [TestMethod]
            public void CRepositoryAddNewCommentAsRandomUserValidTest()
            {
                ChangeActiveUser("gandalf@istari.com", "YouShallNotPass");
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "does not sleep.");
                Assert.AreEqual(gandalf.Email, addedComment.CreatorEmail);
                CollectionAssert.Contains(testingElement.Comments.ToList(), addedComment);
            }

            [TestMethod]
            public void CRepositoryResolveCommentValidTest()
            {
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "They are taking");
                CommentRepository.ResolveComment(addedComment);
                Assert.AreEqual(aragorn.Email, addedComment.ResolverEmail);
            }

            [TestMethod]
            public void CRepositoryResolveCommentAsUserValidTest()
            {
                ChangeActiveUser("gimli@fellowship.com", "AndMyAxe");
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "the hobbits");
                CommentRepository.ResolveComment(addedComment);
                Assert.AreEqual(gimli.Email, addedComment.ResolverEmail);
            }

            [TestMethod]
            public void CRepositoryResolveCommentAsRandomUserValidTest()
            {
                ChangeActiveUser("gandalf@istari.com", "YouShallNotPass");
                Comment addedComment = CommentRepository.AddNewComment(testingElement, "to Isengard!");
                CommentRepository.ResolveComment(addedComment);
                Assert.AreEqual(gandalf.Email, addedComment.ResolverEmail);
            }
        }
    }
}
