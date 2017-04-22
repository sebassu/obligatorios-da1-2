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
                if (Utilities.IsValidTeamName(value))
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