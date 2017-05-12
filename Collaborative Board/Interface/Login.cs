using System;
using System.Windows.Forms;
using Persistence;
using Exceptions;

namespace Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                AttemptLogin();
                RedirectToCorrectHomeMenu();
                Hide(); 
            }
            catch (BoardException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
            }
        }

        private void AttemptLogin()
        {
            Session.Start(txtEmail.Text, txtPassword.Text);
        }

        private void RedirectToCorrectHomeMenu()
        {
            if (Session.HasAdministrationPrivileges())
            {
                new UserWindow().Show();
            }//hacer else
        }
    }
}
