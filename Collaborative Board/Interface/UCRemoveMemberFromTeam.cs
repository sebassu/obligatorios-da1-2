﻿using System;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace Interface
{
    public partial class UCRemoveMemberFromTeam : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;
        public UCRemoveMemberFromTeam(Panel systemPanel, Team oneTeam)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            this.teamToWorkWith = oneTeam;
            LoadData();
        }

        private void LoadData()
        {
            txtTeam.Text = teamToWorkWith.Name;
            LoadMembersOfTeam();
        }

        private void LoadMembersOfTeam()
        {
            if (teamToWorkWith.Members.Count() > 0)
            {
                foreach (User oneUser in teamToWorkWith.Members)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString());
                    itemToAdd.Tag = oneUser;
                    lstUsers.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstUsers.Items.Add(new ListViewItem("No existen equipos registrados."));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                User userToRemove = lstUsers.SelectedItems[0].Tag as User;
                TeamRepository globalTeams = TeamRepository.GetInstance();
                globalTeams.RemoveMemberFromTeam(this.teamToWorkWith, userToRemove);
                InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }
        }
    }
}
