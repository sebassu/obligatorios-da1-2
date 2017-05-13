using Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
    public partial class WhiteboardVisualization : Form
    {
        private Whiteboard whiteboardShown;
        private Point mouseDownLocation;

        public WhiteboardVisualization()
        {
            InitializeComponent();
            //whiteboardShown = someWhiteboard;
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            FileDialog fileSelector = new OpenFileDialog()
            {
                Filter = "Archivos de imagen (*.bmp, *.jpg, *.gif)|*.BMP;*.JPG;*.GIF"
            };
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                /*ImageWhiteboard imageToAdd = ImageWhiteboard.CreateWithContainerSource(whiteboardShown,
                    fileSelector.FileName);*/
                PictureBox interfaceContainer = new PictureBox()
                {
                    //Image = imageToAdd.ActualImage,
                    Image = Image.FromFile(fileSelector.FileName),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Parent = pnlWhiteboard
                };
                interfaceContainer.MouseClick += new MouseEventHandler(pictureBox1_MouseDown);
                interfaceContainer.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
                pnlWhiteboard.Controls.Add(interfaceContainer);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control componentToBeMoved = sender as Control;
                componentToBeMoved.Left = e.X + componentToBeMoved.Left - mouseDownLocation.X;
                componentToBeMoved.Top = e.Y + componentToBeMoved.Top - mouseDownLocation.Y;
            }
        }
    }
}