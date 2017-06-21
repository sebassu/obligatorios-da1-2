using Domain;
using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Persistence
{
    public static class UserRepository
    {
        public static List<User> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Users;
                    return elements.ToList();
                }
            }
        }

        public static User AddNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            using (var context = new BoardContext())
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                if (ThereIsNoUserWithEmail(email))
                {
                    User userToAdd = User.CreateNewCollaborator(firstName, lastName,
                        email, birthdate, password);
                    EntityFrameworkUtilities<User>.Add(context, userToAdd);
                    return userToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserEmailMustBeUnique);
                }
            }
        }

        public static User AddNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            using (var context = new BoardContext())
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                if (ThereIsNoUserWithEmail(email))
                {
                    User administratorToAdd = User.CreateNewAdministrator(firstName,
                        lastName, email, birthdate, password);
                    EntityFrameworkUtilities<User>.Add(context, administratorToAdd);
                    return administratorToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UserEmailMustBeUnique);
                }
            }
        }

        public static void ModifyUser(User userToModify, string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            try
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                AttemptToSetUserAttributes(userToModify, firstNameToSet, lastNameToSet,
                    emailToSet, birthdateToSet, passwordToSet);
            }
            catch (DataException)
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void AttemptToSetUserAttributes(User userToModify, string firstNameToSet,
            string lastNameToSet, string emailToSet, DateTime birthdateToSet, string passwordToSet)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, userToModify);
                if (ChangeDoesNotCauseRepeatedUserEmails(userToModify, emailToSet))
                {
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
            return emailDoesNotChange || ThereIsNoUserWithEmail(emailToSet);
        }

        private static bool ThereIsNoUserWithEmail(string emailToSet)
        {
            using (var context = new BoardContext())
            {
                return !context.Users.Any(u => u.Email == emailToSet);
            }
        }

        public static string ResetUsersPassword(User userToModify)
        {
            using (var context = new BoardContext())
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, userToModify);
                string result = userToModify.ResetPassword();
                context.SaveChanges();
                return result;
            }
        }

        public static void Remove(User elementToRemove)
        {
            Session.ValidateActiveUserHasAdministrationPrivileges();
            if (IsTheOnlyAdministratorLeft(elementToRemove))
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                RemoveUserFromAllTeams(elementToRemove);
                ValidateNoWhiteboardHasUserAsCreator(elementToRemove);
                EntityFrameworkUtilities<User>.Remove(elementToRemove);
            }
        }

        private static bool IsTheOnlyAdministratorLeft(User elementToRemove)
        {
            using (var context = new BoardContext())
            {
                var administrators = context.Users.Where(u => u.HasAdministrationPrivileges).ToList();
                return administrators.Count == 1 && administrators.Single().Equals(elementToRemove);
            }
        }

        private static void ValidateNoWhiteboardHasUserAsCreator(User userToRemove)
        {
            var allWhiteboards = WhiteboardRepository.Elements;
            bool userToRemoveIsCreator = allWhiteboards.Any(w => w.CreatorId.Equals(userToRemove.Email));
            if (userToRemoveIsCreator)
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveWhiteboardCreator);
            }
        }

        private static void RemoveUserFromAllTeams(User userToRemove)
        {
            LoadAssociatedTeams(userToRemove);
            var teamsThatContainUserToRemove = userToRemove.AssociatedTeams.ToList();
            teamsThatContainUserToRemove.ForEach(t => TeamRepository.LoadMembers(t));
            bool teamsOnlyWithUserToRemoveAsMemberExist =
              teamsThatContainUserToRemove.Any(t => t.Members.Count == 1);
            if (teamsOnlyWithUserToRemoveAsMemberExist)
            {
                throw new RepositoryException(ErrorMessages.UserIsLoneMemberOfSomeTeam);
            }
            else
            {
                teamsThatContainUserToRemove.ForEach(t =>
                    TeamRepository.RemoveMemberFromTeam(t, userToRemove));
            }
        }

        public static void InsertOriginalSystemAdministrator()
        {
            using (var context = new BoardContext())
            {
                var elements = context.Users;
                if (elements.FirstOrDefault() == null)
                {
                    var baseUser = User.CreateNewAdministrator("The", "Administrator",
                        "administrator@tf2.com", DateTime.Today, "Victory");
                    elements.Add(baseUser);
                    context.SaveChanges();
                }
            }
        }

        public static void LoadAssociatedTeams(User someUser)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, someUser);
                context.Entry(someUser).Collection(u => u.AssociatedTeams).Load();
            }
        }

        internal static void LoadCreatedComments(User someUser)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, someUser);
                context.Entry(someUser).Collection(t => t.CommentsCreated).Load();
            }
        }
    }
}