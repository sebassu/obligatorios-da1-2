using System;
using System.Drawing;
using System.Windows.Forms;
using Persistence;
using Domain;
using System.Collections.Generic;
using System.ComponentModel;

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
            LoadTeamsWithTotalScores();
        }

        private void LoadTeamsWithTotalScores()
        {
            List<Tuple<Team, int>> auxTuple = new List<Tuple<Team, int>>();
            foreach (var team in TeamRepository.Elements)
            {
                TeamRepository.LoadMembers(team);
                if ((Session.ActiveUser().HasAdministrationPrivileges) || team.Members.Contains(Session.ActiveUser()))
                {
                    int teamTotalScore = 0;
                    List<Tuple<User, int>> scoresByUser = UserScoresRepository.GetScoresForTeam(team.Id);
                    foreach (var userScore in scoresByUser)
                    {
                        teamTotalScore = teamTotalScore + userScore.Item2;
                    }
                    auxTuple.Add(new Tuple<Team, int>(team, teamTotalScore));
                }
            }
            LoadGridViewWithTeamScores(auxTuple);
        }

        private void LoadGridViewWithTeamScores(List<Tuple<Team, int>> teamAndTotalScore)
        {
            dgvScoringBoard.Rows.Clear();
            if (Utilities.IsEmpty(teamAndTotalScore))
            {
                dgvScoringBoard.Rows.Add("Sin datos", "a mostrar.");
                btnTeamRanking.Enabled = false;
                btnResetTeamScore.Enabled = false;
            }
            else
            {
                foreach (var teamScore in teamAndTotalScore)
                {
                    var teamName = teamScore.Item1.ToString();
                    var teamPoints = teamScore.Item2;
                    var index = dgvScoringBoard.Rows.Add();
                    dgvScoringBoard.Rows[index].Cells[0].Value = teamName;
                    dgvScoringBoard.Rows[index].Cells[1].Value = teamPoints;
                    dgvScoringBoard.Rows[index].Tag = teamScore.Item1;
                }
                this.dgvScoringBoard.Sort(this.dgvScoringBoard.Columns[1], ListSortDirection.Descending);
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

        private void ResetTeamScore()
        {
            if (Session.ActiveUser().HasAdministrationPrivileges)
            {
                if (dgvScoringBoard.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea resetear el puntaje del equipo seleccionado? " +
                  " La operación es irreversible.", "Confirmación", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Team teamScore = dgvScoringBoard.SelectedRows[0].Tag as Team;
                        //UserScoresRepository.GetScoresForTeam(teamScore.Item1.Id);
                        UserScoresRepository.ResetTeamScore(teamScore.Id);
                        LoadTeamsWithTotalScores();
                    }
                }
                else
                {
                    InterfaceUtilities.NotElementSelectedMessageBox();
                }
            }
        }

        private void btnTeamRanking_Click(object sender, EventArgs e)
        {
            if (dgvScoringBoard.SelectedRows.Count > 0)
            {
                Team teamScore = dgvScoringBoard.SelectedRows[0].Tag as Team;
                InterfaceUtilities.UCTeamRankingToPanel(systemPanel, teamScore);
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }
        }
    }
}
