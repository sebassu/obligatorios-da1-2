using System;

namespace Exceptions
{
    [Serializable]
    public class TeamException : BoardException
    {
        public TeamException(string message) : base(message) { }
    }
}
