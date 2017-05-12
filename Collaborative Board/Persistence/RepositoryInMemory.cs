﻿using System;
using Exceptions;
using System.Linq;
using System.Resources;
using System.Collections.Generic;

[assembly: NeutralResourcesLanguage("es")]
namespace Persistence
{
    public abstract class RepositoryInMemory<T>
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
                throw new RepositoryException(ErrorMessages.ElementAlreadyExists);
            }
        }

        public bool HasElements()
        {
            return elements.Count > 0;
        }

        public virtual void Remove(T elementToRemove)
        {
            if (!elements.Remove(elementToRemove))
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        protected void ValidateActiveUserHasAdministrationPrivileges()
        {
            if (!Session.HasAdministrationPrivileges())
            {
                throw new RepositoryException(ErrorMessages.NoAdministrationPrivileges);
            }
        }

        internal T GetActualObjectInCollection(T elementToFind)
        {
            try
            {
                return elements.Single(e => e.Equals(elementToFind));
            }
            catch (InvalidOperationException)
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }
    }
}