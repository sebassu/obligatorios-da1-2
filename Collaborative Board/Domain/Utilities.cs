using System;
using System.Linq;

namespace Domain
{
    public static class Utilities
    {
        public static bool IsNotNull(object anObject)
        {
            return anObject != null;
        }

        public static bool ContainsOnlyLettersDigitsOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterDigitOrSpace(c));
        }

        private static bool IsLetterDigitOrSpace(char aCharacter)
        {
            return char.IsLetterOrDigit(aCharacter) || char.IsWhiteSpace(aCharacter);
        }

        public static bool ContainsOnlyLettersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterOrSpace(c));
        }

        private static bool IsLetterOrSpace(char aCharacter)
        {
            return char.IsLetter(aCharacter) || char.IsWhiteSpace(aCharacter);
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            return value <= DateTime.Today;
        }
    }
}
