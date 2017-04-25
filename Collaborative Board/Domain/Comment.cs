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
                    throw new CommentException("El texto introducido para el comentario no es válido, " +
                        "reintente.");
                }
                else
                {
                    text = value;
                }
            }
        }

        public static Comment InstanceForTestingPurposes()
        {
            return new Comment();
        }

        private Comment()
        {
            text = "Comentario inválido.";
        }
    }
}
