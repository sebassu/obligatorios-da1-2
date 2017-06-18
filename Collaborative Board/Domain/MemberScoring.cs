using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MemberScoring
    {
        private const byte absoluteMinimumMembersScore = 1;
        public virtual int Id { get; set; }

        private int membersTotalScore;

        public virtual int MembersTotalScore
        {
            get { return membersTotalScore; }
            set
            {
                if (IsValidMembersTotalScore(value))
                {
                    membersTotalScore = value;
                }
            }
        }

        private bool IsValidMembersTotalScore(int score)
        {
            return score >= absoluteMinimumMembersScore;
        }

        public virtual User Member { get; set; }

        public virtual Team MembersTeam { get; set; }

        internal static MemberScoring InstanceForTestingPurposes()
        {
            return new MemberScoring();
        }

        public MemberScoring()
        {
            Member = User.InstanceForTestingPurposes();
            MembersTeam = Team.InstanceForTestingPurposes();
            membersTotalScore = int.MaxValue;
        }

        public static MemberScoring MemberMembersTeamMembersTotalScore(User theMember,
            Team theMembersTeam, int membersScore)
        {
            return new MemberScoring(theMember, theMembersTeam, membersScore);
        }

        public MemberScoring(User theMember, Team theMembersTeam, int membersScore)
        {
            Member = theMember;
            MembersTeam = theMembersTeam;
            MembersTotalScore = membersScore;
            }





    }

}
