﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace Interface
{
    public partial class UCAdministratorUsers : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorUsers(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkGreen;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Green;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Green;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.DarkGreen;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void BtnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Green;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void BtnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void BtnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOut();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHome(systemPanel);
        }

        private void UCAdministratorUsers_Load(object sender, EventArgs e)
        {
            LoadRegisteredUsers();
        }

        private void LoadRegisteredUsers()
        {
            lstUsers.Clear();
            var globalUsers = UserRepository.GetInstance().Elements.ToList();
            foreach (User oneUser in globalUsers)
            {
                ListViewItem itemToAdd = new ListViewItem(oneUser.ToString()) { Tag = oneUser };
                lstUsers.Items.Add(itemToAdd);
                if (oneUser.HasAdministrationPrivileges)
                {
                    itemToAdd.ForeColor = Color.Blue;
                }
            }
            if (globalUsers.Count == 1)
            {
                btnDelete.Enabled = false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAddOrModifyUserToPanel(systemPanel);
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                User userToModify = lstUsers.SelectedItems[0].Tag as User;
                InterfaceUtilities.UCAddOrModifyUserToPanel(systemPanel, userToModify);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Action deleteUser = delegate { InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformDeleteAction); };
            InterfaceUtilities.PerformActionIfElementIsSelected(lstUsers, deleteUser);
        }

        private void PerformDeleteAction()
        {
            User userToDelete = lstUsers.SelectedItems[0].Tag as User;
            Action deleteUser = delegate { DeleteUser(userToDelete); };
            InterfaceUtilities.AskForDeletionConfirmationAndExecute(deleteUser);
        }

        private void DeleteUser(User oneUser)
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            globalUsers.Remove(oneUser);
            InterfaceUtilities.SuccessfulOperation();
            if (oneUser.Equals(Session.ActiveUser()))
            {
                InterfaceUtilities.EndSessionAndGoToLogInForm();
            }
            else
            {
                LoadRegisteredUsers();
            }
        }
    }
}