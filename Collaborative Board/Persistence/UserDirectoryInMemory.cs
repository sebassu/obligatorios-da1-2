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

        public void AddNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            Administrator administratorToAdd = Administrator.NamesEmailBirthdatePassword(firstName,
                lastName, email, birthdate, password);
            if (!users.Contains(administratorToAdd))
            {
                users.Add(administratorToAdd);
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

        public void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            if (users.Contains(userToModify))
            {
                SetUserAttributes(userToModify, firstNameToSet, lastNameToSet,
                    emailToSet, birthdateToSet, passwordToSet);
            }
            else
            {
                throw new DirectoryException("El elemento recibido no se encuentra " +
                    "registrado en el sistema.");
            }
        }

        private static void SetUserAttributes(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            userToModify.FirstName = firstNameToSet;
            userToModify.LastName = lastNameToSet;
            userToModify.Email = emailToSet;
            userToModify.Birthdate = birthdateToSet;
            userToModify.Password = passwordToSet;
        }

        public bool HasElements()
        {
            return users.Count != 0;
        }
    }
}
