using Exceptions;
using System;
using System.Net.Mail;

namespace Domain
{
    public class User
    {
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
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
            get
            {
                return lastName;
            }
            set
            {
                if (Utilities.IsValidName(value))
                {
                    lastName = value.Trim();
                }
                else
                {
                    throw new UserException("Invalid last name recieved:" + value + ".");
                }
            }
        }

        private MailAddress email;
        public string Email
        {
            get
            {
                return email.ToString();
            }
            set
            {
                try
                {
                    email = new MailAddress(value);
                }
                catch (SystemException)
                {
                    throw new UserException("Invalid email recieved:" + value + ".");
                }
            }
        }
    }
}