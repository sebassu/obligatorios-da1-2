using Domain;
using System;
using System.Windows.Forms;

namespace Interface
{
    public partial class WhiteboardVisualization : Form
    {
        private Whiteboard whiteboardShown;

        public WhiteboardVisualization(Whiteboard someWhiteboard)
        {
            InitializeComponent();
            whiteboardShown = someWhiteboard;
            pnlWhiteboard.Width = someWhiteboard.Width;
            pnlWhiteboard.Height = someWhiteboard.Height;
            Text = "Pizarrón: " + someWhiteboard.ToString();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            FileDialog fileSelector = new OpenFileDialog()
            {
                Filter = "Archivos de imagen (*.jpg, *.png, *.gif, *.jpeg)|*.JPG;*.PNG;*.GIF;*.JPEG;"
            };
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                ImageWhiteboard imageToAdd = ImageWhiteboard.CreateWithContainerSource(whiteboardShown,
                    fileSelector.FileName);
                PictureBox interfaceContainer = new PictureBox()
                {
                    Image = imageToAdd.ActualImage,
                    Tag = imageToAdd,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Parent = pnlWhiteboard,
                    Width = imageToAdd.Width,
                    Height = imageToAdd.Height,
                    Location = imageToAdd.Position
                };
                SetDragAndDropEvents(interfaceContainer);
                pnlWhiteboard.Controls.Add(interfaceContainer);
            }
        }

        private void SetDragAndDropEvents(Control interfaceObject)
        {
            ControlMovingOrResizingHandler.Init(interfaceObject);
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {

        }
    }
}