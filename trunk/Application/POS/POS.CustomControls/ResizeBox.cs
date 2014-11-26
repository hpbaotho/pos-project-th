using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS.CustomControls
{
    public class ResizeBox : UserControl
    {
        private Point startPoint;
        public Point MouseDownStartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        public DragHandleAnchor PositionAnchor;
        public DragItem dragActive { get; set; }
        public ResizeBox(DragHandleAnchor positionAnchor, Control parent)
        {
            this.Name = string.Format("{0}_resize_{1}", parent.Name, positionAnchor.ToString());
            this.Width = 8;
            this.Height = 8;
            this.Location = new System.Drawing.Point(0, 0);
            this.BackColor = SystemColors.MenuHighlight;
            this.PositionAnchor = positionAnchor;
        }
        protected override void OnMouseDown(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left) return;

            startPoint = mouseEventArgs.Location;
            this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove);
            this.MouseMove += new MouseEventHandler(ResizeBox_MouseMove);
            base.OnMouseDown(mouseEventArgs);
        }
        protected override void OnMouseUp(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left) return;
            this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove);

            base.OnMouseUp(mouseEventArgs);
        }
        protected void ResizeBox_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left) { this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove); return; }

            DragContainer dragContainer = Parent as DragContainer;
            if (dragContainer == null) return;

            if (this.Visible && this.dragActive != null)
            {
                Point pMin = new Point((mouseEventArgs.X - startPoint.X), (mouseEventArgs.Y - startPoint.Y));
                Point pMax = new Point(mouseEventArgs.X + this.Width, mouseEventArgs.Y + this.Height);

                Point minPoint = this.PointToScreen(pMin);

                Point maxPoint = new Point(minPoint.X + this.Width, minPoint.Y + this.Height);

                bool IsOutSide = (Parent as DragContainer).IsCursorOutside(minPoint, maxPoint);
                if (IsOutSide) return;

                int orgLeft = this.Left;
                int orgTop = this.Top;
                int moveLeft = mouseEventArgs.X + orgLeft - startPoint.X;
                int moveTop = mouseEventArgs.Y + orgTop - startPoint.Y;
                int newDragW = 0;
                int newDragH = 0;

                switch (PositionAnchor)
                {

                    case DragHandleAnchor.TopLeft:
                        newDragW = this.dragActive.Width + (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                            this.dragActive.Left = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                        }

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                            this.dragActive.Top = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                        }
                        break;
                    case DragHandleAnchor.TopCenter:
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                            this.dragActive.Top = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                        }
                        break;
                    case DragHandleAnchor.TopRight:
                        newDragW = this.dragActive.Width - (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                        }

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                            this.dragActive.Top = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                        }
                        break;
                    case DragHandleAnchor.MiddleLeft:

                        newDragW = this.dragActive.Width + (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                            this.dragActive.Left = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                        }
                      
                        break;
                    case DragHandleAnchor.MiddleRight:
                        newDragW = this.dragActive.Width - (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                        }
                        
                        break;
                    case DragHandleAnchor.BottomLeft:
                        newDragW = this.dragActive.Width + (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height - (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                            this.dragActive.Left = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                        }

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                        }
                        break;
                    case DragHandleAnchor.BottomCenter:
                        newDragH = this.dragActive.Height - (orgTop - moveTop);

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                        }
                        break;
                    case DragHandleAnchor.BottomRight:
                        newDragW = this.dragActive.Width - (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height - (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                        }

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                        }
                        break;

                }
                dragContainer.UpdateLocationBoxResize(this.dragActive, this.PositionAnchor);

            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.Visible)
            {
                switch (PositionAnchor)
                {
                    case DragHandleAnchor.None:
                        break;
                    case DragHandleAnchor.TopLeft:
                        this.Cursor = Cursors.SizeNWSE;
                        break;
                    case DragHandleAnchor.TopCenter:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    case DragHandleAnchor.TopRight:
                        this.Cursor = Cursors.SizeNESW;
                        break;
                    case DragHandleAnchor.MiddleLeft:
                        this.Cursor = Cursors.SizeWE;
                        break;
                    case DragHandleAnchor.MiddleRight:
                        this.Cursor = Cursors.SizeWE;
                        break;
                    case DragHandleAnchor.BottomLeft:
                        this.Cursor = Cursors.SizeNESW;
                        break;
                    case DragHandleAnchor.BottomCenter:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    case DragHandleAnchor.BottomRight:

                        this.Cursor = Cursors.SizeNWSE;
                        break;
                    default:
                        break;
                }

            }
            base.OnMouseEnter(e);
        }
        public void UnRegisterDragActive()
        {
            this.dragActive = null;
            this.Visible = false;
        }
        public void RegisterDragActive(DragItem d, DragHandleAnchor excludePositionAnchor)
        {
            if (excludePositionAnchor != this.PositionAnchor)
                this.UpdateBoxLocation(d);
        }
        public void RegisterDragActive(DragItem d)
        {
            this.UpdateBoxLocation(d);
        }

        private void UpdateBoxLocation(DragItem d)
        {
            this.dragActive = d;

            if (this.dragActive == null) return;
            int controlW = this.dragActive.Width;
            int controlH = this.dragActive.Height;

            int controlX = this.dragActive.Location.X;
            int controlY = this.dragActive.Location.Y;

            int resizeH = this.Height;
            int resizeW = this.Width;

            this.Visible = true;

            switch (PositionAnchor)
            {
                case DragHandleAnchor.None:
                    break;
                case DragHandleAnchor.TopLeft:
                    this.Location = new System.Drawing.Point(controlX - resizeW, controlY - resizeH);
                    break;
                case DragHandleAnchor.TopCenter:
                    this.Location = new System.Drawing.Point(controlW / 2 + controlX - (resizeW / 2), controlY - resizeH);
                    break;
                case DragHandleAnchor.TopRight:
                    this.Location = new System.Drawing.Point(controlX + controlW, controlY - resizeH);
                    break;
                case DragHandleAnchor.MiddleLeft:
                    this.Location = new System.Drawing.Point(controlX - resizeW, controlY + (controlH / 2) - (resizeH / 2));
                    break;
                case DragHandleAnchor.MiddleRight:
                    this.Location = new System.Drawing.Point(controlX + controlW, controlY + (controlH / 2) - (resizeH / 2));
                    break;
                case DragHandleAnchor.BottomLeft:
                    this.Location = new System.Drawing.Point(controlX - resizeW, controlY + controlH);
                    break;
                case DragHandleAnchor.BottomCenter:
                    this.Location = new System.Drawing.Point(controlW / 2 + controlX - (resizeW / 2), controlY + controlH);
                    break;
                case DragHandleAnchor.BottomRight:
                    this.Location = new System.Drawing.Point(controlX + controlW, controlY + controlH);
                    break;
                default:
                    break;
            }
        }
    }
    public enum DragHandleAnchor
    {
        None,

        TopLeft,

        TopCenter,

        TopRight,

        MiddleLeft,

        MiddleRight,

        BottomLeft,

        BottomCenter,

        BottomRight
    }
}
