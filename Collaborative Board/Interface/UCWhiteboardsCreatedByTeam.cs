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
                InterfaceUtilities.ShowError("Para utilizar esta función es necesario que existan " +
                    "equipos registrados en el sistema.", "Error");
                InterfaceUtilities.GoToHome(systemPanel);
            }
            else
            {
                cmbTeams.Items.AddRange(globalTeams.Elements.ToArray());
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
            var whiteboardsToShow = WhiteboardRepository.GetInstance().Elements
                .Where(p => filteringFunction(p)).ToList();
            if (whiteboardsToShow.Count == 0)
            {
                dgvWhiteboardsCreatedByTeam.Rows.Add("Sin", "datos", "a", " mostrar.");
            }
            else
            {
                foreach (var whiteboard in whiteboardsToShow)
                {
                    var creationDateToShow = InterfaceUtilities.GetDateToShow(whiteboard.CreationDate);
                    var lastModificationDateToShow = InterfaceUtilities.GetDateToShow(whiteboard.LastModification);
                    var ownerTeamToShow = whiteboard.OwnerTeam.ToString();
                    dgvWhiteboardsCreatedByTeam.Rows.Add(whiteboardsToShow.ToString(), ownerTeamToShow,
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
            return p.CreationDate >= dtpWhiteboardsCreatedFrom.Value &&
                p.CreationDate <= dtpWhiteboardsCreatedUntil.Value &&
                cmbTeams.SelectedItem.Equals(p.OwnerTeam);
        }
    }
}
