using Domain;
using Persistence;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class ElementComments : Form
    {
        private ElementWhiteboard selectedElement;

        public ElementComments(ElementWhiteboard someElement)
        {
            InitializeComponent();
            selectedElement = someElement;
            ElementRepository.LoadComments(someElement);
        }

        private void BtnAddComment_Click(object sender, EventArgs e)
        {
            rtbNewComment.Visible = true;
            btnSaveComment.Visible = true;
            btnAddComment.Visible = false;
        }

        private void BtnSaveComment_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(CreateNewComment);
        }

        private void CreateNewComment()
        {
            ListViewItem itemToAdd = new ListViewItem(rtbNewComment.Text)
            {
                Tag = CommentRepository.AddNewComment(selectedElement,
                rtbNewComment.Text)
            };
            btnSaveComment.Visible = false;
            rtbNewComment.Visible = false;
            btnAddComment.Visible = true;
            lstComments.Items.Add(itemToAdd);
            rtbNewComment.Text = "";
            btnSolve.Enabled = true;
        }

        private void ElementComments_Load(object sender, EventArgs e)
        {
            LoadComments();
        }

        private void LoadComments()
        {
            lstComments.Clear();
            var commentsOfElement = selectedElement.Comments.ToList();
            if (commentsOfElement.Count > 0)
            {
                ProcessComments(commentsOfElement);
            }
            else
            {
                btnSolve.Enabled = false;
            }
        }

        private void ProcessComments(System.Collections.Generic.List<Comment> commentsOfElement)
        {
            foreach (Comment comment in commentsOfElement)
            {
                ListViewItem itemToAdd = new ListViewItem(comment.ToString()) { Tag = comment };
                lstComments.Items.Add(itemToAdd);
                if (comment.IsResolved)
                {
                    itemToAdd.ForeColor = Color.Lime;
                }
            }
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstComments, AttemptToResolveComment);
        }

        private void AttemptToResolveComment()
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(ResolveComment);
        }

        private void ResolveComment()
        {
            ListViewItem selectedItem = lstComments.SelectedItems[0];
            Comment commentToSolve = selectedItem.Tag as Comment;
            CommentRepository.ResolveComment(commentToSolve);
            selectedItem.ForeColor = Color.Lime;
        }
    }
}
