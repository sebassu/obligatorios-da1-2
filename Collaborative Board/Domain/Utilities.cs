using System.Linq;

namespace Domain
{
    public static class Utilities
    {
        public static bool IsValidTeamName(string aString)
        {
            return !string.IsNullOrEmpty(aString) && ContainsOnlyLettersOrNumbers(aString);
        }

        private static bool ContainsOnlyLettersOrNumbers(string aString)
        {
            return aString.ToCharArray().All(c => CharacterIsNumberOrDigit(c));
        }

        private static bool CharacterIsNumberOrDigit(char aChar)
        {
            return char.IsLetterOrDigit(aChar);
        }
    }
}
