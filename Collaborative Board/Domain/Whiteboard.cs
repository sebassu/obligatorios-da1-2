using System;
using Exceptions;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Domain
{
    public class Whiteboard
    {
        private const byte minimumWidth = 1;
        private const byte minimumHeight = 1;

        public DateTime CreationDate { get; } = DateTime.Today;

        public DateTime LastModification { get; private set; }

        internal void UpdateModificationDate()
        {
            LastModification = DateTime.Now;

        }

        private string name;
        public string Name
        {
            get { return name; }
            internal set
            {
                if (IsValidName(value))
                {
                    name = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, value);
                    throw new WhiteboardException(errorMessage);
                }
            }
        }

        public static bool IsValidName(string value)
        {
            return Utilities.ContainsLettersDigitsOrSpacesOnly(value);
        }

        private string description;
        public string Description
        {
            get { return description; }
            internal set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                    UpdateModificationDate();
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.EmptyDescription);
                }
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            internal set
            {
                if (value >= minimumWidth)
                {
                    width = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.WidthIsInvalid, value);
                    throw new WhiteboardException(errorMessage);
                }
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            internal set
            {
                if (value >= minimumHeight)
                {
                    height = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.HeightIsInvalid, value);
                    throw new WhiteboardException(errorMessage);
                }
            }
        }

        public User Creator { get; }

        public Team OwnerTeam { get; }

        private List<ElementWhiteboard> contents = new List<ElementWhiteboard>();
        public IReadOnlyCollection<ElementWhiteboard> Contents => contents.AsReadOnly();

        internal void AddWhiteboardElement(ElementWhiteboard elementToAdd)
        {
            if (Utilities.IsNotNull(elementToAdd))
            {
                contents.Add(elementToAdd);
            }
            else
            {
                throw new WhiteboardException(ErrorMessages.NullElement);
            }
        }

        public void RemoveWhiteboardElement(ElementWhiteboard elementToRemove)
        {
            bool elementWasRemoved = contents.Remove(elementToRemove);
            if (!elementWasRemoved)
            {
                throw new WhiteboardException(ErrorMessages.NonMemberElement);
            }
        }

        internal static Whiteboard InstanceForTestingPurposes()
        {
            return new Whiteboard();
        }

        private Whiteboard()
        {
            Creator = User.InstanceForTestingPurposes();
            OwnerTeam = Team.InstanceForTestingPurposes();
            SetAttributesForTesting();
            UpdateModificationDate();
            UpdateOwnerTeamsWhiteboardCollection();
        }

        private void SetAttributesForTesting()
        {
            name = "Pizarrón inválido";
            description = "Descripción inválida.";
            width = int.MaxValue;
            height = int.MaxValue;
        }

        internal static Whiteboard CreatorNameDescriptionOwnerTeamWidthHeight(User creator,
            string name, string description, Team ownerTeam, int width, int height)
        {
            return new Whiteboard(creator, name, description, ownerTeam, width, height);
        }

        private Whiteboard(User aCreator, string aName, string aDescription,
            Team anOwnerTeam, int aWidth, int aHeight)
        {
            if (CreatorIsValidMemberOfTeam(aCreator, anOwnerTeam))
            {
                Creator = aCreator;
                OwnerTeam = anOwnerTeam;
                SetModifiableAttributes(aName, aDescription, aWidth, aHeight);
                UpdateModificationDate();
                UpdateOwnerTeamsWhiteboardCollection();
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CreatorIsInvalid, aCreator, anOwnerTeam);
                throw new WhiteboardException(errorMessage);
            }
        }

        private void UpdateOwnerTeamsWhiteboardCollection()
        {
            OwnerTeam.AddWhiteboard(this);
        }

        private void SetModifiableAttributes(string aName, string aDescription, int aWidth,
            int aHeight)
        {
            Name = aName;
            Description = aDescription;
            Width = aWidth;
            Height = aHeight;
        }

        private static bool CreatorIsValidMemberOfTeam(User creator, Team ownerTeam)
        {
            if (Utilities.IsNotNull(ownerTeam))
            {
                return ownerTeam.Members.Contains(creator);
            }
            else
            {
                throw new WhiteboardException(ErrorMessages.TeamIsInvalid);
            }
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Whiteboard whiteboardToCompareAgainst)
            {
                return HasSameOwnerTeam(whiteboardToCompareAgainst)
                    && HasSameName(whiteboardToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameName(Whiteboard aWhiteboard)
        {
            return name.Equals(aWhiteboard.name);
        }

        private bool HasSameOwnerTeam(Whiteboard aWhiteboard)
        {
            return OwnerTeam.Equals(aWhiteboard.OwnerTeam);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}