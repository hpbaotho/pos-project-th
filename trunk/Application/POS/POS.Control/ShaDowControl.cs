using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace POS.Control
{
    public class ShaDowControl : System.Windows.Forms.Form
    {
        private static ShaDowControl shaDow = null;

        // Constructor
        private ShaDowControl()
        {
            // Set some properties to make this form a transparent black rectangle
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.Black;
            this.Opacity = 0.4;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        // Show
        static public void Show(Point location, Size size)
        {
            // Create a new object?
            if (shaDow == null)
            {
                shaDow = new ShaDowControl();
                shaDow.Show(); // Just to get the size correct at first use (.NET bug?). Try to remove this line...
            }
            // Set the location and size, then show the form
            shaDow.Location = location;
            shaDow.Size = size;
            shaDow.Show();
          
        }

   

        // Set Color
        new static public void SetBackColor(Color c)
        {
            if (shaDow != null) {
                (shaDow as System.Windows.Forms.Control).BackColor = c;
            }
        }
        // Hide
        new static public void Hide()
        {
            if (shaDow != null)
            {
                // Since we hide the original Hide() method we need to do this...
                (shaDow as System.Windows.Forms.Control).Hide();
            }
        }

        // Resize
        new static public void Resize(Size size)
        {
            if (shaDow != null)
            {
                (shaDow as System.Windows.Forms.Control).Size = size;
            }
        }

        // Move
        new static public void Move(Point point)
        {
            if (shaDow != null)
            {
                (shaDow as System.Windows.Forms.Control).Location = point;
            }
        }
    }
}
