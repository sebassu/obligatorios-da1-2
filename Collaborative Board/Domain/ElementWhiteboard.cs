using System.Drawing;
using System.Collections.Generic;

namespace Domain
{
    public abstract class ElementWhiteboard
    {
        public virtual int Id { get; set; }

        private const byte minimumWidth = 1;
        private const byte minimumHeight = 1;

        private const byte containerOriginX = 0;
        private const byte containerOriginY = 0;

        public virtual Whiteboard Container { get; set; }

        internal virtual bool CanModifyElement(User someUser)
        {
            return Container.UserCanModify(someUser);
        }

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

        public virtual int RelativeX
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public virtual int RelativeY
        {
            get { return position.Y; }
            set { position.Y = value; }
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

        public virtual int Width
        {
            get { return size.Width; }
            set { size.Width = value; }
        }

        private bool IsValidWidth(int newWidth)
        {
            return newWidth >= minimumWidth &&
                 DoesNotOverflowContainerX(RelativeX, newWidth);
        }

        public virtual int Height
        {
            get { return size.Height; }
            set { size.Height = value; }
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

        internal int WidthContainerNeeded()
        {
            return size.Width + RelativeX;
        }

        internal int HeightContainerNeeded()
        {
            return size.Height + RelativeY;
        }

        public virtual ICollection<Comment> Comments { get; set; }
            = new List<Comment>();

        public void AddComment(Comment someComment)
        {
            if (!Comments.Contains(someComment))
            {
                Comments.Add(someComment);
            }
            else
            {
                throw new CommentException(ErrorMessages.CommentAlreadyAdded);
            }
        }

        public ElementWhiteboard()
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

        public override bool Equals(object obj)
        {
            ElementWhiteboard elementToCompareAgainst = obj as ElementWhiteboard;
            if (Utilities.IsNotNull(elementToCompareAgainst))
            {
                return Id == elementToCompareAgainst.Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}