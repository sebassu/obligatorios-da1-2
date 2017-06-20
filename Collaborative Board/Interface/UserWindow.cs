using Persistence;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
            pnlSystem.Controls.Clear();
            if (Session.HasAdministrationPrivileges())
            {
                pnlSystem.Controls.Add(new UCAdministratorHome(pnlSystem));
            }
            else
            {
                pnlSystem.Controls.Add(new UCUserHome(pnlSystem));
            }
            

        }

        private void UserWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PnlSystem_Click(object sender, System.EventArgs e)
        {
            Activate();
        }
    }
}
