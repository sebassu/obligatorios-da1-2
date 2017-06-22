using System;

namespace Domain
{
    [Serializable]
    public class AssociationException : BoardException
    {
        public AssociationException(string message) : base(message) { }
    }
}