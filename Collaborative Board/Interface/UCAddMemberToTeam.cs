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

        public UCAddMemberToTeam(Panel somePanel, Team oneTeam)
        {
            InitializeComponent();
            systemPanel = somePanel;
            teamToWorkWith = oneTeam;
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
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString())
                    {
                        Tag = oneUser
                    };
                    lstUsers.Items.Add(itemToAdd);
                }
                if (lstUsers.Items.Count == 0)
                {
                    lstUsers.Items.Add(new ListViewItem("No existen usuarios no miembros del equipo."));
                    btnAccept.Enabled = false;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Action acceptAction = delegate { InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerfomAddAction); };
            InterfaceUtilities.PerformActionIfElementIsSelected(lstUsers, acceptAction);
        }

        private void PerfomAddAction()
        {
            User userToAdd = lstUsers.SelectedItems[0].Tag as User;
            TeamRepository globalTeams = TeamRepository.GetInstance();
            globalTeams.AddMemberToTeam(teamToWorkWith, userToAdd);
            InterfaceUtilities.UCAdministrateTeamToPanel(systemPanel, teamToWorkWith);
            InterfaceUtilities.SuccessfulOperation();
        }
    }
}