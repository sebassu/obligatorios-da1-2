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
        protected static void Add(T elementToAdd)
        {
            using (BoardContext context = new BoardContext())
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

        public static DbSet<T> DbElements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    return context.Set<T>();
                }
            }
        }

        public static bool HasElements()
        {
            using (BoardContext context = new BoardContext())
            {
                return !context.Set<T>().Any();
            }
        }

        public static void Remove(T elementToRemove)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Set<T>();
                elements.Remove(elementToRemove);
                context.SaveChanges();
            }
        }

        protected static void AttachIfCorresponds(BoardContext context, T element)
        {
            var elements = context.Set<T>();
            if (context.Entry(element).State == EntityState.Detached)
            {
                elements.Attach(element);
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