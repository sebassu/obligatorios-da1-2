using System;
using System.Windows.Forms;
using Domain;  
using Persistence;

namespace Interface
{
    public partial class UCAddOrModifyUser : UserControl
    {
        private Panel systemPanel;
        private User userToModify;
        public UCAddOrModifyUser(Panel systemPanel, User oneUser = null)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            userToModify = oneUser;
            if (Utilities.IsNotNull(oneUser))
            {
                LoadUserData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorUsers(systemPanel));
        }

        private void LoadUserData()
        {
            txtFirstName.Text = userToModify.FirstName;
            txtLastName.Text = userToModify.LastName;
            txtEmail.Text = userToModify.Email;
            txtPassword.Text = userToModify.Password;
            dtpBirthDate.Value = userToModify.Birthdate;
            cbxIsAdministrator.Checked = userToModify.HasAdministrationPrivileges;
            cbxIsAdministrator.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            if (Utilities.IsNotNull(userToModify))
            {
                globalUsers.ModifyUser(userToModify, txtFirstName.Text, txtLastName.Text, 
                    txtEmail.Text, dtpBirthDate.Value, txtPassword.Text);
            }
            else
            {
                globalUsers.AddNewUser(txtFirstName.Text, txtLastName.Text,
                    txtEmail.Text, dtpBirthDate.Value, txtPassword.Text);
            }
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorUsers(systemPanel));
        }
    }
}
