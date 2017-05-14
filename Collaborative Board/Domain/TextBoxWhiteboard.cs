using System.Drawing;

namespace Domain
{
    public class TextBoxWhiteboard : ElementWhiteboard
    {
        public string TextContent { get; set; }

        public Font TextFont { get; set; }

        internal static TextBoxWhiteboard InstanceForTestingPurposes()
        {
            return new TextBoxWhiteboard();
        }

        private TextBoxWhiteboard() : base() { }

        public static TextBoxWhiteboard CreateWithContainer(Whiteboard container)
        {
            return new TextBoxWhiteboard(container);
        }

        private TextBoxWhiteboard(Whiteboard aWhiteboard) : base(aWhiteboard) { }
    }
}