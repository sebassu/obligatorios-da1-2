using Domain;
using System;
using Persistence;
using System.Windows.Forms;

namespace GraphicInterface
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
                btnResetPassword.Visible = true;
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
        }

        private void PerformChangeAction()
        {
            if (Utilities.IsNotNull(userToModify))
            {
                UserRepository.ModifyUser(userToModify, txtFirstName.Text, txtLastName.Text,
                    txtEmail.Text, dtpBirthDate.Value, txtPassword.Text);
            }
            else
            {
                CreateNewUser();
            }
            InterfaceUtilities.UCAdministatorUsersToPanel(systemPanel);
            InterfaceUtilities.SuccessfulOperation();
        }

        private void CreateNewUser()
        {
            if (cbxIsAdministrator.Checked)
            {
                UserRepository.AddNewAdministrator(txtFirstName.Text, txtLastName.Text,
                    txtEmail.Text, dtpBirthDate.Value, txtPassword.Text);
            }
            else
            {
                UserRepository.AddNewUser(txtFirstName.Text, txtLastName.Text,
                    txtEmail.Text, dtpBirthDate.Value, txtPassword.Text);
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(ResetUsersPassword);
        }

        private void ResetUsersPassword()
        {
            String newPassWord = UserRepository.ResetUsersPassword(userToModify);
            txtPassword.Text = userToModify.Password;
            MessageBox.Show("La nueva contraseña es: " + newPassWord, "Reseteo de contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
