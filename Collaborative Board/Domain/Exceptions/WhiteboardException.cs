using System;

namespace Domain
{
    [Serializable]
    public class WhiteboardException : BoardException
    {
        public WhiteboardException(string message) : base(message) { }
    }
}
