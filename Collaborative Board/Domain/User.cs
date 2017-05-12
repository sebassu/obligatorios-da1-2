﻿using System;
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
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            internal set
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
        public string LastName
        {
            get { return lastName; }
            internal set
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

        private MailAddress email;
        public string Email
        {
            get { return email.ToString(); }
            internal set
            {
                try
                {
                    email = new MailAddress(value);
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
        public DateTime Birthdate
        {
            get { return birthdate; }
            internal set
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

        private readonly IPassword password = new Password();
        public string Password
        {
            get { return password.PasswordValue; }
            internal set
            {
                try
                {
                    password.PasswordValue = value;
                }
                catch (PasswordException exceptionCaught)
                {
                    throw new UserException(exceptionCaught.Message);
                }
            }
        }

        public virtual bool HasAdministrationPrivileges => false;

        internal string ResetPassword()
        {
            return password.Reset();
        }

        private readonly List<Comment> commentsResolved = new List<Comment>();
        public IReadOnlyCollection<Comment> CommentsResolved => commentsResolved.AsReadOnly();

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
            firstName = "Usuario";
            lastName = "inválido.";
            email = new MailAddress("mailInvalido@usuarioInvalido");
        }

        internal static User NamesEmailBirthdatePassword(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new User(firstName, lastName, email, birthdate, password);
        }

        protected User(string firstNameToSet, string lastNameToSet, string emailToSet,
            DateTime birthdateToSet, string passwordToSet)
        {
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Email = emailToSet;
            Birthdate = birthdateToSet;
            Password = passwordToSet;
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
            return email.Equals(other.email);
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