using System;
using System.Linq;
using Exceptions;

namespace Domain
{
    public class Team
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
                if (!string.IsNullOrEmpty(value) && value.ToCharArray().All(c => char.IsLetterOrDigit(c)))
                {
                    name = value;
                }
                else
                {
                    throw new TeamException("Nombre inválido:" + value + ".");
                }
            }
        }
    }
}