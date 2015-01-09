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
    public partial class BaseAddEditMaster : BaseUserControl
    {
        public delegate void SaveHandler();
        public event SaveHandler saveHandler;
        public delegate void ResetHandler();
        public event ResetHandler resetHandler;
        public delegate void BackHandler();
        public event BackHandler backHandler;
        public BaseAddEditMaster()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveHandler != null)
            {
                saveHandler();
                base.onNotifyReturnEvent(ControlMode.Save);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (resetHandler != null)
            {
                resetHandler();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (backHandler != null)
            {
                backHandler();
            }
            base.onNotifyReturnEvent(ControlMode.Back);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected bool btnSaveEnable { get { return btnSave.Enabled; } set { btnSave.Enabled = value; } }
        protected bool btnResetEnable { get { return btnReset.Enabled; } set { btnReset.Enabled = value; } }
        protected bool btnBackEnable { get { return btnBack.Enabled; } set { btnBack.Enabled = value; } }
    }
}
