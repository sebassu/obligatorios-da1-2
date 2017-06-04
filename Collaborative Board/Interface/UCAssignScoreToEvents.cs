using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class UCAssignScoreToEvents : UserControl
    {
        Panel systemPanel;
        public UCAssignScoreToEvents(Panel somePanel)
        {
            InitializeComponent();
            systemPanel = somePanel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.UCScoreMenuToPanel(systemPanel);
        }
    }
}
