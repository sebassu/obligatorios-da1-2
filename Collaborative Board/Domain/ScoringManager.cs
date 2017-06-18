﻿using Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class ScoringManager
    {
        private const byte absoluteMinimumScore = 1;

        private int createWhiteboardScore;

        public int CreateWhiteboardScore
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

        public int DeleteWhiteboardScore
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

        public int AddElementScore
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

        public int AddCommentScore
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

        public int SetCommentAsSolvedScore
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

        private ScoringManager()
        {
            createWhiteboardScore = 1;
            deleteWhiteboardScore = 1;
            addElementScore = 1;
            addCommentScore = 1;
            setCommentAsSolvedScore = 1;
        }

        internal static ScoringManager AllScores(int addWhiteboard, int deleteWhiteboard,
            int addElement, int addComment, int setCommentAsSolved)
        {
            return new ScoringManager(addWhiteboard, deleteWhiteboard, addElement, addComment, setCommentAsSolved);
        }

        private ScoringManager(int addWhiteboard, int deleteWhiteboard, 
            int addElement, int addComment, int setCommentAsSolved)
        {
            createWhiteboardScore = addWhiteboard;
            deleteWhiteboardScore = deleteWhiteboard;
            addElementScore = addElement;
            addCommentScore = addComment;
            setCommentAsSolvedScore = setCommentAsSolved;
        }

        public void ResetScores()
        {
            createWhiteboardScore = absoluteMinimumScore;
            deleteWhiteboardScore = absoluteMinimumScore;
            addElementScore = absoluteMinimumScore;
            addCommentScore = absoluteMinimumScore;
            setCommentAsSolvedScore = absoluteMinimumScore;
        }
    }
}
