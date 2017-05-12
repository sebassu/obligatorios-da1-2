﻿using System;
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
    public partial class UCAdministratorUsers : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorUsers(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkGreen;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Green;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Green;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void btnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.DarkGreen;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void btnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Green;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskExitApplication();
        }

        private void btnHome_Click(object sender, EventArgs e)
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
            if (globalUsers.Count() > 0)
            {
                foreach (User oneUser in globalUsers)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneUser.ToString());
                    itemToAdd.Tag = oneUser;
                    lstUsers.Items.Add(itemToAdd);
                    if (oneUser.HasAdministrationPrivileges)
                    {
                        itemToAdd.ForeColor = Color.Blue;
                    }
                }
            }
            else
            {
                lstUsers.Items.Add(new ListViewItem("No existen usuarios registrados."));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel));
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            User userToModify = lstUsers.SelectedItems[0].Tag as User;
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel, userToModify));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            User userToDelete = lstUsers.SelectedItems[0].Tag as User;
            if (Utilities.IsNotNull(userToDelete))
            {
                AskDeleteUser(userToDelete);
            }
        }

        private void AskDeleteUser(User oneUser)
        {
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar el elemento seleccionado?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteUser(oneUser);
                LoadRegisteredUsers();
            }

        }

        private void DeleteUser(User oneUser)
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            globalUsers.Remove(oneUser);
        }
        
    }
}
