﻿using System;
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
            get { return name; }
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
            get { return creationDate; }
        }

        private string description;
        public string Description
        {
            get { return description; }
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
            get { return maximumMembers; }
            set
            {
                if (value >= minimumMembers)
                {
                    maximumMembers = value;
                }
                else
                {
                    throw new TeamException("Máxima cantidad de miembros inválida: "
                        + value + ".");
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

        private readonly List<Whiteboard> createdWhiteboards = new List<Whiteboard>();

        public IList CreatedWhiteboards
        {
            get
            {
                return createdWhiteboards.AsReadOnly();
            }
        }

        public void AddMember(User aUser)
        {
            if (IsPossibleToAdd(aUser))
            {
                members.Add(aUser);
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

        public void RemoveMember(User aUser)
        {
            if (!UserWasRemoved(aUser))
            {
                throw new TeamException("Miembro no válido o equipo con mínimo de miembros.");
            }
        }

        private bool UserWasRemoved(User aUser)
        {
            return members.Count > minimumMembers && members.Remove(aUser);
        }

        public void AddWhiteboard(Whiteboard aWhiteboard)
        {
            if (IsPossibleToAddWhiteboard(aWhiteboard))
            {
                createdWhiteboards.Add(aWhiteboard);
            }
            else
            {
                throw new TeamException("Pizarrón no válido");
            }
        }

        private bool IsPossibleToAddWhiteboard(Whiteboard aWhiteboard)
        {
            return !createdWhiteboards.Contains(aWhiteboard);
        }

        public void RemoveWhiteboard(Whiteboard aWhiteboard)
        {
            if (WhiteboardWasRemoved(aWhiteboard))
            {
                throw new TeamException("Pizarrón no válido.");
            }
        }
		
        private bool WhiteboardWasRemoved(Whiteboard aWhiteboard)
        {
            return !createdWhiteboards.Remove(aWhiteboard);
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

        public override bool Equals(object parameterObject)
        {
            if (parameterObject is Team teamToCompareAgainst)
            {
                return HasSameName(teamToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameName(Team aTeam)
        {
            return name.Equals(aTeam.name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return name;
        }
    }
}