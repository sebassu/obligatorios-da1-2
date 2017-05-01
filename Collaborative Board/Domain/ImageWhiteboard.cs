using System;
using Exceptions;
using System.Drawing;

namespace Domain
{
    public class ImageWhiteboard : ElementWhiteboard
    {
        public Image ActualImage { get; }

        internal static ImageWhiteboard InstanceForTestingPurposes()
        {
            return new ImageWhiteboard();
        }

        private ImageWhiteboard() : base() { }

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
                throw new ElementException("Ha ocurrido un error al intentar cargar la" +
                    " imagen, verifique que la ruta que ha introducido es válida y no se " +
                    " movido o renombrado a la misma.");
            }
        }
    }
}
