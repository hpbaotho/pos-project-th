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
            base.BindConfigScreen(pnlTableView, ControlCode.POS,null);
        }
    }
}
