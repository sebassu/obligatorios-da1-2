using Domain;
using System.Data.Entity;
using System.Linq;

namespace Persistence
{
    public static class ScoringManagerRepository
    {
        public static void InsertDefaultScores()
        {
            using (var context = new BoardContext())
            {
                var elements = context.GlobalScores;
                if (elements.FirstOrDefault() == null)
                {
                    ScoringManager scoringManagerToAdd = new ScoringManager();
                    elements.Add(scoringManagerToAdd);
                    context.SaveChanges();
                }
            }
        }

        public static void ModifyScores(int createWhiteboardScore, int deleteWhiteboardScore, int addElement,
            int addComment, int setCommentAsSolved)
        {
            Session.ValidateActiveUserHasAdministrationPrivileges();
            AttemptToSetScoringManagerAtributes(createWhiteboardScore, deleteWhiteboardScore, addElement,
                addComment, setCommentAsSolved);
        }

        private static void AttemptToSetScoringManagerAtributes(int createWhiteBoardScore, int deleteWhiteboardScore, int addElement,
            int addComment, int setCommentAsSolved)
        {
            using (var context = new BoardContext())
            {
                var score = context.GlobalScores.Single();
                score.ModifyAllScores(createWhiteBoardScore, deleteWhiteboardScore,
                    addElement, addComment, setCommentAsSolved);
                context.Entry(score).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static ScoringManager GetScores()
        {
            using (var context = new BoardContext())
            {
                var score = context.GlobalScores.Single();
                return score;
            }
        }
    }
}
