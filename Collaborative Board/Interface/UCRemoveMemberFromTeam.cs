using System;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace GraphicInterface
{
    public partial class UCRemoveMemberFromTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;

        public UCRemoveMemberFromTeam(Panel somePanel, Team oneTeam)
        {
            InitializeComponent();
            systemPanel = somePanel;
            teamToWorkWith = oneTeam;
            LoadData();
        }

        private void LoadData()
        {
            lblTeamSelected.Text = teamToWorkWith.Name;
            LoadMembersOfTeam();
        }

        private void LoadMembersOfTeam()
        {
            if (teamToWorkWith.Members.Count() > 0)
            {
                
                foreach (User oneUser in teamToWorkWith.Members)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString()) { Tag = oneUser };
                    lstUsers.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstUsers.Items.Add(new ListViewItem("No existen equipos registrados."));
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.PerformActionIfElementIsSelected(lstUsers, RemoveMember);
        }

        private void RemoveMember()
        {
            User userToRemove = lstUsers.SelectedItems[0].Tag as User;
            TeamRepository.RemoveMemberFromTeam(teamToWorkWith, userToRemove);
            InterfaceUtilities.SuccessfulOperation();
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
        }
    }
}