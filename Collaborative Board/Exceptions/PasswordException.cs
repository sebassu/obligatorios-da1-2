using System;

namespace Exceptions
{
    [Serializable]
    public class PasswordException : BoardException
    {
        public PasswordException(string message) : base(message) { }
    }
}