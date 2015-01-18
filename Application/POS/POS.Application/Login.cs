using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using POS.BL;

namespace POS
{
    public partial class Login : Control.FormBase
    {
        public Login(bool ignoreFontStyle)
        {
            base.IngoreFontDefault = ignoreFontStyle;
            InitializeComponent();
            base.BindConfigScreen(pnlSetup, ControlCode.Login, txtPassword);
            txtPassword.Focus();
        }




        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserAccount.SignIn(string.Empty);
                txtPassword.Text = string.Empty;
                base.OpernNewScreen<SO.SaleProtal>();
               
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        


    }
}
