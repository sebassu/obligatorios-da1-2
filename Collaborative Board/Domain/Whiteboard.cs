﻿using System.Linq;
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