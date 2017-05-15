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

        private Point position = new Point();
        public Point Position
        {
            get { return position; }
            set
            {
                if (IsValidOriginPoint(value))
                {
                    position = value;
                }
                else
                {
                    throw new ElementException(ErrorMessages.OriginPointIsInvalid);
                }
            }
        }

        private bool IsValidOriginPoint(Point aPoint)
        {
            bool hasValidCoordinates = aPoint.X >= containerOriginX && aPoint.Y >= containerOriginY;
            return hasValidCoordinates && DoesNotOverflowContainerX(aPoint.X, Width)
                && DoesNotOverflowContainerY(aPoint.Y, Height);
        }

        private Size size = new Size();
        public Size Size
        {
            get { return size; }
            set
            {
                if (IsValidSize(value))
                {
                    size = value;
                }
            }
        }

        private bool IsValidSize(Size value)
        {
            return Utilities.IsNotNull(value) &&
                IsValidWidth(value.Width) && IsValidHeight(value.Height);
        }

        public int Width
        {
            get { return size.Width; }
            internal set
            {
                if (IsValidWidth(value))
                {
                    size.Width = value;
                    Container.UpdateModificationDate();
                }
            }
        }

        private bool IsValidWidth(int newWidth)
        {
            bool isValid = newWidth >= minimumWidth && DoesNotOverflowContainerX(RelativeX, newWidth);
            if (isValid)
            {
                return true;
            }
            else
            {
                throw new ElementException(ErrorMessages.WidthIsInvalid);
            }
        }

        public int Height
        {
            get { return size.Height; }
            internal set
            {
                if (IsValidHeight(value))
                {
                    size.Height = value;
                    Container.UpdateModificationDate();
                }
            }
        }

        private bool IsValidHeight(int newHeight)
        {
            bool isValid = newHeight >= minimumHeight && DoesNotOverflowContainerY(RelativeY, newHeight);
            if (isValid)
            {
                return true;
            }
            else
            {
                throw new ElementException(ErrorMessages.HeightIsInvalid);
            }
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
            get { return position.X; }
        }

        public double RelativeY
        {
            get { return position.Y; }
        }

        internal double WidthContainerNeeded()
        {
            return size.Width + RelativeX;
        }

        internal double HeightContainerNeeded()
        {
            return size.Height + RelativeY;
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
            position = new Point(xForCentering, yForCentering);
            size = new Size(xForCentering, yForCentering);
        }
    }
}
