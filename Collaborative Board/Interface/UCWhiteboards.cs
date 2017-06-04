using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace GraphicInterface
{
    public partial class UCWhiteboards : UserControl
    {
        private Panel systemPanel;

        public UCWhiteboards(Panel somePanel)
        {
            InitializeComponent();
            systemPanel = somePanel;
        }

        private static bool ActiveUserBelongsToAnyTeam()
        {
            TeamRepository globalTeams = TeamRepository.GetInstance();
            User activeUser = Session.ActiveUser();
            return globalTeams.Elements.Any(t => t.Members.Contains(activeUser));
        }

        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Gold;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Yellow;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Gold;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Yellow;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Gold;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Yellow;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnView_MouseEnter(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Gold;
            btnView.Font = new Font(btnView.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnView_MouseLeave(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Yellow;
            btnView.Font = new Font(btnView.Font.Name, 18, FontStyle.Bold);
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

        private void BtnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHomeRespectiveHome(systemPanel);
        }

        private void UCWhiteboards_Load(object sender, EventArgs e)
        {
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
                    ListViewItem itemToAdd = new ListViewItem(oneWhiteboard.ToString()) { Tag = oneWhiteboard };
                    lstRegisteredWhiteboards.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstRegisteredWhiteboards.Items.Add(new ListViewItem("No existen pizarrones a mostrar."));
                btnModify.Enabled = false;
                btnDelete.Enabled = false;
                btnView.Enabled = false;
            }
        }

        private static bool ValidateWhiteboardIsToBeShown(Whiteboard oneWhiteboard)
        {
            bool whiteboardTeamHasLoggedInUser = oneWhiteboard.OwnerTeam.Members.Contains(Session.ActiveUser());
            return whiteboardTeamHasLoggedInUser || Session.HasAdministrationPrivileges();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ActiveUserBelongsToAnyTeam())
            {
                InterfaceUtilities.UCAddOrModifyWhiteboardToPanel(systemPanel);
            }
            else
            {
                InterfaceUtilities.ShowError("Es necesario pertenecer a algún equipo para acceder " +
                    "a esta funcionalidad", "Error");
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstRegisteredWhiteboards, ModifyWhiteboard);
        }

        private void ModifyWhiteboard()
        {
            Whiteboard oneWhiteboard = lstRegisteredWhiteboards.SelectedItems[0].Tag as Whiteboard;
            InterfaceUtilities.UCAddOrModifyWhiteboardToPanel(systemPanel, oneWhiteboard);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstRegisteredWhiteboards, PerformDeleteAction);
        }

        private void PerformDeleteAction()
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(GetWhiteboardAndAttemptToDelete);
        }

        private void GetWhiteboardAndAttemptToDelete()
        {
            Whiteboard whiteboardToDelete = lstRegisteredWhiteboards.SelectedItems[0].Tag as Whiteboard;
            AskDeleteWhiteboard(whiteboardToDelete);
        }

        private void AskDeleteWhiteboard(Whiteboard whiteboardToDelete)
        {
            Action whiteboardDeletion = delegate { DeleteWhiteboard(whiteboardToDelete); };
            InterfaceUtilities.AskForDeletionConfirmationAndExecute(whiteboardDeletion);
        }

        private void DeleteWhiteboard(Whiteboard whiteboardToDelete)
        {
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            globalWhiteboards.Remove(whiteboardToDelete);
            LoadRegisteredWhiteboards();
            InterfaceUtilities.SuccessfulOperation();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstRegisteredWhiteboards, OpenWhiteboardVisualization);
        }

        private void OpenWhiteboardVisualization()
        {
            Whiteboard whiteboardToShow = lstRegisteredWhiteboards.SelectedItems[0].Tag as Whiteboard;
            (new WhiteboardVisualization(whiteboardToShow)).Show();
        }

        private void UCWhiteboards_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCWhiteboardsToPanel(systemPanel);
        }
    }
}
