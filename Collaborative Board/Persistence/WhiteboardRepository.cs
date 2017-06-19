using Domain;
using Exceptions;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Persistence
{
    public abstract class WhiteboardRepository : EntityFrameworkRepository<Whiteboard>
    {
        public static List<Whiteboard> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    return context.Whiteboards.Include("Creator")
                        .Include("OwnerTeam").ToList();
                }
            }
        }

        public static Whiteboard AddNewWhiteboard(string name, string description,
            Team ownerTeam, int width, int height)
        {
            using (var context = new BoardContext())
            {
                User creator = Session.ActiveUser();
                TeamRepository.LoadMembers(ownerTeam);
                TeamRepository.LoadCreatedWhiteboards(ownerTeam);
                Whiteboard whiteboardToAdd = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                    name, description, ownerTeam, width, height);
                Add(context, whiteboardToAdd);
                return whiteboardToAdd;
            }
        }

        public static void ModifyWhiteboard(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
        {
            if (Utilities.IsNotNull(whiteboardToModify))
            {
                try
                {
                    AttemptToModifyWhiteboard(whiteboardToModify, nameToSet,
                        descriptionToSet, widthToSet, heightToSet);
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void AttemptToModifyWhiteboard(Whiteboard whiteboardToModify, string nameToSet,
            string descriptionToSet, int widthToSet, int heightToSet)
        {
            if (ChangeDoesNotCauseSameWhiteboardNameAndTeam(whiteboardToModify, nameToSet))
            {
                AttemptToSetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
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

        private static void AttemptToSetWhiteboardAttributes(Whiteboard whiteboardToModify,
            string nameToSet, string descriptionToSet, int widthToSet, int heightToSet)
        {
            using (var context = new BoardContext())
            {
                User activeUser = Session.ActiveUser();
                TeamRepository.LoadMembers(whiteboardToModify.OwnerTeam);
                if (whiteboardToModify.UserCanModify(activeUser))
                {
                    AttachIfIsValid(context, whiteboardToModify);
                    SetWhiteboardAttributes(whiteboardToModify, nameToSet, descriptionToSet,
                        widthToSet, heightToSet);
                    context.SaveChanges();
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserCannotModifyWhiteboard);
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
                return !elements.Any(w => ownerTeam.Id == (w.OwnerTeam.Id)
                    && w.Name == nameToSet);
            }
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
    }
}
