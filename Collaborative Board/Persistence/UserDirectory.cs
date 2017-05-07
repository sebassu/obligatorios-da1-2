using Domain;
using System;

namespace Persistence
{
    public abstract class UserDirectory : DirectoryInMemory<User>
    {
        public abstract void AddNewUser(string firstName, string lastName, string email,
            DateTime birthdate, string password);
        public abstract void AddNewAdministrator(string firstName, string lastName, string email,
            DateTime birthdate, string password);
        public abstract void ModifyUser(User userToModify, string firstName, string lastName,
            string email, DateTime birthdate, string password);

        private static volatile UserDirectoryInMemory instance;
        private static object syncRoot = new Object();

        public static UserDirectoryInMemory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new UserDirectoryInMemory();
                    }
                }
            }

            return instance;
        }
    }
}