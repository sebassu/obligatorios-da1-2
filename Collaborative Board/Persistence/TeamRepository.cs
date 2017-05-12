using System;
using Domain;

namespace Persistence
{
    public abstract class TeamRepository : RepositoryInMemory<Team>
    {
        public abstract Team AddNewTeam(string name, string description, int maximumMembers);
        public abstract void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet);
        public abstract void AddMemberToTeam(Team teamToAddTo, User userToAdd);
        public abstract void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove);

        private static volatile TeamRepositoryInMemory instance;
        private static object syncRoot = new Object();
        public static TeamRepositoryInMemory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new TeamRepositoryInMemory();
                    }
                }
            }

            return instance;
        }
    }
}