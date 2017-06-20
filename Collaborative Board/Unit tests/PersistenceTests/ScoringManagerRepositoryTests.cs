using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    public class ScoringManagerRepositoryTests
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ScoringManagerRepository.InsertDefaultScores();
            ChangeActiveUser("administrator@tf2.com", "Victory");
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("administrator@tf2.com", "Victory");
        }

        [TestMethod]
        public void SMRepositoryModifyScoresValidTest()
        {
            ScoringManagerRepository.ModifyScores(10, 20, 30, 40, 50);
            ScoringManager actualScores = ScoringManagerRepository.GetScores();
            Assert.AreEqual(10, actualScores.CreateWhiteboardScore);
            Assert.AreEqual(20, actualScores.DeleteWhiteboardScore);
            Assert.AreEqual(30, actualScores.AddElementScore);
            Assert.AreEqual(40, actualScores.AddCommentScore);
            Assert.AreEqual(50, actualScores.SetCommentAsSolvedScore);
        }

        [TestMethod]
        public void SMRepositoryModifyWithSameScoresValidTest()
        {
            ScoringManagerRepository.ModifyScores(1, 1, 1, 1, 1);
            ScoringManager actualScores = ScoringManagerRepository.GetScores();
            Assert.AreEqual(1, actualScores.CreateWhiteboardScore);
            Assert.AreEqual(1, actualScores.DeleteWhiteboardScore);
            Assert.AreEqual(1, actualScores.AddElementScore);
            Assert.AreEqual(1, actualScores.AddCommentScore);
            Assert.AreEqual(1, actualScores.SetCommentAsSolvedScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void SMRepositoryModifyScoresAllZeroInvalidTest()
        {
            ScoringManager actualScores = ScoringManagerRepository.GetScores();
            ScoringManagerRepository.ModifyScores(-1, -1, -1, -1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void SMRepositoryModifyScoresAllNegativeInvalidTest()
        {
            ScoringManager actualScores = ScoringManagerRepository.GetScores();
            ScoringManagerRepository.ModifyScores(-1, -2, -10, -20, -30);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void SMRepositoryModifyScoresOneInvalidTest()
        {
            ScoringManager actualScores = ScoringManagerRepository.GetScores();
            ScoringManagerRepository.ModifyScores(-1, 10, 10, 20, 1);
        }




    }
}
