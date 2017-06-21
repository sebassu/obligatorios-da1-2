using System.Globalization;

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

        public virtual string MemberId { get; set; }

        public virtual int MembersTeamId { get; set; }

        protected MemberScoring()
        {
            membersTotalScore = int.MaxValue;
        }

        public static MemberScoring MemberTeam(string userId, int teamId)
        {
            return new MemberScoring(userId, teamId);
        }

        public MemberScoring(string someUserId, int someTeamId)
        {
            MemberId = someUserId;
            MembersTeamId = someTeamId;
        }
    }
}