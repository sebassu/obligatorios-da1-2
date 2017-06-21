using Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System;

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
                    MemberScoring scoringToAdd = MemberScoring.MemberTeam(creator.Id, teamToAdd.Id);
                    context.Scores.Add(scoringToAdd);
                    context.SaveChanges();
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
                    AttemptToAddMemberToTeam(teamToAddTo, userToAdd, context);
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        private static void AttemptToAddMemberToTeam(Team teamToAddTo, User userToAdd,
            BoardContext context)
        {
            Session.ValidateActiveUserHasAdministrationPrivileges();
            EntityFrameworkUtilities<User>.AttachIfIsValid(context, userToAdd);
            EntityFrameworkUtilities<Team>.AttachIfIsValid(context, teamToAddTo);
            context.Entry(userToAdd).Collection(u => u.AssociatedTeams).Load();
            teamToAddTo.AddMember(userToAdd);
            MemberScoring scoringToAdd = MemberScoring.MemberTeam(userToAdd.Id, teamToAddTo.Id);
            context.Scores.Add(scoringToAdd);
            context.SaveChanges();
        }

        public static void RemoveMemberFromTeam(Team teamToRemoveFrom, User userToRemove)
        {
            using (var context = new BoardContext())
            {
                try
                {
                    AttemptToRemoveMemberFromTeam(teamToRemoveFrom, userToRemove, context);
                }
                catch (DataException exception)
                {
                    throw new RepositoryException("Error en base de datos. Detalles: "
                        + exception.Message);
                }
            }
        }

        private static void AttemptToRemoveMemberFromTeam(Team teamToRemoveFrom, User
            userToRemove, BoardContext context)
        {
            try
            {
                Session.ValidateActiveUserHasAdministrationPrivileges();
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, teamToRemoveFrom);
                teamToRemoveFrom.RemoveMember(userToRemove);
                MemberScoring scoringToRemove = context.Scores.Single(s =>
                    userToRemove.Id == s.MemberId);
                context.Scores.Remove(scoringToRemove);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new RepositoryException(ErrorMessages.InvalidElementRecieved);
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