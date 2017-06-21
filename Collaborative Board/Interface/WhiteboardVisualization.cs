using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicInterface
{
    public partial class WhiteboardVisualization : Form
    {
        internal static List<Domain.Association> globalAssociations;

        private Whiteboard whiteboardShown;
        private int addAssociationItemsRemaining;
        private int removeAssociationItemsRemaining;
        private ElementWhiteboard origin;

        private void MakeDragAndDroppable(Control interfaceObject)
        {
            ControlMovingOrResizingHandler.cursorStartPoint = Point.Empty;
            interfaceObject.MouseDown += new MouseEventHandler(ControlMovingOrResizingHandler.StartMovingOrResizing);
            interfaceObject.MouseMove += new MouseEventHandler(ControlIsMoving);
            interfaceObject.MouseUp += new MouseEventHandler(ControlMovingOrResizingHandler.StopDragOrResizing);
        }

        private void ControlIsMoving(object sender, MouseEventArgs e)
        {
            bool mustRepaint = ControlMovingOrResizingHandler.MoveControl(sender, e);
            if (mustRepaint)
            {
                RepaintWhiteboard(pnlWhiteboard);
            }
        }

        private void RepaintWhiteboard(Panel whiteboardPanel)
        {
            whiteboardPanel.Invalidate();
        }

        public WhiteboardVisualization(Whiteboard someWhiteboard)
        {
            InitializeComponent();
            whiteboardShown = someWhiteboard;
            pnlWhiteboard.Width = someWhiteboard.Width;
            pnlWhiteboard.Height = someWhiteboard.Height;
            Text = "Pizarrón: " + someWhiteboard.ToString();
            globalAssociations = AssociationRepository.Elements;
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(LoadWhiteboardComponentsOnInteface);
        }

        private void LoadWhiteboardComponentsOnInteface()
        {
            WhiteboardRepository.LoadContents(whiteboardShown);
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
            ImageWhiteboard imageToAdd = ElementRepository.AddNewImage(whiteboardShown,
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
            MakeDragAndDroppable(interfaceContainer);
            interfaceContainer.Click += (sender, e) => VerifyAssociationConditions(imageToAdd);
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

        private static void AddSeeCommentsOption(ElementWhiteboard domainElement, ContextMenu contMenu)
        {
            MenuItem seeComments = new MenuItem("Ver comentarios");
            seeComments.Click += (sender, e) => ClickSeeComments(domainElement);
            contMenu.MenuItems.Add(seeComments);
        }

        private static void ClickSeeComments(ElementWhiteboard sender)
        {
            Form comments = new ElementComments(sender);
            comments.Show();
            comments.TopMost = true;
        }
        private static void AddModifyImageOption(PictureBox interfaceContainer, ContextMenu contMenu,
            ImageWhiteboard domainImage)
        {
            MenuItem modifyImage = new MenuItem("Modificar imagen");
            modifyImage.Click += (sender, e) => ChangeDisplayedImage(interfaceContainer, domainImage);
            contMenu.MenuItems.Add(modifyImage);
        }

        private static void ChangeDisplayedImage(PictureBox container, ImageWhiteboard domainImage)
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
            ElementRepository.UpdateImage(domainImage, imageToSet);
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
            ElementRepository.Remove(domainElement);
            pnlWhiteboard.Controls.Remove(interfaceContainer);
            pnlWhiteboard.Update();
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {
            TextBoxWhiteboard textBoxToAdd = ElementRepository.AddNewTextBox(whiteboardShown);
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
                Location = textBoxToAdd.Position,
            };
            Action setContextMenu = delegate { SetRightClickOptionTextBox(interfaceContainer); };
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(setContextMenu);
            interfaceContainer.TextChanged += (sender, e) => UpdateElementText(interfaceContainer, textBoxToAdd);
            interfaceContainer.Click += (sender, e) => VerifyAssociationConditions(textBoxToAdd);
            MakeDragAndDroppable(interfaceContainer);
            pnlWhiteboard.Controls.Add(interfaceContainer);
        }

        private void VerifyAssociationConditions(ElementWhiteboard someElement)
        {
            VerifyAssociationAdditionConditions(someElement);
            VerifyAssociationRemovalConditions(someElement);
        }

        private void VerifyAssociationAdditionConditions(ElementWhiteboard someElement)
        {
            if (addAssociationItemsRemaining == 2)
            {
                origin = someElement;
                addAssociationItemsRemaining -= 1;
            }
            else if (addAssociationItemsRemaining == 1)
            {
                Domain.Association associationToAdd = AssociationRepository.AddNewAssociation(origin,
                    someElement);
                globalAssociations.Add(associationToAdd);
                addAssociationItemsRemaining = 0;
                pnlWhiteboard.Invalidate();
            }
        }

        private void VerifyAssociationRemovalConditions(ElementWhiteboard someElement)
        {
            if (removeAssociationItemsRemaining == 2)
            {
                origin = someElement;
                addAssociationItemsRemaining -= 1;
            }
            else if (removeAssociationItemsRemaining == 1)
            {
                AssociationRepository.RemoveAssociation(origin, someElement);
                globalAssociations = AssociationRepository.Elements;
                addAssociationItemsRemaining = 0;
                MessageBox.Show("Wololo");
            }
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

        private static void UpdateElementText(RichTextBox interfaceContainer, TextBoxWhiteboard domainTextBox)
        {
            ElementRepository.ChangeText(domainTextBox, interfaceContainer.Text);
        }

        private static void AddModifyFontDomainTextBox(RichTextBox interfaceContainer,
            TextBoxWhiteboard domainTextBox, ContextMenu contMenu)
        {
            MenuItem modifyFontItem = new MenuItem("Modificar tipo/tamaño de letra");
            modifyFontItem.Click += (sender, e) => ChangeTextBoxFont(interfaceContainer, domainTextBox);
            contMenu.MenuItems.Add(modifyFontItem);
        }

        private static void ChangeTextBoxFont(RichTextBox interfaceContainer, TextBoxWhiteboard domainTextBox)
        {
            FontDialog fontChooser = CreateFontChooser(interfaceContainer);
            if (fontChooser.ShowDialog() != DialogResult.Cancel)
            {
                Font chosenFont = fontChooser.Font;
                interfaceContainer.Font = chosenFont;
                ElementRepository.ChangeFont(domainTextBox, chosenFont);
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
            ExportingStrategy pngGenerator = new PDFConcreteExportingStrategy(pnlWhiteboard,
                whiteboardShown.Name);
            ExportImage(pngGenerator);
        }

        private void BtnPrintPng_Click(object sender, EventArgs e)
        {
            ExportingStrategy pdfGenerator = new PngConcreteExportingStrategy(pnlWhiteboard,
                whiteboardShown.Name);
            ExportImage(pdfGenerator);
        }

        private static void ExportImage(ExportingStrategy strategyToUse)
        {
            strategyToUse.ExportImage();
            InterfaceUtilities.SuccessfulOperation();
        }

        public void PnlWhiteboard_Paint(object sender, PaintEventArgs e)
        {
            int width = (pnlWhiteboard.Width + pnlWhiteboard.Height) / 300;
            e.Graphics.Clear(Color.LightGray);
            Pen line = new Pen(Color.Black, width);
            Pen arrow = new Pen(Color.Black, width)
            {
                StartCap = LineCap.ArrowAnchor,
            };
            foreach (var association in globalAssociations)
            {
                ElementWhiteboard origin = association.Origin;
                ElementWhiteboard destination = association.Destination;
                SetLinesOriginAndEndingPoints(origin, destination, out int startingX,
                    out int startingY, out int endingX, out int endingY);
                e.Graphics.DrawLine(arrow, startingX, startingY, (endingX + startingX) / 2, (endingY + startingY) / 2);
                e.Graphics.DrawLine(line, startingX, startingY, endingX, endingY);
                e.Graphics.Flush();
            }
        }

        private static void SetLinesOriginAndEndingPoints(ElementWhiteboard origin, ElementWhiteboard destination, out int startingX,
            out int startingY, out int endingX, out int endingY)
        {
            startingX = origin.RelativeX + (origin.Width / 2);
            startingY = origin.RelativeY + (origin.Height / 2);
            endingX = destination.RelativeX + (destination.Width / 2);
            endingY = destination.RelativeY + (destination.Height / 2);
            Control draggedObject = ControlMovingOrResizingHandler.interfaceObject;
            if (origin.Equals(draggedObject.Tag))
            {
                startingX = draggedObject.Location.X + (draggedObject.Width / 2);
                startingY = draggedObject.Location.Y + (draggedObject.Height / 2);
            }
            else if (destination.Equals(draggedObject.Tag))
            {
                endingX = draggedObject.Location.X + (draggedObject.Width / 2);
                endingY = draggedObject.Location.Y + (draggedObject.Height / 2);
            }
        }

        private void AddAssociationButton_Click(object sender, EventArgs e)
        {
            addAssociationItemsRemaining = 2;
            removeAssociationItemsRemaining = 0;
        }

        private void RemoveAssociationButton_Click(object sender, EventArgs e)
        {
            addAssociationItemsRemaining = 0;
            removeAssociationItemsRemaining = 2;
        }
    }
}