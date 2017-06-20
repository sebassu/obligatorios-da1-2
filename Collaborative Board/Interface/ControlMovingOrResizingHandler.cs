using Domain;
using Persistence;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicInterface
{

    /**
    * Code adapted from http://stackoverflow.com/questions/2308987/resizing-controls-at-runtime
    */
    internal static class ControlMovingOrResizingHandler
    {
        private const int edgePrecision = 20;
        private static readonly Cursor[] leftCursors = { Cursors.SizeNWSE, Cursors.SizeNESW,
            Cursors.SizeWE };
        private static readonly Cursor[] rightCursors = { Cursors.SizeNESW, Cursors.SizeNWSE,
            Cursors.SizeWE };

        private static Point cursorStartPoint;
        private static Point controlInitialLocation;
        private static Size controlInitialSize;

        private static bool isMoving;
        private static bool isResizing;
        private static bool moveIsInternal;

        private static bool MouseIsInLeftEdge { get; set; }
        private static bool MouseIsInRightEdge { get; set; }
        private static bool MouseIsInTopEdge { get; set; }
        private static bool MouseIsInBottomEdge { get; set; }

        internal static void MakeDragAndDroppable(Control interfaceObject)
        {
            cursorStartPoint = Point.Empty;
            interfaceObject.MouseDown += new MouseEventHandler(StartMovingOrResizing);
            interfaceObject.MouseMove += new MouseEventHandler(MoveControl);
            interfaceObject.MouseUp += new MouseEventHandler(StopDragOrResizing);
        }

        private static void UpdateMouseCursor(Control interfaceObject)
        {
            if (MouseIsInLeftEdge)
            {
                GetCorrespondingVerticalOrientationForCursor(interfaceObject, leftCursors);
            }
            else if (MouseIsInRightEdge)
            {
                GetCorrespondingVerticalOrientationForCursor(interfaceObject, rightCursors);
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                interfaceObject.Cursor = Cursors.SizeNS;
            }
            else
            {
                interfaceObject.Cursor = GetCorrespondingDefaultCursor(interfaceObject);
            }
        }

        private static void GetCorrespondingVerticalOrientationForCursor(Control interfaceObject,
            Cursor[] cursorsToSet)
        {
            if (MouseIsInTopEdge)
            {
                interfaceObject.Cursor = cursorsToSet[0];
            }
            else if (MouseIsInBottomEdge)
            {
                interfaceObject.Cursor = cursorsToSet[1];
            }
            else
            {
                interfaceObject.Cursor = cursorsToSet[2];
            }
        }

        private static Cursor GetCorrespondingDefaultCursor(Control interfaceObject)
        {
            if (interfaceObject is RichTextBox)
            {
                return Cursors.IBeam;
            }
            else
            {
                return Cursors.Default;
            }
        }

        private static void StartMovingOrResizing(object sender, MouseEventArgs e)
        {
            Control interfaceObject = sender as Control;
            bool mouseDownRequiresAnAction = !isMoving && !isResizing;
            if (mouseDownRequiresAnAction)
            {
                DetermineWhetherUserWantsToResizeOrMoveObject(interfaceObject);
                UpdateStartConditions(e, interfaceObject);
                interfaceObject.Capture = true;
            }
        }

        private static void DetermineWhetherUserWantsToResizeOrMoveObject(Control interfaceObject)
        {
            bool mouseIsInSomeEdge = MouseIsInRightEdge || MouseIsInLeftEdge ||
                MouseIsInTopEdge || MouseIsInBottomEdge;
            if (mouseIsInSomeEdge)
            {
                isResizing = true;
            }
            else
            {
                isMoving = true;
                interfaceObject.Cursor = Cursors.Hand;
            }
        }

        private static void UpdateStartConditions(MouseEventArgs e, Control interfaceObject)
        {
            cursorStartPoint = e.Location;
            controlInitialSize = interfaceObject.Size;
            controlInitialLocation = interfaceObject.Location;
        }

        private static void MoveControl(object sender, MouseEventArgs e)
        {
            Control interfaceObject = sender as Control;
            if (!isResizing && !isMoving)
            {
                UpdateMouseEdgeProperties(interfaceObject, e.Location);
                UpdateMouseCursor(interfaceObject);
            }
            if (isResizing)
            {
                PerformResizing(interfaceObject, e);
            }
            else if (isMoving)
            {
                moveIsInternal = !moveIsInternal;
                if (!moveIsInternal)
                {
                    int x = (e.X - cursorStartPoint.X) + interfaceObject.Left;
                    int y = (e.Y - cursorStartPoint.Y) + interfaceObject.Top;
                    interfaceObject.Location = new Point(x, y);
                }
            }
        }

        private static void PerformResizing(Control interfaceObject, MouseEventArgs e)
        {
            if (MouseIsInLeftEdge)
            {
                interfaceObject.Width -= (e.X - cursorStartPoint.X);
                interfaceObject.Left += (e.X - cursorStartPoint.X);
                PerformCornerResizing(interfaceObject, e);
            }
            else if (MouseIsInRightEdge)
            {
                interfaceObject.Width = (e.X - cursorStartPoint.X) + controlInitialSize.Width;
                PerformCornerResizing(interfaceObject, e);
            }
            else if (MouseIsInTopEdge)
            {
                TopResizing(interfaceObject, e);
            }
            else if (MouseIsInBottomEdge)
            {
                BottomResizing(interfaceObject, e);
            }
        }

        private static void PerformCornerResizing(Control interfaceObject, MouseEventArgs e)
        {
            if (MouseIsInTopEdge)
            {
                TopResizing(interfaceObject, e);
            }
            else if (MouseIsInBottomEdge)
            {
                BottomResizing(interfaceObject, e);
            }
        }

        private static void BottomResizing(Control interfaceObject, MouseEventArgs e)
        {
            interfaceObject.Height = (e.Y - cursorStartPoint.Y) + controlInitialSize.Height;
        }

        private static void TopResizing(Control interfaceObject, MouseEventArgs e)
        {
            interfaceObject.Height -= (e.Y - cursorStartPoint.Y);
            interfaceObject.Top += (e.Y - cursorStartPoint.Y);
        }

        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= edgePrecision;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= edgePrecision;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= edgePrecision;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= edgePrecision;
        }

        private static void StopDragOrResizing(object sender, MouseEventArgs e)
        {
            Control interfaceObject = sender as Control;
            ElementWhiteboard boardElement = interfaceObject.Tag as ElementWhiteboard;
            try
            {
                ElementRepository.UpdateElementPositionAndSize(boardElement, interfaceObject.Size, interfaceObject.Location);
            }
            catch (BoardException exception)
            {
                interfaceObject.Location = controlInitialLocation;
                interfaceObject.Size = controlInitialSize;
                InterfaceUtilities.ShowError(exception.Message, "Movimiento inválido");
            }
            finally
            {
                EndMovement(interfaceObject);
            }
        }

        private static void EndMovement(Control interfaceObject)
        {
            isResizing = false;
            isMoving = false;
            interfaceObject.Capture = false;
            UpdateMouseCursor(interfaceObject);
        }
    }
}