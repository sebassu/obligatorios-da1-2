using Exceptions;
using System.Linq;

namespace Domain
{
    public class User
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !value.ToCharArray().All(c => char.IsLetter(c)))
                {
                    throw new UserException("Invalid name recieved.");
                }
                name = value;
            }
        }
    }
}
