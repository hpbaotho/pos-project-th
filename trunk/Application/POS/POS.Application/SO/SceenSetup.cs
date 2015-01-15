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
using POS.BL.DTO.SO;

namespace POS.SO
{
    public partial class SceenSetup : POS.Control.FormBase
    {
        public SceenSetup()
        {

            InitializeComponent();
            this.LoadDDlScreen();

            this.LoadScreenConfig();

            dragContainer2.SelectDragEvent += new Control.DragContainer.SelectDragItemHandler(dragContainer2_SelectDragEvent);
        }

        private void LoadDDlScreen()
        {
            cmdForm.DataSource = ServiceProvider.ScreenConfigService.getParentScreen();
            cmdForm.ValueMember = "control_id";
            cmdForm.DisplayMember = "control_code";
            ddlScreen.DataSource = ServiceProvider.ScreenConfigService.getParentScreen();
            ddlScreen.ValueMember = "control_id";
            ddlScreen.DisplayMember = "control_code";
        }

        protected void dragContainer2_SelectDragEvent(object sender)
        {
            Control.DragItem d = sender as Control.DragItem;
            spComtrolCommand.Panel2.Enabled = false;

            ddlControlType.SelectedIndex = -1;
            ddlControlType.Enabled = false;
            ddlScreen.SelectedIndex = -1;
            ddlScreen.Enabled = false;
            txtTableName.Text = string.Empty;
            txtTableName.Enabled = false;


            if (d != null)
            {
                ddlControlType.Enabled = true;
                spComtrolCommand.Panel2.Enabled = true;
                propertyGrid1.SelectedObject = d.CustomProperties;
                ddlControlType.SelectedIndex = ddlControlType.FindString(d.ControlCommand.control_type);
                if (d.ControlCommand.control_type == ControlType.Table)
                {
                    txtTableName.Text = d.ControlCommand.TableName;
                    txtTableName.Enabled = true;
                }
                else
                {

                }

                ddlScreen.SelectedIndex = ddlScreen.FindString(d.ControlCommand.NextScreen);
            }
            else
            {

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
            d.CustomProperties.Top = 0;
            d.CustomProperties.Left = 0;
            d.Width = 60;
            d.Height = 60;
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
            if (base.ShowConfirmMessage(GeneralMessage.ConfirmSaveDate, ""))
            {
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
                string screenCode = string.Empty;
                if (cmdForm.SelectedItem != null)
                {
                    screenCode = (cmdForm.SelectedItem as ScreenConfig).control_code;
                }

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
                    if (dragItem.control_type == ControlType.Table)
                    {
                        dragItem.control_command = item.ControlCommand.TableName;
                    }
                    else if (dragItem.control_type == ControlType.Button && !string.IsNullOrEmpty(item.ControlCommand.NextScreen))
                    {
                        dragItem.control_command = item.ControlCommand.NextScreen;
                        dragItem.control_command_group = CommandGroup.OpenNextScreen;

                    }
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
                this.LoadDDlScreen();
                cmdForm.SelectedIndex = cmdForm.FindString(mainScreen.control_code);
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
                    d.ControlCommand.ControlState = ObjectState.Add;
                    d.ControlCommand.control_type = string.IsNullOrEmpty(item.control_type) ? ControlType.Button : item.control_type;
                    if (d.ControlCommand.control_type == ControlType.Table)
                    {
                        d.ControlCommand.TableName = item.control_command;
                    }
                    else if (d.ControlCommand.control_type == ControlType.Button && item.control_command_group == CommandGroup.OpenNextScreen)
                    {
                        d.ControlCommand.NextScreen = item.control_command;
                    }
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
            dragContainer2.HideBoxResize();
            this.NewScreenSetup();
        }

        private void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustromControlPropertyDTO dragProprty = dragContainer2.getCurentSelectDragItemProprty();
            if (dragProprty != null && ddlControlType.SelectedItem != null)
            {
                ddlScreen.Enabled = false;
                if (ddlControlType.SelectedItem.ToString() == ControlType.Table)
                {
                    txtTableName.Enabled = true;
                    txtTableName.Text = dragProprty.TableName;

                }
                else if (ddlControlType.SelectedItem.ToString() == ControlType.Button)
                {
                    ddlScreen.Enabled = true;
                }
                else
                {
                    txtTableName.Enabled = false;
                    dragProprty.TableName = string.Empty;
                }

                dragProprty.control_type = ddlControlType.SelectedItem.ToString();
                dragContainer2.setCurentSelectDragItemProprty(dragProprty);
            }
        }

        private void txtTableName_TextChanged(object sender, EventArgs e)
        {
            CustromControlPropertyDTO dragProprty = dragContainer2.getCurentSelectDragItemProprty();
            string tableName = txtTableName.Text.Trim();
            if (dragProprty != null && !string.IsNullOrEmpty(tableName) && ddlControlType.SelectedItem.ToString() == ControlType.Table)
            {
                dragProprty.TableName = tableName;
                dragContainer2.setCurentSelectDragItemProprty(dragProprty);

            }
        }

        private void ddlScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustromControlPropertyDTO dragProprty = dragContainer2.getCurentSelectDragItemProprty();
            if (dragProprty != null && ddlScreen.SelectedItem != null && ddlControlType.SelectedItem.ToString() == ControlType.Button)
            {

                string screenCode = string.Empty;
                screenCode = (ddlScreen.SelectedItem as ScreenConfig).control_code;
                dragProprty.NextScreen = screenCode;
                dragContainer2.setCurentSelectDragItemProprty(dragProprty);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
