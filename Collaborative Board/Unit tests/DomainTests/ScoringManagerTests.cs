using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void ScoringManageForTestingPurposesTest()
        {
            Assert.AreEqual(1, testingScoringManager.CreateWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.DeleteWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
            Assert.AreEqual(1, testingScoringManager.AddCommentScore);
            Assert.AreEqual(1, testingScoringManager.SetCommentAsSolvedScore);
        }

        [TestMethod]
        public void ScoringManageSetValidCreateWhiteboardScore()
        {
            testingScoringManager.CreateWhiteboardScore = 10;
            Assert.AreEqual(10, testingScoringManager.CreateWhiteboardScore);
        }

        [TestMethod]
        public void ScoringManageSetValidDeleteWhiteboardScore()
        {
            testingScoringManager.DeleteWhiteboardScore = 50;
            Assert.AreEqual(50, testingScoringManager.DeleteWhiteboardScore);
        }

        [TestMethod]
        public void ScoringManageSetValidAddElementScore()
        {
            testingScoringManager.AddElementScore = 1;
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
        }

        [TestMethod]
        public void ScoringManageSetValidAddCommentScore()
        {
            testingScoringManager.AddCommentScore = 100;
            Assert.AreEqual(100, testingScoringManager.AddCommentScore);
        }

        [TestMethod]
        public void ScoringManageSetValidSetCommentAsSolvedScore()
        {
            testingScoringManager.SetCommentAsSolvedScore = 20;
            Assert.AreEqual(20, testingScoringManager.SetCommentAsSolvedScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManageSetInvalidCreateWhiteboardScore()
        {
            testingScoringManager.CreateWhiteboardScore = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ScoringManagerException))]
        public void ScoringManageSetInvalidDeleteWhiteboardScore()
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
        public void ScoringManageResetTest()
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
