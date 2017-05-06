using Domain;
using System;
using Exceptions;
using System.Collections;
using System.Collections.Generic;

namespace Persistence
{
    public class UserDirectoryInMemory : UserDirectory
    {
        private List<User> users = new List<User>();

        public IList Elements => users.AsReadOnly();

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
                throw new DirectoryException("El elemento recibido ya existe en " +
                    "el sistema.");
            }
        }

        public void Remove(User userToRemove)
        {
            if (!users.Remove(userToRemove))
            {
                throw new DirectoryException("Elemento inválido recibido: no se " +
                    "encuentra registrado en el sistema.");
            }
        }
    }
}
