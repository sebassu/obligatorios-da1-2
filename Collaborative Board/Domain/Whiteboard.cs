using System;
using Exceptions;
using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Whiteboard
    {
        private const byte minimumWidth = 1;
        private const byte minimumHeight = 1;

        public DateTime LastModification { get; private set; }

        internal void UpdateModificationDate()
        {
            LastModification = DateTime.Now;

        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (IsValidName(value))
                {
                    name = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(ErrorMessages.NameIsInvalid, value);
                    throw new WhiteboardException(errorMessage);
                }
            }
        }

        public static bool IsValidName(string value)
        {
            return !string.IsNullOrEmpty(value) &&
                Utilities.ContainsOnlyLettersDigitsOrSpaces(value);
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
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
            set
            {
                if (value >= minimumWidth)
                {
                    width = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(ErrorMessages.WidthIsInvalid, value);
                    throw new WhiteboardException(errorMessage);
                }
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value >= minimumHeight)
                {
                    height = value;
                    UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(ErrorMessages.HeightIsInvalid, value);
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
            name = "Pizarrón inválido";
            description = "Descripción inválida.";
            width = int.MaxValue;
            height = int.MaxValue;
            UpdateModificationDate();
        }

        public static Whiteboard CreatorNameDescriptionOwnerTeamWidthHeight(User creator,
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
            }
            else
            {
                string errorMessage = string.Format(ErrorMessages.CreatorIsInvalid,
                    aCreator, anOwnerTeam);
                throw new WhiteboardException(errorMessage);
            }
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
            return Utilities.IsNotNull(ownerTeam) && ownerTeam.Members.Contains(creator);
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
            return OwnerTeam == aWhiteboard.OwnerTeam;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}