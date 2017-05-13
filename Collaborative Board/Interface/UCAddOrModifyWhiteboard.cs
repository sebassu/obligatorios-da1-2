using System;
using System.Windows.Forms;

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
    }
}
