using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
            pnlSystem.Controls.Clear();
            pnlSystem.Controls.Add(new UCAdministratorHome(pnlSystem));   
        }
    }
}
