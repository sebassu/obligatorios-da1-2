using System;
using System.Collections;
using System.Globalization;
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

        public static bool IsEmpty(ICollection someCollection)
        {
            return someCollection.Count == 0;
        }

        public static bool IsTodayOrBefore(DateTime value)
        {
            return value <= DateTime.Today;
        }

        public static bool HasAdministrationPrivileges(User someUser)
        {
            return IsNotNull(someUser) && someUser.HasAdministrationPrivileges;
        }

        public static string GetDateToShow(DateTime someDate)
        {
            if (someDate != DateTime.MinValue)
            {
                return someDate.ToString("d/M/yyyy, h:mm tt", CultureInfo.CurrentCulture);
            }
            else
            {
                return "N/a";
            }
        }
    }
}
