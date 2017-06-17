using Domain;
using Exceptions;
using System.Globalization;
using System.Linq;

namespace Persistence
{
    public abstract class WhiteboardRepository : EntityFrameworkRepository<Whiteboard>
    {
        public static Whiteboard AddNewWhiteboard(string name, string description,
            Team ownerTeam, int width, int height)
        {
            User creator = Session.ActiveUser();
            Whiteboard whiteboardToAdd = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                name, description, ownerTeam, width, height);
            Add(whiteboardToAdd);
            return whiteboardToAdd;
        }

        public static void ModifyWhiteboard(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
        {
            User activeUser = Session.ActiveUser();
            if (whiteboardToModify.UserCanModify(activeUser))
            {
                AttemptToSetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
                    widthToSet, heightToSet);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
            }
        }

        private static void AttemptToSetWhiteboardAttributes(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
        {
            using (var context = new BoardContext())
            {
                if (ChangeDoesNotCauseSameWhiteboardNameAndTeam(whiteboardToModify, nameToSet))
                {
                    AttachIfCorresponds(context, whiteboardToModify);
                    SetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
                        widthToSet, heightToSet);
                    context.SaveChanges();
                }
                else
                {
                    string ownerTeamName = whiteboardToModify.OwnerTeam.Name;
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.WhiteboardNameTeamMustBeUnique, ownerTeamName, nameToSet);
                    throw new RepositoryException(errorMessage);
                }
            }
        }

        private static void SetWhiteboardAttributes(Whiteboard whiteboardToModify, string nameToSet,
            string descriptionToSet, int widthToSet, int heightToSet)
        {
            whiteboardToModify.Name = nameToSet;
            whiteboardToModify.Description = descriptionToSet;
            whiteboardToModify.Width = widthToSet;
            whiteboardToModify.Height = heightToSet;
        }

        private static bool ChangeDoesNotCauseSameWhiteboardNameAndTeam(Whiteboard whiteboardToModify,
            string nameToSet)
        {
            bool nameDoesNotChange = whiteboardToModify.Name == nameToSet;
            return nameDoesNotChange ||
                ThereIsNoWhiteboardWithNameAndTeam(whiteboardToModify.OwnerTeam, nameToSet);
        }

        private static bool ThereIsNoWhiteboardWithNameAndTeam(Team ownerTeam, string nameToSet)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Whiteboards;
                return !elements.Any(w => OwnerTeamAndNameEqual(ownerTeam, nameToSet, w));
            }
        }

        private static bool OwnerTeamAndNameEqual(Team ownerTeam, string nameToSet,
            Whiteboard otherWhiteboard)
        {
            return ownerTeam.Equals(otherWhiteboard.OwnerTeam) &&
                otherWhiteboard.Name == nameToSet;
        }

        new public static void Remove(Whiteboard elementToRemove)
        {
            ValidateUserCanRemoveWhiteboard(elementToRemove);
            PerformRemove(elementToRemove);
        }

        private static void ValidateUserCanRemoveWhiteboard(Whiteboard whiteboardToRemove)
        {
            User activeUser = Session.ActiveUser();
            bool cannotPerformRemoval = whiteboardToRemove == null
                || !whiteboardToRemove.UserCanRemove(activeUser);
            if (cannotPerformRemoval)
            {
                throw new RepositoryException(ErrorMessages.UserCannotRemoveWhiteboard);
            }
        }

        private static void PerformRemove(Whiteboard elementToRemove)
        {
            Team whiteboardsOwnerTeam = elementToRemove.OwnerTeam;
            whiteboardsOwnerTeam.RemoveWhiteboard(elementToRemove);
            EntityFrameworkRepository<Whiteboard>.Remove(elementToRemove);
        }

        internal static void RemoveDueToTeamDeletion(Whiteboard whiteboardToRemove)
        {
            PerformRemove(whiteboardToRemove);
        }

        internal static void RemoveAllWhiteboards()
        {
            using (var context = new BoardContext())
            {
                context.RemoveAllWhiteboards();
            }
        }
    }
}
