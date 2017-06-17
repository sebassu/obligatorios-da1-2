using Domain;
using Exceptions;
using System.Resources;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    public abstract class EntityFrameworkRepository<T> where T : class
    {
        protected static void Add(BoardContext context, T elementToAdd)
        {
            var elements = context.Set<T>();
            try
            {
                elements.Add(elementToAdd);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new RepositoryException(ErrorMessages.ElementAlreadyExists);
            }
        }

        public static List<T> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Set<T>();
                    return elements.ToList();
                }
            }
        }

        public static void Remove(T elementToRemove)
        {
            using (BoardContext context = new BoardContext())
            {
                try
                {
                    var elements = context.Set<T>();
                    AttachIfCorresponds(context, elementToRemove);
                    elements.Remove(elementToRemove);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
                }
            }

        }

        protected static void AttachIfCorresponds(BoardContext context, T element)
        {
            var elements = context.Set<T>();
            bool IsValidElement = Utilities.IsNotNull(element) &&
                context.Entry(element).State == EntityState.Detached;
            if (IsValidElement)
            {
                elements.Attach(element);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        protected static void ValidateActiveUserHasAdministrationPrivileges()
        {
            if (!Session.HasAdministrationPrivileges())
            {
                throw new RepositoryException(ErrorMessages.NoAdministrationPrivileges);
            }
        }
    }
}