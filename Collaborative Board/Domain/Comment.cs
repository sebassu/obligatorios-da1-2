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
                    throw new CommentException("El texto introducido para el comentario " +
                        "no es válido, reintente.");
                }
                else
                {
                    text = value;
                }
            }
        }

        private readonly DateTime creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get { return creationDate; }
        }

        public User Creator { get; private set; }

        private DateTime resolutionDate;

        // Created as a method since generating a Property raises a warning in Visual Studio
        // due to an exception being thrown, result of DateTime being a non-nullable type.
        public DateTime ResolutionDate()
        {
            if (resolutionDate != DateTime.MinValue)
            {
                return resolutionDate;
            }
            else
            {
                throw new CommentException("El comentario actual no se ha " +
                      "resuelto aún.");
            }
        }

        public User Resolver { get; private set; }

        internal void Resolve(User aUser)
        {
            if (IsResolved)
            {
                throw new CommentException("El comentario seleccionado ya había " +
                    "sido resuelto.");
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
                throw new CommentException("Usuario inválido (nulo) recibido.");
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
        // a date that already long ago passed.
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
                throw new CommentException("Usuario inválido (nulo) recibido.");
            }
        }

        private void SetCreationAttributes(User aUser, string someText)
        {
            Text = someText;
            Creator = aUser;
        }
    }
}
