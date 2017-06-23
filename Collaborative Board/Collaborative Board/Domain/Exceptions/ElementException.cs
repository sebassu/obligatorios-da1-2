using System;

namespace Domain
{
    [Serializable]
    public class ElementException : BoardException
    {
        public ElementException(string message) : base(message) { }
    }
}