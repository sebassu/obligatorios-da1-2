using System;

namespace Domain
{
    [Serializable]
    public class TeamException : BoardException
    {
        public TeamException(string message) : base(message) { }
    }
}
