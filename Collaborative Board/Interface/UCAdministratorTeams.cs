using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace GraphicInterface
{
    public partial class UCAdministratorTeams : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorTeams(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Maroon;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.DarkRed;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Maroon;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.DarkRed;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Maroon;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnAdministrate_MouseEnter(object sender, EventArgs e)
        {
            btnAdministrate.BackColor = Color.Maroon;
            btnAdministrate.Font = new Font(btnAdministrate.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnAdministrate_MouseLeave(object sender, EventArgs e)
        {
            btnAdministrate.BackColor = Color.DarkRed;
            btnAdministrate.Font = new Font(btnAdministrate.Font.Name, 18, FontStyle.Bold);
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
            InterfaceUtilities.GoToHome(systemPanel);
        }

        private void UCAdministratorTeams_Load(object sender, EventArgs e)
        {
            LoadRegisteredTeams();
        }

        private void LoadRegisteredTeams()
        {
            lstTeams.Clear();
            var globalTeams = TeamRepository.Elements.ToList();
            if (globalTeams.Count() > 0)
            {
                foreach (Team oneTeam in globalTeams)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneTeam.ToString()) { Tag = oneTeam };
                    lstTeams.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstTeams.Items.Add(new ListViewItem("No existen equipos registrados."));
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnAdministrate.Enabled = false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAddOrModifyTeamToPanel(systemPanel);
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (lstTeams.SelectedItems.Count > 0)
            {
                Team teamToModify = lstTeams.SelectedItems[0].Tag as Team;
                InterfaceUtilities.UCAddOrModifyTeamToPanel(systemPanel, teamToModify);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Action deleteTeam = delegate { InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformDeleteAction); };
            InterfaceUtilities.PerformActionIfElementIsSelected(lstTeams, deleteTeam);
        }

        private void PerformDeleteAction()
        {
            Team teamToDelete = lstTeams.SelectedItems[0].Tag as Team;
            AskDeleteTeam(teamToDelete);
        }

        private void AskDeleteTeam(Team teamToDelete)
        {
            Action deleteTeam = delegate { DeleteTeam(teamToDelete); };
            InterfaceUtilities.AskForDeletionConfirmationAndExecute(deleteTeam);
        }

        private void DeleteTeam(Team oneTeam)
        {
            TeamRepository.Remove(oneTeam);
            LoadRegisteredTeams();
            InterfaceUtilities.SuccessfulOperation();
        }

        private void BtnAdministrate_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstTeams, OpenAdministrateTeam);
        }

        private void OpenAdministrateTeam()
        {
            Team teamToVisualize = lstTeams.SelectedItems[0].Tag as Team;
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToVisualize);
        }
    }
}
