using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence;
using Domain;

namespace Interface
{
    public partial class UCWhiteboards : UserControl
    {
        private Panel systemPanel;
        public UCWhiteboards(Panel systemPanel)
        {
            InitializeComponent();
            this.systemPanel = systemPanel;
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Gold;
            btnAdd.Font = new Font(btnAdd.Font.Name, 19, FontStyle.Bold);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Yellow;
            btnAdd.Font = new Font(btnAdd.Font.Name, 18, FontStyle.Bold);
        }

        private void btnModify_MouseEnter(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Gold;
            btnModify.Font = new Font(btnModify.Font.Name, 19, FontStyle.Bold);
        }

        private void btnModify_MouseLeave(object sender, EventArgs e)
        {
            btnModify.BackColor = Color.Yellow;
            btnModify.Font = new Font(btnModify.Font.Name, 18, FontStyle.Bold);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Gold;
            btnDelete.Font = new Font(btnDelete.Font.Name, 19, FontStyle.Bold);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Yellow;
            btnDelete.Font = new Font(btnDelete.Font.Name, 18, FontStyle.Bold);
        }

        private void btnView_MouseEnter(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Gold;
            btnView.Font = new Font(btnView.Font.Name, 19, FontStyle.Bold);
        }

        private void btnView_MouseLeave(object sender, EventArgs e)
        {
            btnView.BackColor = Color.Yellow;
            btnView.Font = new Font(btnView.Font.Name, 18, FontStyle.Bold);
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

        private void UCWhiteboards_Load(object sender, EventArgs e)
        {
            lstRegisteredWhiteboards.Clear();
            var globalWhiteboards = WhiteboardRepository.GetInstance().Elements.ToList();
            if (globalWhiteboards.Count() > 0)
            {
                foreach (Whiteboard oneWhiteboard in globalWhiteboards)
                {
                    ListViewItem itemToAdd = new ListViewItem(oneWhiteboard.ToString());
                    itemToAdd.Tag = oneWhiteboard;
                    lstRegisteredWhiteboards.Items.Add(itemToAdd);
                }
            }
            else
            {
                lstRegisteredWhiteboards.Items.Add(new ListViewItem("No existen usuarios registrados."));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAddOrModifyWhiteboard(systemPanel));
        }
    }
}
