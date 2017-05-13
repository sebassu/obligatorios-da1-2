using System;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace Interface
{
    public partial class UCAddOrModifyWhiteboard : UserControl
    {
        private Panel systemPanel;
        public UCAddOrModifyWhiteboard(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCWhiteboards(systemPanel));
        }

        private void UCAddOrModifyWhiteboard_Load(object sender, EventArgs e)
        {
            var globalTeams = TeamRepository.GetInstance().Elements.ToList();
            if (globalTeams.Count() > 0)
            {
                foreach (Team oneTeam in globalTeams)
                {
                    cmbOwnerTeam.Items.Add(oneTeam.ToString());
                }
            }
            else
            {
                cmbOwnerTeam.Items.Add("No existen equipos registrados.");
            }
        }
    }
}
