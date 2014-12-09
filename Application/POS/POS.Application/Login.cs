using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;

namespace POS
{
    public partial class Login : Control.FormBase
    {
        public Login()
        {
          
            InitializeComponent();
            base.BindConfigScreen(pnlSetup, ControlCode.Login, textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

     
      

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                base.ShowMessage("You press OK");
                using (TestGridControl form = new TestGridControl())
                {
                    DialogResult result =  form.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                }
            }
        }


    }
}
