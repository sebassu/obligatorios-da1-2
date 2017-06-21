using System;

namespace Domain
{
    [Serializable]
    public class AssociationException : ArgumentException
    {
        public AssociationException(string message) : base(message) { }
    }
}