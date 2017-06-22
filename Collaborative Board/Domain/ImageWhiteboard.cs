using System;
using System.Drawing;
using System.IO;

namespace Domain
{
    public class ImageWhiteboard : ElementWhiteboard
    {
        private Image actualImage;
        public Image ActualImage
        {
            get { return actualImage; }
            set
            {
                if (Utilities.IsNotNull(value))
                {
                    actualImage = value;
                }
                else
                {
                    throw new ElementException(ErrorMessages.ImageIsNull);
                }
            }
        }

        public virtual byte[] ImageToSave
        {
            get
            {
                ImageConverter converter = new ImageConverter();
                return converter.ConvertTo(ActualImage, typeof(byte[])) as byte[];
            }
            set
            {
                var memoryStream = new MemoryStream(value);
                Image imageToSet = Image.FromStream(memoryStream);
                ActualImage = imageToSet;
            }
        }

        internal static ImageWhiteboard InstanceForTestingPurposes()
        {
            return new ImageWhiteboard()
            {
                Container = Whiteboard.InstanceForTestingPurposes()
            };
        }

        protected ImageWhiteboard() : base() { }

        public static ImageWhiteboard CreateWithContainerSource(Whiteboard container,
            string imageLocation)
        {
            return new ImageWhiteboard(container, imageLocation);
        }

        private ImageWhiteboard(Whiteboard container, string imageLocation)
            : base(container)
        {
            try
            {
                ActualImage = Image.FromFile(imageLocation);
            }
            catch (Exception)
            {
                throw new ElementException(ErrorMessages.ImageLoadingError);
            }
        }
    }
}
