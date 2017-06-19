using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System;

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

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringInvalidZeroTotalScoreTest()
        {
            User member = User.InstanceForTestingPurposes();
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberMembersTeamMembersTotalScore(member, 
                membersTeam, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringInvalidNegativeTotalScoreTest()
        {
            User member = User.InstanceForTestingPurposes();
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberMembersTeamMembersTotalScore(member,
                membersTeam, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringUserNotInTeamTest()
        {
            User member = User.CreateNewCollaborator("No", "Pertenece",
                "mail@nopertenece.com", DateTime.Today, "contraseñaVálida123");
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberMembersTeamMembersTotalScore(member,
                membersTeam, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringNullTeamTest()
        {
            User member = User.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberMembersTeamMembersTotalScore(member,
                null, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringNullUserTest()
        {
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberMembersTeamMembersTotalScore(null,
                membersTeam, 20);
        }
    }
}
