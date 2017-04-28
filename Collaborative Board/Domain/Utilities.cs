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

        private static bool CharacterIsNumberOrDigit(char aChar)
        {
            return char.IsLetterOrDigit(aChar);
        }

        public static bool ContainsOnlyLettersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterOrSpace(c));
        }

        public static bool ContainsOnlyLettersOrNumbersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterOrDigitOrSpace(c));
        }

        private static bool IsLetterOrDigitOrSpace(char aChar)
        {
            return char.IsLetter(aChar) || char.IsWhiteSpace(aChar) || char.IsNumber(aChar);
        }

        private static bool IsLetterOrSpace(char aChar)
        {
            return char.IsLetter(aCharacter) || char.IsWhiteSpace(aCharacter);
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            return value <= DateTime.Today;
        }
    }
}
