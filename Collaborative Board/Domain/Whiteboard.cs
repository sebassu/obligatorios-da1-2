using System;
using Exceptions;

namespace Domain
{
    public class Whiteboard
    {
        private const int minimumWidth = 1;

        private const int minimumHeight = 1;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (IsValidName(value))
                {
                    name = value;
                }
                else
                {
                    throw new WhiteboardException("Nombre inválido: " + value + ".");
                }
            }
        }

        public bool IsValidName(string aString)
        {
            return !string.IsNullOrEmpty(aString) && Utilities.ContainsOnlyLettersDigitsOrSpaces(aString);
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
                }
                else
                {
                    throw new WhiteboardException("Descripción inválida: "
                        + value + ".");
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
                }
                else
                {
                    throw new WhiteboardException("Altura de pizarrón inválida: "
                        + value + ".");
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
                }
                else
                {
                    throw new WhiteboardException("Altura de pizarrón inválida: "
                        + value + ".");
                }
            }
        }

        public User Creator { get; }

        public Team OwnerTeam { get; }

        internal static Whiteboard InstanceForTestingPurposes()
        {
            return new Whiteboard();
        }

        private Whiteboard()
        {
            name = "Nombre inválido";
            description = "Descripción inválida.";
            width = Int32.MaxValue;
            height = Int32.MaxValue;
        }

        public static Whiteboard CreatorNameDescriptionOwnerTeamWidthHeight(User creator,
            string aName, string aDescription, Team anOwnerTeam, int width, int height)
        {
            return new Whiteboard(creator, aName, aDescription, anOwnerTeam, width, height);
        }

        private Whiteboard(User aCreator, string aName, string aDescription,
            Team anOwnerTeam, int aWidth, int aHeight)
        {
            Creator = aCreator;
            Name = aName;
            Description = aDescription;
            OwnerTeam = anOwnerTeam;
            Width = aWidth;
            Height = aHeight;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object parameterObject)
        {
            if (parameterObject is Whiteboard whiteboardToCompareAgainst)
            {
                return HasSameOwnerTeam(whiteboardToCompareAgainst) && HasSameName(whiteboardToCompareAgainst);
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