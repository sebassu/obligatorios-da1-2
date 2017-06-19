﻿using Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public static class TeamRepository
    {
        public static List<Team> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Teams;
                    return elements.ToList();
                }
            }
        }

        public static Team AddNewTeam(string name, string description, int maximumMembers)
        {
            using (var context = new BoardContext())
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                if (ThereIsNoTeamWithName(name))
                {
                    User creator = Session.ActiveUser();
                    EntityFrameworkUtilities<User>.AttachIfIsValid(context, creator);
                    Team teamToAdd = Team.CreatorNameDescriptionMaximumMembers(creator,
                        name, description, maximumMembers);
                    EntityFrameworkUtilities<Team>.Add(context, teamToAdd);
                    return teamToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.TeamNameMustBeUnique);
                }
            }
        }

        public static void ModifyTeam(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            try
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                AttemptToSetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                    maximumMembersToSet);
            }
            catch (DataException exception)
            {
                throw new RepositoryException("Error en base de datos. Detalles: "
                    + exception.Message);
            }
        }

        private static void AttemptToSetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, teamToModify);
                if (ChangeDoesNotCauseRepeatedTeamNames(teamToModify, nameToSet))
                {
                    SetTeamAttributes(teamToModify, nameToSet, descriptionToSet,
                        maximumMembersToSet);
                    context.SaveChanges();
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.TeamNameMustBeUnique);
                }
            }
        }

        private static void SetTeamAttributes(Team teamToModify, string nameToSet,
            string descriptionToSet, int maximumMembersToSet)
        {
            teamToModify.Name = nameToSet;
            teamToModify.Description = descriptionToSet;
            teamToModify.MaximumMembers = maximumMembersToSet;
        }

        private static bool ChangeDoesNotCauseRepeatedTeamNames(Team teamToModify, string nameToSet)
        {
            bool nameDoesNotChange = teamToModify.Name == nameToSet;
            return nameDoesNotChange || ThereIsNoTeamWithName(nameToSet);
        }

        private static bool ThereIsNoTeamWithName(string nameToSet)
        {
            using (var context = new BoardContext())
            {
                return !context.Teams.Any(t => t.Name == nameToSet);
            }
        }

        public static void Remove(Team elementToRemove)
        {
            Session.ValidateActiveUserHasAdministrationPrivileges();
            if (Utilities.IsNotNull(elementToRemove))
            {
                RemoveAllTeamWhiteboardsFromRepository(elementToRemove);
                EntityFrameworkUtilities<Team>.Remove(elementToRemove);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.ElementDoesNotExist);
            }
        }

        private static void RemoveAllTeamWhiteboardsFromRepository(Team teamToRemove)
        {
            LoadCreatedWhiteboards(teamToRemove);
            var teamWhiteboards = teamToRemove.CreatedWhiteboards.ToList();
            foreach (var whiteboard in teamWhiteboards)
            {
                WhiteboardRepository.RemoveDueToTeamDeletion(whiteboard);
            }
        }

        public static void AddMemberToTeam(Team teamToAddTo, User userToAdd)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    ValidateActiveUserHasAdministrationPrivileges();
                    context.Users.Attach(userToAdd);
                    context.Entry(userToAdd).Collection(u => u.AssociatedTeams).Load();
                    context.Teams.Attach(teamToAddTo);
                    context.Entry(teamToAddTo).Collection(t => t.Members).Load();
                    teamToAddTo.AddMember(userToAdd);
                    context.SaveChanges();
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        public static void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    ValidateActiveUserHasAdministrationPrivileges();
                    context.Users.Attach(userToRemove);
                    context.Entry(userToRemove).Collection(u => u.AssociatedTeams).Load();
                    context.Teams.Attach(teamToRemoveFrom);
                    context.Entry(teamToRemoveFrom).Collection(t => t.Members).Load();
                    teamToRemoveFrom.RemoveMember(userToRemove);
                    context.SaveChanges();
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        public static void LoadMembers(Team someTeam)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, someTeam);
                context.Entry(someTeam).Collection(t => t.Members).Load();
            }
        }

        public static void LoadCreatedWhiteboards(Team someTeam)
        {
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, someTeam);
                context.Entry(someTeam).Collection(t => t.CreatedWhiteboards).Load();
            }
        }
    }
}