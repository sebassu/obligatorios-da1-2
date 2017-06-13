using System;
using System.Windows.Forms;
using Persistence;
using Exceptions;

namespace GraphicInterface
{
    public partial class LogOn : Form
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                AttemptLogin();
                new UserWindow().Show();
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
