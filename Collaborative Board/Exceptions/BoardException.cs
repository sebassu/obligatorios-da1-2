using System;

namespace Exceptions
{
    [Serializable]
    public class BoardException : ArgumentException
    {
        public BoardException(string message) : base(message) { }
    }
}