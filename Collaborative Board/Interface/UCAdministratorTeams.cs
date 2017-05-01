using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
