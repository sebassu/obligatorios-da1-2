using System;

namespace Domain
{
    [Serializable]
    public class RepositoryException : BoardException
    {
        public RepositoryException(string message) : base(message) { }
    }
}