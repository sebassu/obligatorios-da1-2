﻿using System.Linq;

namespace Domain
{
    public static class Utilities
    {
        public static bool IsValidName(string aString)
        {
            return !string.IsNullOrWhiteSpace(aString) && ContainsOnlyLettersOrSpaces(aString);
        }

        private static bool ContainsOnlyLettersOrSpaces(string aString)
        {
            return aString.ToCharArray().All(c => IsValidCharacter(c));
        }

        private static bool IsValidCharacter(char aChar)
        {
            return char.IsLetter(aChar) || char.IsWhiteSpace(aChar);
        }
    }
}
