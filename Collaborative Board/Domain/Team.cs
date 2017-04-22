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
        private DateTime creationDate = DateTime.Now;

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set { }
        }

        private string description;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    description = value;
                }
                else
                {
                    throw new TeamException("Descripción inválida: " + value + ".");
                }
            }
        }

        private int maximumMembers;

        public int MaximumMembers
        {
            get
            {
                return maximumMembers;
            }
            set
            {
                if (value > 0)
                {
                    maximumMembers = value;
                }
                else
                {
                    throw new TeamException("Máxima cantidad de miembros inválida: " + value + ".");
                }
            }
        }
    }
}