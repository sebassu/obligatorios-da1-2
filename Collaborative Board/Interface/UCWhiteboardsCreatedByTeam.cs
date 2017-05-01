using System;
using System.Data;
using System.Windows.Forms;
using Domain;
using System.Drawing;

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
        }

        private void UCWhiteboardsCreatedByTeam_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Equipo", typeof(Team));
            table.Columns.Add("Fecha de creación", typeof(DateTime));
            table.Columns.Add("Última modificación", typeof(DateTime));
            table.Columns.Add("Cantidad de elementos", typeof(int));
            dgvWhiteboardsCreatedByTeam.DataSource = table;
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
    }
}
