using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
    public partial class UCAdministratorHome : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorHome(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnTeams_MouseEnter(object sender, EventArgs e)
        {
            btnTeams.BackColor = Color.Maroon;
            btnTeams.Font = new Font(btnTeams.Font.Name, 19, FontStyle.Bold);
        }

        private void btnTeams_MouseLeave(object sender, EventArgs e)
        {
            btnTeams.BackColor = Color.DarkRed;
            btnTeams.Font = new Font(btnTeams.Font.Name, 18, FontStyle.Bold);

        }

        private void btnInforms_MouseEnter(object sender, EventArgs e)
        {
            btnInforms.BackColor = Color.MidnightBlue;
            btnInforms.Font = new Font(btnInforms.Font.Name, 19, FontStyle.Bold);
        }

        private void btnInforms_MouseLeave(object sender, EventArgs e)
        {
            btnInforms.BackColor = Color.Navy;
            btnInforms.Font = new Font(btnInforms.Font.Name, 18, FontStyle.Bold);
        }

        private void btnWhiteboards_MouseEnter(object sender, EventArgs e)
        {
            btnWhiteboards.BackColor = Color.Gold;
            btnWhiteboards.Font = new Font(btnWhiteboards.Font.Name, 19, FontStyle.Bold);
        }

        private void btnWhiteboards_MouseLeave(object sender, EventArgs e)
        {
            btnWhiteboards.BackColor = Color.Yellow;
            btnWhiteboards.Font = new Font(btnWhiteboards.Font.Name, 18, FontStyle.Bold);
        }

        private void btnUsers_MouseEnter(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.DarkGreen;
            btnUsers.Font = new Font(btnUsers.Font.Name, 19, FontStyle.Bold);
        }

        private void btnUsers_MouseLeave(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.Green;
            btnUsers.Font = new Font(btnUsers.Font.Name, 18, FontStyle.Bold);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOut();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministatorUsersToPanel(systemPanel);
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAdministratorTeamsToPanel(systemPanel);
        }

        private void btnWhiteboards_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCWhiteboardsToPanel(systemPanel);
        }

        private void btnInforms_Click(object sender, EventArgs e)
        {
            new SelectReport(systemPanel).Show();
            systemPanel.Enabled = false;
        }
    }
}
