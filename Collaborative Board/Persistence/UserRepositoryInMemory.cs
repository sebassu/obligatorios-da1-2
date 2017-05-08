using Domain;
using System;
using Exceptions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Persistence
{
    public class UserRepositoryInMemory : UserRepository
    {
        public override void AddNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            User userToAdd = User.NamesEmailBirthdatePassword(firstName, lastName,
                email, birthdate, password);
            Add(userToAdd);
        }

        public override void AddNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            Administrator administratorToAdd = Administrator.NamesEmailBirthdatePassword(firstName,
                lastName, email, birthdate, password);
            Add(administratorToAdd);
        }

        public override void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            if (elements.Contains(userToModify))
            {
                SetUserAttributes(userToModify, firstNameToSet, lastNameToSet,
                    emailToSet, birthdateToSet, passwordToSet);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void SetUserAttributes(User userToModify, string firstNameToSet,
            string lastNameToSet, string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            userToModify.FirstName = firstNameToSet;
            userToModify.LastName = lastNameToSet;
            userToModify.Email = emailToSet;
            userToModify.Birthdate = birthdateToSet;
            userToModify.Password = passwordToSet;
        }

        internal UserRepositoryInMemory()
        {
            elements = new List<User>();
        }
    }
}