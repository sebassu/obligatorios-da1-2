using System;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
    public class CommentRepository
    {
        public static List<Comment> Elements
        {
            get
            {
                using (BoardContext context = new BoardContext())
                {
                    var elements = context.Comments;
                    return elements.Include("AssociatedElement.Container").ToList();
                }
            }
        }

        public static Comment AddNewComment(ElementWhiteboard associatedElement, string text)
        {
            User creator = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<ElementWhiteboard>.AttachIfIsValid(context, associatedElement);
                if (associatedElement.CanModifyElement(creator))
                {
                    return PerformCommentAddition(associatedElement, text, creator, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.CannotCreateComment);
                }
            }
        }

        private static Comment PerformCommentAddition(ElementWhiteboard associatedElement,
            string text, User creator, BoardContext context)
        {
            creator = context.Users.Find(creator.Id);
            Comment commentToAdd = Comment.CreatorElementText(creator, associatedElement, text);
            EntityFrameworkUtilities<Comment>.Add(context, commentToAdd);
            int scoreToAdd = ScoringManagerRepository.GetScores().AddCommentScore;
            UserScoresRepository.UpdateUserScoreInTeam(associatedElement.Container.OwnerTeam.Id, scoreToAdd);
            return commentToAdd;
        }

        public static void ResolveComment(Comment commentToResolve)
        {
            User resolver = Session.ActiveUser();
            using (var context = new BoardContext())
            {
                EntityFrameworkUtilities<Comment>.AttachIfIsValid(context, commentToResolve);
                bool userCanResolveComment = commentToResolve.AssociatedElement.CanModifyElement(resolver);
                if (userCanResolveComment)
                {
                    PerformCommentResolution(commentToResolve, resolver, context);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.CannotCreateComment);
                }
            }
        }

        private static void PerformCommentResolution(Comment commentToResolve, User resolver,
            BoardContext context)
        {
            resolver = context.Users.Find(resolver.Id);
            commentToResolve.Resolve(resolver);
            int scoreToAdd = ScoringManagerRepository.GetScores().SetCommentAsSolvedScore;
            UserScoresRepository.UpdateUserScoreInTeam(commentToResolve.AssociatedWhiteboard.OwnerTeam.Id, scoreToAdd);
            context.SaveChanges();
        }
    }
}