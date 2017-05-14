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
                ControlMovingOrResizingHandler.Init(interfaceContainer);
                SetRightClickOptionsImage(interfaceContainer);
            }
        }

        private void SetRightClickOptionsImage(PictureBox interfaceContainer)
        {
            ContextMenu contMenu = new ContextMenu();
            MenuItem seeComments = new MenuItem("Ver comentarios");
            MenuItem modifyImage = new MenuItem("Modificar imagen");
            MenuItem removeImage = new MenuItem("Eliminar imagen");
            contMenu.MenuItems.Add(seeComments);
            contMenu.MenuItems.Add(modifyImage);
            contMenu.MenuItems.Add(removeImage);
            ImageWhiteboard domainElement = interfaceContainer.Tag as ImageWhiteboard;
            seeComments.Click += (sender, e) => ClickSeeComments(domainElement, e);
            interfaceContainer.ContextMenu = contMenu;
        }

        private void ClickSeeComments(ImageWhiteboard image, EventArgs e)
        {
            Form comments = new ElementComments(image);
            comments.Show();
            comments.TopMost = true;
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {

        }

        private void WhiteboardVisualization_Click(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void WhiteboardVisualization_MouseLeave(object sender, EventArgs e)
        {
            TopMost = false;
        }

        private void WhiteboardVisualization_MouseEnter(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}