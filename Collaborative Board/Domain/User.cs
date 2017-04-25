﻿using System;
using Exceptions;
using System.Net.Mail;
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
                if (Utilities.IsValidName(value))
                {
                    firstName = value.Trim();
                }
                else
                {
                    throw new UserException("Nombre inválido recibido: " + value + ".");
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (Utilities.IsValidName(value))
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

        private Password password = new Password();
        public string Password
        {
            get { return password.PasswordValue; }
            set
            {
                password.PasswordValue = value;
            }
        }

        public virtual bool HasAdministrationPrivileges
        {
            get { return false; }
        }

        public string ResetPassword()
        {
            return password.Reset();
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

        protected User(string aFirstName, string aLastName, string anEmail, DateTime aBirthdate, string aPassword)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            Email = anEmail;
            Birthdate = aBirthdate;
            Password = aPassword;
        }

        public override string ToString()
        {
            return firstName + " " + lastName + " <" + Email + ">";
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
    }
}