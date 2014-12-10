using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using Core.Standards.Exceptions;
using Core.Standards.Validations;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.BL;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using POS.Control.BaseMessageBox;

namespace POS.Control
{
    public class FormBase : Form
    {
        private BaseTextBox txtProcress = null;

        public void ShowMessage(string message)
        {
            UtilityMessage.Alert(message, GeneralMessage.MessageBoxTitle);
        }
        public void ShowErrorMessage(string message)
        {
            UtilityMessage.ErrorMessage(message, GeneralMessage.MessageBoxTitle);
        }
        public void ShowErrorMessage(ValidationException error)
        {
            string template = "Please see error[s] as detail" + Environment.NewLine;

            foreach (ValidationError message in error.Errors)
            {
                template += "  - " + message.ErrorMessage + Environment.NewLine;
            }
            UtilityMessage.ErrorMessage(template, GeneralMessage.MessageBoxTitle);

        }
        public bool ShowConfirmMessage(string message, string title)
        {
            return UtilityMessage.Confirm(message, title);
        }
        protected void BindConfigScreen(Panel contanner, string screenCode, BaseTextBox txt)
        {
            ScreenConfig mainScreen = ServiceProvider.ScreenConfigService.getScreenByCode(screenCode);
            txtProcress = txt;
            if (mainScreen != null)
            {
                contanner.Width = mainScreen.control_width;
                contanner.Height = mainScreen.control_height;

                List<ScreenConfig> dragItem = new List<ScreenConfig>();
                dragItem = ServiceProvider.ScreenConfigService.getChildScreenByParent(mainScreen.control_id);

                foreach (ScreenConfig item in dragItem)
                {

                    switch (item.control_type)
                    {
                        case ControlType.Button:
                            BaseButton btn = new BaseButton();
                            btn.Location = new System.Drawing.Point(0, 0);
                            btn.Left = item.position_left;
                            btn.Top = item.position_top;
                            btn.Width = item.control_width;
                            btn.Height = item.control_height;
                            btn.Text = item.text;
                            btn.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);
                            btn.Click += new EventHandler(btn_Click);
                            contanner.Controls.Add(btn);
                            break;
                        default:
                            break;
                    }
                }

            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            BaseButton btn = sender as BaseButton;
            if (txtProcress != null)
            {
                txtProcress.Focus();
                Thread t1 = new Thread(() => sendKey(btn.Text));
                t1.Start();

            }

        }
        public void sendKey(string key)
        {
            if (key == "C")
            {
                key = "{BACKSPACE}";
            }
            else if (key == "OK")
            {
                key = "{ENTER}";
            }
            System.Windows.Forms.SendKeys.SendWait(key);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
        private void FindControlAll(System.Windows.Forms.Control c)
        {
            foreach (System.Windows.Forms.Control item in c.Controls)
            {
                item.Font = new Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, (FontStyle)DefaultFontControl.FontStyle);
                FindControlAll(item);
            }
        }
       
        protected override void OnValidated(EventArgs e)
        {
            FindControlAll(this);
            base.Refresh();
            base.OnValidated(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            FindControlAll(this);
            base.OnPaint(e);
        }
        /*
            * Key  | Code
            -----------
            SHIFT  +
            CTRL   ^
            ALT    %
         ==================================
             Key  | Code
            -----------
            BACKSPACE   {BACKSPACE}, {BS}, or {BKSP}
            BREAK   {BREAK}
            CAPS LOCK   {CAPSLOCK}
            DEL or DELETE   {DELETE} or {DEL}
            DOWN ARROW  {DOWN}
            END {END}
            ENTER   {ENTER}or ~
            ESC {ESC}
            HELP    {HELP}
            HOME    {HOME}
            INS or INSERT   {INSERT} or {INS}
            LEFT ARROW  {LEFT}
            NUM LOCK    {NUMLOCK}
            PAGE DOWN   {PGDN}
            PAGE UP {PGUP}
            RIGHT ARROW {RIGHT}
            SCROLL LOCK {SCROLLLOCK}
            TAB {TAB}
            UP ARROW    {UP}
            F1  {F1}
            F2  {F2}
            F3  {F3}
            F4  {F4}
            F5  {F5}
            F6  {F6}
            F7  {F7}
            F8  {F8}
            F9  {F9}
            F10 {F10}
            F11 {F11}
            F12 {F12}
            F13 {F13}
            F14 {F14}
            F15 {F15}
            F16 {F16}
            Keypad add  {ADD}
            Keypad subtract {SUBTRACT}
            Keypad multiply {MULTIPLY}
            Keypad divide   {DIVIDE}
         */

    }
    public enum ControlMode
    {
        Add,
        Edit,
        Delete,
        Save,
        Back
    }
 
}
