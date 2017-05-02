using System;

namespace Exceptions
{
    [Serializable]
    public class PasswordException : ArgumentException
    {
        public PasswordException(string message) : base(message) { }
    }
}