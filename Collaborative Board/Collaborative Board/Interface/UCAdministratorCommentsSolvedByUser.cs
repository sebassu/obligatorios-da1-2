using System;
using System.Windows.Forms;
using System.Drawing;
using Persistence;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace GraphicInterface
{
    public partial class UCAdministratorCommentsSolvedByUser : UserControl
    {
        private Panel systemPanel;
        private List<Comment> allComments;

        public UCAdministratorCommentsSolvedByUser(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            LoadUserComboboxes();
            SetDateTimePickerFormat();
        }

        private void LoadUserComboboxes()
        {

            foreach (var user in UserRepository.Elements)
            {
                cmbCreatorUser.Items.Add(user);
                cmbSolverUser.Items.Add(user);
            }
            cmbCreatorUser.SelectedIndex = 0;
            cmbSolverUser.SelectedIndex = 0;
        }

        public void SetDateTimePickerFormat()
        {
            dtpCommentsCreatedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsCreatedUntil.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedUntil.CustomFormat = "dd/MM/yyyy";
        }

        private void UCAdministratorCommentsSolvedByUser_Load(object sender, EventArgs e)
        {
            allComments = CommentRepository.Elements;
            LoadGridViewWithCommentsFilteringBy(allComments, (_ => true));
        }

        private void LoadGridViewWithCommentsFilteringBy(List<Comment> comments, Func<Comment, bool> filteringFunction)
        {
            var commentsToShow = comments.Where(c => filteringFunction(c)).ToList();
            dgvCommentsSolvedByUser.Rows.Clear();
            if (Utilities.IsEmpty(commentsToShow))
            {
                dgvCommentsSolvedByUser.Rows.Add("Sin", "datos", "a", " mostrar.");
            }
            else
            {
                foreach (var comment in commentsToShow)
                {
                    var creationDateToShow = Utilities.GetDateToShow(comment.CreationDate);
                    var resolutionDate = comment.ResolutionDate;
                    var resolutionDateToShow = resolutionDate == Comment.DefaultUnresolvedDate ? "N/A" :
                        Utilities.GetDateToShow(resolutionDate);
                    var creatorToShow = comment.CreatorEmail;
                    var resolverToShow = comment.ResolverEmail;
                    var whiteboardToShow = comment.AssociatedWhiteboard.ToString();
                    dgvCommentsSolvedByUser.Rows.Add(comment.Text, creationDateToShow, creatorToShow,
                        resolverToShow, whiteboardToShow, resolutionDateToShow);
                }
            }
        }

        private void BtnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void BtnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOff();
        }

        private void BtnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadGridViewWithCommentsFilteringBy(allComments,
                (c => FilterByCreatorResolverAndDates(c)));
        }

        private bool FilterByCreatorResolverAndDates(Comment c)
        {
            return FallsBetweenDates(c) && CreatorAndResolverMatchSelection(c);
        }

        private bool CreatorAndResolverMatchSelection(Comment c)
        {
            User selectedCreator = cmbCreatorUser.SelectedItem as User;
            User selectedResolver = cmbSolverUser.SelectedItem as User;
            return selectedCreator.Email.Equals(c.CreatorEmail) &&
                selectedResolver.Email.Equals(c.ResolverEmail);
        }

        private bool FallsBetweenDates(Comment c)
        {
            return c.CreationDate.Date >= dtpCommentsCreatedFrom.Value.Date &&
                c.CreationDate.Date <= dtpCommentsCreatedUntil.Value.Date &&
                c.ResolutionDate.Date >= dtpCommentsCreatedFrom.Value.Date &&
                c.ResolutionDate.Date <= dtpCommentsSolvedUntil.Value.Date;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHome(systemPanel);
        }
    }
}
