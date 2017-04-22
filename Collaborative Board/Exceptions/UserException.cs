using System;

namespace Exceptions
{
    [Serializable]
    public class UserException : BoardException
    {
        public UserException(string message) : base(message) { }
    }
}