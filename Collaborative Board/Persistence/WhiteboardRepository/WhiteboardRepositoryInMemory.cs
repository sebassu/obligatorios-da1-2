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
            User activeUser = Session.ActiveUser();
            whiteboardToModify = GetActualObjectInCollection(whiteboardToModify);
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

        private void AttemptToSetWhiteboardAttributes(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
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
            return ownerTeam.Equals(otherWhiteboard.OwnerTeam) &&
                otherWhiteboard.Name == nameToSet;
        }

        public override void Remove(Whiteboard elementToRemove)
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

        private void PerformRemove(Whiteboard elementToRemove)
        {
            Team whiteboardsOwnerTeam = elementToRemove.OwnerTeam;
            whiteboardsOwnerTeam.RemoveWhiteboard(elementToRemove);
            base.Remove(elementToRemove);
        }

        internal override void RemoveDueToTeamDeletion(Whiteboard whiteboardToRemove)
        {
            PerformRemove(whiteboardToRemove);
        }

        internal WhiteboardRepositoryInMemory()
        {
            elements = new List<Whiteboard>();
        }
    }
}