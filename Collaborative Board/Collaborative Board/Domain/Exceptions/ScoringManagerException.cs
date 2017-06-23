using System;

namespace Domain
{
    [Serializable]
    public class ScoringManagerException : BoardException
    {
        public ScoringManagerException(string message) : base(message) { }
    }
}
