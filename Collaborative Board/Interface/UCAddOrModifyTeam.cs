using System;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace GraphicInterface
{
    public partial class UCAddOrModifyTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToModify;

        public UCAddOrModifyTeam(Panel somePanel, Team oneTeam = null)
        {
            InitializeComponent();
            systemPanel = somePanel;
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
        }

        private void PerformChangeAction()
        {
            int maxUsers = Convert.ToInt32(Math.Round(numMaximumAmmountUsers.Value, 0));
            if (Utilities.IsNotNull(teamToModify))
            {
                TeamRepository.ModifyTeam(teamToModify, txtName.Text, rtbDescription.Text, maxUsers);
            }
            else
            {
                TeamRepository.AddNewTeam(txtName.Text, rtbDescription.Text, maxUsers);
            }
            InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
            InterfaceUtilities.SuccessfulOperation();
        }
    }
}
