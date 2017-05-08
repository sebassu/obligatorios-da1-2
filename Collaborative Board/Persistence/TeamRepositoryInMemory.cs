using Domain;
using Exceptions;
using System.Collections.Generic;

namespace Persistence
{
    public class TeamRepositoryInMemory : TeamRepository
    {
        public override void AddNewTeam(string name, string description, int maximumMembers)
        {

            if (Session.HasAdministrationPrivileges())
            {
                User creator = Session.ActiveUser();
                Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                    name, description, maximumMembers);
                Add(teamToAdd);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.NoAdministrationPrivileges);
            }
        }

        internal TeamRepositoryInMemory()
        {
            elements = new List<Team>();
        }
    }
}
