using System;
using Domain;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class ConnectionRepository
    {

        public static List<Connection> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Connections.Include("Origin").Include("Destination");
                    return elements.ToList();
                }
            }
        }

        public static Connection AddNewAssociation(string name, string description, ElementWhiteboard origin,
            ElementWhiteboard destination, int direction)
        {
            using (var context = new BoardContext())
            {
                bool associationAlreadyExists = context.Connections.Any(a => (a.Origin.Id == origin.Id
                    && a.Destination.Id == destination.Id) || (a.Destination.Id == origin.Id
                    && a.Origin.Id == destination.Id));
                if (associationAlreadyExists)
                {
                    throw new RepositoryException(ErrorMessages.ConnectionAlreadyExists);
                }
                else
                {
                    Connection associationToAdd = Connection.NameDescriptionOriginDestinationDirection(name,
                        description, origin, destination, direction);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, origin);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, destination);
                    context.Connections.Add(associationToAdd);
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
                    throw new RepositoryException(ErrorMessages.ConnectionDoesNotExist);
                }
            }
        }

        private static void PerformRemove(ElementWhiteboard origin, ElementWhiteboard destination, BoardContext context)
        {
            Connection connectionToRemove = context.Connections.Single(a => (a.Origin.Id == origin.Id
                    && a.Destination.Id == destination.Id) || (a.Destination.Id == origin.Id
                    && a.Origin.Id == destination.Id));
            context.Connections.Remove(connectionToRemove);
            context.SaveChanges();
        }

        internal static void RemoveAllConectionsWith(ElementWhiteboard elementToRemove)
        {
            using (var context = new BoardContext())
            {
                var connectionsToRemove = context.Connections.Where(a => (a.Origin.Id == elementToRemove.Id)
                    || (a.Origin.Id == elementToRemove.Id));
                context.Connections.RemoveRange(connectionsToRemove);
                context.SaveChanges();
            }
        }
    }
}