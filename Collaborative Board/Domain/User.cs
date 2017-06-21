using System;
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
        public virtual int Id { get; set; }

        private string firstName;
        public virtual string FirstName
        {
            get { return firstName; }
            set
            {
                if (IsValidName(value))
                {
                    firstName = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.UserNameIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        private string lastName;
        public virtual string LastName
        {
            get { return lastName; }
            set
            {
                if (IsValidName(value))
                {
                    lastName = value.Trim();
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

        public string email;
        public virtual string Email
        {
            get { return email; }
            set
            {
                try
                {
                    MailAddress emailToSet = new MailAddress(value);
                    email = emailToSet.ToString();
                }
                catch (SystemException)
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.EmailIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        private DateTime birthdate;
        public virtual DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                var dateToSet = value.Date;
                if (Utilities.IsTodayOrBefore(dateToSet))
                {
                    birthdate = dateToSet;
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

        private string password;
        public virtual string Password
        {
            get { return password; }
            set
            {
                if (PasswordUtilities.IsValidPassword(value))
                {
                    password = value;
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

        public virtual bool HasAdministrationPrivileges { get; set; }

        internal string ResetPassword()
        {
            string newPassword = PasswordUtilities.GenerateNewPassword();
            password = newPassword;
            return newPassword;
        }

        public virtual ICollection<Comment> CommentsCreated { get; set; }
            = new List<Comment>();

        public virtual ICollection<Comment> CommentsResolved { get; set; }
            = new List<Comment>();

        public virtual ICollection<Team> AssociatedTeams { get; set; }
            = new List<Team>();

        internal void AddCreatedComment(Comment someComment)
        {
            if (!CommentsCreated.Contains(someComment))
            {
                CommentsCreated.Add(someComment);
            }
            else
            {
                throw new UserException(ErrorMessages.CommentAlreadyAdded);
            }
        }

        internal void AddResolvedComment(Comment someComment)
        {
            if (!CommentsResolved.Contains(someComment))
            {
                CommentsResolved.Add(someComment);
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
            firstName = "Usuario";
            lastName = "inválido.";
            email = "mailInvalido@usuarioInvalido";
            password = "Contraseña inválida.";
        }

        internal static User CreateNewAdministrator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new User(firstName, lastName, email, birthdate, password, true);
        }

        internal static User CreateNewCollaborator(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new User(firstName, lastName, email, birthdate, password);
        }

        private User(string firstNameToSet, string lastNameToSet, string emailToSet,
            DateTime birthdateToSet, string passwordToSet, bool isAdministrator = false)
        {
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Email = emailToSet;
            Birthdate = birthdateToSet;
            Password = passwordToSet;
            HasAdministrationPrivileges = isAdministrator;
        }

        public override bool Equals(object obj)
        {
            User userToCompareAgainst = obj as User;
            if (Utilities.IsNotNull(userToCompareAgainst))
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