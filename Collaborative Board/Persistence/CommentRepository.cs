using System;
using Domain;

namespace Persistence
{
    public class CommentRepository
    {
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
            context.Entry(creator).Collection(u => u.CommentsCreated).Load();
            Comment commentToAdd = Comment.CreatorElementText(creator, associatedElement, text);
            EntityFrameworkUtilities<Comment>.Add(context, commentToAdd);
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
            context.Entry(resolver).Collection(e => e.CommentsResolved).Load();
            commentToResolve.Resolve(resolver);
            context.SaveChanges();
        }
    }
}