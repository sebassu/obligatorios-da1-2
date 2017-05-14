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

        public UCAddOrModifyUser(Panel somePanel, User someUser = null)
        {
            InitializeComponent();
            systemPanel = somePanel;
            if (Utilities.IsNotNull(someUser))
            {
                userToModify = someUser;
                LoadUserData();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
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

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(PerformChangeAction);
            InterfaceUtilities.UCAdministatorUsersToPanel(systemPanel);
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
            InterfaceUtilities.SuccesfulOperation();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            UserRepository globalUsers = UserRepository.GetInstance();
            String newPassWord = globalUsers.ResetUsersPassword(userToModify);
            txtPassword.Text = userToModify.Password;
            DialogResult result = MessageBox.Show("La nueva contraseña es: " + newPassWord, "Reseteo de contraseña",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
