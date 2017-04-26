using System;
using Exceptions;
using System.Collections.Generic;
using System.Collections;

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
                if (IsValidTeamName(value))
                {
                    name = value;
                }
                else
                {
                    throw new TeamException("Nombre inválido:" + value + ".");
                }
            }
        }

        public bool IsValidTeamName(string value)
        {
            return !string.IsNullOrEmpty(value) && Utilities.ContainsOnlyLettersDigitsOrSpaces(value);
        }

        private readonly DateTime creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new TeamException("Descripción inválida: " + value + ".");
                }
                else
                {
                    description = value;
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

        private readonly List<User> members = new List<User>();
        public IList Members
        {
            get
            {
                return members.AsReadOnly();
            }
        }

        public void AddMember(User aMember)
        {
            if (IsPossibleToAdd(aMember))
            {
                members.Add(aMember);
            }
            else
            {
                throw new TeamException("Miembro no válido o equipo completo.");
            }
        }

        private bool IsPossibleToAdd(User aMember)
        {
            return members.Count < maximumMembers && !members.Contains(aMember);
        }

        public void RemoveMember(User aMember)
        {
            if (IsPossibleToRemove(aMember))
            {
                members.Remove(aMember);
            }
            else
            {
                throw new TeamException("Miembro no válido o equipo con mínimo de miembros.");
            }
        }

        private bool IsPossibleToRemove(User aMember)
        {
            return members.Count > minimumMembers && members.Contains(aMember);
        }

        internal static Team InstanceForTestingPurposes()
        {
            return new Team();
        }

        private Team()
        {
            name = "Nombre inválido.";
            description = "Descripción inválida.";
            maximumMembers = 0;
        }

        public static Team CreatorNameDescriptionMaximumMembers(User creator, string aName,
            string aDescription, int aMaximimMembers)
        {
            return new Team(creator, aName, aDescription, aMaximimMembers);
        }

        private Team(User creator, string aName, string aDescription, int aMaximumMembers)
        {
            Name = aName;
            Description = aDescription;
            MaximumMembers = aMaximumMembers;
            members.Add(creator);
        }

        public override string ToString()
        {
            return name;
        }
    }
}