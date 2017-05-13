using System;

namespace Exceptions
{
    [Serializable]
    public class RepositoryException : BoardException
    {
        public RepositoryException(string message) : base(message) { }
    }
}