using System;
using Domain;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class ConnectionRepository
    {

        public static List<Connection> Elements(Whiteboard someWhiteboard)
        {
            using (BoardContext context = new BoardContext())
            {
                var elements = context.Connections.Include("Origin").Include("Destination")
                    .Where(a => a.Origin.Container.Id == someWhiteboard.Id && a.Destination.Container.Id == someWhiteboard.Id);
                return elements.ToList();
            }
        }

        public static Connection AddNewConnection(string name, string description, ElementWhiteboard origin,
            ElementWhiteboard destination, int direction)
        {
            using (var context = new BoardContext())
            {
                bool connectionAlreadyExists = context.Connections.Any(a => (a.Origin.Id == origin.Id
                    && a.Destination.Id == destination.Id) || (a.Destination.Id == origin.Id
                    && a.Origin.Id == destination.Id));
                if (connectionAlreadyExists)
                {
                    throw new RepositoryException(ErrorMessages.ConnectionAlreadyExists);
                }
                else
                {
                    Connection connectionToAdd = Connection.NameDescriptionOriginDestinationDirection(name,
                        description, origin, destination, direction);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, origin);
                    EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, destination);
                    context.Connections.Add(connectionToAdd);
                    context.SaveChanges();
                    return connectionToAdd;
                }
            }
        }

        public static void RemoveConnection(ElementWhiteboard origin,
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
                if (Utilities.IsNotNull(elementToRemove))
                {
                    PermformRemovalOfConnections(elementToRemove, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.InvalidElementRecieved);
                }
            }
        }

        private static void PermformRemovalOfConnections(ElementWhiteboard elementToRemove,
            BoardContext context)
        {
            var connectionsToRemove = context.Connections.Where(a => (a.Origin.Id == elementToRemove.Id)
                || (a.Origin.Id == elementToRemove.Id));
            context.Connections.RemoveRange(connectionsToRemove);
            context.SaveChanges();
        }
    }
}