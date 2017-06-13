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
        private const byte absoluteMinimumMembers = 1;

        private string name;
        public virtual string Name
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
        public virtual string Description
        {
            get { return description; }
            set
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
        public virtual int MaximumMembers
        {
            get { return maximumMembers; }
            set
            {
                int minimumMembersNeeded =
                    Math.Max(absoluteMinimumMembers, Members.Count);
                if (value >= minimumMembersNeeded)
                {
                    maximumMembers = value;
                }
                else
                {
                    string errorMessage = GenerateMaximumMembersNotHighEnoughErrorMessage(value,
                        minimumMembersNeeded);
                    throw new TeamException(errorMessage);
                }
            }
        }

        private static string GenerateMaximumMembersNotHighEnoughErrorMessage(int value,
            int minimumMaximumMembersNeeded)
        {
            string errorMessage = ErrorMessages.InvalidMaximumMembers;
            if (value >= 1)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidMaximumMembers, value, minimumMaximumMembersNeeded);
            }
            return errorMessage;
        }

        public virtual List<User> Members { get; set; }
            = new List<User>();

        public virtual List<Whiteboard> CreatedWhiteboards { get; set; }
            = new List<Whiteboard>();

        internal void AddMember(User userToAdd)
        {
            bool canBeMember = Utilities.IsNotNull(userToAdd) && IsPossibleToAdd(userToAdd);
            if (canBeMember)
            {
                Members.Add(userToAdd);
            }
            else
            {
                throw new TeamException(ErrorMessages.CannotAddUser);
            }
        }

        private bool IsPossibleToAdd(User someUser)
        {
            return Members.Count < maximumMembers && !Members.Contains(someUser);
        }

        internal void RemoveMember(User userToRemove)
        {
            if (!WasRemoved(userToRemove))
            {
                throw new TeamException(ErrorMessages.CannotRemoveUser);
            }
        }

        private bool WasRemoved(User userToRemove)
        {
            return Members.Count > absoluteMinimumMembers && Members.Remove(userToRemove);
        }

        internal void AddWhiteboard(Whiteboard whiteboardToAdd)
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
            bool isPossibleToAddWhiteboard = !CreatedWhiteboards.Contains(whiteboardToAdd);
            if (isPossibleToAddWhiteboard)
            {
                CreatedWhiteboards.Add(whiteboardToAdd);
            }
            else
            {
                throw new TeamException(ErrorMessages.RepeatedWhiteboardName);
            }
        }

        internal void RemoveWhiteboard(Whiteboard someWhiteboard)
        {
            bool whiteboardWasRemoved = CreatedWhiteboards.Remove(someWhiteboard);
            if (!whiteboardWasRemoved)
            {
                throw new TeamException(ErrorMessages.NotAddedWhiteboardRecieved);
            }
        }

        internal static Team InstanceForTestingPurposes()
        {
            return new Team();
        }

        public Team()
        {
            User defaultCreator = User.InstanceForTestingPurposes();
            name = "Equipo inválido.";
            description = "Descripción inválida.";
            maximumMembers = int.MaxValue;
            Members.Add(defaultCreator);
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
            Members.Add(creator);
        }

        public override bool Equals(object obj)
        {
            Team teamToCompareAgainst = obj as Team;
            if (Utilities.IsNotNull(teamToCompareAgainst))
            {
                return HasSameName(teamToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameName(Team teamToCompareAgainst)
        {
            return name.Equals(teamToCompareAgainst.name);
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