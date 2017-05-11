using Domain;
using System;

namespace Persistence
{
    public abstract class WhiteboardRepository : RepositoryInMemory<Whiteboard>
    {
        public abstract Whiteboard AddNewWhiteboard(string name, string description,
            Team ownerTeam, int width, int height);

        private static volatile WhiteboardRepositoryInMemory instance;
        private static object syncRoot = new Object();
        public static WhiteboardRepositoryInMemory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new WhiteboardRepositoryInMemory();
                    }
                }
            }

            return instance;
        }
    }
}
