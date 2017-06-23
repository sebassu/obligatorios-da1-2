using System;
using System.Globalization;

namespace Domain
{
    public class Connection
    {
        public enum Direction { DIRECT, INVERSE, BIDIRECTIONAL, NO_DIRECTION };

        public virtual int Id { get; set; }

        private string name;
        public virtual string Name
        {
            get { return name; }
            set
            {
                if (IsValidAssociationName(value))
                {
                    name = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, value);
                    throw new ConnectionException(errorMessage);
                }
            }
        }

        private bool IsValidAssociationName(string value)
        {
            return Utilities.ContainsLettersDigitsOrSpacesOnly(value);
        }

        public virtual string Description { get; set; }

        public virtual ElementWhiteboard Origin { get; set; }
        public virtual ElementWhiteboard Destination { get; set; }

        private int connectionDirection;
        public virtual int ConectionDirection
        {
            get { return connectionDirection; }
            set
            {
                if (Enum.IsDefined(typeof(Direction), value))
                {
                    connectionDirection = value;
                }
            }
        }

        protected Connection() { }

        public static Connection NameDescriptionOriginDestinationDirection(string name, string description,
            ElementWhiteboard origin, ElementWhiteboard destination, int direction)
        {
            return new Connection(name, description, origin, destination, direction);
        }

        protected Connection(string aName, string aDscription, ElementWhiteboard origin,
            ElementWhiteboard destination, int someDirection)
        {
            if (ElementsAreValidAsociationMembers(origin, destination))
            {
                SetInicializacionAttributes(aName, aDscription, origin, destination, someDirection);
            }
            else
            {
                throw new ConnectionException(ErrorMessages.ConnectionElementIsInvalid);
            }
        }

        private void SetInicializacionAttributes(string aName, string aDscription,
            ElementWhiteboard origin, ElementWhiteboard destination, int someDirection)
        {
            Origin = origin;
            Destination = destination;
            Name = aName;
            Description = aDscription;
            ConectionDirection = someDirection;
        }

        private bool ElementsAreValidAsociationMembers(ElementWhiteboard origin, ElementWhiteboard destination)
        {
            return Utilities.IsNotNull(origin) && Utilities.IsNotNull(destination)
                && !origin.Equals(destination);
        }
    }
}