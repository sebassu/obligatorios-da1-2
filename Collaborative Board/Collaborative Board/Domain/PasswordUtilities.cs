using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace Domain
{
    public static class PasswordUtilities
    {
        private static readonly ReadOnlyCollection<char> allowedCharacters = Array.AsReadOnly(
            "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789áéíóúÁÉÍÓÚüÜëË"
            .ToCharArray());
        public const byte minimumLength = 6;
        public const byte maximumLength = 20;
        private const byte lengthOfGeneratedPassword = 10;

        public static bool IsValidPassword(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && HasValidLength(value)
                && HasOnlyValidCharacters(value);
        }

        private static bool HasOnlyValidCharacters(string value)
        {
            return value.ToCharArray().All(c => allowedCharacters.Contains(c));
        }

        private static bool HasValidLength(string value)
        {
            return value.Length <= maximumLength && value.Length >= minimumLength;
        }

        public static string GenerateNewPassword()
        {
            var result = new char[lengthOfGeneratedPassword];
            var random = new Random();
            AddRandomCharacters(result, random);
            return new String(result);
        }

        private static void AddRandomCharacters(char[] password, Random aRandom)
        {
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = allowedCharacters[aRandom.Next(allowedCharacters.Count)];
            }
        }
    }
}
