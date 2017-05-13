using Domain;
using System;
using Exceptions;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Persistence
{
    public class UserRepositoryInMemory : UserRepository
    {
        public override User AddNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            User userToAdd = User.NamesEmailBirthdatePassword(firstName, lastName,
                email, birthdate, password);
            Add(userToAdd);
            return userToAdd;
        }

        public override Administrator AddNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            Administrator administratorToAdd = Administrator.NamesEmailBirthdatePassword(firstName,
                lastName, email, birthdate, password);
            Add(administratorToAdd);
            return administratorToAdd;
        }

        public override void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            userToModify = GetActualObjectInCollection(userToModify);
            AttemptToSetUserAttributes(userToModify, firstNameToSet, lastNameToSet,
                emailToSet, birthdateToSet, passwordToSet);
        }

        private void AttemptToSetUserAttributes(User userToModify, string firstNameToSet,
            string lastNameToSet, string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            if (ChangeDoesNotCauseRepeatedUserEmails(userToModify, emailToSet))
            {
                SetUserAttributes(userToModify, firstNameToSet, lastNameToSet, emailToSet,
                    birthdateToSet, passwordToSet);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.UserEmailMustBeUnique);
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

        private bool ChangeDoesNotCauseRepeatedUserEmails(User userToModify, string emailToSet)
        {
            bool emailDoesNotChange = userToModify.Email == emailToSet;
            return emailDoesNotChange || ThereIsNoTeamWithName(emailToSet);
        }

        private bool ThereIsNoTeamWithName(string emailToSet)
        {
            return !elements.Any(u => u.Email == emailToSet);
        }

        public override string ResetUsersPassword(User userToModify)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            userToModify = GetActualObjectInCollection(userToModify);
            return userToModify.ResetPassword();
        }

        public override void Remove(User elementToRemove)
        {
            if (IsTheOnlyAdministratorLeft(elementToRemove))
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                base.Remove(elementToRemove);
            }
        }

        private bool IsTheOnlyAdministratorLeft(User elementToRemove)
        {
            var administrators = elements.Where(u => Utilities.HasAdministrationPrivileges(u)).ToList();
            return administrators.Count == 1 && administrators.Single().Equals(elementToRemove);
        }

        internal UserRepositoryInMemory()
        {
            elements = new List<User>();
            InsertOriginalSystemAdministrator();
        }

        private void InsertOriginalSystemAdministrator()
        {
            Administrator baseAdministrator = Administrator.NamesEmailBirthdatePassword("The",
                "Administrator", "administrator@tf2.com", DateTime.Today, "Victory");
            elements.Add(baseAdministrator);
        }
    }
}