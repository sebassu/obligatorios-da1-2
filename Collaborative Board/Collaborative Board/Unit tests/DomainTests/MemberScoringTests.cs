﻿using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

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
            testingMemberScoring = MemberScoring.MemberTeam(member.Id, membersTeam.Id);
            Assert.AreEqual(member.Id, testingMemberScoring.MemberId);
            Assert.AreEqual(membersTeam.Id, testingMemberScoring.MembersTeamId);
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