using Domain;
using System;
using Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public static class Session
    {
        private static User loggedUser;
        public static User LoggedUser
        {
            get { return loggedUser; }
        }

        public static void Start(string emailEntered, string passwordEntered)
        {
            var users = UserDirectory.GetInstance().Elements;
            try
            {
                UpdateLoggedUser(emailEntered, passwordEntered, users);
            }
            catch (InvalidOperationException)
            {
                throw new SessionException(ErrorMessages.EmailPasswordMismatch);
            }
        }

        private static void UpdateLoggedUser(string emailEntered, string passwordEntered,
            IReadOnlyCollection<User> users)
        {
            loggedUser = users.First(u => VerifyLoginDataMatches(u, emailEntered, passwordEntered));
        }

        private static bool VerifyLoginDataMatches(User userToVerify, string emailEntered, string passwordEntered)
        {
            return userToVerify.Email == emailEntered && userToVerify.Password == passwordEntered;
        }

        public static bool HasAdministrationPrivileges()
        {
            return Utilities.IsNotNull(loggedUser) && loggedUser.HasAdministrationPrivileges;
        }
    }
}