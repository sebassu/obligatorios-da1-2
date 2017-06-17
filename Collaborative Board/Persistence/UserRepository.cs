using Domain;
using System;
using Exceptions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Entity;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Persistence
{
    public abstract class UserRepository : EntityFrameworkRepository<User>
    {
        public static User AddNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            User userToAdd = User.CreateNewCollaborator(firstName, lastName,
                email, birthdate, password);
            Add(userToAdd);
            return userToAdd;
        }

        public static User AddNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            User UserToAdd = User.CreateNewAdministrator(firstName,
                lastName, email, birthdate, password);
            Add(UserToAdd);
            return UserToAdd;
        }

        public static void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            AttemptToSetUserAttributes(userToModify, firstNameToSet, lastNameToSet,
                emailToSet, birthdateToSet, passwordToSet);
        }

        private static void AttemptToSetUserAttributes(User userToModify, string firstNameToSet,
            string lastNameToSet, string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            using (var context = new BoardContext())
            {
                if (ChangeDoesNotCauseRepeatedUserEmails(userToModify, emailToSet))
                {
                    AttachIfCorresponds(context, userToModify);
                    SetUserAttributes(userToModify, firstNameToSet, lastNameToSet, emailToSet,
                        birthdateToSet, passwordToSet);
                    context.SaveChanges();
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserEmailMustBeUnique);
                }
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

        private static bool ChangeDoesNotCauseRepeatedUserEmails(User userToModify, string emailToSet)
        {
            bool emailDoesNotChange = userToModify.Email == emailToSet;
            return emailDoesNotChange || ThereIsNoTeamWithName(emailToSet);
        }

        private static bool ThereIsNoTeamWithName(string emailToSet)
        {
            return !Elements.Any(u => u.Email == emailToSet);
        }

        public static string ResetUsersPassword(User userToModify)
        {
            using (var context = new BoardContext())
            {
                ValidateActiveUserHasAdministrationPrivileges();
                AttachIfCorresponds(context, userToModify);
                string result = userToModify.ResetPassword();
                context.SaveChanges();
                return result;
            }
        }

        new public static void Remove(User elementToRemove)
        {
            ValidateActiveUserHasAdministrationPrivileges();
            if (IsTheOnlyUserLeft(elementToRemove))
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                ValidateNoWhiteboardHasUserAsCreator(elementToRemove);
                EntityFrameworkRepository<User>.Remove(elementToRemove);
            }
        }

        private static void ValidateNoWhiteboardHasUserAsCreator(User elementToRemove)
        {
            var allWhiteboards = WhiteboardRepository.Elements;
            bool userToRemoveIsCreator = allWhiteboards.Any(w => w.Creator.Equals(elementToRemove));
            if (userToRemoveIsCreator)
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveWhiteboardCreator);
            }
        }

        private static bool IsTheOnlyUserLeft(User elementToRemove)
        {
            var Users = Elements.Where(u => u.HasAdministrationPrivileges).ToList();
            return Users.Count == 1 && Users.Single().Equals(elementToRemove);
        }

        internal static void InsertOriginalSystemAdministrator()
        {
            using (var context = new BoardContext())
            {
                if (!HasElements())
                {
                    var elements = context.Set<User>();
                    var baseUser = User.CreateNewAdministrator("The", "Administrator",
                        "administrator@tf2.com", DateTime.Today, "Victory");
                    elements.Add(baseUser);
                    context.SaveChanges();
                }
            }
        }

        internal static void RemoveAllUsers()
        {
            using (var context = new BoardContext())
            {
                context.RemoveAllUsers();
            }
        }
    }
}