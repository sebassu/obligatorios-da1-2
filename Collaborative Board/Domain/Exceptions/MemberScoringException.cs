using System;

namespace Domain
{
    [Serializable]
    public class MemberScoringException : BoardException
    {
        public MemberScoringException(string message) : base(message) { }
    }
}
