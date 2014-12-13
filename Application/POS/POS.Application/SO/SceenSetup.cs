using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Entities.Entity;
using POS.BL.Utilities;
using POS.BL;
using Core.Standards.Exceptions;
using Core.Standards.Converters;

namespace POS.SO
{
    public partial class SceenSetup : POS.Control.FormBase
    {
        public SceenSetup()
        {

            InitializeComponent();
            cmdForm.DataSource = ServiceProvider.ScreenConfigService.getParentScreen();
            cmdForm.ValueMember = "control_id";
            cmdForm.DisplayMember = "control_code";
            this.LoadScreenConfig();
          
            dragContainer2.SelectDragEvent += new Control.DragContainer.SelectDragItemHandler(dragContainer2_SelectDragEvent);
        }

        protected void dragContainer2_SelectDragEvent(object sender)
        {
            Control.DragItem d = sender as Control.DragItem;
            if (d != null)
            {
                spComtrolCommand.Panel2.Enabled = true;
                propertyGrid1.SelectedObject = d.CustomProperties;
                ddlControlType.SelectedIndex = ddlControlType.FindString(d.ControlCommand.control_type);
            }
            else
            {
                spComtrolCommand.Panel2.Enabled = false;
                ddlControlType.SelectedIndex = -1;
                dragContainer2.HideBoxResize();
                propertyGrid1.SelectedObject = sender;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddDragControl();
        }
        private void btnDelete_ButtonClick(object sender, EventArgs e)
        {
            dragContainer2.DeletCurrentItem();
        }

        private void AddDragControl()
        {
            Control.DragItem d = new Control.DragItem(new Point(0, 0));
            d.ControlCommand.ControlState = ObjectState.Add;
            d.ControlCommand.control_type = ControlType.Button;
            dragContainer2.AddDragControl(d);
        }
        //For Hot Key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                dragContainer2.DeletCurrentItem();
                spComtrolCommand.Panel2.Enabled = false;
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                this.AddDragControl();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                this.SaveScreen();
            }
            else if (keyData == (Keys.Control | Keys.D))
            {
                dragContainer2.DuplicateDragItem();
               
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                this.NewScreenSetup();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void NewScreenSetup()
        {
            if (base.ShowConfirmMessage(GeneralMessage.ConfirmSaveDate, "")) {
                this.SaveScreen();
            }
            cmdForm.SelectedIndex = -1;
            spComtrolCommand.Panel2.Enabled = false;

            txtHeight.Text = "500";
            txtWidth.Text = "300";
            dragContainer2.Width = 300;
            dragContainer2.Height = 500;
            dragContainer2.ClearDragItem();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveScreen();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            dragContainer2.DuplicateDragItem();
        }
        private void SaveScreen()
        {
            try
            {

                ScreenConfig mainScreen = new ScreenConfig();
                string screenCode = (cmdForm.SelectedItem as ScreenConfig).control_code;
                if (string.IsNullOrEmpty(screenCode))
                {
                    dragContainer2.ControlCommand.control_id = null;
                    screenCode = Microsoft.VisualBasic.Interaction.InputBox("Please Input Screen Code", "Screen code", string.Empty);
                }

                List<ScreenConfig> saveControls = new List<ScreenConfig>();
                mainScreen.control_id = dragContainer2.ControlCommand.control_id;
                mainScreen.control_code = screenCode;
                mainScreen.control_type = ControlType.Form;
                mainScreen.control_width = dragContainer2.Width;
                mainScreen.control_height = dragContainer2.Height;
                foreach (Control.DragItem item in dragContainer2.DragItem.Where(a => a.ControlCommand.ControlState != ObjectState.Delete))
                {
                    ScreenConfig dragItem = new ScreenConfig();
                    dragItem.control_id = item.ControlCommand.control_id;
                    dragItem.control_parent_id = mainScreen.control_id;
                    dragItem.control_type = item.ControlCommand.control_type;
                    dragItem.border_style = (int)item.BorderStyle;
                    dragItem.display_text = item.CustomProperties.Text;
                    dragItem.control_width = item.Width;
                    dragItem.control_height = item.Height;
                    dragItem.background_color = item.BackColor.ToArgb();
                    dragItem.background_image_path = item.CustomProperties.BackGroundImage;
                    dragItem.fore_color = item.ForeColor.ToArgb();
                    dragItem.percent_height = item.PercenyHeight;
                    dragItem.percent_width = item.PercenyWidth;
                    dragItem.position_left = item.CustomProperties.Left;
                    dragItem.position_top = item.CustomProperties.Top;
                    dragItem.font = item.FontStr;
                    dragItem.ObjectState = item.ControlCommand.ControlState;
                    saveControls.Add(dragItem);
                }
                ServiceProvider.ScreenConfigService.Save(mainScreen, saveControls);
                base.ShowMessage(GeneralMessage.SaveComplete);

            }
            catch (ValidationException ex)
            {

                base.ShowErrorMessage(ex);
            }
        }

        private void cmdForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadScreenConfig();
        }

        private void LoadScreenConfig()
        {
            ScreenConfig mainScreen = new ScreenConfig();
            if (cmdForm.SelectedValue == null) return;

            spComtrolCommand.Panel2.Enabled = false;
            mainScreen.control_id = Converts.ParseLongNullable(cmdForm.SelectedValue.ToString());
            mainScreen = ServiceProvider.ScreenConfigService.FindByKeys(mainScreen, false);
            if (mainScreen != null)
            {
                dragContainer2.HideBoxResize();
                dragContainer2.ControlCommand.control_id = mainScreen.control_id;
                dragContainer2.ClearDragItem();
                dragContainer2.Width = mainScreen.control_width;
                dragContainer2.Height = mainScreen.control_height;

                txtWidth.Text = dragContainer2.Width.ToString();
                txtHeight.Text = dragContainer2.Height.ToString();

                List<ScreenConfig> dragItem = new List<ScreenConfig>();
                dragItem = ServiceProvider.ScreenConfigService.getChildScreenByParent(mainScreen.control_id);
                foreach (ScreenConfig item in dragItem)
                {
                    Control.DragItem d = new Control.DragItem(new Point(0, 0));
                    d.CustomProperties.Text = item.display_text;
                    d.CustomProperties.BorderStyle = (BorderStyle)item.border_style;
                    d.ControlCommand.ControlState = ObjectState.Nothing;
                    d.ControlCommand.control_type = string.IsNullOrEmpty(item.control_type) ? ControlType.Button : item.control_type;
                    d.Width = item.control_width;
                    d.Height = item.control_height;
                    d.FontStr = item.font;
                    d.CustomProperties.BackGroundImage = item.background_image_path;
                    d.BackColor = Color.FromArgb(item.background_color);
                    d.ForeColor = Color.FromArgb(item.fore_color);
                    d.Top = item.position_top;
                    d.Left = item.position_left;
                    dragContainer2.AddDragControl(d);
                }

            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            int newHeight = Converts.ParseInt(txtHeight.Text);
            if (newHeight > 0)
            {
                dragContainer2.Height = newHeight;
            }
            else
            {
                txtHeight.Text = dragContainer2.Height.ToString();
            }
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            int newWidth = Converts.ParseInt(txtWidth.Text);
            if (newWidth > 0)
            {
                dragContainer2.Width = newWidth;
            }
            else
            {
                txtWidth.Text = dragContainer2.Width.ToString();
            }

        }

        private void btnNewScreen_Click(object sender, EventArgs e)
        {
            this.NewScreenSetup();
        }

        



    }
}
