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
using System.Drawing.Drawing2D;

namespace POS.Control
{
    public class FormBase : Form
    {
        #region :: Custem delegate Event ::
        public delegate void TableClickHandler(string tableCode);
        public event TableClickHandler TableClickEvent;
        #endregion
        #region :: Property ::
        private bool _IngoreFontDefault = false;


        public bool IngoreFontDefault { get { return _IngoreFontDefault; } set { _IngoreFontDefault = value; } }
        private BaseTextBox txtProcress = null;
        private Panel Control_contanner = null;
        #endregion
        //====================================================================
        #region :: Construtor ::
        public FormBase(bool ignordDefaulstFont)
        {
            this._IngoreFontDefault = ignordDefaulstFont;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public FormBase()
        {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        #endregion

        #region :: Popup Function ::


        public delegate void ClosePopupHandler(object obj);
        public event ClosePopupHandler closePopupHandler;

        public delegate object OpenPupupHandler(object sender);
        public event OpenPupupHandler openPopupHandler;

        public object PageObjrct
        {
            get
            {
                if (openPopupHandler != null && _PageObjrct == null)
                {
                    _PageObjrct = openPopupHandler(this);
                }
                return _PageObjrct;

            }
        }
        private object _PageObjrct = null;


        protected void CloseScreen(object result)
        {
            if (closePopupHandler != null)
            {
                closePopupHandler(result);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        public void CloseScreen()
        {

            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }



        #endregion
        //====================================================================
        #region :: Message Control

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

        #endregion
        //====================================================================
        #region :: Custom Function ::

        // Public function

        public void OpernNewScreen<T>() where T : FormBase
        {

            Type type = typeof(T);
            using (FormBase form = (FormBase)Activator.CreateInstance(type))
            {
                this.Hide();
                DialogResult result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Abort)
                {
                    this.Show();
                    this.Activate();
                }
                else
                {
                    Application.Exit();
                }

            }
        }

        public void UpdateFontDefault()
        {
            this.FindControlAll(this);
        }
        // Private function
        private void FindControlAll(System.Windows.Forms.Control c)
        {
            if (!IngoreFontDefault)
            {
                foreach (System.Windows.Forms.Control item in c.Controls)
                {
                    if (item.Font.Size < DefaultFontControl.FontSize)
                    {
                        item.Font = new Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, (FontStyle)DefaultFontControl.FontStyle);
                    }
                    this.FindControlAll(item);

                }
            }
        }
        protected void BindConfigScreen(string screenCode, BaseTextBox txt)
        {
            if (this.Control_contanner != null && !string.IsNullOrEmpty(screenCode))
            {
                this.BindConfigScreen(this.Control_contanner, screenCode, txt);
            }
        }
        protected void BindConfigScreen(Panel contanner, string screenCode, BaseTextBox txt)
        {
            Control_contanner = contanner;
            Control_contanner.Controls.Clear();
            ScreenConfig mainScreen = ServiceProvider.ScreenConfigService.getScreenByCode(screenCode);
            txtProcress = txt;
            if (mainScreen != null)
            {
                Control_contanner.Width = mainScreen.control_width;
                Control_contanner.Height = mainScreen.control_height;

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
                            btn.Text = item.display_text;
                            btn.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);

                            if (item.control_command_group == CommandGroup.OpenNextScreen)
                            {
                                btn.CommandArg = item.control_command;
                                btn.Click += new EventHandler(btn_NextScreen);
                            }
                            else
                            {
                                btn.Click += new EventHandler(btn_Click);
                            }
                            Control_contanner.Controls.Add(btn);
                            break;
                        case ControlType.Table:
                            Button btnTable = new Button();
                            btnTable.Location = new System.Drawing.Point(0, 0);
                            btnTable.Left = item.position_left;
                            btnTable.Top = item.position_top;
                            btnTable.Width = item.control_width;
                            btnTable.Height = item.control_height;
                            btnTable.Text = item.display_text;
                            btnTable.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);
                            btnTable.BackColor = Color.FromArgb(item.background_color);
                            btnTable.Tag = item.control_command;
                            btnTable.Click += new EventHandler(btn_TableClick);
                            btnTable.FlatStyle = FlatStyle.Popup;
                            Control_contanner.Controls.Add(btnTable);
                            break;
                        default:
                            Panel pnlObj = new Panel();
                            pnlObj.Location = new System.Drawing.Point(0, 0);
                            pnlObj.Left = item.position_left;
                            pnlObj.Top = item.position_top;
                            pnlObj.Width = item.control_width;
                            pnlObj.Height = item.control_height;
                            pnlObj.Text = item.display_text;
                            pnlObj.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);
                            pnlObj.BackColor = Color.FromArgb(item.background_color);
                            Control_contanner.Controls.Add(pnlObj);
                            break;
                    }
                }

            }
        }
        private void sendKey(string key, object sender)
        {
            //BaseButton btn = sender as BaseButton;
            //btn.Invoke((MethodInvoker)(() => btn.ColorTable = Colortable.Office2010Red));
            if (key.ToUpper() == "C")
            {
                key = "{BACKSPACE}";
            }
            else if (key.ToUpper() == "OK")
            {
                key = "{ENTER}";
            }

            System.Windows.Forms.SendKeys.SendWait(key);
            // btn.Invoke((MethodInvoker)(() => btn.ColorTable = Colortable.Office2010White));

        }
        #endregion
        //====================================================================
        #region :: Custom Events ::
        protected void btn_TableClick(object sender, EventArgs e)
        {
            if (TableClickEvent != null)
            {
                TableClickEvent(((Button)sender).Tag.ToString());
            }
        }

        protected void btn_NextScreen(object sender, EventArgs e)
        {
            BaseButton btn = sender as BaseButton;
            this.BindConfigScreen(btn.CommandArg, null);

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            BaseButton btn = sender as BaseButton;
            if (btn.Text.ToUpper() == "EXIT")
            {
                Application.Exit();
            }
            else
            {
                if (txtProcress != null)
                {
                    txtProcress.Focus();
                    Thread t1 = new Thread(() => sendKey(btn.Text, sender));
                    t1.Start();

                }
            }

        }

        #endregion
        //====================================================================
        #region :: Override Method ::
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(286, 262);
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
        protected override void OnValidated(EventArgs e)
        {

            base.Refresh();
            base.OnValidated(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(30, 87, 153);
            Color color2 = Color.FromArgb(125, 185, 232);
            base.OnPaint(e);
            //using (var brush = new LinearGradientBrush
            //  (DisplayRectangle, color1, Color.DarkGray, LinearGradientMode.Vertical))
            //{
            //    e.Graphics.FillRectangle(brush, DisplayRectangle);
            //}
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Force repainting on resize
        }

        #endregion

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
    public class PopupBase : FormBase
    {
        public object popupDataSource = null;
        public PopupBase()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;

        }


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
