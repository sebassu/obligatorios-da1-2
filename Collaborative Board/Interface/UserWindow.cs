using System.Windows.Forms;

namespace Interface
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
            pnlSystem.Controls.Clear();
            pnlSystem.Controls.Add(new UCAdministratorCommentsSolvedByUser(pnlSystem));   
        }
    }
}
