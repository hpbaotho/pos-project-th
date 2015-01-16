using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;

namespace POS.SO
{
    public partial class PopupDiverControl : PopupBase
    {
        public PopupDiverControl()
        {
            InitializeComponent();
        }

        private void btnScreenConfig_Click(object sender, EventArgs e)
        {
            this.ClosePopup(typeof(SO.SceenSetup));
        }
    }
}
