using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Persistence
{
    public interface UserDirectory
    {
        IReadOnlyCollection<User> Elements { get; }
        void AddNewUser(string firstName, string lastName, string email,
            DateTime birthdate, string password);
        void Remove(User userToRemove);
        void ModifyUser(User userToModify, string firstName, string lastName,
            string email, DateTime birthdate, string password);
        bool HasElements();
    }
}