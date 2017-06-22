using System;

namespace Domain
{
    [Serializable]
    public class ConnectionException : BoardException
    {
        public ConnectionException(string message) : base(message) { }
    }
}