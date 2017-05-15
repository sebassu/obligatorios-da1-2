using Exceptions;
using System.Collections.Generic;
using System.Drawing;

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
            bool hasValidCoordinates = aPoint.X >= containerOriginX
                && aPoint.Y >= containerOriginY;
            return hasValidCoordinates && DoesNotOverflowContainerX(aPoint.X, Width)
                && DoesNotOverflowContainerY(aPoint.Y, Height);
        }

        private Size size = new Size();
        public Size Dimensions
        {
            get { return size; }
            set
            {
                if (IsValidSize(value))
                {
                    size = value;
                }
                else
                {
                    throw new ElementException(ErrorMessages.InvalidWhiteboardDimensions);
                }
            }
        }

        private bool IsValidSize(Size value)
        {
            return IsValidWidth(value.Width) &&
                IsValidHeight(value.Height);
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
                else
                {
                    throw new ElementException(ErrorMessages.WidthIsInvalid);
                }
            }
        }

        private bool IsValidWidth(int newWidth)
        {
            return newWidth >= minimumWidth &&
                 DoesNotOverflowContainerX(RelativeX, newWidth);
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
                else
                {
                    throw new ElementException(ErrorMessages.HeightIsInvalid);
                }
            }
        }

        private bool IsValidHeight(int newHeight)
        {
            return newHeight >= minimumHeight &&
                DoesNotOverflowContainerY(RelativeY, newHeight);
        }

        // Order of parameters is not critical, as its sum is commutative.
        private bool DoesNotOverflowContainerX(int elementX, int elementWidth)
        {
            return (elementX + elementWidth) <= Container.Width;
        }

        private bool DoesNotOverflowContainerY(int elementY, int elementHeight)
        {
            return (elementY + elementHeight) <= Container.Height;
        }

        public int RelativeX
        {
            get { return position.X; }
        }

        public int RelativeY
        {
            get { return position.Y; }
        }

        internal int WidthContainerNeeded()
        {
            return size.Width + RelativeX;
        }

        internal int HeightContainerNeeded()
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