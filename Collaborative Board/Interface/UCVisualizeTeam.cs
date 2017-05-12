using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Interface
{
    public partial class UCVisualizeTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;
        public UCVisualizeTeam(Panel systemPanel, Team oneTeam)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            this.teamToWorkWith = oneTeam;
            txtTeam.Text = oneTeam.Name;
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
            InterfaceUtilities.AskExitApplication();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorTeams(systemPanel));
        }
    }
}
