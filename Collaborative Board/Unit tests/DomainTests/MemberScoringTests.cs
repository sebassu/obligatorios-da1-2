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

        [TestMethod]
        public void MemberScoringCreationValidTest()
        {
            User member = User.InstanceForTestingPurposes();
            Team membersTeam = Team.InstanceForTestingPurposes();
            membersTeam.AddMember(member);
            testingMemberScoring = MemberScoring.MemberTeam(member, membersTeam);
            Assert.AreEqual(member, testingMemberScoring.Member);
            Assert.AreEqual(membersTeam, testingMemberScoring.MembersTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringUserNotInTeamTest()
        {
            User member = User.CreateNewCollaborator("No", "Pertenece",
                "mail@nopertenece.com", DateTime.Today, "contraseñaVálida123");
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberTeam(member, membersTeam);
            Assert.AreEqual(member, testingMemberScoring.Member);
            Assert.AreEqual(membersTeam, testingMemberScoring.MembersTeam);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringNullTeamTest()
        {
            User member = User.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberTeam(member, null);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringNullUserTest()
        {
            Team membersTeam = Team.InstanceForTestingPurposes();
            testingMemberScoring = MemberScoring.MemberTeam(null, membersTeam);
        }

        [TestMethod]
        public void MemberScoringSetScorePositiveValidTest()
        {
            testingMemberScoring.MembersTotalScore = 139;
            Assert.AreEqual(139, testingMemberScoring.MembersTotalScore);
        }

        [TestMethod]
        public void MemberScoringSetScoreZeroValidTest()
        {
            testingMemberScoring.MembersTotalScore = 0;
            Assert.AreEqual(0, testingMemberScoring.MembersTotalScore);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MemberScoringSetScoreNegativeInvalidTest()
        {
            testingMemberScoring.MembersTotalScore = -2378;
        }
    }
}
