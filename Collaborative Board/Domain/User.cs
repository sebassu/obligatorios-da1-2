using Exceptions;
using System;
using System.Linq;
using System.Net.Mail;

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
                    throw new UserException("Invalid first name recieved:" + value + ".");
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
                    throw new UserException("Invalid last name recieved: " + value + ".");
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
                    throw new UserException("Invalid email recieved: " + value + ".");
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
                if (Utilities.IsBeforeToday(dateToSet))
                {
                    birthdate = dateToSet;
                }
                else
                {
                    throw new UserException("Invalid birthdate recieved: " + value.ToString("d") + ".");
                }
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (IsValidPassword(value))
                {
                    password = value;
                }
                else
                {
                    throw new UserException("Invalid password recieved: " + value + ".");
                }
            }
        }

        private static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.ToCharArray().All(c => char.IsLetterOrDigit(c)) && password.Length < 21 && password.Length > 5;
        }
    }
}