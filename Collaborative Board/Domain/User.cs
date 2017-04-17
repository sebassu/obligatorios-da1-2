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
                var characters = value.ToCharArray();
                if (!characters.All(c => char.IsLetter(c)))
                {
                    throw new UserException("Invalid name recieved.");
                }
                name = value;
            }
        }
    }
}
