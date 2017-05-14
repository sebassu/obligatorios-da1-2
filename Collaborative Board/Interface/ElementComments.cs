using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            rtbNewComment.Visible = true;
            btnSaveComment.Visible = true;
            btnAddComment.Visible = false;
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            btnSaveComment.Visible = false;
            rtbNewComment.Visible = false;
            btnAddComment.Visible = true;
            ListViewItem itemToAdd = new ListViewItem(rtbNewComment.Text);
            lstComments.Items.Add(rtbNewComment.Text);
            itemToAdd.Tag = Comment.CreatorElementText(Session.ActiveUser(),
                selectedElement, rtbNewComment.Text);
            lstComments.Items.Add(itemToAdd);
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
                        itemToAdd.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                btnSolve.Enabled = false;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstComments, AddNewComment);
        }

        private void AddNewComment()
        {
            ListViewItem selectedItem = lstComments.SelectedItems[0];
            Comment commentToSolve = selectedItem.Tag as Comment;
            commentToSolve.Resolve(Session.ActiveUser());
            selectedItem.ForeColor = Color.Green;
        }
    }
}
