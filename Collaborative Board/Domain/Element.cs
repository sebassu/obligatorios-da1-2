using Exceptions;

namespace Domain
{
    public abstract class Element
    {
        private const int minimumWidth = 1;

        private const int minimumHeight = 1;

        protected int width;
        public int Width
        {
            get
            {
                return width;
            }
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
    }
}
