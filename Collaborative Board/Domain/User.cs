using Exceptions;

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
                    throw new UserException("Invalid name recieved.");
                }
                else
                {
                    firstName = value;
                }
            }
        }
    }
}
