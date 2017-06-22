using Domain;
using Persistence;
using System.Windows.Forms;
using System;

namespace GraphicInterface
{
    public partial class ConnectionRegistration : Form
    {
        private ElementWhiteboard origin;
        private ElementWhiteboard destination;
        private Panel whiteboardPanel;
        private Whiteboard whiteboardShown;

        public ConnectionRegistration(ElementWhiteboard someOrigin,
            ElementWhiteboard someDestination, Panel somePanel, Whiteboard someWhiteboard)
        {
            InitializeComponent();
            origin = someOrigin;
            destination = someDestination;
            whiteboardPanel = somePanel;
            whiteboardShown = someWhiteboard;
        }

        private void BtnFinalize_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(RegisterNewConection);
            WhiteboardVisualization.DeepRepaint(whiteboardPanel, whiteboardShown);
            Dispose();
        }

        private void RegisterNewConection()
        {
            string nameToSet = txtName.Text;
            string descriptionToSet = rtbDescription.Text;
            int direction = GetDirectionFromRadioButtons();
            ConnectionRepository.AddNewConnection(nameToSet, descriptionToSet,
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
