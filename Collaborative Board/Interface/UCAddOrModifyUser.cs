using Domain;
using System;
using Persistence;
using System.Windows.Forms;

namespace Interface
{
    public partial class UCAddOrModifyUser : UserControl
    {
        private Panel systemPanel;
        private User userToModify;

        public UCAddOrModifyUser(Panel systemPanel, User someUser = null)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            if (Utilities.IsNotNull(someUser))
            {
                userToModify = someUser;
                LoadUserData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministatorUsersToPanel(systemPanel);
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
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
        }

        private void PerformChangeAction()
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
            InterfaceUtilities.UCAdministatorUsersToPanel(systemPanel);
        }
    }
}
