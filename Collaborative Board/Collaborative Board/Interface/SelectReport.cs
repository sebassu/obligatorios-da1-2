using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class SelectReport : Form
    {
        private Panel systemPanel;
        public SelectReport(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void SelectInform_FormClosed(object sender, FormClosedEventArgs e)
        {
            systemPanel.Enabled = true;
        }

        private void BtnWhiteboardsCreatedByTeam_Click(object sender, EventArgs e)
        {
            Hide();
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCWhiteboardsCreatedByTeam(systemPanel));
            systemPanel.Enabled = true;

        }

        private void BtnCommentsSolvedByUser_Click(object sender, EventArgs e)
        {
            Hide();
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorCommentsSolvedByUser(systemPanel));
            systemPanel.Enabled = true;
        }
    }
}