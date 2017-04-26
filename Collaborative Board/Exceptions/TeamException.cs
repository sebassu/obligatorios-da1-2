using System;

namespace Exceptions
{
    [Serializable]
    public class TeamException : ArgumentException
    {
        public TeamException(string message) : base(message) { }
    }
}
