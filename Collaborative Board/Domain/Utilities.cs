using System.Linq;

namespace Domain
{
    public static class Utilities
    {
        public static bool IsValidName(string aString)
        {
            return !string.IsNullOrEmpty(aString) && ContainsOnlyLetters(aString);
        }

        private static bool ContainsOnlyLetters(string aString)
        {
            return aString.ToCharArray().All(c => IsValidCharacter(c));
        }

        private static bool IsValidCharacter(char aChar)
        {
            return char.IsLetter(aChar);
        }
    }
}
