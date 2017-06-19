using Domain;

namespace Persistence
{
    public static class ElementRepository
    {
        public static ImageWhiteboard AddNewImage(Whiteboard container, string fileName)
        {
            using (var context = new BoardContext())
            {
                User activeUser = Session.ActiveUser();
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, activeUser);
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, ownerTeam);
                context.Entry(ownerTeam).Collection(t => t.Members);
                if (container.UserCanModify(activeUser))
                {
                    ImageWhiteboard elementToAdd = ImageWhiteboard.CreateWithContainerSource(container,
                        fileName);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    return elementToAdd;
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }

        public static TextBoxWhiteboard AddNewTextbox(Whiteboard container)
        {
            using (var context = new BoardContext())
            {
                User activeUser = Session.ActiveUser();
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, activeUser);
                EntityFrameworkUtilities<Whiteboard>.AttachIfIsValid(context, container);
                Team ownerTeam = container.OwnerTeam;
                EntityFrameworkUtilities<Team>.AttachIfIsValid(context, ownerTeam);
                context.Entry(ownerTeam).Collection(t => t.Members);
                if (container.UserCanModify(activeUser))
                {
                    TextBoxWhiteboard elementToAdd = TextBoxWhiteboard.CreateWithContainer(container);
                    context.Elements.Add(elementToAdd);
                    context.SaveChanges();
                    return elementToAdd;
                }
                else
                {
                    throw new WhiteboardException(ErrorMessages.UserCannotModifyWhiteboard);
                }
            }
        }
    }
}
