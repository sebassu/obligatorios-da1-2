using Domain;
using System;
using System.Drawing;
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
            CreateNewPictureBoxWithImage();
        }

        private void CreateNewPictureBoxWithImage()
        {
            FileDialog fileSelector = CreateImageFileChooser();
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                Action createImage = delegate { CreateNewPictureBoxWithImage(fileSelector); };
                InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(createImage);
            }
        }

        private static FileDialog CreateImageFileChooser()
        {
            return new OpenFileDialog()
            {
                Filter = "Archivos de imagen (*.jpg, *.png, *.gif, *.jpeg)|*.JPG;*.PNG;*.GIF;*.JPEG;"
            };
        }

        private void CreateNewPictureBoxWithImage(FileDialog fileSelector)
        {
            ImageWhiteboard imageToAdd = ImageWhiteboard.CreateWithContainerSource(whiteboardShown,
                fileSelector.FileName);
            AddPictureBoxFromWhiteboardImage(imageToAdd);
        }

        private void AddPictureBoxFromWhiteboardImage(ImageWhiteboard imageToAdd)
        {
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
            ControlMovingOrResizingHandler.MakeDragAndDroppable(interfaceContainer);
            pnlWhiteboard.Controls.Add(interfaceContainer);
        }

        private void SetRightClickOptionsImage(PictureBox interfaceContainer)
        {
            ContextMenu contMenu = new ContextMenu();
            ImageWhiteboard domainImage = interfaceContainer.Tag as ImageWhiteboard;
            AddSeeCommentsOption(contMenu, domainImage);
            AddModifyImageOption(interfaceContainer, contMenu, domainImage);
            AddRemoveElementOption(interfaceContainer, domainImage, contMenu);
            interfaceContainer.ContextMenu = contMenu;
        }

        private void AddSeeCommentsOption(ContextMenu contMenu, ElementWhiteboard domainElement)
        {
            MenuItem seeComments = new MenuItem("Ver comentarios");
            seeComments.Click += (sender, e) => ClickSeeComments(domainElement, e);
            contMenu.MenuItems.Add(seeComments);
        }

        private void ClickSeeComments(ElementWhiteboard sender, EventArgs e)
        {
            Form comments = new ElementComments(sender);
            comments.Show();
            comments.TopMost = true;
        }

        private void AddModifyImageOption(PictureBox interfaceContainer, ContextMenu contMenu, ImageWhiteboard domainImage)
        {
            MenuItem modifyImage = new MenuItem("Modificar imagen");
            modifyImage.Click += (sender, e) => ChangeDisplayedImage(interfaceContainer, domainImage);
            contMenu.MenuItems.Add(modifyImage);
        }

        private void ChangeDisplayedImage(PictureBox container, ImageWhiteboard domainImage)
        {
            FileDialog fileSelector = CreateImageFileChooser();
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                Action changeImage = delegate { PerformImageChange(container, domainImage, fileSelector); };
                InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(changeImage);
            }
        }

        private static void PerformImageChange(PictureBox container, ImageWhiteboard domainImage,
            FileDialog fileSelector)
        {
            Image imageToSet = Image.FromFile(fileSelector.FileName);
            domainImage.ActualImage = imageToSet;
            container.Image = imageToSet;
            container.Update();
        }

        private void AddRemoveElementOption(PictureBox interfaceContainer,
            ElementWhiteboard elementToRemove, ContextMenu contMenu)
        {
            MenuItem removeElementItem = new MenuItem("Eliminar elemento");
            removeElementItem.Click += (sender, e) => RemoveElement(interfaceContainer, elementToRemove);
            contMenu.MenuItems.Add(removeElementItem);
        }

        private void RemoveElement(PictureBox interfaceContainer, ElementWhiteboard domainElement)
        {
            Action deleteAction = delegate { PerformDelete(interfaceContainer, domainElement); };
            InterfaceUtilities.AskForDeletionConfirmationAndExecute(deleteAction);
        }

        private void PerformDelete(PictureBox interfaceContainer, ElementWhiteboard domainElement)
        {
            Action deleteAction = delegate { ActualDelete(interfaceContainer, domainElement); };
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(deleteAction);
        }

        private void ActualDelete(PictureBox interfaceContainer, ElementWhiteboard domainElement)
        {
            whiteboardShown.RemoveWhiteboardElement(domainElement);
            pnlWhiteboard.Controls.Remove(interfaceContainer);
            pnlWhiteboard.Update();
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {
            TextBoxWhiteboard textBoxToAdd = TextBoxWhiteboard.CreateWithContainer(whiteboardShown);
            RichTextBox interfaceContainer = new RichTextBox()
            {
                Tag = textBoxToAdd,
                Parent = pnlWhiteboard,
                Width = textBoxToAdd.Width,
                Height = textBoxToAdd.Height,
                Location = textBoxToAdd.Position
            };
            ControlMovingOrResizingHandler.MakeDragAndDroppable(interfaceContainer);
            pnlWhiteboard.Controls.Add(interfaceContainer);
        }
    }
}