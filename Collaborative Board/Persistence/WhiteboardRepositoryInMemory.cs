using Domain;
using Exceptions;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Persistence
{
    public class WhiteboardRepositoryInMemory : WhiteboardRepository
    {
        public override Whiteboard AddNewWhiteboard(string name, string description,
            Team ownerTeam, int width, int height)
        {
            User creator = Session.ActiveUser();
            Whiteboard whiteboardToAdd = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                name, description, ownerTeam, width, height);
            Add(whiteboardToAdd);
            return whiteboardToAdd;
        }

        public override void ModifyWhiteboard(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
        {
            ValidateUserIsAdministratorOrCreator(whiteboardToModify);
            whiteboardToModify = GetActualObjectInCollection(whiteboardToModify);
            AttemptToSetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
                widthToSet, heightToSet);
        }

        private static void ValidateUserIsAdministratorOrCreator(Whiteboard whiteboardToModify)
        {
            User activeUser = Session.ActiveUser();
            bool isAdministratorOrCreator = activeUser.HasAdministrationPrivileges ||
                activeUser.Equals(whiteboardToModify.Creator);
            if (!isAdministratorOrCreator)
            {
                throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
            }
        }

        private void AttemptToSetWhiteboardAttributes(Whiteboard whiteboardToModify, string nameToSet,
            string descriptionToSet, int widthToSet, int heightToSet)
        {
            if (ChangeDoesNotCauseSameWhiteboardNameAndTeam(whiteboardToModify, nameToSet))
            {
                SetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
                    widthToSet, heightToSet);
            }
            else
            {
                string ownerTeamName = whiteboardToModify.OwnerTeam.Name;
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.WhiteboardNameTeamMustBeUnique, ownerTeamName, nameToSet);
                throw new RepositoryException(errorMessage);
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

        private bool ChangeDoesNotCauseSameWhiteboardNameAndTeam(Whiteboard whiteboardToModify,
            string nameToSet)
        {
            bool nameDoesNotChange = whiteboardToModify.Name == nameToSet;
            return nameDoesNotChange ||
                ThereIsNoWhiteboardWithNameAndTeam(whiteboardToModify.OwnerTeam, nameToSet);
        }

        private bool ThereIsNoWhiteboardWithNameAndTeam(Team ownerTeam, string nameToSet)
        {
            return !elements.Any(w => OwnerTeamAndNameEqual(ownerTeam, nameToSet, w));
        }

        private static bool OwnerTeamAndNameEqual(Team ownerTeam, string nameToSet,
            Whiteboard otherWhiteboard)
        {
            return ownerTeam.Equals(otherWhiteboard.OwnerTeam) && otherWhiteboard.Name == nameToSet;
        }

        public override void Remove(Whiteboard elementToRemove)
        {
            if (elementToRemove != null)
            {
                Team whiteboardsOwnerTeam = elementToRemove.OwnerTeam;
                whiteboardsOwnerTeam.RemoveWhiteboard(elementToRemove);
                base.Remove(elementToRemove);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        internal WhiteboardRepositoryInMemory()
        {
            elements = new List<Whiteboard>();
        }
    }
}