using System;

namespace Exceptions
{
    public class BoardException : ArgumentException
    {
        public BoardException(string message) : base(message) { }
    }
}
