using System;
using System.Linq;
using Exceptions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit tests")]
namespace Domain
{
    public class Team
    {
        private const int minimumMembers = 1;

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
                if (value >= minimumMembers)
                {
                    maximumMembers = value;
                }
                else
                {
                    throw new TeamException("Máxima cantidad de miembros inválida: " + value + ".");
                }
            }
        }

        internal static Team TeamForTestingPurposes()
        {
            Team result = new Team()
            {
                name = "Nombre inválido.",
                description = "Descripción inválida.",
                maximumMembers = 0
            };
            return result;
        }

        private Team()
        {
            creationDate = DateTime.Now;
        }

        public static Team NameCreationDateDescriptionMaximumMembers(string aName, DateTime aCreationDate, string aDescription, int aMaximimMembers)
        {
            return new Team(aName, aCreationDate, aDescription, aMaximimMembers);
        }

        private Team(string aName, DateTime aCreationDate, string aDescription, int aMaximumMembers) 
            : this()
        {
            Name = aName;
            CreationDate = aCreationDate;
            Description = aDescription;
            MaximumMembers = aMaximumMembers;
        }

        public override string ToString()
        {
            return name;
        }

    }
}