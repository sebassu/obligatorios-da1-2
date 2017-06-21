namespace Domain
{
    public class Association
    {
        public virtual int Id { get; set; }

        public virtual ElementWhiteboard Origin { get; set; }
        public virtual ElementWhiteboard Destination { get; set; }

        protected Association() { }

        public static Association OriginDestination(ElementWhiteboard origin, ElementWhiteboard destination)
        {
            return new Association(origin, destination);
        }

        protected Association(ElementWhiteboard origin, ElementWhiteboard destination)
        {
            if (ElementsAreValidAsociationMembers(origin, destination))
            {
                Origin = origin;
                Destination = destination;
            }
            else
            {
                throw new AssociationException(ErrorMessages.AssociationElementIsInvalid);
            }
        }

        private bool ElementsAreValidAsociationMembers(ElementWhiteboard origin, ElementWhiteboard destination)
        {
            return Utilities.IsNotNull(origin) && Utilities.IsNotNull(destination)
                && !origin.Equals(destination);
        }
    }
}