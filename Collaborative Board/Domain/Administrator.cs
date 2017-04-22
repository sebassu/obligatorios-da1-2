using System;

namespace Domain
{
    public class Administrator : User
    {
        new public static Administrator NamesEmailBirthdatePassword(string aFirstName, string aLastName,
            string anEmail, DateTime aBirthdate, string aPassword)
        {
            return new Administrator(aFirstName, aLastName, anEmail, aBirthdate, aPassword);
        }

        protected Administrator(string aFirstName, string aLastName, string anEmail, DateTime aBirthdate, string aPassword)
            : base(aFirstName, aLastName, anEmail, aBirthdate, aPassword) { }

        new internal static Administrator InstanceForTestingPurposes()
        {
            return new Administrator();
        }

        protected Administrator() : base() { }
    }
}
