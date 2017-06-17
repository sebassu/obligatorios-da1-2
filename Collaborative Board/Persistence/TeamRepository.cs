using Domain;
using Exceptions;
using System.Linq;

namespace Persistence
{
    public abstract class TeamRepository : EntityFrameworkRepository<Team>
    {
        public static Team AddNewTeam(string name, string description, int maximumMembers)
        {
            using (var context = new BoardContext())
            {
                ValidateActiveUserHasAdministrationPrivileges();
                User creator = Session.ActiveUser();
                EntityFrameworkRepository<User>.AttachIfCorresponds(context, creator);
                Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                    name, description, maximumMembers);
                Add(context, teamToAdd);
                return teamToAdd;
            }
        }

        public static void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            AttemptToSetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                maximumMembersToSet);
        }

        private static void AttemptToSetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            using (var context = new BoardContext())
            {
                if (ChangeDoesNotCauseRepeatedTeamNames(teamToModify, nameToSet))
                {
                    AttachIfCorresponds(context, teamToModify);
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
            return !Elements.Any(t => t.Name == nameToSet);
        }

        new public static void Remove(Team elementToRemove)
        {
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

        private static void RemoveAllTeamWhiteboardsFromRepository(Team elementToRemove)
        {
            var teamWhiteboards = elementToRemove.CreatedWhiteboards.ToList();
            foreach (var whiteboard in teamWhiteboards)
            {
                WhiteboardRepository.RemoveDueToTeamDeletion(whiteboard);
            }
        }

        public static void AddMemberToTeam(Team teamToAddTo, User userToAdd)
        {
            using (var context = new BoardContext())
            {
                ValidateActiveUserHasAdministrationPrivileges();
                AttachIfCorresponds(context, teamToAddTo);
                EntityFrameworkRepository<User>.AttachIfCorresponds(context, userToAdd);
                teamToAddTo.AddMember(userToAdd);
                context.SaveChanges();
            }
        }

        public static void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove)
        {
            using (var context = new BoardContext())
            {
                ValidateActiveUserHasAdministrationPrivileges();
                AttachIfCorresponds(context, teamToRemoveFrom);
                EntityFrameworkRepository<User>.AttachIfCorresponds(context, userToRemove);
                teamToRemoveFrom.RemoveMember(userToRemove);
                context.SaveChanges();
            }
        }

        internal static void RemoveAllTeams()
        {
            using (var context = new BoardContext())
            {
                context.RemoveAllTeams();
            }
        }
    }
}