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
using Persistence;

namespace Interface
{
    public partial class UCAddOrModifyTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToModify;

        public UCAddOrModifyTeam(Panel systemPanel, Team oneTeam = null)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            teamToModify = oneTeam;
            if (Utilities.IsNotNull(oneTeam))
            {
                LoadTeamData();
            }
        }

        private void LoadTeamData()
        {
            txtName.Text = teamToModify.Name;
            rtbDescription.Text = teamToModify.Description;
            numMaximumAmmountUsers.Value = teamToModify.MaximumMembers;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UCAdministratorTeamsToPanel();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            TeamRepository globalTeams = TeamRepository.GetInstance();
            int maxUsers = Convert.ToInt32(Math.Round(numMaximumAmmountUsers.Value, 0));
            if (Utilities.IsNotNull(teamToModify))
            {
                globalTeams.ModifyTeam(teamToModify, txtName.Text, rtbDescription.Text , maxUsers);
            }
            else
            {
                globalTeams.AddNewTeam(txtName.Text, rtbDescription.Text, maxUsers);
            }
            UCAdministratorTeamsToPanel();
        }

        private void UCAdministratorTeamsToPanel()
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorTeams(systemPanel));
        }
    }
}
