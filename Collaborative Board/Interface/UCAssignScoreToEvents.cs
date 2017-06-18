using System;
using System.Windows.Forms;
using Domain;

namespace GraphicInterface
{
    public partial class UCAssignScoreToEvents : UserControl
    {
        private Panel systemPanel;
        private ScoringManager scores;
        public UCAssignScoreToEvents(Panel somePanel, ScoringManager theScores)
        {
            InitializeComponent();
            systemPanel = somePanel;
            scores = theScores;
            if (!IsDefaultScoring())
            {
                LoadScoreData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCScoreMenuToPanel(systemPanel);
        }

        private bool IsDefaultScoring()
        {
            return ((scores.CreateWhiteboardScore == 1) && (scores.DeleteWhiteboardScore == 1) && (scores.AddElementScore == 1)
                && (scores.AddCommentScore == 1) && (scores.SetCommentAsSolvedScore == 1));
        }

        private void LoadScoreData()
        {
            numCreateWhiteboard.Value = scores.CreateWhiteboardScore;
            numDeleteWhiteboard.Value = scores.DeleteWhiteboardScore;
            numAddElement.Value = scores.AddElementScore;
            numAddComment.Value = scores.AddCommentScore;
            numMarkCommentAsSolved.Value = scores.SetCommentAsSolvedScore;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
        }

        private void PerformChangeAction()
        {
            int changeCreateWhiteboard = Convert.ToInt32(Math.Round(numCreateWhiteboard.Value, 0));
            int changeDeleteWhiteboard = Convert.ToInt32(Math.Round(numDeleteWhiteboard.Value, 0));
            int changeAddElement = Convert.ToInt32(Math.Round(numAddElement.Value, 0));
            int changeAddComment = Convert.ToInt32(Math.Round(numAddComment.Value, 0));
            int changeSetCommentAsSolved = Convert.ToInt32(Math.Round(numMarkCommentAsSolved.Value, 0));
            ScoringManager.AllScores(changeCreateWhiteboard, changeDeleteWhiteboard, changeAddElement, changeAddComment, changeSetCommentAsSolved);
            InterfaceUtilities.UCScoreMenuToPanel(systemPanel);
            InterfaceUtilities.SuccessfulOperation();
        }
    }
}
