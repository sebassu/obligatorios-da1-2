using System;
using System.Windows.Forms;
using System.Drawing;
using Domain;
using Persistence;
using System.Linq;

namespace Interface
{
    public partial class UCWhiteboardsCreatedByTeam : UserControl
    {
        private Panel systemPanel;

        public UCWhiteboardsCreatedByTeam(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            SetDateTimePickerFormat();
            LoadTeamComobox();
        }

        private void LoadTeamComobox()
        {
            var globalTeams = TeamRepository.GetInstance();
            if (globalTeams.HasElements())
            {
                cmbTeams.Items.AddRange(globalTeams.Elements.ToArray());
            }
            else
            {
                InterfaceUtilities.ShowError("Para utilizar esta función es necesario que existan " +
                    "equipos registrados en el sistema.", "Error");
                InterfaceUtilities.GoToHome(systemPanel);
            }
        }

        public void SetDateTimePickerFormat()
        {
            dtpWhiteboardsCreatedFrom.CustomFormat = "dd/MM/yyyy";
            dtpWhiteboardsCreatedUntil.CustomFormat = "dd/MM/yyyy";
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
            InterfaceUtilities.AskLogOut();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.GoToHome(systemPanel);
        }

        private void UCWhiteboardsCreatedByTeam_Load(object sender, EventArgs e)
        {
            LoadGridViewWithWhiteboardsFilteringBy(_ => true);
        }

        private void LoadGridViewWithWhiteboardsFilteringBy(Func<Whiteboard, bool> filteringFunction)
        {
            dgvWhiteboardsCreatedByTeam.Rows.Clear();
            var whiteboardsToShow = WhiteboardRepository.GetInstance().Elements
                .Where(p => filteringFunction(p)).ToList();
            if (whiteboardsToShow.Count == 0)
            {
                dgvWhiteboardsCreatedByTeam.Rows.Add("Sin", "datos", "a", " mostrar.");
            }
            else
            {
                foreach (Whiteboard whiteboard in whiteboardsToShow)
                {
                    var creationDateToShow = Utilities.GetDateToShow(whiteboard.CreationDate);
                    var lastModificationDateToShow = Utilities.GetDateToShow(whiteboard.LastModification);
                    var ownerTeamToShow = whiteboard.OwnerTeam.ToString();
                    dgvWhiteboardsCreatedByTeam.Rows.Add(whiteboard.ToString(), ownerTeamToShow,
                        creationDateToShow, lastModificationDateToShow, whiteboard.Contents.Count);
                }
            }
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadGridViewWithWhiteboardsFilteringBy(p => FilterByDatesAndTeam(p));
        }

        private bool FilterByDatesAndTeam(Whiteboard p)
        {
            return p.CreationDate >= dtpWhiteboardsCreatedFrom.Value.Date &&
                p.CreationDate <= dtpWhiteboardsCreatedUntil.Value.Date &&
                cmbTeams.SelectedItem.Equals(p.OwnerTeam);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadGridViewWithWhiteboardsFilteringBy(_ => true);
        }
    }
}
