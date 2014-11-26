using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS.CustomControls
{
    public class DragContainer : Panel
    {



        private bool isContainsDragItem;
        private Pen gridPen = new Pen(Color.LightGray);
        private int grid = 10; // Set this to what ever...
        public List<DragItem> DragItem { get; set; }

        ResizeBox rTopLeft;
        ResizeBox rTopCenter;
        ResizeBox rTopRight;
        ResizeBox rMiddleRight;
        ResizeBox rMiddleLeft;
        ResizeBox rBottomRight;
        ResizeBox rBottomCenter;
        ResizeBox rBottomLeft;
        public DragContainer()
        {
            this.DragItem = new List<DragItem>();

            this.AddResizeControls();

        }

        private void AddResizeControls()
        {
            rTopLeft = new ResizeBox(DragHandleAnchor.TopLeft, this);
            rTopCenter = new ResizeBox(DragHandleAnchor.TopCenter, this);
            rTopRight = new ResizeBox(DragHandleAnchor.TopRight, this);
            rMiddleRight = new ResizeBox(DragHandleAnchor.MiddleRight, this);
            rMiddleLeft = new ResizeBox(DragHandleAnchor.MiddleLeft, this);
            rBottomRight = new ResizeBox(DragHandleAnchor.BottomRight, this);
            rBottomCenter = new ResizeBox(DragHandleAnchor.BottomCenter, this);
            rBottomLeft = new ResizeBox(DragHandleAnchor.BottomLeft, this);

            this.Controls.Add(rTopLeft);
            this.Controls.Add(rTopCenter);
            this.Controls.Add(rTopRight);
            this.Controls.Add(rMiddleRight);
            this.Controls.Add(rMiddleLeft);
            this.Controls.Add(rBottomRight);
            this.Controls.Add(rBottomCenter);
            this.Controls.Add(rBottomLeft);
        }
        public void AddDragControl(DragItem control)
        {
            string controlName = string.Format("{0}_DragItem_{1}", this.Name, this.DragItem.Count());

            control.Name = controlName;
            control.SelectDragEvent += new CustomControls.DragItem.SelectDragItemHandler(control_SelectDragEvent);
            this.DragItem.Add(control);
            this.Controls.Add(control);
        }

        protected void control_SelectDragEvent(string controlNmae)
        {
            foreach (DragItem d in this.DragItem)
            {
                d.IsSelect = false;
                this.HideBoxResize();
            }
            DragItem dragItem = this.DragItem.Find(a => a.Name == controlNmae);
            if (dragItem != null)
            {
                dragItem.IsSelect = true;
                this.UpdateLocationBoxResize(dragItem,DragHandleAnchor.None);

            }
        }

        private void HideBoxResize()
        {
            rTopLeft.UnRegisterDragActive();
            rTopCenter.UnRegisterDragActive();
            rTopRight.UnRegisterDragActive();
            rMiddleLeft.UnRegisterDragActive();
            rMiddleRight.UnRegisterDragActive();
            rBottomLeft.UnRegisterDragActive();
            rBottomRight.UnRegisterDragActive();
            rBottomCenter.UnRegisterDragActive();
        }
        public void UpdateLocationBoxResize(DragItem dragItem, DragHandleAnchor excludePositionAnchor)
        {

            rTopLeft.RegisterDragActive(dragItem, excludePositionAnchor);
            rTopCenter.RegisterDragActive(dragItem, excludePositionAnchor);
            rTopRight.RegisterDragActive(dragItem, excludePositionAnchor);
            rMiddleLeft.RegisterDragActive(dragItem, excludePositionAnchor);
            rMiddleRight.RegisterDragActive(dragItem, excludePositionAnchor);
            rBottomLeft.RegisterDragActive(dragItem, excludePositionAnchor);
            rBottomRight.RegisterDragActive(dragItem, excludePositionAnchor);
            rBottomCenter.RegisterDragActive(dragItem, excludePositionAnchor);
        }
        protected override void OnMouseMove(MouseEventArgs mouseEventArgs)
        {
            Point pMin = new Point(mouseEventArgs.X, mouseEventArgs.Y);
            Point minPoint = this.PointToScreen(pMin);

            isContainsDragItem = true;
            foreach (DragItem d in this.DragItem)
            {
                Point areaPoint = this.Parent.PointToScreen(new Point(d.Location.X, d.Location.Y));
                Rectangle rectangle = new Rectangle(areaPoint.X, areaPoint.Y, d.Width, d.Height);
                isContainsDragItem &= rectangle.Contains(minPoint);
            }

            base.OnMouseMove(mouseEventArgs);
        }
        protected override void OnClick(EventArgs e)
        {
            if (!isContainsDragItem) {
                rTopLeft.UnRegisterDragActive();
                rTopCenter.UnRegisterDragActive();
                rTopRight.UnRegisterDragActive();
                rMiddleLeft.UnRegisterDragActive();
                rMiddleRight.UnRegisterDragActive();
                rBottomLeft.UnRegisterDragActive();
                rBottomRight.UnRegisterDragActive();
                rBottomCenter.UnRegisterDragActive();
            }
            base.OnClick(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.DisplayOrHideGrid(e.Graphics, this);
        }
        // Recalculate the coordinates to snap to grid
        // Note! Used by the MyUserControl object when positioning
        public Point SnapToGrid(Point dropPoint)
        {
            // Snap to grid
            int X_snap = (int)(Math.Round((decimal)(dropPoint.X) / grid) * grid);
            int Y_snap = (int)(Math.Round((decimal)(dropPoint.Y) / grid) * grid);
            // Check that we stay within the visible area
            if (X_snap < 0) X_snap = 0;
            if (Y_snap < 0) Y_snap = 0;
            return new Point(X_snap, Y_snap);
        }

        // Draw the grid or not
        private void DisplayOrHideGrid(Graphics gridGraphics, Control control)
        {
            Point pControl = control.PointToScreen(new Point(control.Location.X, control.Location.Y));
            // Dispose the current grid
            if (gridGraphics != null) gridGraphics.Dispose();

            gridGraphics = this.CreateGraphics();
            // Horizontal lines
            gridGraphics.DrawLine(gridPen, 0, 0, 0, control.Height);
            gridGraphics.DrawLine(gridPen, control.Width - 1, 0, control.Width - 1, control.Height);

            for (int X = grid; X < control.Width; X += grid)
            {
                gridGraphics.DrawLine(gridPen, X, 0, X, control.Height);
            }

            // Vertical lines
            gridGraphics.DrawLine(gridPen, 0, 0, control.Width, 0);
            gridGraphics.DrawLine(gridPen, 0, control.Height - 1, control.Width, control.Height - 1);

            for (int Y = grid; Y < control.Height; Y += grid)
            {
                gridGraphics.DrawLine(gridPen, 0, Y, control.Width, Y);
            }

        }
        // Is the cursor outside of the parent container?
        public bool IsCursorOutside(Point Minlocation, Point MaxLocation)
        {



            Point areaPoint = this.Parent.PointToScreen(new Point(this.Location.X, this.Location.Y));
            bool isContains = false;
            Rectangle rectangle = new Rectangle(areaPoint.X, areaPoint.Y, this.Width, this.Height);

            //  Point pointCheck = this.PointToScreen(location);

            isContains = rectangle.Contains(Minlocation) && rectangle.Contains(MaxLocation);


            return !isContains;
        }
    }
}
