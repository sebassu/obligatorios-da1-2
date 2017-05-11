using System;

namespace Exceptions
{
    [Serializable]
    public class ElementException : BoardException
    {
        public ElementException(string message) : base(message) { }
    }
}