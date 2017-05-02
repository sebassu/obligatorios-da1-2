using System;

namespace Exceptions
{
    [Serializable]
    public class DirectoryException : BoardException
    {
        public DirectoryException(string message) : base(message) { }
    }
}