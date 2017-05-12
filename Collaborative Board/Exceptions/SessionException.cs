using System;

namespace Exceptions
{
    [Serializable]
    public class SessionException : BoardException
    {
        public SessionException(string message) : base(message) { }
    }
}