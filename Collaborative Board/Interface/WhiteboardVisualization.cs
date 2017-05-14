using Domain;
using Exceptions;
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
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(LoadWhiteboardComponentsOnInteface);
        }

        private void LoadWhiteboardComponentsOnInteface()
        {
            foreach (var element in whiteboardShown.Contents)
            {
                if (element is ImageWhiteboard imageToAdd)
                {
                    AddPictureBoxFromWhiteboardImage(imageToAdd);
                }
                else if (element is TextBoxWhiteboard textBoxToAdd)
                {
                    AddRichTextBoxFromDomainTextBoxWhiteboard(textBoxToAdd);
                }
                else
                {
                    throw new BoardException("Elemento desconocido encontrado.");
                }
            }
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
            Action setContextMenu = delegate { SetRightClickOptionsImage(interfaceContainer); };
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(setContextMenu);
            ControlMovingOrResizingHandler.MakeDragAndDroppable(interfaceContainer);
            pnlWhiteboard.Controls.Add(interfaceContainer);
        }

        private void SetRightClickOptionsImage(PictureBox interfaceContainer)
        {
            ContextMenu contMenu = new ContextMenu();
            if (interfaceContainer.Tag is ImageWhiteboard domainImage)
            {
                AddSeeCommentsOption(domainImage, contMenu);
                AddModifyImageOption(interfaceContainer, contMenu, domainImage);
                AddRemoveElementOption(interfaceContainer, domainImage, contMenu);
                interfaceContainer.ContextMenu = contMenu;
            }
        }

        private void AddSeeCommentsOption(ElementWhiteboard domainElement, ContextMenu contMenu)
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

        private void AddModifyImageOption(PictureBox interfaceContainer, ContextMenu contMenu,
            ImageWhiteboard domainImage)
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

        private void AddRemoveElementOption(Control interfaceContainer,
            ElementWhiteboard elementToRemove, ContextMenu contMenu)
        {
            MenuItem removeElementItem = new MenuItem("Eliminar elemento");
            removeElementItem.Click += (sender, e) => RemoveElement(interfaceContainer, elementToRemove);
            contMenu.MenuItems.Add(removeElementItem);
        }

        private void RemoveElement(Control interfaceContainer, ElementWhiteboard domainElement)
        {
            Action deleteAction = delegate { PerformDelete(interfaceContainer, domainElement); };
            InterfaceUtilities.AskForDeletionConfirmationAndExecute(deleteAction);
        }

        private void PerformDelete(Control interfaceContainer, ElementWhiteboard domainElement)
        {
            Action deleteAction = delegate { ActualDelete(interfaceContainer, domainElement); };
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(deleteAction);
        }

        private void ActualDelete(Control interfaceContainer, ElementWhiteboard domainElement)
        {
            whiteboardShown.RemoveWhiteboardElement(domainElement);
            pnlWhiteboard.Controls.Remove(interfaceContainer);
            pnlWhiteboard.Update();
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {
            TextBoxWhiteboard textBoxToAdd = TextBoxWhiteboard.CreateWithContainer(whiteboardShown);
            AddRichTextBoxFromDomainTextBoxWhiteboard(textBoxToAdd);
        }

        private void AddRichTextBoxFromDomainTextBoxWhiteboard(TextBoxWhiteboard textBoxToAdd)
        {
            RichTextBox interfaceContainer = new RichTextBox()
            {
                Tag = textBoxToAdd,
                Text = textBoxToAdd.TextContent,
                Font = textBoxToAdd.TextFont,
                Parent = pnlWhiteboard,
                Width = textBoxToAdd.Width,
                Height = textBoxToAdd.Height,
                Location = textBoxToAdd.Position
            };
            Action setContextMenu = delegate { SetRightClickOptionTextBox(interfaceContainer); };
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(setContextMenu);
            interfaceContainer.TextChanged += (sender, e) => UpdateElementText(interfaceContainer, textBoxToAdd);
            ControlMovingOrResizingHandler.MakeDragAndDroppable(interfaceContainer);
            pnlWhiteboard.Controls.Add(interfaceContainer);
        }

        private void SetRightClickOptionTextBox(RichTextBox interfaceContainer)
        {
            ContextMenu contMenu = new ContextMenu();
            if (interfaceContainer.Tag is TextBoxWhiteboard domainTextBox)
            {
                AddSeeCommentsOption(domainTextBox, contMenu);
                AddModifyFontDomainTextBox(interfaceContainer, domainTextBox, contMenu);
                AddRemoveElementOption(interfaceContainer, domainTextBox, contMenu);
                interfaceContainer.ContextMenu = contMenu;
            }
        }

        private void UpdateElementText(RichTextBox interfaceContainer, TextBoxWhiteboard domainTextBox)
        {
            domainTextBox.TextContent = interfaceContainer.Text;
        }

        private void AddModifyFontDomainTextBox(RichTextBox interfaceContainer,
            TextBoxWhiteboard domainTextBox, ContextMenu contMenu)
        {
            MenuItem removeElementItem = new MenuItem("Modificar tipo/tamaño de letra");
            removeElementItem.Click += (sender, e) => ChangeTextBoxFont(interfaceContainer, domainTextBox);
            contMenu.MenuItems.Add(removeElementItem);
        }

        private static void ChangeTextBoxFont(RichTextBox interfaceContainer, TextBoxWhiteboard domainTextBox)
        {
            FontDialog fontChooser = CreateFontChooser(interfaceContainer);
            if (fontChooser.ShowDialog() != DialogResult.Cancel)
            {
                Font chosenFont = fontChooser.Font;
                interfaceContainer.Font = chosenFont;
                domainTextBox.TextFont = chosenFont;
            }
        }

        private static FontDialog CreateFontChooser(RichTextBox interfaceContainer)
        {
            return new FontDialog()
            {
                ShowColor = false,
                FontMustExist = true,
                Font = interfaceContainer.Font,
                ShowEffects = true
            };
        }

        private void BtnPrintPDF_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrintPng_Click(object sender, EventArgs e)
        {

        }
    }
}