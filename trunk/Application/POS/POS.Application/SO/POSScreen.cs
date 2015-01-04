using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;

namespace POS.SO
{
    public partial class POSScreen : Control.FormBase
    {
        public POSScreen()
        {
            InitializeComponent();
            base.BindConfigScreen(pnlTableView, ControlCode.POS, null);
            this.TableClickEvent += new TableClickHandler(POSScreen_TableClickEvent);
        }

        protected void POSScreen_TableClickEvent(string tableCode)
        {
            base.OpernNewScreen<OpenOrder>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }
    }
}
