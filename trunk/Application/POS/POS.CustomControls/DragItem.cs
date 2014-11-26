using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS.CustomControls
{
    public class DragItem : UserControl
    {
        public delegate void SelectDragItemHandler(string controlNmae);
        public event SelectDragItemHandler SelectDragEvent;

        public bool IsSelect { get; set; }
        private bool IsFirstClickDrag;
        private bool IsOutSide;
        private Point OrignalLocation;
        public DragItem(Point location)
        {
            this.InitializeComponent();
            this.Location = location;
            this.OrignalLocation = location;

        }

        protected void onSelectDragEvent(string controlName)
        {
            if (SelectDragEvent != null)
            {
                SelectDragEvent(controlName);
            }
        }
        //************************* Handle Move and Drag ******************************

        private Point startPoint;

        // Mousedown start point property; Used at drop for positioning at parent container
        public Point MouseDownStartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        // Handle key pressed; Used to perform a local move with the arrow keys
        protected override bool IsInputKey(System.Windows.Forms.Keys keys)
        {
            if (keys == Keys.Right) this.Left++;
            else if (keys == Keys.Left) this.Left--;
            else if (keys == Keys.Down) this.Top++;
            else if (keys == Keys.Up) this.Top--;
            return base.IsInputKey(keys);
        }
        // Handle mouse down; Start check for "mouse up" or "mouse leave parent container"
        protected override void OnMouseDown(MouseEventArgs mouseEventArgs)
        {
            this.onSelectDragEvent(this.Name);
            // Continue?
            if (mouseEventArgs.Button != MouseButtons.Left) return;
            // Save coordinates for later use (at "mouse up" or "drop")
            startPoint = new Point(mouseEventArgs.X, mouseEventArgs.Y);
            this.IsFirstClickDrag = true;
            // Show the outline object
            ShaDowControl.Show(this.PointToScreen(new Point(mouseEventArgs.X - startPoint.X - 1, mouseEventArgs.Y - startPoint.Y - 1)), this.Size);
            // Register the mouse move handler
            this.MouseMove -= new MouseEventHandler(DragItem_MouseMove);
            this.MouseMove += new MouseEventHandler(DragItem_MouseMove);
            base.OnMouseDown(mouseEventArgs);
        }


        // Handle mouse up; perform a local move
        protected override void OnMouseUp(MouseEventArgs mouseEventArgs)
        {


            this.Cursor = Cursors.Arrow;
            // Continue?
            if (mouseEventArgs.Button != MouseButtons.Left) return;
            // Unregister the mouse move event
            this.MouseMove -= new MouseEventHandler(DragItem_MouseMove);
            // New location
            this.Left += mouseEventArgs.X - startPoint.X;
            this.Top += mouseEventArgs.Y - startPoint.Y;
            if (!this.IsOutSide)
            {

                // Snap to parent grid?
                this.Location = (Parent as DragContainer).SnapToGrid(this.Location); // Here we might use an interface instead of casting... 
                this.OrignalLocation = this.Location;
            }
            else
            {
                this.Location = this.OrignalLocation;
            }
            // Hide the outline object
            ShaDowControl.Hide();
            this.onSelectDragEvent(this.Name);
            base.OnMouseUp(mouseEventArgs);
        }

        // Handle mouse-move; If we are out of parent container then perform global drag
        protected void DragItem_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {


            if (this.IsFirstClickDrag)
                this.Cursor = Cursors.NoMove2D;
            // Get the current mouse coordinates as screen coordinates
            Point pMin = new Point((mouseEventArgs.X - startPoint.X), (mouseEventArgs.Y - startPoint.Y));
            Point pMax = new Point(mouseEventArgs.X + this.Width, mouseEventArgs.Y + this.Height);

            Point minPoint = this.PointToScreen(pMin);

            Point maxPoint = new Point(minPoint.X + this.Width, minPoint.Y + this.Height);

            this.IsOutSide = (Parent as DragContainer).IsCursorOutside(minPoint, maxPoint);
            // Have we left the parent container?
            if (this.IsOutSide == true)
            {
                // Unregister this event
                this.MouseMove -= new MouseEventHandler(DragItem_MouseMove);
                ShaDowControl.Hide();
                // Hide the outline object
               // ShaDowControl.SetBackColor(Color.Red);

               // ShaDowControl.Move(this.PointToScreen(new Point(mouseEventArgs.X - startPoint.X, mouseEventArgs.Y - startPoint.Y)));

                // Do start the drag-drop action
                this.DoDragDrop(this, DragDropEffects.Move);
            }
            else
            {
                ShaDowControl.SetBackColor(Color.Black);
                // Move the outline object
                ShaDowControl.Move(this.PointToScreen(new Point(mouseEventArgs.X - startPoint.X, mouseEventArgs.Y - startPoint.Y)));
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DragItem
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Name = "DragItem";
            this.ResumeLayout(false);

        }


    }
}
