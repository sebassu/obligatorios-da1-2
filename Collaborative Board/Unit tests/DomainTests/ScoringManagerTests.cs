using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void TeamForTestingPurposesTest()
        {
            Assert.AreEqual(1, testingScoringManager.CreateWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.DeleteWhiteboardScore);
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
            Assert.AreEqual(1, testingScoringManager.AddCommentScore);
            Assert.AreEqual(1, testingScoringManager.SetCommentAsSolvedScore);
        }

        [TestMethod]
        public void TeamSetValidCreateWhiteboardScore()
        {
            testingScoringManager.CreateWhiteboardScore = 10;
            Assert.AreEqual(10, testingScoringManager.CreateWhiteboardScore);
        }

        [TestMethod]
        public void TeamSetValidDeleteWhiteboardScore()
        {
            testingScoringManager.DeleteWhiteboardScore = 50;
            Assert.AreEqual(50, testingScoringManager.DeleteWhiteboardScore);
        }

        [TestMethod]
        public void TeamSetValidAddElementScore()
        {
            testingScoringManager.AddElementScore = 1;
            Assert.AreEqual(1, testingScoringManager.AddElementScore);
        }

        [TestMethod]
        public void TeamSetValidAddCommentScore()
        {
            testingScoringManager.AddCommentScore = 100;
            Assert.AreEqual(100, testingScoringManager.AddCommentScore);
        }

        [TestMethod]
        public void TeamSetValidSetCommentAsSolvedScore()
        {
            testingScoringManager.SetCommentAsSolvedScore = 20;
            Assert.AreEqual(20, testingScoringManager.SetCommentAsSolvedScore);
        }
    }
}
