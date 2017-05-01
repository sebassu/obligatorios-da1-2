using System;

namespace Exceptions
{
    [Serializable]
    public class WhiteboardException : BoardException
    {
        public WhiteboardException(string message) : base(message) { }
    }
}
