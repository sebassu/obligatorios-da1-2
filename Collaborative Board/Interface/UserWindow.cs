using Persistence;
using System.Windows.Forms;

namespace Interface
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
                pnlSystem.Controls.Add(new UCWhiteboards(pnlSystem));
            }
            

        }

        private void UserWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
