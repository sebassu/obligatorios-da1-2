using System;
using System.Globalization;

namespace Domain
{
    public class Association
    {
        public enum Directions { DIRECT, INVERSE, BIDIRECTIONAL, NO_DIRECTION };

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
                    throw new AssociationException(errorMessage);
                }
            }
        }

        private bool IsValidAssociationName(string value)
        {
            throw new NotImplementedException();
        }

        private string description;
        public virtual string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AssociationException(ErrorMessages.EmptyDescription);
                }
                else
                {
                    description = value;
                }
            }
        }

        public virtual ElementWhiteboard Origin { get; set; }
        public virtual ElementWhiteboard Destination { get; set; }

        private int direction;
        public virtual int Direction
        {
            get { return direction; }
            set
            {
                if (Enum.IsDefined(typeof(Directions), value))
                {
                    direction = value;
                }
                else
                {
                    throw new AssociationException(ErrorMessages.InvalidDirection);
                }
            }
        }

        protected Association() { }

        public static Association NameDescriptionOriginDestinationDirection(string name, string description,
            ElementWhiteboard origin, ElementWhiteboard destination, int direction)
        {
            return new Association(name, description, origin, destination, direction);
        }

        protected Association(string aName, string aDscription, ElementWhiteboard origin,
            ElementWhiteboard destination, int someDirection)
        {
            if (ElementsAreValidAsociationMembers(origin, destination))
            {
                SetInicializacionAttributes(aName, aDscription, origin, destination, someDirection);
            }
            else
            {
                throw new AssociationException(ErrorMessages.AssociationElementIsInvalid);
            }
        }

        private void SetInicializacionAttributes(string aName, string aDscription,
            ElementWhiteboard origin, ElementWhiteboard destination, int someDirection)
        {
            Origin = origin;
            Destination = destination;
            Name = aName;
            Description = aDscription;
        }

        private bool ElementsAreValidAsociationMembers(ElementWhiteboard origin, ElementWhiteboard destination)
        {
            return Utilities.IsNotNull(origin) && Utilities.IsNotNull(destination)
                && !origin.Equals(destination);
        }
    }
}