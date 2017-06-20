using System.Drawing;

namespace Domain
{
    public class TextBoxWhiteboard : ElementWhiteboard
    {
        public virtual string TextContent { get; set; }

        private Font textFont;
        public Font TextFont
        {
            get { return textFont; }
            set
            {
                if (Utilities.IsNotNull(value))
                {
                    textFont = value;
                }
                else
                {
                    throw new ElementException(ErrorMessages.FontIsNull);
                }
            }
        }

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