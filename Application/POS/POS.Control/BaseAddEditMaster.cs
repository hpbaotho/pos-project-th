using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Standards.Exceptions;

namespace POS.Control
{
    public partial class BaseAddEditMaster : BaseUserControl
    {
        protected ObjectState FormMode { get; set; }
        protected string FormKeyCode { get; set; }

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
            try
            {
                if (saveHandler != null)
                {
                    saveHandler();
                    base.onNotifyReturnEvent(ControlMode.Save);
                }
            }
            catch (ValidationException ex)
            {
                formBase.ShowErrorMessage(ex);
            }
            catch (Exception ex)
            {
                formBase.ShowErrorMessage(ex.Message);
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

        public bool btnSaveEnable { get { return btnSave.Enabled; } set { btnSave.Enabled = value; } }
        public bool btnResetEnable { get { return btnReset.Enabled; } set { btnReset.Enabled = value; } }
        public bool btnBackEnable { get { return btnBack.Enabled; } set { btnBack.Enabled = value; } }

        public bool btnSaveVisible { get { return btnSave.Visible; } set { btnSave.Visible = value; } }
        public bool btnResetVisible { get { return btnReset.Visible; } set { btnReset.Visible = value; } }
        public bool btnBackVisible { get { return btnBack.Visible; } set { btnBack.Visible = value; } }
    }
}
