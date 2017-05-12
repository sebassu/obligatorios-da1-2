using System;
using System.Linq;

namespace Domain
{
    public static class Utilities
    {
        public static bool IsNotNull(object value)
        {
            return value != null;
        }

        public static bool ContainsLettersDigitsOrSpacesOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterDigitOrSpace(c));
        }

        public static bool ContainsLettersOrSpacesOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterOrSpace(c));
        }

        private static bool IsLetterDigitOrSpace(char value)
        {
            return IsLetterOrSpace(value) || char.IsNumber(value);
        }

        private static bool IsLetterOrSpace(char value)
        {
            return char.IsLetter(value) || char.IsWhiteSpace(value);
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            return value <= DateTime.Today;
        }
    }
}
