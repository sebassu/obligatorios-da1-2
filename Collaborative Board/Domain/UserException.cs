using System;

namespace Domain
{
    public class UserException : ArgumentException
    {
        public UserException(string message) : base(message) { }
    }
}
