using System;

namespace Domain
{
    [Serializable]
    public class UserException : BoardException
    {
        public UserException(string message) : base(message) { }
    }
}