using Domain;
using System.Data;
using System.Resources;
using System.Data.Entity;
using System;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    internal static class EntityFrameworkUtilities<T> where T : class
    {
        internal static void Add(BoardContext context, T elementToAdd)
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

        internal static void Remove(T elementToRemove)
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

        internal static void AttachIfIsValid(BoardContext context, T element)
        {
            var elements = context.Set<T>();
            try
            {
                PerformAttachIfCorresponds(context, element, elements);
            }
            catch (SystemException)
            {
                throw new RepositoryException(ErrorMessages.InvalidElementRecieved);
            }
        }

        private static void PerformAttachIfCorresponds(BoardContext context, T element, DbSet<T> elements)
        {
            if (context.Entry(element).State == EntityState.Detached)
            {
                elements.Attach(element);
            }
        }
    }
}