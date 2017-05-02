using System;
using System.Collections;

namespace Persistence
{
    public interface UserDirectory
    {
        IList Elements { get; }
        void AddNewUser(string firstName, string lastName, string email,
            DateTime birthdate, string password);
    }
}