using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace Interface
{
    public partial class UCAdministratorTeams : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorTeams(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Maroon;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.DarkRed;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void btnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Maroon;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void btnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.DarkRed;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Maroon;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void btnVisualize_MouseEnter(object sender, EventArgs e)
        {
            btnVisualize.BackColor = Color.Maroon;
            btnVisualize.Font = new Font(btnVisualize.Font.Name, 19, FontStyle.Bold);
        }

        private void btnVisualize_MouseLeave(object sender, EventArgs e)
        {
            btnVisualize.BackColor = Color.DarkRed;
            btnVisualize.Font = new Font(btnVisualize.Font.Name, 18, FontStyle.Bold);
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Size = new Size(87, 67);
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Size = new Size(80, 62);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.AskExitApplication();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHome(systemPanel);
        }

        private void UCAdministratorTeams_Load(object sender, EventArgs e)
        {
            LoadRegisteredTeams();
        }

        private void LoadRegisteredTeams()
        {
            lstTeams.Clear();
            var globalTeams = TeamRepository.GetInstance().Elements.ToList();
            if (globalTeams.Count() > 0)
            {
                foreach (Team oneTeam in globalTeams)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneTeam.ToString());
                    itemToAdd.Tag = oneTeam;
                    lstTeams.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstTeams.Items.Add(new ListViewItem("No existen equipos registrados."));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel));
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Team teamToModify = lstTeams.SelectedItems[0].Tag as Team;
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel, teamToModify));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Team teamToDelete = lstTeams.SelectedItems[0].Tag as Team;
            if (Utilities.IsNotNull(teamToDelete))
            {
                AskDeleteTeam(teamToDelete);
            }
        }

        private void AskDeleteTeam(Team oneTeam)
        {
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar el elemento seleccionado?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteTeam(oneTeam);
                LoadRegisteredTeams();
            }

        }

        private void DeleteTeam(Team oneTeam)
        {
            TeamRepository globalTeams = TeamRepository.GetInstance();
            globalTeams.Remove(oneTeam);
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            Team teamToVisualize = lstTeams.SelectedItems[0].Tag as Team;
            if (Utilities.IsNotNull(teamToVisualize))
            {
                systemPanel.Controls.Clear();
                systemPanel.Controls.Add(new UCVisualizeTeam(systemPanel, teamToVisualize));
            }
            else
            {
                InterfaceUtilities.NotElementSelectedMessageBox();
            }
                
        }
    }
}
