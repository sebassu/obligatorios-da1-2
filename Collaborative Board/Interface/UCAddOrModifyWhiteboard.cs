﻿using System;
using System.Windows.Forms;
using Persistence;
using System.Linq;
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
            if (Utilities.IsNotNull(someWhiteboard))
            {
                whiteboardToModify = someWhiteboard;
                LoadWhiteboardData();
            }
        }

        private void LoadWhiteboardData()
        {
            txtName.Text = whiteboardToModify.Name;
            numWidth.Value = whiteboardToModify.Width;
            numHeight.Value = whiteboardToModify.Height;
            cmbOwnerTeam.SelectedItem = whiteboardToModify.OwnerTeam;
            cmbOwnerTeam.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UCWhiteboardsToPanel();
        }

        private void UCWhiteboardsToPanel()
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCWhiteboards(systemPanel));
        }

        private void UCAddOrModifyWhiteboard_Load(object sender, EventArgs e)
        {
            var globalTeams = TeamRepository.GetInstance();
            cmbOwnerTeam.Items.AddRange(globalTeams.Elements.ToArray());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
        }

        private void PerformChangeAction()
        {
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            int widthToSet = (int)numWidth.Value;
            int heightToSet = (int)numHeight.Value;
            if (Utilities.IsNotNull(whiteboardToModify))
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
            UCWhiteboardsToPanel();
        }
    }
}