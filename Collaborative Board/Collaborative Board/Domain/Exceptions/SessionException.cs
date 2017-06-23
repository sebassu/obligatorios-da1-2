using System;

namespace Domain
{
    [Serializable]
    public class SessionException : BoardException
    {
        public SessionException(string message) : base(message) { }
    }
}