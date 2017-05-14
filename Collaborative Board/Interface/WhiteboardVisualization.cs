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
                SetRightClickOptionsImage(interfaceContainer);
                SetDragAndDropEvents(interfaceContainer);
                pnlWhiteboard.Controls.Add(interfaceContainer);
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
            ImageWhiteboard domainElement = interfaceContainer.Tag as ImageWhiteboard;
            seeComments.Click += (sender, e) => ClickSeeComments(domainElement, e);
            interfaceContainer.ContextMenu = contMenu;
        }

        private void SetDragAndDropEvents(Control interfaceObject)
        {
            ControlMovingOrResizingHandler.Init(interfaceObject);
            interfaceObject.MouseClick += new MouseEventHandler(ClickMouseElement);
            interfaceObject.MouseMove += new MouseEventHandler(MoveMouseElement);
            interfaceObject.MouseUp += new MouseEventHandler(UpMouseElement);
        }

        private void ClickSeeComments(ImageWhiteboard image, EventArgs e)
        {
            Form comments = new ElementComments(image);
            comments.Show();
            comments.TopMost = true;
        }

        private void ClickMouseElement(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control interfaceComponent = ((Control)sender);
                mouseDownLocation = e.Location;
                componentInitialPosition = interfaceComponent.Location;
            }
        }

        private void MoveMouseElement(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control componentToBeMoved = sender as Control;
                componentToBeMoved.Left = e.X + componentToBeMoved.Left - mouseDownLocation.X;
                componentToBeMoved.Top = e.Y + componentToBeMoved.Top - mouseDownLocation.Y;
            }
        }

        private void UpMouseElement(object sender, MouseEventArgs e)
        {
            Control interfaceComponent = ((Control)sender);
            ElementWhiteboard boardElement = interfaceComponent.Tag as ElementWhiteboard;
            try
            {
                boardElement.Position = interfaceComponent.Location;
            }
            catch (BoardException exception)
            {
                interfaceComponent.Location = componentInitialPosition;
                InterfaceUtilities.ShowError(exception.Message, "Movimiento inválido");
            }
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {

        }
    }
}