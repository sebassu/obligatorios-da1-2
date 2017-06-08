using System;
using Exceptions;
using System.Net.Mail;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: NeutralResourcesLanguage("es")]
[assembly: InternalsVisibleTo("UnitTests")]
namespace Domain
{
    public class User
    {
        internal readonly UserDataEntityFramework userData;

        public string FirstName
        {
            get { return userData.FirstName; }
            internal set
            {
                if (IsValidName(value))
                {
                    userData.FirstName = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.UserNameIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        public string LastName
        {
            get { return userData.LastName; }
            internal set
            {
                if (IsValidName(value))
                {
                    userData.LastName = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.LastNameIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        public static bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        public string Email
        {
            get { return userData.Email; }
            internal set
            {
                try
                {
                    MailAddress emailToSet = new MailAddress(value);
                    userData.Email = emailToSet.ToString();
                }
                catch (SystemException)
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.EmailIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        public DateTime Birthdate
        {
            get { return userData.Birthdate; }
            internal set
            {
                var dateToSet = value.Date;
                if (Utilities.IsTodayOrBefore(dateToSet))
                {
                    userData.Birthdate = dateToSet;
                }
                else
                {
                    IFormatProvider format = CultureInfo.CurrentCulture;
                    string errorMessage = string.Format(format,
                        ErrorMessages.BirthdateIsInvalid, value.ToString("d", format));
                    throw new UserException(errorMessage);
                }
            }
        }

        public string Password
        {
            get { return userData.Password; }
            internal set
            {
                if (PasswordUtilities.IsValidPassword(value))
                {
                    userData.Password = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.PasswordIsInvalid, value, PasswordUtilities.minimumLength,
                        PasswordUtilities.maximumLength);
                    throw new UserException(errorMessage);
                }
            }
        }

        public virtual bool HasAdministrationPrivileges => userData.HasAdministrationPrivileges;

        internal string ResetPassword()
        {
            string newPassword = PasswordUtilities.GenerateNewPassword();
            userData.Password = newPassword;
            return newPassword;
        }

        public IReadOnlyCollection<Comment> CommentsCreated => userData.CommentsCreated.AsReadOnly();

        public IReadOnlyCollection<Comment> CommentsResolved => userData.CommentsResolved.AsReadOnly();

        internal void AddCreatedComment(Comment someComment)
        {
            var commentsCreated = userData.CommentsCreated;
            if (!commentsCreated.Contains(someComment))
            {
                commentsCreated.Add(someComment);
            }
            else
            {
                throw new UserException(ErrorMessages.CommentAlreadyAdded);
            }
        }

        internal void AddResolvedComment(Comment someComment)
        {
            var commentsResolved = userData.CommentsResolved;
            if (!commentsResolved.Contains(someComment))
            {
                commentsResolved.Add(someComment);
            }
            else
            {
                throw new UserException(ErrorMessages.CommentAlreadyAdded);
            }
        }

        internal static User InstanceForTestingPurposes()
        {
            return new User();
        }

        protected User()
        {
            userData = new UserDataEntityFramework();
        }

        internal static User CreateNewUser(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new User(firstName, lastName, email, birthdate, password, true);
        }

        internal static User CreateNewCollaborator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new User(firstName, lastName, email, birthdate, password);
        }

        protected User(string firstName, string lastName, string email, DateTime birthdate,
            string password, bool hasUserPrivileges = false)
        {
            userData = new UserDataEntityFramework(firstName, lastName, email, birthdate,
                password, hasUserPrivileges);
        }

        public override bool Equals(object obj)
        {
            if (obj is User userToCompareAgainst)
            {
                return HasSameEmail(userToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameEmail(User other)
        {
            return Email.Equals(other.Email);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " <" + Email + ">";
        }
    }
}