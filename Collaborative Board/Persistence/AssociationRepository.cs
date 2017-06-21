using System;
using Domain;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class AssociationRepository
    {

        public static List<Association> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Associations.Include("Origin").Include("Destination");
                    return elements.ToList();
                }
            }
        }

        public static Association AddNewAssociation(ElementWhiteboard origin,
            ElementWhiteboard destination)
        {
            using (var context = new BoardContext())
            {
                bool associationAlreadyExists = context.Associations.Any(a => a.Origin.Id == origin.Id
                    && a.Destination.Id == destination.Id);
                if (associationAlreadyExists)
                {
                    throw new RepositoryException(ErrorMessages.AssociationAlreadyExists);
                }
                else
                {
                    Association associationToAdd = Association.OriginDestination(origin, destination);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, origin);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, destination);
                    context.Associations.Add(associationToAdd);
                    context.SaveChanges();
                    return associationToAdd;
                }
            }
        }

        public static void RemoveAssociation(ElementWhiteboard origin,
            ElementWhiteboard destination)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    PerformRemove(origin, destination, context);
                }
                catch (InvalidOperationException)
                {
                    throw new RepositoryException(ErrorMessages.AssociationDoesNotExist);
                }
            }
        }

        private static void PerformRemove(ElementWhiteboard origin, ElementWhiteboard destination, BoardContext context)
        {
            Association associationToRemove = context.Associations.Single(a => a.Origin.Id == origin.Id
                && a.Destination.Id == destination.Id);
            context.Associations.Remove(associationToRemove);
            context.SaveChanges();
        }
    }
}
