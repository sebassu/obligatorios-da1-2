using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserDataEntityFramework
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime Birthdate { get; set; }
        public virtual string Password { get; set; }
        public virtual bool HasAdministrationPrivileges { get; set; }
        public virtual List<Comment> CommentsCreated { get; set; }
        public virtual List<Comment> CommentsResolved { get; set; }

        public UserDataEntityFramework()
        {
            FirstName = "Usuario";
            LastName = "inválido.";
            Email = "mailInvalido@usuarioInvalido";
        }

        public UserDataEntityFramework(string firstNameToSet, string lastNameToSet,
            string emailToSet, DateTime birthdateToSet, string passwordToSet,
            bool UserPrivilegesToSet)
        {
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Email = emailToSet;
            Birthdate = birthdateToSet;
            Password = passwordToSet;
            HasAdministrationPrivileges = UserPrivilegesToSet;
        }
    }
}
