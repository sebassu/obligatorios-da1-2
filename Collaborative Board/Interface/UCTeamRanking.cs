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
    }
}
