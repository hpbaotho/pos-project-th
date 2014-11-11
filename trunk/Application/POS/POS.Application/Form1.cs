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
    public partial class Form1 : FormBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void coreButton1_Click(object sender, EventArgs e)
        {
            decimal a = 199 / int.Parse(coreTextBox1.Text);
        }
    }
}
