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

        public virtual User Member { get; set; }

        public virtual Team MembersTeam { get; set; }

        protected MemberScoring()
        {
            Member = User.InstanceForTestingPurposes();
            MembersTeam = Team.InstanceForTestingPurposes();
            membersTotalScore = int.MaxValue;
        }

        public static MemberScoring MemberTeam(User someUser,
            Team someTeam)
        {
            return new MemberScoring(someUser, someTeam);
        }

        public MemberScoring(User member, Team someTeam)
        {
            if (UserIsValidMemberOfTeam(member, someTeam))
            {
                Member = member;
                MembersTeam = someTeam;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                   ErrorMessages.MemberIsInvalid, member, someTeam);
                throw new MemberScoringException(errorMessage);
            }
        }

        private static bool UserIsValidMemberOfTeam(User aMember, Team aTeam)
        {
            if (Utilities.IsNotNull(aTeam))
            {
                return UserBelongsToTeam(aMember, aTeam);
            }
            else
            {
                throw new MemberScoringException(ErrorMessages.TeamIsInvalid);
            }
        }

        private static bool UserBelongsToTeam(User aMember, Team aTeam)
        {
            if (Utilities.IsNotNull(aMember))
            {
                return aTeam.Members.Contains(aMember);
            }
            else
            {
                throw new MemberScoringException(ErrorMessages.NullUser);
            }
        }
    }
}