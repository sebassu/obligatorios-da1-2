using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class UCTeamRanking : UserControl
    {
        private Panel systemPanel;
        public UCTeamRanking(Panel somePanel)
        {
            InitializeComponent();
            systemPanel = somePanel;
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
