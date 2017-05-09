using Domain;
using Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class TeamRepositoryInMemory : TeamRepository
    {
        public override void AddNewTeam(string name, string description, int maximumMembers)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            User creator = Session.ActiveUser();
            Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                name, description, maximumMembers);
            Add(teamToAdd);
        }

        public override void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            if (elements.Contains(teamToModify))
            {
                SetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                    maximumMembersToSet);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private void SetTeamAttributes(Team teamToModify, string nameToSet, string descriptionToSet,
            int maximumMembersToSet)
        {
            if (ChangeDoesNotCauseRepeatedTeamNames(teamToModify, nameToSet))
            {
                teamToModify.Name = nameToSet;
                teamToModify.Description = descriptionToSet;
                teamToModify.MaximumMembers = maximumMembersToSet;
            }
        }

        private bool ChangeDoesNotCauseRepeatedTeamNames(Team teamToModify, string nameToSet)
        {
            bool nameDoesNotChange = teamToModify.Name == nameToSet;
            return nameDoesNotChange || ThereIsNoTeamWithName(nameToSet);
        }

        private bool ThereIsNoTeamWithName(string nameToSet)
        {
            return elements.Count(t => t.Name == nameToSet) == 0;
        }

        internal TeamRepositoryInMemory()
        {
            elements = new List<Team>();
        }
    }
}