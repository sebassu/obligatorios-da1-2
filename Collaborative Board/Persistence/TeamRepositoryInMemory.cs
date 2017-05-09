using Domain;
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

        internal TeamRepositoryInMemory()
        {
            elements = new List<Team>();
        }
    }
}