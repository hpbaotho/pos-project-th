using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using POS.BL.Utilities;
using POS.BL.DTO.SO;

namespace POS.Control
{
    public partial class DragContainer : System.Windows.Forms.Panel
    {
        public delegate void SelectDragItemHandler(object sender);
        public event SelectDragItemHandler SelectDragEvent;

        private CustromControlPropertyDTO _ControlCommand;
        public CustromControlPropertyDTO ControlCommand { get { return _ControlCommand; } set { _ControlCommand = value; } }

        private bool isContainsDragItem;
        private Pen gridPen = new Pen(Color.LightGray);
        private int grid = CustomControl.GridSize; // Set this to what ever...

        public List<DragItem> DragItem;

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
            InitializeComponent();
            this.DragItem = new List<DragItem>();
            this._ControlCommand = new CustromControlPropertyDTO();
            this.AddResizeControls();
        }
        protected void onSelectDragEvent(object sender)
        {
            if (SelectDragEvent != null)
            {
                SelectDragEvent(sender);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            this.DisplayOrHideGrid(pe.Graphics, this);
            base.OnPaint(pe);
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
            control = this.CheckIsContainOtherObj(control);
            if (control != null)
            {
                string controlName = string.Format("{0}_DragItem_{1}", this.Name, this.DragItem.Count());

                control.Name = controlName;
                control.SelectDragEvent += new DragItem.SelectDragItemHandler(control_SelectDragEvent);
                this.DragItem.Add(control);
                this.Controls.Add(control);
            }
        }
        public void DuplicateDragItem()
        {
            DragItem dragItem = this.DragItem.Find(a => a.IsSelect == true && a.ControlCommand.ControlState != ObjectState.Delete);
            if (dragItem != null)
            {
                DragItem duplicate = new Control.DragItem(new Point(0, 0));
                duplicate = dragItem.CloneTo(duplicate);
                duplicate.ControlCommand.ControlState = ObjectState.Add;
                this.AddDragControl(duplicate);

            }
        }
        protected void control_SelectDragEvent(string controlNmae)
        {

            this.HideBoxResize();
            DragItem dragItem = this.DragItem.Find(a => a.Name == controlNmae && a.ControlCommand.ControlState != ObjectState.Delete);
            if (dragItem != null)
            {
                dragItem.IsSelect = true;
                this.UpdateLocationBoxResize(dragItem, DragHandleAnchor.None);
                this.onSelectDragEvent(dragItem);

            }
        }
        public void ClearDragItem()
        {

            List<DragItem> dragItem = this.DragItem.Where(a => a.ControlCommand.ControlState != ObjectState.Delete).ToList();
            if (dragItem != null && dragItem.Count > 0)
            {
                foreach (DragItem item in dragItem)
                {
                    this.Controls.Remove(item);
                }

            }

            this.DragItem = new List<DragItem>();

        }
        public void DeletCurrentItem()
        {
            DragItem dragItem = this.DragItem.Find(a => a.IsSelect == true && a.ControlCommand.ControlState != ObjectState.Delete);
            if (dragItem != null)
            {
                if (dragItem.ControlCommand.ControlState == ObjectState.Add)
                {
                    this.DragItem.Remove(dragItem);
                }
                else
                {
                    dragItem.ControlCommand.ControlState = ObjectState.Delete;
                }
                this.Controls.Remove(dragItem);
                this.HideBoxResize();
            }
        }
        public void setCurentSelectDragItemProprty(CustromControlPropertyDTO prorpty)
        {
            DragItem dragItem = this.DragItem.Find(a => a.IsSelect == true && a.ControlCommand.ControlState != ObjectState.Delete);
            if (dragItem != null)
            {
                dragItem.ControlCommand = prorpty;
            }
        }
        public CustromControlPropertyDTO getCurentSelectDragItemProprty()
        {
            DragItem dragItem = this.DragItem.Find(a => a.IsSelect == true && a.ControlCommand.ControlState != ObjectState.Delete);
            if (dragItem != null)
            {
                return dragItem.ControlCommand;
            }
            else
            {
                return null;
            }
        }
        public void HideBoxResize()
        {
            rTopLeft.UnRegisterDragActive();
            rTopCenter.UnRegisterDragActive();
            rTopRight.UnRegisterDragActive();
            rMiddleLeft.UnRegisterDragActive();
            rMiddleRight.UnRegisterDragActive();
            rBottomLeft.UnRegisterDragActive();
            rBottomRight.UnRegisterDragActive();
            rBottomCenter.UnRegisterDragActive();
            foreach (DragItem d in this.DragItem)
            {
                d.IsSelect = false;
            }
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
            foreach (DragItem d in this.DragItem.Where(a => a.ControlCommand.ControlState != ObjectState.Delete))
            {
                Point areaPoint = this.Parent.PointToScreen(new Point(d.Location.X, d.Location.Y));
                Rectangle rectangle = new Rectangle(areaPoint.X, areaPoint.Y, d.Width, d.Height);
                isContainsDragItem &= rectangle.Contains(minPoint);
            }

            base.OnMouseMove(mouseEventArgs);
        }
        protected override void OnClick(EventArgs e)
        {
            this.onSelectDragEvent(this);
            if (!isContainsDragItem)
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
            base.OnClick(e);
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
        private void DisplayOrHideGrid(Graphics gridGraphics, System.Windows.Forms.Control control)
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
        public DragItem CheckIsContainOtherObj(DragItem control)
        {
            control.CustomProperties.Top = 0;
            bool isCanPast = false;
            for (int Y = 0; Y <= this.Height; Y += grid)
            {
                control.CustomProperties.Left = 0;
                for (int X = 0; X <= this.Width; X += grid)
                {

                    #region :: Create Rectangrl Check ::
                    Rectangle rectangle1 = new Rectangle(control.CustomProperties.Left, control.CustomProperties.Top, 1, 1);
                    Rectangle rectangle2 = new Rectangle(control.CustomProperties.Left + control.Width - 1, control.CustomProperties.Top, 1, 1);
                    Rectangle rectangle3 = new Rectangle(control.CustomProperties.Left + control.Width - 1, control.CustomProperties.Top + control.Height - 1, 1, 1);
                    Rectangle rectangle4 = new Rectangle(control.CustomProperties.Left, control.CustomProperties.Top + control.Height - 1, 1, 1);
                    #endregion

                    bool isContains = false;
                    #region :: Check Contain Other obj ::

                    foreach (DragItem OtherObj in this.DragItem)
                    {

                        Rectangle recOtherObj = new Rectangle(OtherObj.CustomProperties.Left, OtherObj.CustomProperties.Top, OtherObj.Width, OtherObj.Height);
                        isContains = recOtherObj.Contains(rectangle1) || recOtherObj.Contains(rectangle2) || recOtherObj.Contains(rectangle3) || recOtherObj.Contains(rectangle4);
                        if (isContains)
                        {
                            break;
                        }

                    }
                    #endregion

                    if (!isContains && this.Width >= control.CustomProperties.Left + control.Width-1 && this.Height >= control.CustomProperties.Top + control.Height-1)
                    {
                        isCanPast = true;
                        break;
                    }

                    control.CustomProperties.Left += grid;
                }

                if (isCanPast)
                {
                    break;
                }
                control.CustomProperties.Top += grid;

            }

            #region :: Result ::

            if (isCanPast)
            {
                return control;
            }
            else
            {
                return null;
            }
            #endregion
        }


        // Is the cursor outside of the parent container?
        public bool IsCursorOutside(Point Minlocation, Point MaxLocation)
        {

            Point areaPoint = this.Parent.PointToScreen(new Point(this.Location.X, this.Location.Y));
            bool isContains = false;
            Rectangle rectangle = new Rectangle(areaPoint.X, areaPoint.Y, this.Width + 10, this.Height + 10);

            //  Point pointCheck = this.PointToScreen(location);

            isContains = rectangle.Contains(Minlocation) && rectangle.Contains(MaxLocation);


            return !isContains;
        }
    }
}
