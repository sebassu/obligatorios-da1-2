using System;
using Exceptions;
using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit tests")]
namespace Domain
{
    public class User
    {
        private string firstName;
        public string FirstName
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
                    throw new UserException("Nombre inválido recibido: " + value + ".");
                }
            }
        }

        public bool IsValidName(string aString)
        {
            return !string.IsNullOrWhiteSpace(aString) && Utilities.ContainsOnlyLettersOrSpaces(aString);
        }

        private string lastName;
        public string LastName
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
                    throw new UserException("Apellido inválido recibido: " + value + ".");
                }
            }
        }

        private MailAddress email;
        public string Email
        {
            get { return email.ToString(); }
            set
            {
                try
                {
                    email = new MailAddress(value);
                }
                catch (SystemException)
                {
                    throw new UserException("Email inválido recibido: " + value + ".");
                }
            }
        }

        private DateTime birthdate;
        public DateTime Birthdate
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
                    throw new UserException("Fecha de nacimiento inválida recibida: "
                        + value.ToString("d") + ".");
                }
            }
        }

        private readonly Password password = new Password();
        public string Password
        {
            get { return password.PasswordValue; }
            set
            {
                password.PasswordValue = value;
            }
        }

        public virtual bool HasAdministrationPrivileges => false;

        public string ResetPassword()
        {
            return password.Reset();
        }

        private readonly List<Comment> commentsResolved = new List<Comment>();
        public IList CommentsResolved => commentsResolved.AsReadOnly();

        internal void AddResolvedComment(Comment aComment)
        {
            commentsResolved.Add(aComment);
        }

        internal static User InstanceForTestingPurposes()
        {
            return new User();
        }

        protected User()
        {
            firstName = "Nombre inválido.";
            lastName = "Apellido inválido.";
            email = new MailAddress("mailInvalido@usuarioInvalido");
        }

        public static User NamesEmailBirthdatePassword(string aFirstName, string aLastName,
            string anEmail, DateTime aBirthdate, string aPassword)
        {
            return new User(aFirstName, aLastName, anEmail, aBirthdate, aPassword);
        }

        protected User(string aFirstName, string aLastName, string anEmail,
            DateTime aBirthdate, string aPassword)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            Email = anEmail;
            Birthdate = aBirthdate;
            Password = aPassword;
        }

        public override bool Equals(object parameterObject)
        {
            if (parameterObject is User userToCompareAgainst)
            {
                return HasSameEmail(userToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameEmail(User aUser)
        {
            return email.Equals(aUser.email);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return firstName + " " + lastName + " <" + Email + ">";
        }
    }
}