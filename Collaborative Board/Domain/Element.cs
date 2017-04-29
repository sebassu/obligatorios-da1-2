using Exceptions;
using System.Windows;

namespace Domain
{
    public abstract class Element
    {
        private const int minimumWidth = 1;

        private const int minimumHeight = 1;

        protected int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (value >= minimumWidth)
                {
                    width = value;
                }
                else
                {
                    throw new ElementException("Altura de pizarrón inválida: "
                        + value + ".");
                }
            }
        }

        protected int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value >= minimumHeight)
                {
                    height = value;
                }
                else
                {
                    throw new ElementException("Altura de pizarrón inválida: "
                        + value + ".");
                }
            }
        }

        private Point origin = new Point(0, 0);

        public void SetOriginPoint(Point newOrigin)
        {
            if (IsValidOriginPoint(newOrigin))
            {
                origin = newOrigin;
            }
            else
            {
                throw new ElementException("Punto de origen inválido recibido.");
            }
        }

        private bool IsValidOriginPoint(Point aPoint)
        {
            return aPoint.X >= 0 && aPoint.Y >= 0;
        }

        public double RelativeX
        {
            get { return origin.X; }
        }

        public double RelativeY
        {
            get { return origin.Y; }
        }
    }
}
