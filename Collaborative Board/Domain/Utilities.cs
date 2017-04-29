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

        public static bool ContainsOnlyLettersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterOrSpace(c));
        }

        private static bool IsLetterDigitOrSpace(char aChar)
        {
            return IsLetterOrSpace(aChar) || char.IsNumber(aChar);
        }

        private static bool IsLetterOrSpace(char aChar)
        {
            return char.IsLetter(aChar) || char.IsWhiteSpace(aChar);
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            return value <= DateTime.Today;
        }
    }
}
