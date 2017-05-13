using System;
using System.Data;
using System.Windows.Forms;
using Domain;
using System.Drawing;

namespace Interface
{
    public partial class UCAdministratorCommentsSolvedByUser : UserControl
    {
        private Panel systemPanel;
        public UCAdministratorCommentsSolvedByUser(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
            SetDateTimePickerFormat();
        }

        public void SetDateTimePickerFormat()
        {
            dtpCommentsCreatedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsCreatedUntil.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedFrom.CustomFormat = "dd/MM/yyyy";
            dtpCommentsSolvedUntil.CustomFormat = "dd/MM/yyyy";
        }

        private void UCAdministratorCommentsSolvedByUser_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Fecha de creación", typeof(DateTime));
            table.Columns.Add("Creador", typeof(User));
            table.Columns.Add("Solucionador", typeof(User));
            table.Columns.Add("Pizarrón contenedor", typeof(Whiteboard));
            table.Columns.Add("Fecha de resolución", typeof(DateTime));
            dgvCommentsSolvedByUser.DataSource = table;
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
    }
}
