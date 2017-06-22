using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Persistence;

namespace GraphicInterface
{
    public partial class UCTeamRanking : UserControl
    {
        private Panel systemPanel;
        private Team teamToWorkWith;
        public UCTeamRanking(Panel somePanel, Team oneTeam) 
        {
            InitializeComponent();
            systemPanel = somePanel;
            teamToWorkWith = oneTeam;
            lblTeamSelected.Text = oneTeam.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOff();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCScoreMenuToPanel(systemPanel);
        }

        private void UCTeamRanking_Load(object sender, EventArgs e)
        {
            LoadUsersScores();
        }

        private void LoadUsersScores()
        {
            dgvRankingBoard.Rows.Clear();
            TeamRepository.LoadMembers(teamToWorkWith);
            List<Tuple<User, int>> userScoresForTeam = UserScoresRepository.GetScoresForTeam(teamToWorkWith.Id);
            if (Utilities.IsEmpty(userScoresForTeam))
            {
                dgvRankingBoard.Rows.Add("Sin datos", "a mostrar.");
            }
            else
            {
                foreach (var userScore in userScoresForTeam)
                {
                    var userMail = userScore.Item1.Email;
                    var userPoints = userScore.Item2;
                    var index = dgvRankingBoard.Rows.Add();
                    dgvRankingBoard.Rows[index].Cells[0].Value = userMail;
                    dgvRankingBoard.Rows[index].Cells[1].Value = userPoints;
                    dgvRankingBoard.Rows[index].Tag = userScore.Item1;
                }
                this.dgvRankingBoard.Sort(this.dgvRankingBoard.Columns[1], ListSortDirection.Descending);
            }
        }
    }
}
