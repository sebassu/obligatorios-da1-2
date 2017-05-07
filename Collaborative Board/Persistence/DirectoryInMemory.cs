using Exceptions;
using System.Collections.Generic;

namespace Persistence
{
    public abstract class DirectoryInMemory<T>
    {
        protected List<T> elements;
        public IReadOnlyCollection<T> Elements => elements.AsReadOnly();

        protected void Add(T elementToAdd)
        {
            if (!elements.Contains(elementToAdd))
            {
                elements.Add(elementToAdd);
            }
            else
            {
                throw new DirectoryException(ErrorMessages.ElementAlreadyExists);
            }
        }

        public bool HasElements()
        {
            return elements.Count > 0;
        }

        public void Remove(T elementToRemove)
        {
            if (!elements.Remove(elementToRemove))
            {
                throw new DirectoryException(ErrorMessages.ElementDoesNotExist);
            }
        }
    }
}
