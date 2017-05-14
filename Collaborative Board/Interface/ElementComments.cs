using Domain;
using Persistence;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class ElementComments : Form
    {
        private ElementWhiteboard selectedElement;
        public ElementComments(ElementWhiteboard selectedElement)
        {
            InitializeComponent();
            this.selectedElement = selectedElement;
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
                Tag = Comment.CreatorElementText(Session.ActiveUser(),
                selectedElement, rtbNewComment.Text)
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
            var comments = selectedElement.Comments.ToList();
            if (comments.Count > 0)
            {
                foreach (Comment comment in comments)
                {
                    ListViewItem itemToAdd = new ListViewItem(comment.ToString())
                    {
                        Tag = comment
                    };
                    lstComments.Items.Add(itemToAdd);
                    if (comment.IsResolved)
                    {
                        itemToAdd.ForeColor = Color.Lime;
                    }
                }
            }
            else
            {
                btnSolve.Enabled = false;
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
            commentToSolve.Resolve(Session.ActiveUser());
            selectedItem.ForeColor = Color.Lime;
        }
    }
}
