using Exceptions;
using System.Globalization;

namespace Domain
{
    public class ScoringManager
    {
        private const byte absoluteMinimumScore = 1;

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
            createWhiteboardScore = 1;
            deleteWhiteboardScore = 1;
            addElementScore = 1;
            addCommentScore = 1;
            setCommentAsSolvedScore = 1;
        }

        public static ScoringManager AllScores(int addWhiteboard, int deleteWhiteboard,
            int addElement, int addComment, int setCommentAsSolved)
        {
            return new ScoringManager(addWhiteboard, deleteWhiteboard, addElement, addComment, setCommentAsSolved);
        }

        public ScoringManager(int addWhiteboard, int deleteWhiteboard, 
            int addElement, int addComment, int setCommentAsSolved)
        {
            createWhiteboardScore = addWhiteboard;
            deleteWhiteboardScore = deleteWhiteboard;
            addElementScore = addElement;
            addCommentScore = addComment;
            setCommentAsSolvedScore = setCommentAsSolved;
        }
    }
}
