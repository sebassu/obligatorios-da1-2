using System;
using System.Linq;


namespace Domain
{
    public static class Utilities
    {
        public static bool ContainsOnlyLettersOrNumbers(string aString)
        {
            return aString.ToCharArray().All(c => CharacterIsNumberOrDigit(c));
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
            return char.IsLetter(aChar) || char.IsWhiteSpace(aChar);
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            var todaysDate = DateTime.Now.Date;
            return value.CompareTo(todaysDate) <= 0;
        }

        public static bool IsNotNull(Object anObject)
        {
            return anObject != null;
        }
    }
}
