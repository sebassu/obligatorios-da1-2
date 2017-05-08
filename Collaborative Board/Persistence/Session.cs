using Domain;
using System;
using Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public static class Session
    {
        private static User activeUser;
        public static User ActiveUser()
        {
            if (IsActive())
            {
                return activeUser;
            }
            else
            {
                throw new SessionException(ErrorMessages.SessionNotStarted);
            }
        }

        public static bool IsActive()
        {
            return Utilities.IsNotNull(activeUser);
        }

        public static void Start(string emailEntered, string passwordEntered)
        {
            if (IsActive())
            {
                throw new SessionException(ErrorMessages.SessionAlreadyStarted);
            }
            else
            {
                LoginUserWithData(emailEntered, passwordEntered);
            }

        }

        private static void LoginUserWithData(string emailEntered, string passwordEntered)
        {
            var users = UserRepository.GetInstance().Elements;
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
            activeUser = users.First(u => VerifyLoginDataMatches(u, emailEntered, passwordEntered));
        }

        private static bool VerifyLoginDataMatches(User userToVerify, string emailEntered, string passwordEntered)
        {
            return userToVerify.Email == emailEntered && userToVerify.Password == passwordEntered;
        }

        public static bool HasAdministrationPrivileges()
        {
            return Utilities.IsNotNull(activeUser) && activeUser.HasAdministrationPrivileges;
        }

        public static void End()
        {
            activeUser = null;
        }
    }
}