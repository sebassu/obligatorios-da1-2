using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Exceptions;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MemberScoringTests
    {
        private static MemberScoring testingMemberScoring;

        [TestInitialize]
        public void TestSetup()
        {
            testingMemberScoring = MemberScoring.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void MemberScoringForTestingPurposesTest()
        {
            Assert.AreEqual(User.InstanceForTestingPurposes(),
               testingMemberScoring.Member);
            Assert.AreEqual(Team.InstanceForTestingPurposes(),
                testingMemberScoring.MembersTeam);
            Assert.AreEqual(int.MaxValue, testingMemberScoring.MembersTotalScore);
        }
    }
}
