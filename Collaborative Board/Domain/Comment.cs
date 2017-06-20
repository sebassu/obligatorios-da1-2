using System;

namespace Domain
{
    public class Comment
    {
        public virtual int Id { get; set; }

        private string text;
        public virtual string Text
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

        public virtual DateTime CreationDate { get; set; } = DateTime.Now;

        public virtual User Creator { get; set; }

        public virtual ElementWhiteboard AssociatedElement { get; set; }

        public Whiteboard AssociatedWhiteboard
        {
            get { return AssociatedElement.Container; }
        }

        // Minimum value for database DateTime.
        public virtual DateTime ResolutionDate { get; set; } = new DateTime(1753, 1, 1);

        public virtual User Resolver { get; set; }

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
            ResolutionDate = DateTime.Now;
        }

        // Valid since resolutionDate will never be set to the mentioned date, which represents 
        // a date that already passed. Usage of DateTime? (System.Nullable<DateTime>) was considered
        // but decided against due to the boxing/unboxing overhead as well as the previous alternative.
        public bool IsResolved
        {
            get
            {
                bool resolutionDateWasSet = ResolutionDate != new DateTime(1753, 1, 1);
                return resolutionDateWasSet;
            }
        }

        public static Comment InstanceForTestingPurposes()
        {
            return new Comment();
        }

        protected Comment()
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
            someElement.AddComment(this);
            Creator.AddCreatedComment(this);
        }

        public override bool Equals(object obj)
        {
            Comment commentToCompareAgainst = obj as Comment;
            if (Utilities.IsNotNull(commentToCompareAgainst))
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
