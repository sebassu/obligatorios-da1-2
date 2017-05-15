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

        public User Creator { get; }

        internal ElementWhiteboard AssociatedElement { get; }

        public Whiteboard AssociatedWhiteboard
        {
            get { return AssociatedElement.Container; }
        }

        private DateTime resolutionDate;
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

        public void Resolve(User someResolver)
        {
            if (IsResolved)
            {
                throw new CommentException(ErrorMessages.AlreadyResolvedComment);
            }
            else
            {
                ProcessResolutionIfPossible(someResolver);
            }
        }

        private void ProcessResolutionIfPossible(User someResolver)
        {
            if (Utilities.IsNotNull(someResolver))
            {
                SetResolutionAttributes(someResolver);
            }
            else
            {
                throw new CommentException(ErrorMessages.NullUser);
            }
        }

        private void SetResolutionAttributes(User someResolver)
        {
            Resolver = someResolver;
            someResolver.AddResolvedComment(this);
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
            Creator = User.InstanceForTestingPurposes();
            AssociatedElement = TextBoxWhiteboard.InstanceForTestingPurposes();
        }

        public static Comment CreatorElementText(User someCreator,
            ElementWhiteboard someElement, string someText)
        {
            return new Comment(someCreator, someElement, someText);
        }

        private Comment(User someCreator, ElementWhiteboard someElement, string someText)
        {
            bool creationParametersAreValid = Utilities.IsNotNull(someCreator)
                && Utilities.IsNotNull(someElement);
            if (creationParametersAreValid)
            {
                Creator = someCreator;
                AssociatedElement = someElement;
                Text = someText;
                UpdateReferencesComments(someElement);
            }
            else
            {
                throw new CommentException(ErrorMessages.NullUser);
            }
        }

        private void UpdateReferencesComments(ElementWhiteboard someElement)
        {
            Creator.AddCreatedComment(this);
            someElement.AddComment(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Comment commentToCompareAgainst)
            {
                return CreatorDateAndTextAreEqual(commentToCompareAgainst);
            }
            else
            {
                return false;
            }
        }

        private bool CreatorDateAndTextAreEqual(Comment commentToCompareAgainst)
        {
            return Creator.Equals(commentToCompareAgainst.Creator) &&
                text.Equals(commentToCompareAgainst.text) &&
                CreationDate.Equals(commentToCompareAgainst.CreationDate);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Text + " <" + Utilities.GetDateToShow(CreationDate) + ">"
                + " <" + Creator.Email + ">";
        }
    }
}
