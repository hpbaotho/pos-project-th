using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Control
{
    public partial class ResizeBox : System.Windows.Forms.UserControl
    {

        private Point startPoint;
        public Point MouseDownStartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        public DragHandleAnchor PositionAnchor;
        public DragItem dragActive { get; set; }
        public ResizeBox(DragHandleAnchor positionAnchor, System.Windows.Forms.Control parent)
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
            if (mouseEventArgs.Button == MouseButtons.Left) {
                startPoint = mouseEventArgs.Location;
                this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove);
                this.MouseMove += new MouseEventHandler(ResizeBox_MouseMove);
            }
            
           
            base.OnMouseDown(mouseEventArgs);
        }
        protected override void OnMouseUp(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {

                this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove);
                this.dragActive.Refresh();
            }

            base.OnMouseUp(mouseEventArgs);
        }
        protected void ResizeBox_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left) { this.MouseMove -= new MouseEventHandler(ResizeBox_MouseMove); return; }

            DragContainer dragContainer = Parent as DragContainer;
            if (dragContainer == null) return;

            if (this.Visible && this.dragActive != null)
            {

                int orgLeft = this.Left;
                int orgTop = this.Top;
                int moveLeft = mouseEventArgs.X + orgLeft - startPoint.X;
                int moveTop = mouseEventArgs.Y + orgTop - startPoint.Y;
                int newDragW = 0;
                int newDragH = 0;
                int newDragL = 0;
                int newDragT = 0;

                int maxDragW = this.dragActive.Parent.Width - this.dragActive.Left;
                int maxDragH = this.dragActive.Parent.Height - this.dragActive.Top;

                switch (PositionAnchor)
                {

                    case DragHandleAnchor.TopLeft:
                        newDragW = this.dragActive.Width + (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            newDragL = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                            if (newDragL > 0)
                            {
                                this.dragActive.Left = newDragL;
                                this.dragActive.Width = newDragW;
                            }
                            else
                            {
                                this.dragActive.Left = 0;
                            }
                        }

                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            newDragT = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                            if (newDragT > 0)
                            {
                                this.dragActive.Height = newDragH;
                                this.dragActive.Top = newDragT;
                            }
                            else
                            {
                                this.dragActive.Top = 0;
                            }
                        }
                        break;
                    case DragHandleAnchor.TopCenter:
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        if (newDragH > this.Height)
                        {
                            this.Top = moveTop;
                            newDragT = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                            if (newDragT > 0)
                            {
                                this.dragActive.Height = newDragH;
                                this.dragActive.Top = newDragT;
                            }
                            else
                            {
                                this.dragActive.Top = 0;
                            }
                        }
                        break;
                    case DragHandleAnchor.TopRight:
                        newDragW = this.dragActive.Width - (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);

                        newDragT = mouseEventArgs.Y + this.dragActive.Top - startPoint.Y;
                        if (newDragW > this.Width)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                        }

                        if (newDragH > this.Height && newDragT > 0)
                        {
                            this.Top = moveTop;
                            this.dragActive.Height = newDragH;
                            this.dragActive.Top = newDragT;
                        }
                        else if (newDragT <= 0)
                        {
                            this.dragActive.Top = 0;
                        }
                        break;
                    case DragHandleAnchor.MiddleLeft:

                        newDragW = this.dragActive.Width + (orgLeft - moveLeft);
                        newDragH = this.dragActive.Height + (orgTop - moveTop);
                        newDragL = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                        if (newDragW > this.Width && newDragL > 0)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                            this.dragActive.Left = newDragL;
                        }
                        else if (newDragL <= 0)
                        {
                            this.dragActive.Left = 0;
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
                        newDragL = mouseEventArgs.X + this.dragActive.Left - startPoint.X;
                        if (newDragW > this.Width && newDragL > 0)
                        {
                            this.Left = moveLeft;
                            this.dragActive.Width = newDragW;
                            this.dragActive.Left = newDragL;
                        }
                        else if (newDragL <= 0)
                        {
                            this.dragActive.Left = 0;
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
                if (this.dragActive.Width > maxDragW)
                {
                    this.dragActive.Width = maxDragW;
                }
                if (this.dragActive.Height > maxDragH)
                {
                    this.dragActive.Height = maxDragH;
                }

                int maxLeft = this.dragActive.Left + this.dragActive.Width;
                int maxTop = this.dragActive.Top + this.dragActive.Height;

                int minLeft = this.dragActive.Left - this.Width;
                int minTop = this.dragActive.Top - this.Height;

                if (this.Left > maxLeft)
                {
                    this.Left = maxLeft;
                }
                else if (this.Left <= minLeft) {
                    this.Left = minLeft;
                }

                if (this.Top > maxTop)
                {
                    this.Top = maxTop;
                }
                else if (this.Top <= minTop) {
                    this.Top = minTop;
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
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
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
