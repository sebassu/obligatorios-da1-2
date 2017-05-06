using Domain;
using System;
using Exceptions;
using System.Collections.Generic;

namespace Persistence
{
    public class UserDirectoryInMemory : UserDirectory
    {
        private List<User> users = new List<User>();

        public IReadOnlyCollection<User> Elements => users.AsReadOnly();

        public void AddNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            User userToAdd = User.NamesEmailBirthdatePassword(firstName, lastName,
                email, birthdate, password);
            if (!users.Contains(userToAdd))
            {
                users.Add(userToAdd);
            }
            else
            {
                throw new DirectoryException(ErrorMessages.ElementAlreadyExists);
            }
        }

        public void Remove(User userToRemove)
        {
            if (!users.Remove(userToRemove))
            {
                throw new DirectoryException(ErrorMessages.ElementDoesNotExist);
            }
        }
    }
}
