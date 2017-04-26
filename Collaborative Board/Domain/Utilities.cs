using System;
using System.Linq;


namespace Domain
{
    public static class Utilities
    {
        public static bool ContainsOnlyLettersOrNumbers(string aString)
        {
            return aString.ToCharArray().All(c => char.IsLetterOrDigit(c));
        }

        public static bool IsNotNull(object anObject)
        {
            return anObject != null;
        }

        public static bool IsValidName(string aString)
        {
            return !string.IsNullOrWhiteSpace(aString) && ContainsOnlyLettersOrSpaces(aString);
        }

        private static bool ContainsOnlyLettersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsLetterOrSpace(c));
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
