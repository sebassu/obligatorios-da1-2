using System;
using Exceptions;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Domain
{
    public class Whiteboard
    {
        public virtual int Id { get; set; }

        private const byte minimumWidth = 1;
        private const byte minimumHeight = 1;

        public virtual DateTime CreationDate { get; set; } = DateTime.Today;

        public virtual DateTime LastModification { get; set; }

        internal void UpdateModificationDate()
        {
            LastModification = DateTime.Now;

        }

        private string name;
        public virtual string Name
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
        public virtual string Description
        {
            get { return description; }
            set
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
        public virtual int Width
        {
            get { return width; }
            set
            {
                if (IsValidWidth(value))
                {
                    width = value;
                    UpdateModificationDate();
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.WidthIsInvalid);
                }
            }
        }

        private bool IsValidWidth(int value)
        {
            return value >= minimumWidth &&
                (Utilities.IsEmpty(Contents) || value >= GetMaximumWidthNeededOfComponents());
        }

        private double GetMaximumWidthNeededOfComponents()
        {
            return Contents.Max(c => c.WidthContainerNeeded());
        }

        private int height;
        public virtual int Height
        {
            get { return height; }
            set
            {
                if (IsValidHeight(value))
                {
                    height = value;
                    UpdateModificationDate();
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.HeightIsInvalid);
                }
            }
        }

        private bool IsValidHeight(int value)
        {
            return value >= minimumWidth &&
                (Utilities.IsEmpty(Contents) || value >= GetMaximumHeightNeededOfComponents());
        }

        private double GetMaximumHeightNeededOfComponents()
        {
            return Contents.Max(c => c.HeightContainerNeeded());
        }

        public virtual User Creator { get; set; }

        public virtual Team OwnerTeam { get; set; }

        public List<ElementWhiteboard> Contents { get; set; }
            = new List<ElementWhiteboard>();

        internal void AddWhiteboardElement(ElementWhiteboard elementToAdd)
        {
            if (Utilities.IsNotNull(elementToAdd))
            {
                Contents.Add(elementToAdd);
            }
            else
            {
                throw new WhiteboardException(ErrorMessages.NullElement);
            }
        }

        public void RemoveWhiteboardElement(ElementWhiteboard elementToRemove)
        {
            bool elementWasRemoved = Contents.Remove(elementToRemove);
            if (!elementWasRemoved)
            {
                throw new WhiteboardException(ErrorMessages.NonMemberElement);
            }
        }

        internal bool UserCanModify(User someUser)
        {
            var teamMembers = OwnerTeam.Members.ToList();
            return Utilities.HasAdministrationPrivileges(someUser)
                || teamMembers.Contains(someUser);
        }

        internal bool UserCanRemove(User someUser)
        {
            return Utilities.HasAdministrationPrivileges(someUser)
                || Creator.Equals(someUser);
        }

        internal static Whiteboard InstanceForTestingPurposes()
        {
            return new Whiteboard();
        }

        public Whiteboard()
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
            Whiteboard whiteboardToCompareAgainst = obj as Whiteboard;
            if (Utilities.IsNotNull(whiteboardToCompareAgainst))
            {
                return HasSameOwnerTeam(whiteboardToCompareAgainst)
                    && HasSameName(whiteboardToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool HasSameName(Whiteboard someWhiteboard)
        {
            return name.Equals(someWhiteboard.name);
        }

        private bool HasSameOwnerTeam(Whiteboard someWhiteboard)
        {
            return OwnerTeam.Equals(someWhiteboard.OwnerTeam);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}