using System.Linq;
using Exceptions;

namespace Domain
{
    internal class Password
    {
        private const int minimunLength = 6;

        private const int maximumLength = 20;

        private string passwordValue;

        internal string PasswordValue
        {
            get { return passwordValue; }
            set
            {
                if (IsValidPassword(value))
                {
                    passwordValue = value;
                }
                else
                {
                    throw new PasswordException("Invalid password recieved: " + value + ".");
                }
            }
        }

        private static bool IsValidPassword(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && HasValidLength(value) && HasOnlyValidCharacters(value);
        }

        private static bool HasOnlyValidCharacters(string value)
        {
            return value.ToCharArray().All(c => char.IsLetterOrDigit(c));
        }

        private static bool HasValidLength(string value)
        {
            return value.Length <= maximumLength && value.Length >= minimunLength;
        }

        internal Password()
        {
            passwordValue = "Contraseña inválida.";
        }
    }
}
