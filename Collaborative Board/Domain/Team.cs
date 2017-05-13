using System;
using Exceptions;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Persistence")]
namespace Domain
{
    public class Team
    {
        private const byte minimumMembers = 1;

        private string name;
        public string Name
        {
            get { return name; }
            internal set
            {
                if (IsValidTeamName(value))
                {
                    name = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, value);
                    throw new TeamException(errorMessage);
                }
            }
        }

        public static bool IsValidTeamName(string value)
        {
            return Utilities.ContainsLettersDigitsOrSpacesOnly(value);
        }

        public DateTime CreationDate { get; } = DateTime.Now;

        private string description;
        public string Description
        {
            get { return description; }
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new TeamException(ErrorMessages.EmptyDescription);
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
            internal set
            {
                if (value >= minimumMembers)
                {
                    maximumMembers = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.InvalidMaximumMembers, value, minimumMembers);
                    throw new TeamException(errorMessage);
                }
            }
        }

        private readonly List<User> members = new List<User>();
        public IReadOnlyCollection<User> Members => members.AsReadOnly();

        private readonly List<Whiteboard> createdWhiteboards = new List<Whiteboard>();
        public IReadOnlyCollection<Whiteboard> CreatedWhiteboards
        {
            get
            {
                return createdWhiteboards.AsReadOnly();
            }
        }

        internal void AddMember(User userToAdd)
        {
            bool canBeMember = Utilities.IsNotNull(userToAdd) && IsPossibleToAdd(userToAdd);
            if (canBeMember)
            {
                members.Add(userToAdd);
            }
            else
            {
                throw new TeamException(ErrorMessages.CannotAddUser);
            }
        }

        private bool IsPossibleToAdd(User aMember)
        {
            return members.Count < maximumMembers && !members.Contains(aMember);
        }

        internal void RemoveMember(User userToRemove)
        {
            if (!WasRemoved(userToRemove))
            {
                throw new TeamException(ErrorMessages.CannotRemoveUser);
            }
        }

        private bool WasRemoved(User aUser)
        {
            return members.Count > minimumMembers && members.Remove(aUser);
        }

        public void AddWhiteboard(Whiteboard whiteboardToAdd)
        {
            if (Utilities.IsNotNull(whiteboardToAdd))
            {
                AddWhiteboardToCollectionIfPossible(whiteboardToAdd);
            }
            else
            {
                throw new TeamException(ErrorMessages.NullWhiteboard);
            }
        }

        private void AddWhiteboardToCollectionIfPossible(Whiteboard whiteboardToAdd)
        {
            bool isPossibleToAddWhiteboard = !createdWhiteboards.Contains(whiteboardToAdd);
            if (isPossibleToAddWhiteboard)
            {
                createdWhiteboards.Add(whiteboardToAdd);
            }
            else
            {
                throw new TeamException(ErrorMessages.RepeatedWhiteboardName);
            }
        }

        public void RemoveWhiteboard(Whiteboard someWhiteboard)
        {
            bool whiteboardWasRemoved = createdWhiteboards.Remove(someWhiteboard);
            if (!whiteboardWasRemoved)
            {
                throw new TeamException(ErrorMessages.NotAddedWhiteboardRecieved);
            }
        }

        internal static Team InstanceForTestingPurposes()
        {
            return new Team();
        }

        private Team()
        {
            User defaultCreator = User.InstanceForTestingPurposes();
            name = "Equipo inválido.";
            description = "Descripción inválida.";
            maximumMembers = int.MaxValue;
            members.Add(defaultCreator);
        }

        internal static Team CreatorNameDescriptionMaximumMembers(User creator, string name,
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