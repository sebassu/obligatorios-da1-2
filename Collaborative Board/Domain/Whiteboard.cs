using System.Linq;
using Exceptions;
using System;

namespace Domain
{
    public class Whiteboard
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.ToCharArray().All(c => char.IsLetterOrDigit(c)))
                {
                    name = value;
                }
                else
                {
                    throw new WhiteboardException("Nombre inválido: " + value + ".");
                }
            }
        }

        private string description;

        public string Description
        {
            get; set;
        }

        private Team ownerTeam;

        public Team OwnerTeam
        {
            get; set;
        }

        private int width;

        public int Width
        {
            get; set;
        }

        private int height;

        public int Height
        {
            get; set;
        }

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
    }
}