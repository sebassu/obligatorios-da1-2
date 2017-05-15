﻿using System;
using System.Linq;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace Interface
{
    public partial class UCAddOrModifyWhiteboard : UserControl
    {
        private Panel systemPanel;
        private Whiteboard whiteboardToModify;

        public UCAddOrModifyWhiteboard(Panel systemPanel,
            Whiteboard someWhiteboard = null)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            bool isForModification = Utilities.IsNotNull(someWhiteboard);
            if (isForModification)
            {
                whiteboardToModify = someWhiteboard;
                InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(
                    LoadWhiteboardData);
            }
            else
            {
                InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(
                    LoadTeamComboboxWithActiveUsersTeams);
            }
            cmbOwnerTeam.SelectedIndex = 0;
        }

        private void LoadWhiteboardData()
        {
            txtName.Text = whiteboardToModify.Name;
            numWidth.Value = whiteboardToModify.Width;
            numHeight.Value = whiteboardToModify.Height;
            rtbDescription.Text = whiteboardToModify.Description;
            cmbOwnerTeam.Items.Add(whiteboardToModify.OwnerTeam);
            cmbOwnerTeam.Enabled = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCWhiteboardsToPanel(systemPanel);
        }

        private void LoadTeamComboboxWithActiveUsersTeams()
        {
            var globalTeams = TeamRepository.GetInstance();
            var activeUser = Session.ActiveUser();
            var teamsToShow = globalTeams.Elements.Where(t => t.Members.Contains(activeUser));
            cmbOwnerTeam.Items.AddRange(teamsToShow.ToArray());
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
        }

        private void PerformChangeAction()
        {
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            int widthToSet = (int)numWidth.Value;
            int heightToSet = (int)numHeight.Value;
            bool isForModification = Utilities.IsNotNull(whiteboardToModify);
            if (isForModification)
            {
                globalWhiteboards.ModifyWhiteboard(whiteboardToModify, txtName.Text,
                    rtbDescription.Text, widthToSet, heightToSet);
            }
            else
            {
                Team teamToSet = cmbOwnerTeam.SelectedItem as Team;
                globalWhiteboards.AddNewWhiteboard(txtName.Text,
                    rtbDescription.Text, teamToSet, widthToSet, heightToSet);
            }
            InterfaceUtilities.UCWhiteboardsToPanel(systemPanel);
            InterfaceUtilities.SuccessfulOperation();
        }
    }
}