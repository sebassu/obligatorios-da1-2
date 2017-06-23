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
    public partial class UCUserHome : UserControl
    {
        private Panel systemPanel;
        public UCUserHome(Panel somePanel)
        {
            InitializeComponent();
            systemPanel = somePanel;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskLogOff();
        }

        private void btnWhiteboards_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCWhiteboardsToPanel(systemPanel);
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCScoreMenuToPanel(systemPanel);
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

        private void btnScore_MouseEnter(object sender, EventArgs e)
        {
            btnScore.BackColor = Color.DimGray;
            btnScore.Font = new Font(btnScore.Font.Name, 19, FontStyle.Bold);
        }

        private void btnScore_MouseLeave(object sender, EventArgs e)
        {
            btnScore.BackColor = Color.Gray;
            btnScore.Font = new Font(btnScore.Font.Name, 18, FontStyle.Bold);
        }
    }
}
