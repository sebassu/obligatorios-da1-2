using System;
using Exceptions;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        private const byte minimumMembers = 1;

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
                    throw new TeamException("Nombre inválido: " + value + ".");
                }
            }
        }

        public static bool IsValidTeamName(string value)
        {
            return !string.IsNullOrEmpty(value) && Utilities.ContainsOnlyLettersDigitsOrSpaces(value);
        }

        public DateTime CreationDate { get; } = DateTime.Now;

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
        public IList Members => members.AsReadOnly();

        private readonly List<Whiteboard> createdWhiteboards = new List<Whiteboard>();
        public IList CreatedWhiteboards
        {
            get
            {
                return createdWhiteboards.AsReadOnly();
            }
        }

        public void AddMember(User userToAdd)
        {
            bool canBeMember = Utilities.IsNotNull(userToAdd) && IsPossibleToAdd(userToAdd);
            if (canBeMember)
            {
                members.Add(userToAdd);
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

        public void RemoveMember(User userToRemove)
        {
            if (!WasRemoved(userToRemove))
            {
                throw new TeamException("Miembro no válido o equipo con mínimo de miembros.");
            }
        }

        private bool WasRemoved(User aUser)
        {
            return members.Count > minimumMembers && members.Remove(aUser);
        }

        public void AddWhiteboard(Whiteboard whiteboardToAdd)
        {
            if (IsPossibleToAdd(whiteboardToAdd))
            {
                createdWhiteboards.Add(whiteboardToAdd);
            }
            else
            {
                throw new TeamException("Pizarrón no válido");
            }
        }

        private bool IsPossibleToAdd(Whiteboard aWhiteboard)
        {
            return !createdWhiteboards.Contains(aWhiteboard);
        }

        internal static Team InstanceForTestingPurposes()
        {
            return new Team();
        }

        private Team()
        {
            User defaultCreator = User.InstanceForTestingPurposes();
            name = "Nombre inválido.";
            description = "Descripción inválida.";
            maximumMembers = int.MaxValue;
            members.Add(defaultCreator);
        }

        public static Team CreatorNameDescriptionMaximumMembers(User creator, string name,
            string description, int maximumMembers)
        {
            return new Team(creator, name, description, maximumMembers);
        }

        private Team(User creator, string nameToSet, string descriptionToSet, int maximumMembersToSet)
        {
            Name = nameToSet;
            Description = descriptionToSet;
            MaximumMembers = maximumMembersToSet;
            members.Add(creator);
        }

        public override bool Equals(object obj)
        {
            if (obj is Team teamToCompareAgainst)
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