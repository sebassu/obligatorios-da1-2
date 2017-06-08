using Exceptions;
using System.Resources;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    public abstract class EntityFrameworkRepository<T> where T : class
    {
        protected static void Add(T elementToAdd)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Set<T>();
                if (!elements.Contains(elementToAdd))
                {
                    elements.Add(elementToAdd);
                    context.SaveChanges();
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.ElementAlreadyExists);
                }
            }
        }

        protected static List<T> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    return context.Set<T>().ToList();
                }
            }
        }

        public static bool HasElements()
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Set<T>();
                return !elements.Any();
            }
        }

        public static void Remove(T elementToRemove)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Set<T>();
                AttachIfCorresponds(elementToRemove);
                elements.Remove(elementToRemove);
                context.SaveChanges();
            }
        }

        protected static void AttachIfCorresponds(T element)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Set<T>();
                if (context.Entry(element).State == EntityState.Detached)
                {
                    elements.Attach(element);
                }
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