using System;

namespace Domain
{
    [Serializable]
    public class CommentException : BoardException
    {
        public CommentException(string message) : base(message) { }
    }
}