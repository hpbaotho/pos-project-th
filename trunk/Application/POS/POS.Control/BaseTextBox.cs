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
    public partial class BaseTextBox : TextBox
    {
        public BaseTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public void procressKey(KeyPressEventArgs e)
        {
            
            base.OnKeyPress(e);
        }
    }
}
