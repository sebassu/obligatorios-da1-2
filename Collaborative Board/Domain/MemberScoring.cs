using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Domain
{
    public class MemberScoring
    {
        private const byte absoluteMinimumMembersScore = 0;
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
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.MembersScoreIsInvalid, value, absoluteMinimumMembersScore);
                    throw new MemberScoringException(errorMessage);
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
            if (UserIsValidMemberOfTeam(theMember, theMembersTeam))
            {
                Member = theMember;
                MembersTeam = theMembersTeam;
                MembersTotalScore = membersScore;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                   ErrorMessages.MemberIsInvalid, theMember, theMembersTeam);
                throw new MemberScoringException(errorMessage);
            }
        }

        private static bool UserIsValidMemberOfTeam(User aMember, Team aTeam)
        {
            if (Utilities.IsNotNull(aMember))
            {
                if (Utilities.IsNotNull(aTeam))
                {
                    return aTeam.Members.Contains(aMember);
                }
                else
                {
                    throw new MemberScoringException(ErrorMessages.TeamIsInvalid);
                }
            }
            else
            {
                throw new MemberScoringException(ErrorMessages.NullUser);
            }
        }





    }

}
