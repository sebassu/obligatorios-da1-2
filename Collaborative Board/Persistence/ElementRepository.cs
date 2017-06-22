using Domain;
using System.Drawing;
using System.Data.Entity.Infrastructure;

namespace Persistence
{
    public static class ElementRepository
    {
        public static ImageWhiteboard AddNewImage(Whiteboard container, string fileName)
        {
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                context.Entry(ownerTeam).Collection(t => t.Members).Load();
                if (container.UserCanModify(activeUser))
                {
                    ImageWhiteboard elementToAdd = ImageWhiteboard.CreateWithContainerSource(container,
                        fileName);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    AddCorrespondingScoreToTeam(container);
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
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, ownerTeam);
                context.Entry(ownerTeam).Collection(t => t.Members).Load();
                if (container.UserCanModify(activeUser))
                {
                    TextBoxWhiteboard elementToAdd = TextBoxWhiteboard.CreateWithContainer(container);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    AddCorrespondingScoreToTeam(container);
                    return elementToAdd;
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        private static void AddCorrespondingScoreToTeam(Whiteboard container)
        {
            int scoreToAdd = ScoringManagerRepository.GetScores().AddElementScore;
            UserScoresRepository.UpdateUserScoreInTeam(container.OwnerTeam.Id, scoreToAdd);
        }

        public static void UpdateElementPositionAndSize(ElementWhiteboard elementToModify, Size newDimensions,
            Point newPosition)
        {
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                if (elementToModify.CanModifyElement(activeUser))
                {
                    PerformDimensionsAndPositionModification(elementToModify, newDimensions, newPosition, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        private static void PerformDimensionsAndPositionModification(ElementWhiteboard elementToModify,
            Size newDimensions, Point newPosition, BoardContext context)
        {
            elementToModify.Dimensions = newDimensions;
            elementToModify.Position = newPosition;
            var entry = context.Entry(elementToModify);
            MarkDimensionsAndPositionPropertiesAsChanged(entry);
            context.SaveChanges();
        }

        private static void MarkDimensionsAndPositionPropertiesAsChanged(DbEntityEntry<ElementWhiteboard> entry)
        {
            entry.Property(e => e.RelativeX).IsModified = true;
            entry.Property(e => e.RelativeY).IsModified = true;
            entry.Property(e => e.Width).IsModified = true;
            entry.Property(e => e.Height).IsModified = true;
        }

        public static void UpdateImage(ImageWhiteboard elementToModify, Image newImage)
        {
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                if (elementToModify.CanModifyElement(activeUser))
                {
                    PerformImageChange(elementToModify, newImage, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        private static void PerformImageChange(ImageWhiteboard elementToModify, Image newImage, BoardContext context)
        {
            elementToModify.ActualImage = newImage;
            context.Entry(elementToModify).Property(i => i.ImageToSave).IsModified = true;
            context.SaveChanges();
        }

        public static void ChangeFont(TextBoxWhiteboard elementToModify, Font newFont)
        {
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                if (elementToModify.CanModifyElement(activeUser))
                {
                    PerformFontChange(elementToModify, newFont, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        private static void PerformFontChange(TextBoxWhiteboard elementToModify, Font newFont, BoardContext context)
        {
            elementToModify.TextFont = newFont;
            context.Entry(elementToModify).Property(t => t.FontToSave).IsModified = true;
            context.SaveChanges();
        }

        public static void ChangeText(TextBoxWhiteboard elementToModify, string newText)
        {
            User activeUser = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, elementToModify);
                if (elementToModify.CanModifyElement(activeUser))
                {
                    PerformTextChange(elementToModify, newText, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        private static void PerformTextChange(TextBoxWhiteboard elementToModify, string newText, BoardContext context)
        {
            elementToModify.TextContent = newText;
            context.SaveChanges();
        }

        public static void Remove(ElementWhiteboard elementToRemove)
        {
            EntityFrameworkUtilities<ElementWhiteboard>.Remove(elementToRemove);
        }

        public static void LoadComments(ElementWhiteboard someElement)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, someElement);
                context.Entry(someElement).Collection(e => e.Comments).Load();
            }
        }
    }
}