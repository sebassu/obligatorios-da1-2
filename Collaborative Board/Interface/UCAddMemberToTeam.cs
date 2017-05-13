using System;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace Interface
{
    public partial class UCAddMemberToTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;
        public UCAddMemberToTeam(Panel systemPanel, Team oneTeam)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            this.teamToWorkWith = oneTeam;
            LoadData();
        }

        private void LoadData()
        {
            lblTeamSelected.Text = teamToWorkWith.Name;
            LoadNotMembersOfTeam();
        }

        private void LoadNotMembersOfTeam()
        {
            var globalUsers = UserRepository.GetInstance().Elements.ToList();
            foreach (User oneUser in globalUsers)
            {
                if (!teamToWorkWith.Members.Contains(oneUser))
                {
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString());
                    itemToAdd.Tag = oneUser;
                    lstUsers.Items.Add(itemToAdd);
                }
                if (lstUsers.Items.Count == 0)
                {
                    lstUsers.Items.Add(new ListViewItem("No existen usuarios no miembros del equipo."));
                    btnAccept.Enabled = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerfomAddAction);
        }

        private void PerfomAddAction()
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                User userToAdd = lstUsers.SelectedItems[0].Tag as User;
                TeamRepository globalTeams = TeamRepository.GetInstance();
                globalTeams.AddMemberToTeam(this.teamToWorkWith, userToAdd);
                InterfaceUtilities.SuccesfulOperation();
                InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }
        }
    }
}
