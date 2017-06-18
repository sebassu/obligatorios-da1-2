using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class ScoringManager
    {
        private int createWhiteboardScore;

        public int CreateWhiteboardScore
        {
            get { return createWhiteboardScore; }
            set
            {
                if (value > 1)
                {
                    createWhiteboardScore = value;
                }
            }
        }

        private int deleteWhiteboardScore;

        public int DeleteWhiteboardScore
        {
            get { return deleteWhiteboardScore; }
            set
            {
                if (value > 1)
                {
                    deleteWhiteboardScore = value;
                }
            }
        }

        private int addElementScore;

        public int AddElementScore
        {
            get { return addElementScore; }
            set
            {
                if (value > 1)
                {
                    addElementScore = value;
                }
            }
        }

        private int addCommentScore;

        public int AddCommentScore
        {
            get { return addCommentScore; }
            set
            {
                if (value > 1)
                {
                    addCommentScore = value;
                }
            }
        }

        private int setCommentAsSolvedScore;

        public int SetCommentAsSolvedScore
        {
            get { return setCommentAsSolvedScore; }
            set
            {
                if (value > 1)
                {
                    setCommentAsSolvedScore = value;
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

    }
}
