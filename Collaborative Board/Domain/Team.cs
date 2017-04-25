﻿using System;
using System.Linq;
using Exceptions;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections;

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

        private List<User> members = new List<User>();

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

        public static Team NameDescriptionMaximumMembers(string aName, string aDescription, int aMaximimMembers)
        {
            return new Team(aName, aDescription, aMaximimMembers);
        }

        private Team(string aName, string aDescription, int aMaximumMembers) 
            : this()
        {
            Name = aName;
            Description = aDescription;
            MaximumMembers = aMaximumMembers;
        }

        public override string ToString()
        {
            return name;
        }

    }
}