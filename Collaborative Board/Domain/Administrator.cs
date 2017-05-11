using System;

namespace Domain
{
    public class Administrator : User
    {
        public override bool HasAdministrationPrivileges => true;

        new public static Administrator NamesEmailBirthdatePassword(string firstName, string lastName,
            string email, DateTime birthdate, string password)
        {
            return new Administrator(firstName, lastName, email, birthdate, password);
        }

        protected Administrator(string firstName, string lastName, string email, DateTime birthdate, string password)
            : base(firstName, lastName, email, birthdate, password) { }

        new internal static Administrator InstanceForTestingPurposes()
        {
            return new Administrator();
        }

        protected Administrator() : base() { }

        public override string ToString()
        {
            return String.Concat(base.ToString(), " (Admin.)");
        }
    }
}