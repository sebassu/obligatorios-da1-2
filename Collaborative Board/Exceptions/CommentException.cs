using System;

namespace Exceptions
{
    [Serializable]
    public class CommentException : BoardException
    {
        public CommentException(string message) : base(message) { }
    }
}