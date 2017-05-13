using System;
using System.Windows.Forms;
using System.Drawing;
using Persistence;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Interface
{
    public partial class UCAdministratorCommentsSolvedByUser : UserControl
    {
        private Panel systemPanel;
        private List<Comment> comments = new List<Comment>();

        public UCAdministratorCommentsSolvedByUser(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            LoadUserComboboxes();
            SetDateTimePickerFormat();
            SetDateTimePickerMinimumValidDates();
        }

        private void LoadUserComboboxes()
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            foreach (var user in globalUsers.Elements)
            {
                cmbCreatorUser.Items.Add(user);
                cmbSolverUser.Items.Add(user);
            }
        }

        public void SetDateTimePickerFormat()
        {
            dtpCommentsCreatedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsCreatedUntil.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedUntil.CustomFormat = "dd/MM/yyyy";
        }

        private void SetDateTimePickerMinimumValidDates()
        {
            dtpCommentsCreatedFrom.MinDate = DateTime.Today;
            dtpCommentsCreatedUntil.MinDate = DateTime.Today;
            dtpCommentsSolvedFrom.MinDate = DateTime.Today;
            dtpCommentsSolvedUntil.MinDate = DateTime.Today;
        }

        private void UCAdministratorCommentsSolvedByUser_Load(object sender, EventArgs e)
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            foreach (var user in globalUsers.Elements)
            {
                comments.AddRange(user.CommentsCreated.Where(c => c.IsResolved));
            }
            LoadGridViewWithCommentsFilteringBy(_ => true);
        }

        private void LoadGridViewWithCommentsFilteringBy(Func<Comment, bool> filteringFunction)
        {
            var commentsToShow = comments.Where(c => filteringFunction(c)).ToList();
            if (commentsToShow.Count == 0)
            {
                dgvCommentsSolvedByUser.Rows.Add("Sin", "datos", "a", " mostrar.");
            }
            else
            {
                foreach (var comment in commentsToShow)
                {
                    var creationDateToShow = InterfaceUtilities.GetDateToShow(comment.CreationDate);
                    var resolutionDateToShow = InterfaceUtilities.GetDateToShow(comment.ResolutionDate());
                    var creatorToShow = comment.Creator.Email;
                    var resolverToShow = comment.Resolver.Email;
                    var whiteboardToShow = comment.AssociatedWhiteboard.ToString();
                    dgvCommentsSolvedByUser.Rows.Add(comment.Text, creationDateToShow, creatorToShow,
                        resolverToShow, whiteboardToShow, resolutionDateToShow);
                }
            }
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOut();
        }

        private void btnApllyFilters_Click(object sender, EventArgs e)
        {
            LoadGridViewWithCommentsFilteringBy(c => FilterByCreatorResolverAndDates(c));
        }

        private bool FilterByCreatorResolverAndDates(Comment c)
        {
            return FallsBetweenDates(c) && CreatorAndResolverMatchSelection(c);
        }

        private bool CreatorAndResolverMatchSelection(Comment c)
        {
            User selectedCreator = cmbCreatorUser.SelectedValue as User;
            User selectedResolver = cmbSolverUser.SelectedValue as User;
            return selectedCreator.Equals(c.Creator) &&
                selectedResolver.Equals(c.Resolver);
        }

        private bool FallsBetweenDates(Comment c)
        {
            return c.CreationDate >= dtpCommentsCreatedFrom.Value.Date &&
                c.CreationDate <= dtpCommentsCreatedUntil.Value.Date &&
                c.ResolutionDate() >= dtpCommentsCreatedFrom.Value.Date &&
                c.ResolutionDate() <= dtpCommentsSolvedUntil.Value.Date;
        }
    }
}
