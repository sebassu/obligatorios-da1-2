using System;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace GraphicInterface
{
    public partial class UCAdministrateTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;
        public UCAdministrateTeam(Panel systemPanel, Team oneTeam)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            this.teamToWorkWith = oneTeam;
            lblTeamSelected.Text = oneTeam.Name;
            TeamRepository.LoadMembers(oneTeam);
            if (oneTeam.Members.Count == 1)
            {
                btnRemoveUser.Enabled = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddMemberToTeam(systemPanel, teamToWorkWith));
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCRemoveMemberFromTeam(systemPanel, teamToWorkWith));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOff();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
        }
    }
}
