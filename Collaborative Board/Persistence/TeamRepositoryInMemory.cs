using Domain;
using Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class TeamRepositoryInMemory : TeamRepository
    {
        public override Team AddNewTeam(string name, string description, int maximumMembers)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            User creator = Session.ActiveUser();
            Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                name, description, maximumMembers);
            Add(teamToAdd);
            return teamToAdd;
        }

        public override void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            teamToModify = GetActualObjectInCollection(teamToModify);
            AttemptToSetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                maximumMembersToSet);
        }

        private void AttemptToSetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            if (ChangeDoesNotCauseRepeatedTeamNames(teamToModify, nameToSet))
            {
                SetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                    maximumMembersToSet);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.TeamNameMustBeUnique);
            }
        }

        private static void SetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            teamToModify.Name = nameToSet;
            teamToModify.Description = descriptionToSet;
            teamToModify.MaximumMembers = maximumMembersToSet;
        }

        private bool ChangeDoesNotCauseRepeatedTeamNames(Team teamToModify, string nameToSet)
        {
            bool nameDoesNotChange = teamToModify.Name == nameToSet;
            return nameDoesNotChange || ThereIsNoTeamWithName(nameToSet);
        }

        private bool ThereIsNoTeamWithName(string nameToSet)
        {
            return !elements.Any(t => t.Name == nameToSet);
        }

        public override void Remove(Team elementToRemove)
        {
            if (Utilities.IsNotNull(elementToRemove))
            {
                RemoveAllTeamWhiteboardsFromRepository(elementToRemove);
                base.Remove(elementToRemove);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void RemoveAllTeamWhiteboardsFromRepository(Team elementToRemove)
        {
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            var teamWhiteboards = elementToRemove.CreatedWhiteboards.ToList();
            foreach (var whiteboard in teamWhiteboards)
            {
                globalWhiteboards.RemoveDueToTeamDeletion(whiteboard);
            }
        }

        public override void AddMemberToTeam(Team teamToAddTo, User userToAdd)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            teamToAddTo = GetActualObjectInCollection(teamToAddTo);
            UserRepository users = UserRepository.GetInstance();
            userToAdd = users.GetActualObjectInCollection(userToAdd);
            teamToAddTo.AddMember(userToAdd);
        }

        public override void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            teamToRemoveFrom = GetActualObjectInCollection(teamToRemoveFrom);
            teamToRemoveFrom.RemoveMember(userToRemove);
        }

        internal TeamRepositoryInMemory()
        {
            elements = new List<Team>();
        }
    }
}