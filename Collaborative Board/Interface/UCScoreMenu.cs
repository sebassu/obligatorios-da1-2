using System;
using System.Drawing;
using System.Windows.Forms;
using Persistence;

namespace GraphicInterface
{
    public partial class UCScoreMenu : UserControl
    {
        private Panel systemPanel;
        public UCScoreMenu(Panel somePanel)
        {
            InitializeComponent();
            systemPanel = somePanel;
        }

        private void btnTeamRanking_MouseEnter(object sender, EventArgs e)
        {
            btnTeamRanking.BackColor = Color.DimGray;
            btnTeamRanking.Font = new Font(btnTeamRanking.Font.Name, 16, FontStyle.Bold);
        }

        private void btnTeamRanking_MouseLeave(object sender, EventArgs e)
        {
            btnTeamRanking.BackColor = Color.Gray;
            btnTeamRanking.Font = new Font(btnTeamRanking.Font.Name, 14, FontStyle.Bold);
        }

        private void btnAssignScoreToEvents_MouseEnter(object sender, EventArgs e)
        {
            btnAssignScoreToEvents.BackColor = Color.DimGray;
            btnAssignScoreToEvents.Font = new Font(btnAssignScoreToEvents.Font.Name, 16, FontStyle.Bold);
        }

        private void btnAssignScoreToEvents_MouseLeave(object sender, EventArgs e)
        {
            btnAssignScoreToEvents.BackColor = Color.Gray;
            btnAssignScoreToEvents.Font = new Font(btnAssignScoreToEvents.Font.Name, 14, FontStyle.Bold);
        }

        private void btnResetTeamScore_MouseEnter(object sender, EventArgs e)
        {
            btnResetTeamScore.BackColor = Color.DimGray;
            btnResetTeamScore.Font = new Font(btnResetTeamScore.Font.Name, 16, FontStyle.Bold);
        }

        private void btnResetTeamScore_MouseLeave(object sender, EventArgs e)
        {
            btnResetTeamScore.BackColor = Color.Gray;
            btnResetTeamScore.Font = new Font(btnResetTeamScore.Font.Name, 14, FontStyle.Bold);
        }

        private void btnAssignScoreToEvents_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCAssignScoreToEventsToPanel(systemPanel);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOff();
        }

        private void UCScoreAdministrator_Load(object sender, EventArgs e)
        {
            if (!Session.HasAdministrationPrivileges())
            {
                btnAssignScoreToEvents.Visible = false;
                btnResetTeamScore.Visible = false;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHomeRespectiveHome(systemPanel);
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void btnResetTeamScore_Click(object sender, EventArgs e)
        {
            ResetTeamScore();
        }

        private static void ResetTeamScore()
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea resetear el puntaje del equipo seleccionado? " +
                " La operación es irreversible.", "Confirmación", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //HACER RESET DE RANKING DEL EQUIPO
            }
        }
    }
}
