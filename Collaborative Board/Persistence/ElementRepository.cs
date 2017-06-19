using Domain;
using System.Data.Entity.Infrastructure;
using System.Drawing;

namespace Persistence
{
    public static class ElementRepository
    {
        public static ImageWhiteboard AddNewImage(Whiteboard container, string fileName)
        {
            using (var context = new BoardContext())
            {
                User activeUser = Session.ActiveUser();
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, ownerTeam);
                context.Entry(ownerTeam).Collection(t => t.Members);
                if (container.UserCanModify(activeUser))
                {
                    ImageWhiteboard elementToAdd = ImageWhiteboard.CreateWithContainerSource(container,
                        fileName);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    return elementToAdd;
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        public static TextBoxWhiteboard AddNewTextBox(Whiteboard container)
        {
            using (var context = new BoardContext())
            {
                User activeUser = Session.ActiveUser();
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, ownerTeam);
                context.Entry(ownerTeam).Collection(t => t.Members);
                if (container.UserCanModify(activeUser))
                {
                    TextBoxWhiteboard elementToAdd = TextBoxWhiteboard.CreateWithContainer(container);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    return elementToAdd;
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        public static void UpdateElementPositionAndSize(ElementWhiteboard elementToModify, Size newDimensions,
            Point newPosition)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                elementToModify.Dimensions = newDimensions;
                elementToModify.Position = newPosition;
                var entry = context.Entry(elementToModify);
                MarkPositionAndSizePropertiesAsChanged(entry);
                context.SaveChanges();
            }
        }

        private static void MarkPositionAndSizePropertiesAsChanged(DbEntityEntry<ElementWhiteboard> entry)
        {
            entry.Property(e => e.RelativeX).IsModified = true;
            entry.Property(e => e.RelativeX).IsModified = true;
            entry.Property(e => e.Width).IsModified = true;
            entry.Property(e => e.Height).IsModified = true;
        }

        public static void UpdateImage(ImageWhiteboard elementToModify, Image newImage)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                elementToModify.ActualImage = newImage;
                context.Entry(elementToModify).Property(i => i.ImageToSave).IsModified = true;
                context.SaveChanges();
            }
        }

        public static void UpdateFont(TextBoxWhiteboard elementToModify, Font newFont)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                elementToModify.TextFont = newFont;
                context.Entry(elementToModify).Property(t => t.FontToSave).IsModified = true;
                context.SaveChanges();
            }
        }

        public static void UpdateText(TextBoxWhiteboard elementToModify, string newText)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                elementToModify.TextContent = newText;
                context.SaveChanges();
            }
        }

        public static void Remove(ElementWhiteboard elementToRemove)
        {
            EntityFrameworkUtilities<ElementWhiteboard>.Remove(elementToRemove);
        }
    }
}