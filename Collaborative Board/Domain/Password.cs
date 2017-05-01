using System;
using Exceptions;
using System.Linq;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Password
    {
        private static readonly ReadOnlyCollection<char> allowedCharacters =
            Array.AsReadOnly("ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789".ToCharArray());
        private const byte minimumLength = 6;
        private const byte maximumLength = 20;
        private const byte lengthOfGeneratedPassword = 10;

        private string passwordValue;
        internal string PasswordValue
        {
            get { return passwordValue; }
            set
            {
                if (IsValidPassword(value))
                {
                    passwordValue = value;
                }
                else
                {
                    throw new PasswordException("Invalid password recieved: " + value + ".");
                }
            }
        }

        public static bool IsValidPassword(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && HasValidLength(value) && HasOnlyValidCharacters(value);
        }

        private static bool HasOnlyValidCharacters(string value)
        {
            return value.ToCharArray().All(c => allowedCharacters.Contains(c));
        }

        private static bool HasValidLength(string value)
        {
            return value.Length <= maximumLength && value.Length >= minimumLength;
        }

        internal Password()
        {
            passwordValue = "Contraseña inválida.";
        }

        internal string Reset()
        {
            string newPassword = GenerateNewPassword();
            passwordValue = newPassword;
            return newPassword;
        }

        private static string GenerateNewPassword()
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
