using System;
using Domain;

namespace Persistence
{
    public abstract class TeamRepository : Repository<Team>
    {
        public abstract void AddNewTeam(string name, string description, int maximumMembers);
        public abstract void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet);

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