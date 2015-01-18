using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL;

namespace POS.SO
{
    public partial class SaleProtal : Control.FormBase
    {
        public SaleProtal()
        {
            InitializeComponent();
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            base.OpernNewScreen<SO.WorkPeriodSetup>();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            base.OpernNewScreen<SO.POSScreen>();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            base.OpernNewScreen<IN.SetupIN>();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            base.OpernNewScreen<SU.SetupMaster>();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {

        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            Type formOpenType = base.OpenPopup<SO.PopupDiverControl>() as Type;
            base.OpernNewScreen(formOpenType);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            UserAccount.SignOut();
            base.CloseScreen();
        }

       
    }
}
