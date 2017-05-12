using System;
using Exceptions;

namespace Domain
{
    public class Comment
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new CommentException(ErrorMessages.CommentTextIsInvalid);
                }
                else
                {
                    text = value;
                }
            }
        }

        public DateTime CreationDate { get; } = DateTime.Now;

        public User Creator { get; private set; }

        private DateTime resolutionDate;

        // Created as a method since generating a Property raises a warning in Visual Studio
        // due to an exception being thrown.
        public DateTime ResolutionDate()
        {
            if (resolutionDate != DateTime.MinValue)
            {
                return resolutionDate;
            }
            else
            {
                throw new CommentException(ErrorMessages.UnresolvedComment);
            }
        }

        public User Resolver { get; private set; }

        internal void Resolve(User aUser)
        {
            if (IsResolved)
            {
                throw new CommentException(ErrorMessages.AlreadyResolvedComment);
            }
            else
            {
                ProcessResolutionIfPossible(aUser);
            }
        }

        private void ProcessResolutionIfPossible(User aUser)
        {
            if (Utilities.IsNotNull(aUser))
            {
                SetResolutionAttributes(aUser);
            }
            else
            {
                throw new CommentException(ErrorMessages.NullUser);
            }
        }

        private void SetResolutionAttributes(User aUser)
        {
            Resolver = aUser;
            aUser.AddResolvedComment(this);
            resolutionDate = DateTime.Now;
        }

        public bool IsResolved
        {
            get
            {
                return ResolutionDateWasSet();
            }
        }

        // Valid since resolutionDate will never be set to DateTime.MinValue, which represents 
        // a date that already passed. Usage of DateTime? (System.Nullable<DateTime>) was considered
        // but decided against due to the boxing/unboxing overhead as well as the previous alternative.
        private bool ResolutionDateWasSet()
        {
            return (resolutionDate != DateTime.MinValue);
        }

        public static Comment InstanceForTestingPurposes()
        {
            return new Comment();
        }

        private Comment()
        {
            text = "Comentario inválido.";
        }

        internal static Comment CreatorText(User aUser, string someText)
        {
            return new Comment(aUser, someText);
        }

        private Comment(User aUser, string someText)
        {
            if (Utilities.IsNotNull(aUser))
            {
                SetCreationAttributes(aUser, someText);
            }
            else
            {
                throw new CommentException(ErrorMessages.NullUser);
            }
        }

        private void SetCreationAttributes(User aUser, string someText)
        {
            Text = someText;
            Creator = aUser;
        }
    }
}
