namespace Exceptions
{
    public class UserException : BoardException
    {
        public UserException(string message) : base(message) { }
    }
}
