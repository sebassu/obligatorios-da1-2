using Domain;
using Exceptions;
using System.Resources;
using System.Data.Entity;
using System.Data;

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
            catch (DataException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.Message);
            }
        }

        public static void Remove(T elementToRemove)
        {
            using (BoardContext context = new BoardContext())
            {
                try
                {
                    var elements = context.Set<T>();
                    AttachIfIsValid(context, elementToRemove);
                    elements.Remove(elementToRemove);
                    context.SaveChanges();
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        protected static void AttachIfIsValid(BoardContext context, T element)
        {
            var elements = context.Set<T>();
            if (Utilities.IsNotNull(element))
            {
                if (context.Entry(element).State == EntityState.Detached)
                {
                    elements.Attach(element);
                }
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