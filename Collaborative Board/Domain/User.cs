using System;

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
                foreach (var character in characters)
                {
                    if (!Char.IsLetter(character))
                    {
                        throw new UserException("Invalid name recieved.");
                    }
                }
                name = value;
            }
        }
    }
}
