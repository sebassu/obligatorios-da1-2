using System;
using System.Drawing;
using System.IO;

namespace Domain
{
    public class ImageWhiteboard : ElementWhiteboard
    {
        public Image ActualImage { get; set; }

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
            return new ImageWhiteboard();
        }

        public ImageWhiteboard() : base() { }

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
