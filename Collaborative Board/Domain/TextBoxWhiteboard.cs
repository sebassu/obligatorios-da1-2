using System.Drawing;

namespace Domain
{
    public class TextBoxWhiteboard : ElementWhiteboard
    {
        public virtual string TextContent { get; set; }

        public Font TextFont { get; set; }

        public virtual string FontToSave
        {
            get
            {
                FontConverter converter = new FontConverter();
                return converter.ConvertToInvariantString(TextFont);
            }
            set
            {
                FontConverter converter = new FontConverter();
                TextFont = converter.ConvertFromInvariantString(value) as Font;
            }
        }

        internal static TextBoxWhiteboard InstanceForTestingPurposes()
        {
            return new TextBoxWhiteboard();
        }

        public TextBoxWhiteboard() : base() { }

        public static TextBoxWhiteboard CreateWithContainer(Whiteboard container)
        {
            return new TextBoxWhiteboard(container);
        }

        private TextBoxWhiteboard(Whiteboard aWhiteboard) : base(aWhiteboard) { }
    }
}