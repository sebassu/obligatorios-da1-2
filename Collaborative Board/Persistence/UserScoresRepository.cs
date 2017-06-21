using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
    public class UserScoresRepository
    {
        public static void UpdateUserScoreInTeam(int teamId, int scoreIncrement)
        {
            int userId = Session.ActiveUser().Id;
            using (var context = new BoardContext())
            {
                try
                {
                    SetScore(teamId, scoreIncrement, userId, context);
                }
                catch (InvalidOperationException)
                {
                    throw new RepositoryException(ErrorMessages.UserIsNotMemberOfTeam);
                }
            }
        }

        private static void SetScore(int teamId, int scoreIncrement, int userId, BoardContext context)
        {
            MemberScoring score = context.Scores.Single(s => s.MemberId == userId
                && s.MembersTeamId == teamId);
            score.MembersTotalScore += scoreIncrement;
            context.SaveChanges();
        }

        public static List<Tuple<User, int>> GetScoresForTeam(int teamId)
        {
            try
            {
                return ObtainScoresPerUser(teamId);
            }
            catch (InvalidOperationException)
            {
                throw new RepositoryException(ErrorMessages.UserIsNotRegistered);
            }
        }

        private static List<Tuple<User, int>> ObtainScoresPerUser(int teamId)
        {
            List<Tuple<User, int>> result = new List<Tuple<User, int>>();
            List<MemberScoring> scores;
            using (var context = new BoardContext())
            {
                scores = context.Scores.Where(s => s.MembersTeamId == teamId).ToList();
                foreach (var score in scores)
                {
                    User userWithId = context.Users.Find(score.MemberId);
                    result.Add(new Tuple<User, int>(userWithId, score.MembersTotalScore));
                }
            }
            return result;
        }

        public static void ResetTeamScore(int teamId)
        {
            using (var context = new BoardContext())
            {
                var scoresToDelete = context.Scores.Where(t => t.MembersTeamId == teamId);
                foreach (var score in scoresToDelete)
                {
                    score.MembersTotalScore = 0;
                }
                context.SaveChanges();
            }
        }
    }
}
