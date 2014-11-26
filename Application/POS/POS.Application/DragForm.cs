using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.CustomControls;
namespace POS
{
    public partial class DragForm : Form
    {


        public DragForm()
        {
            InitializeComponent();
            LoadDragItem();
        }
        private void LoadDragItem()
        {
            DragItem d1 = new DragItem(new Point(0, 0));

            DragItem d2 = new DragItem(new Point(0, 0));
            pnlDragArea.AddDragControl(d1);
            pnlDragArea.AddDragControl(d2);
        }





    }
}
