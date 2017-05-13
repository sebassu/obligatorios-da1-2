using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace Interface
{
    public partial class UCWhiteboards : UserControl
    {
        private Panel systemPanel;
        public UCWhiteboards(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Gold;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Yellow;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void btnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Gold;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void btnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Yellow;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Gold;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Yellow;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void btnView_MouseEnter(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Gold;
            btnView.Font = new Font(btnView.Font.Name, 19, FontStyle.Bold);
        }

        private void btnView_MouseLeave(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Yellow;
            btnView.Font = new Font(btnView.Font.Name, 18, FontStyle.Bold);
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHome(systemPanel);
        }

        private void UCWhiteboards_Load(object sender, EventArgs e)
        {
            if (!Session.HasAdministrationPrivileges())
            {
                btnHome.Visible = false;
            }
            LoadRegisteredWhiteboards();
        }

        private void LoadRegisteredWhiteboards()
        {
            lstRegisteredWhiteboards.Clear();
            var globalWhiteboards = WhiteboardRepository.GetInstance().Elements
                .Where(w => ValidateWhiteboardIsToBeShown(w)).ToList();
            if (globalWhiteboards.Count() > 0)
            {
                foreach (Whiteboard oneWhiteboard in globalWhiteboards)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneWhiteboard.ToString());
                    itemToAdd.Tag = oneWhiteboard;
                    lstRegisteredWhiteboards.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstRegisteredWhiteboards.Items.Add(new ListViewItem("No existen pizarrones a mostrar."));
            }
        }

        private bool ValidateWhiteboardIsToBeShown(Whiteboard oneWhiteboard)
        {
            bool whiteboardTeamHasLoggedInUser = oneWhiteboard.OwnerTeam.Members.Contains(Session.ActiveUser());
            return whiteboardTeamHasLoggedInUser || Session.HasAdministrationPrivileges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAddOrModifyWhiteboardToPanel(systemPanel);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lstRegisteredWhiteboards.SelectedItems.Count > 0)
            {
                Whiteboard oneWhiteboard = lstRegisteredWhiteboards.SelectedItems[0].Tag as Whiteboard;
                InterfaceUtilities.UCAddOrModifyWhiteboardToPanel(systemPanel, oneWhiteboard);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformDeleteAction);
        }

        private void PerformDeleteAction()
        {
            if (lstRegisteredWhiteboards.SelectedItems.Count > 0)
            {
                Whiteboard whiteboardToDelete = lstRegisteredWhiteboards.SelectedItems[0].Tag as Whiteboard;
                AskDeleteWhiteboard(whiteboardToDelete);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }
        }

        private void AskDeleteWhiteboard(Whiteboard whiteboardToDelete)
        {
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar el elemento seleccionado?", "Eliminar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteWhiteboard(whiteboardToDelete);
                LoadRegisteredWhiteboards();
            }
        }

        private void DeleteWhiteboard(Whiteboard whiteboardToDelete)
        {
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            globalWhiteboards.Remove(whiteboardToDelete);
        }
    }
}
