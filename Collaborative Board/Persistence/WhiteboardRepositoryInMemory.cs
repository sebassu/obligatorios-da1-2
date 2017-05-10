using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public class WhiteboardRepositoryInMemory : WhiteboardRepository
    {
        public override Whiteboard AddNewWhiteboard(string name, string description,
            Team ownerTeam, int width, int height)
        {
            User creator = Session.ActiveUser();
            Whiteboard whiteboardToAdd = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                name, description, ownerTeam, width, height);
            Add(whiteboardToAdd);
            return whiteboardToAdd;
        }

        internal WhiteboardRepositoryInMemory()
        {
            elements = new List<Whiteboard>();
        }
    }
}