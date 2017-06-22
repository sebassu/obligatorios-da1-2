using System.Globalization;

namespace Domain
{
    public class ScoringManager
    {
        private const byte absoluteMinimumScore = 0;

        public virtual int Id { get; set; }

        private int createWhiteboardScore;

        public virtual int CreateWhiteboardScore
        {
            get { return createWhiteboardScore; }
            set
            {
                if (IsAllowedScore(value))
                {
                    createWhiteboardScore = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ScoreIsInvalid, value, absoluteMinimumScore);
                    throw new ScoringManagerException(errorMessage);
                }
            }
        }

        private bool IsAllowedScore(int value)
        {
            return (value >= absoluteMinimumScore);
        }

        private int deleteWhiteboardScore;

        public virtual int DeleteWhiteboardScore
        {
            get { return deleteWhiteboardScore; }
            set
            {
                if  (IsAllowedScore(value))
                {
                    deleteWhiteboardScore = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ScoreIsInvalid, value, absoluteMinimumScore);
                    throw new ScoringManagerException(errorMessage);
                }
            }
        }

        private int addElementScore;

        public virtual int AddElementScore
        {
            get { return addElementScore; }
            set
            {
                if (IsAllowedScore(value))
                {
                    addElementScore = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ScoreIsInvalid, value, absoluteMinimumScore);
                    throw new ScoringManagerException(errorMessage);
                }
            }
        }

        private int addCommentScore;

        public virtual int AddCommentScore
        {
            get { return addCommentScore; }
            set
            {
                if (IsAllowedScore(value))
                {
                    addCommentScore = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ScoreIsInvalid, value, absoluteMinimumScore);
                    throw new ScoringManagerException(errorMessage);
                }
            }
        }

        private int setCommentAsSolvedScore;

        public virtual int SetCommentAsSolvedScore
        {
            get { return setCommentAsSolvedScore; }
            set
            {
                if (IsAllowedScore(value))
                {
                    setCommentAsSolvedScore = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ScoreIsInvalid, value, absoluteMinimumScore);
                    throw new ScoringManagerException(errorMessage);
                }
            }
        }

        internal static ScoringManager InstanceForTestingPurposes()
        {
            return new ScoringManager();
        }

        public ScoringManager()
        {
            CreateWhiteboardScore = 1;
            DeleteWhiteboardScore = 1;
            AddElementScore = 1;
            AddCommentScore = 1;
            SetCommentAsSolvedScore = 1;
        }

        public void ModifyAllScores(int addWhiteboard, int deleteWhiteboard,
            int addElement, int addComment, int setCommentAsSolved)
        {
            CreateWhiteboardScore = addWhiteboard;
            DeleteWhiteboardScore = deleteWhiteboard;
            AddElementScore = addElement;
            AddCommentScore = addComment;
            SetCommentAsSolvedScore = setCommentAsSolved;
        }
    }
}
