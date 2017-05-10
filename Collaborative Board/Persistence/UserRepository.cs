using Domain;
using System;

namespace Persistence
{
    public abstract class UserRepository : RepositoryInMemory<User>
    {
        public abstract User AddNewUser(string firstName, string lastName, string email,
            DateTime birthdate, string password);
        public abstract Administrator AddNewAdministrator(string firstName, string lastName, string email,
            DateTime birthdate, string password);
        public abstract void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet);

        private static volatile UserRepositoryInMemory instance;
        private static object syncRoot = new Object();
        public static UserRepositoryInMemory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new UserRepositoryInMemory();
                    }
                }
            }

            return instance;
        }
    }
}