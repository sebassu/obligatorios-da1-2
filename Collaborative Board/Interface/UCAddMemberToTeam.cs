using System;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace GraphicInterface
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
            var globalUsers = UserRepository.GetInstance().Elements;
            var notMembersOfTeam = globalUsers.Where(u => !teamToWorkWith.Members.Contains(u)).ToList();
            if (Utilities.IsEmpty(notMembersOfTeam))
            {
                lstUsers.Items.Add(new ListViewItem("No existen usuarios no miembros del equipo."));
                btnAccept.Enabled = false;
            }
            else
            {
                foreach (User oneUser in notMembersOfTeam)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString()) { Tag = oneUser };
                    lstUsers.Items.Add(itemToAdd);
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