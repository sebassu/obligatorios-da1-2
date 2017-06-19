using Domain;
using Exceptions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Persistence
{
    public abstract class TeamRepository : EntityFrameworkRepository<Team>
    {
        public static List<Team> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Teams;
                    return elements.ToList();
                }
            }
        }

        public static Team AddNewTeam(string name, string description, int maximumMembers)
        {
            using (var context = new BoardContext())
            {
                ValidateActiveUserHasAdministrationPrivileges();
                if (ThereIsNoTeamWithName(name))
                {
                    User creator = Session.ActiveUser();
                    EntityFrameworkRepository<User>.AttachIfIsValid(context, creator);
                    Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                        name, description, maximumMembers);
                    Add(context, teamToAdd);
                    return teamToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.TeamNameMustBeUnique);
                }
            }
        }

        public static void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            try
            {
                ValidateActiveUserHasAdministrationPrivileges();
                AttemptToSetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                    maximumMembersToSet);
            }
            catch (DataException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.Message);
            }
        }

        private static void AttemptToSetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            using (var context = new BoardContext())
            {
                AttachIfIsValid(context, teamToModify);
                if (ChangeDoesNotCauseRepeatedTeamNames(teamToModify, nameToSet))
                {
                    SetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                        maximumMembersToSet);
                    context.SaveChanges();
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.TeamNameMustBeUnique);
                }
            }
        }

        private static void SetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            teamToModify.Name = nameToSet;
            teamToModify.Description = descriptionToSet;
            teamToModify.MaximumMembers = maximumMembersToSet;
        }

        private static bool ChangeDoesNotCauseRepeatedTeamNames(Team teamToModify, string nameToSet)
        {
            bool nameDoesNotChange = teamToModify.Name == nameToSet;
            return nameDoesNotChange || ThereIsNoTeamWithName(nameToSet);
        }

        private static bool ThereIsNoTeamWithName(string nameToSet)
        {
            using (var context = new BoardContext())
            {
                return !context.Teams.Any(t => t.Name == nameToSet);
            }
        }

        new public static void Remove(Team elementToRemove)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            if (Utilities.IsNotNull(elementToRemove))
            {
                RemoveAllTeamWhiteboardsFromRepository(elementToRemove);
                EntityFrameworkRepository<Team>.Remove(elementToRemove);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void RemoveAllTeamWhiteboardsFromRepository(Team teamToRemove)
        {
            LoadCreatedWhiteboards(teamToRemove);
            var teamWhiteboards = teamToRemove.CreatedWhiteboards.ToList();
            foreach (var whiteboard in teamWhiteboards)
            {
                WhiteboardRepository.RemoveDueToTeamDeletion(whiteboard);
            }
        }

        public static void AddMemberToTeam(Team teamToAddTo, User userToAdd)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    AttemptToAddMemberToTeam(teamToAddTo, userToAdd, context);
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        private static void AttemptToAddMemberToTeam(Team teamToAddTo, User userToAdd,
            BoardContext context)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            AttachIfIsValid(context, teamToAddTo);
            teamToAddTo.AddMember(userToAdd);
            context.SaveChanges();
        }

        public static void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    AttemptToRemoveMemberFromTeam(teamToRemoveFrom, userToRemove, context);
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        private static void AttemptToRemoveMemberFromTeam(Team teamToRemoveFrom, User
            userToRemove, BoardContext context)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            AttachIfIsValid(context, teamToRemoveFrom);
            teamToRemoveFrom.RemoveMember(userToRemove);
            context.SaveChanges();
        }

        public static void LoadMembers(Team someTeam)
        {
            using (var context = new BoardContext())
            {
                AttachIfIsValid(context, someTeam);
                context.Entry(someTeam).Collection(t => t.Members).Load();
            }
        }

        public static void LoadCreatedWhiteboards(Team someTeam)
        {
            using (var context = new BoardContext())
            {
                AttachIfIsValid(context, someTeam);
                context.Entry(someTeam).Collection(t => t.CreatedWhiteboards).Load();
            }
        }
    }
}