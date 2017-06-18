using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;
using Exceptions;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ScoringManagerTests
    {
        private static ScoringManager testingScoringManager;

        [TestInitialize]
        public void TestSetup()
        {
            testingScoringManager = ScoringManager.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ScoringManagerForTestingPurposesTest()
        {
            Assert.AreEqual(1, testingScoringManager.CreateWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.DeleteWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
            Assert.AreEqual(1, testingScoringManager.AddCommentScore);
            Assert.AreEqual(1, testingScoringManager.SetCommentAsSolvedScore);
        }

        [TestMethod]
        public void ScoringManagerSetValidCreateWhiteboardScore()
        {
            testingScoringManager.CreateWhiteboardScore = 10;
            Assert.AreEqual(10, testingScoringManager.CreateWhiteboardScore);
        }

        [TestMethod]
        public void ScoringManagerSetValidDeleteWhiteboardScore()
        {
            testingScoringManager.DeleteWhiteboardScore = 50;
            Assert.AreEqual(50, testingScoringManager.DeleteWhiteboardScore);
        }

        [TestMethod]
        public void ScoringManagerSetValidAddElementScore()
        {
            testingScoringManager.AddElementScore = 1;
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
        }

        [TestMethod]
        public void ScoringManagerSetValidAddCommentScore()
        {
            testingScoringManager.AddCommentScore = 100;
            Assert.AreEqual(100, testingScoringManager.AddCommentScore);
        }

        [TestMethod]
        public void ScoringManagerSetValidSetCommentAsSolvedScore()
        {
            testingScoringManager.SetCommentAsSolvedScore = 20;
            Assert.AreEqual(20, testingScoringManager.SetCommentAsSolvedScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManagerSetInvalidCreateWhiteboardScore()
        {
            testingScoringManager.CreateWhiteboardScore = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManagerSetInvalidDeleteWhiteboardScore()
        {
            testingScoringManager.DeleteWhiteboardScore = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManagerSetInvalidAddElementcore()
        {
            testingScoringManager.AddElementScore = -10;
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManagerSetInvalidAddCommentScore()
        {
            testingScoringManager.AddCommentScore = -20;
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManagerSetInvalidSetCommentAsSolvedScore()
        {
            testingScoringManager.SetCommentAsSolvedScore = -5;
        }

        [TestMethod]
        public void ScoringManagerResetTest()
        {
            testingScoringManager = ScoringManager.AllScores(20, 30, 40, 50, 60);
            testingScoringManager.ResetScores();
            Assert.AreEqual(1, testingScoringManager.CreateWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.DeleteWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
            Assert.AreEqual(1, testingScoringManager.AddCommentScore);
            Assert.AreEqual(1, testingScoringManager.SetCommentAsSolvedScore);
        }
    }
}
