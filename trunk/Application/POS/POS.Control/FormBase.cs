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
using System.Drawing.Imaging;

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


        protected object popupDataSource = null;
        protected object popupResult = null;
        #endregion
        //====================================================================
        #region :: Construtor ::
        public FormBase(bool ignordDefaulstFont)
        {
            this._IngoreFontDefault = ignordDefaulstFont;
            this.InintControlForm();
        }

        public FormBase()
        {
            this.InintControlForm();
        }
        private void InintControlForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;





        }
        private Image PrintInvisibleControl()
        {

            Graphics g = this.CreateGraphics();
            //new bitmap object to save the image        
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            //Drawing control to the bitmap        
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

            return bmp;
        }
        private Image TakeSnapshot(bool isBlur)
        {
            Graphics g = this.CreateGraphics();
            //new bitmap object to save the image        
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            //Drawing control to the bitmap     
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            this.DrawToBitmap(bmp, rec);
            if (isBlur)
                bmp = this.MakeGrayscale3(bmp);
            return bmp;
        }

        //private void Blur()
        //{
        //    this.UnBlur();
        //    PictureBox pb = new PictureBox();
        //    pb.Location = new Point(0, 0);
        //    pb.Name = "pbBlueForm";

        //    pb.Visible = true;
        //    pb.Dock = DockStyle.Fill;
        //    pb.BackgroundImage = TakeSnapshot(true);

        //    this.Controls.Add(pb);
        //    pb.BringToFront();
        //}

        //private void UnBlur()
        //{
        //    List<System.Windows.Forms.Control> c = this.Controls.Find("pbBlueForm", true).ToList();
        //    if (c != null && c.Count > 0)
        //    {
        //        foreach (var item in c)
        //        {
        //            this.Controls.Remove(item);
        //        }

        //    }

        //}
        public Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
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
        public object OpenPopup<T>() where T : FormBase
        {
            return OpenPopup<T>(null);
        }
        public object OpenPopup<T>(object popupCriteria) where T : FormBase
        {
            //   this.Blur();
            object popupresult = null;
            Type type = typeof(T);
            using (PopupBase form = (PopupBase)Activator.CreateInstance(type))
            {
                //this.Hide();
                form.popupDataSource = popupCriteria;

                DialogResult result = form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.Cancel)
                {

                    this.Show();
                    this.Focus();
                    this.Activate();
                }
                else if (result == System.Windows.Forms.DialogResult.OK)
                {
                    popupresult = form.popupResult;
                    this.Show();
                    this.Focus();
                    this.Activate();
                }
                else
                {
                    Application.Exit();
                }

            }
            //   this.UnBlur();
            return popupresult;
        }
        public void ClosePopup(object result)
        {
            this.popupResult = result;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public void ClosePopup()
        {
            this.CloseScreen();
        }
        public object OpernNewScreen<T>() where T : FormBase
        {
            return this.OpernNewScreen<T>(null);
        }
        public object OpernNewScreen<T>(object dataSource) where T : FormBase
        {
            //  this.UnBlur();
            object resultPopup = null;
            Type type = typeof(T);
            using (FormBase form = (FormBase)Activator.CreateInstance(type))
            {
                this.Hide();
                form.popupDataSource = dataSource;
                DialogResult result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.Cancel || result == System.Windows.Forms.DialogResult.OK)
                {
                    resultPopup = form.popupResult;
                    this.Show();
                    this.Focus();
                    this.Activate();
                }
                else
                {
                    Application.Exit();
                }

            }
            return resultPopup;
        }
        public void OpernNewScreen(Type type)
        {
            if (type == null) return;
            //   this.UnBlur();
            using (FormBase form = (FormBase)Activator.CreateInstance(type))
            {
                this.Hide();
                DialogResult result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel || result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Show();
                    this.Focus();
                    this.Activate();
                }
                else
                {
                    Application.Exit();
                }

            }
        }
        public void CloseScreen()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
                    if (item.Font.Size < DefaultFontControl.FontSizeM)
                    {
                        item.Font = new Font(DefaultFontControl.FontName, DefaultFontControl.FontSizeM, (FontStyle)DefaultFontControl.FontStyle);
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
            this.BindConfigScreen(contanner, screenCode, txt, false);
        }
        protected void BindConfigScreen(Panel contanner, string screenCode, BaseTextBox txt, bool isFullScreen)
        {
            Control_contanner = contanner;
            Control_contanner.Controls.Clear();
            ScreenConfig mainScreen = ServiceProvider.ScreenConfigService.getScreenByCode(screenCode);
            txtProcress = txt;
            if (mainScreen != null)
            {
                if (!isFullScreen)
                {
                    Control_contanner.Width = mainScreen.control_width;
                    Control_contanner.Height = mainScreen.control_height;
                }
                else
                {
                    Control_contanner.Dock = DockStyle.Fill;
                }
                contanner.BackColor = Color.FromArgb(mainScreen.background_color);
                if (mainScreen.image != null && mainScreen.image.Length > 0)
                {
                    contanner.BackgroundImage = Converts.ParseImage(mainScreen.image);
                    // contanner.BackgroundImageLayout = ImageLayout.Zoom;
                }
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
                            SOTable tableDB = ServiceProvider.SOTableService.GetTaleByCode(item.control_command);
                            if (tableDB != null && tableDB.active)
                            {
                                BasePanel PnlTable = new BasePanel();
                                PictureBox tableImage = new PictureBox();
                                PnlTable.DataObject = item;
                                Label labTableName = new Label();

                                if (item.image != null && item.image.Length > 0)
                                {
                                    tableImage.BackgroundImage = Converts.ParseImage(item.image);
                                    tableImage.BackgroundImageLayout = ImageLayout.Zoom;
                                    tableImage.Dock = DockStyle.Fill;

                                }
                                labTableName.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);
                                PnlTable.Location = new System.Drawing.Point(0, 0);
                                PnlTable.Left = item.position_left;
                                PnlTable.Top = item.position_top;
                                PnlTable.Width = item.control_width;
                                PnlTable.Height = item.control_height;
                                PnlTable.Text = item.display_text;
                                labTableName.Text = item.display_text;
                                //labTableName.Anchor = ((AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top));
                                labTableName.AutoSize = false;
                                labTableName.Dock = DockStyle.Fill;
                                labTableName.TextAlign = ContentAlignment.MiddleCenter;
                                PnlTable.Font = Core.Standards.Converters.Converts.ConvertStringToFont(item.font);
                                PnlTable.BackColor = Color.FromArgb(item.background_color);
                                labTableName.BackColor = Color.Transparent;
                                labTableName.Click += new EventHandler(btn_TableClick);

                                PnlTable.Controls.Add(tableImage);
                                labTableName.Location = new Point(0, 0);
                                labTableName.Parent = tableImage;

                                Control_contanner.Controls.Add(PnlTable);
                            }
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
                Label labTable = sender as Label;
                PictureBox pb = ((PictureBox)labTable.Parent);
                if (pb != null)
                {
                    BasePanel panel = ((BasePanel)pb.Parent);
                    ScreenConfig panelConfig = panel.DataObject as ScreenConfig;

                    TableClickEvent(panelConfig.control_command);
                }
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

        public PopupBase()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.BackColor = Color.FromArgb(255, 255, 128);
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
