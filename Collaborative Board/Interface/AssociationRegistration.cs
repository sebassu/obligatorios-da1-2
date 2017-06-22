using Domain;
using Persistence;
using System.Windows.Forms;
using System;

namespace GraphicInterface
{
    public partial class AssociationRegistration : Form
    {
        private ElementWhiteboard origin;
        private ElementWhiteboard destination;
        private Panel whiteboardPanel;

        public AssociationRegistration(ElementWhiteboard someOrigin,
            ElementWhiteboard someDestination, Panel somePanel)
        {
            InitializeComponent();
            origin = someOrigin;
            destination = someDestination;
            whiteboardPanel = somePanel;
        }

        private void BtnFinalize_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(RegisterNewConection);
            WhiteboardVisualization.DeepRepaint(whiteboardPanel);
            Dispose();
        }

        private void RegisterNewConection()
        {
            string nameToSet = txtName.Text;
            string descriptionToSet = rtbDescription.Text;
            int direction = GetDirectionFromRadioButtons();
            ConnectionRepository.AddNewAssociation(nameToSet, descriptionToSet,
                origin, destination, direction);
        }

        private int GetDirectionFromRadioButtons()
        {
            if (rbnDirect.Checked)
            {
                return 0;
            }
            else if (rbnInverse.Checked)
            {
                return 1;
            }
            else if (rbnBidirectional.Checked)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
