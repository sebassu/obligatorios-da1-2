using System.Linq;
using Exceptions;
using System;

namespace Domain
{
    public class Whiteboard
    {
        private static int minimumHeightWidth = 1;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
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
            return !string.IsNullOrEmpty(aString) && Utilities.ContainsOnlyLettersOrNumbersOrSpaces(aString);
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
                    throw new WhiteboardException("Descripción inválida: " + value + ".");
                }
            }
        }

        private Team ownerTeam;

        public Team OwnerTeam
        {
            get
            {
                return ownerTeam;
            }
            set
            {
                if (Utilities.IsNotNull(value))
                {
                    ownerTeam = value;
                }
                else
                {
                    throw new WhiteboardException("El nombre del equipo no es válido: " + value + ".");
                }
            }
        }

        private int width;

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value >= minimumHeightWidth)
                {
                    width = value;
                }
                else
                {
                    throw new WhiteboardException("Altura de pizarrón inválida: " + value + ".");
                }
            }
        }

        private int height;

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value >= minimumHeightWidth)
                {
                    height = value;
                }
                else
                {
                    throw new WhiteboardException("Altura de pizarrón inválida: " + value + ".");
                }
            }
        }

        public User Creator {get; private set;} 

        internal static Whiteboard WhiteboardForTestingPurposes()
        {
            Whiteboard result = new Whiteboard()
            {
                name = "Nombre inválido",
                description = "Descripción inválida.",
                width = 1,
                height = 1
            };
            return result;
        }

        private Whiteboard()
        {
            Creator = User.InstanceForTestingPurposes();
            ownerTeam = Team.InstanceForTestingPurposes();
        }

        public static Whiteboard CreatorNameDescriptionOwnerTeamWidthHeight(User creator, string aName, string aDescription, Team anOwnerTeam, int width, int height)
        {
            return new Whiteboard(creator, aName, aDescription, anOwnerTeam, width, height);
        }

        private Whiteboard(User aCreator, string aName, string aDescription, Team anOwnerTeam, int aWidth, int aHeight)
            : this()
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


    }
}