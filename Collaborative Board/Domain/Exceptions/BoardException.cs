using System;

namespace Domain
{
    [Serializable]
    public class BoardException : ArgumentException
    {
        public BoardException(string message) : base(message) { }
    }
}