using Exceptions;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Domain
{
    public abstract class ElementWhiteboard
    {
        private const byte minimumWidth = 1;
        private const byte minimumHeight = 1;

        private const byte containerOriginX = 0;
        private const byte containerOriginY = 0;

        public Whiteboard Container { get; }

        protected int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (IsValidWidth(value))
                {
                    width = value;
                    Container.UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.WidthIsInvalid, value);
                    throw new ElementException(errorMessage);
                }
            }
        }

        private bool IsValidWidth(int newWidth)
        {
            return newWidth >= minimumWidth && DoesNotOverflowContainerX(RelativeX, newWidth);
        }

        protected int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (IsValidHeight(value))
                {
                    height = value;
                    Container.UpdateModificationDate();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.HeightIsInvalid, value);
                    throw new ElementException(errorMessage);
                }
            }
        }

        private bool IsValidHeight(int newHeight)
        {
            return newHeight >= minimumHeight && DoesNotOverflowContainerY(RelativeY, newHeight);
        }

        private Point origin;
        public void SetOriginPoint(Point newOrigin)
        {
            if (IsValidOriginPoint(newOrigin))
            {
                origin = newOrigin;
            }
            else
            {
                throw new ElementException(ErrorMessages.OriginPointIsInvalid);
            }
        }

        private bool IsValidOriginPoint(Point aPoint)
        {
            bool hasValidCoordinates = aPoint.X >= containerOriginX && aPoint.Y >= containerOriginY;
            return hasValidCoordinates && DoesNotOverflowContainerX(aPoint.X, width)
                && DoesNotOverflowContainerY(aPoint.Y, height);
        }

        // Order of parameters is not critical, as its sum is commutative.
        private bool DoesNotOverflowContainerX(double elementX, double elementWidth)
        {
            return (elementX + elementWidth) <= Container.Width;
        }

        private bool DoesNotOverflowContainerY(double elementY, double elementHeight)
        {
            return (elementY + elementHeight) <= Container.Height;
        }

        public double RelativeX
        {
            get { return origin.X; }
        }

        public double RelativeY
        {
            get { return origin.Y; }
        }

        private readonly List<Comment> comments = new List<Comment>();
        public IReadOnlyCollection<Comment> Comments => comments.AsReadOnly();

        public void AddComment(Comment someComment)
        {
            if (!comments.Contains(someComment))
            {
                comments.Add(someComment);
            }
            else
            {
                throw new CommentException(ErrorMessages.CommentAlreadyAdded);
            }
        }

        protected ElementWhiteboard()
        {
            Container = Whiteboard.InstanceForTestingPurposes();
            origin = new Point(0, 0);
        }

        protected ElementWhiteboard(Whiteboard container)
        {
            if (container != null)
            {
                Container = container;
                CenterDefaultSizedElementInWhiteboard(container.Width, container.Height);
                container.AddWhiteboardElement(this);
            }
            else
            {
                throw new ElementException(ErrorMessages.NullWhiteboard);
            }
        }

        private void CenterDefaultSizedElementInWhiteboard(int containerWidth,
            int containerHeight)
        {
            int xForCentering = containerWidth / 3;
            int yForCentering = containerHeight / 3;
            width = xForCentering;
            height = yForCentering;
            origin = new Point(xForCentering, yForCentering);
        }
    }
}
