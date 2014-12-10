using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.BL;
using POS.BL.Utilities;
using System.Collections;
using POS.BL.Service.SU;
using POS.Control;

namespace POS
{
    public partial class SetupSystemConfigGroup : Control.FormBase
    {
        TabPage tabPageAddEdit = null;
        string DataKeyName = "system_configuration_group_code";

        public SetupSystemConfigGroup()
        {
            InitializeComponent();
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(grdBase_onDeleteDataRows);

        }

        #region :: Event Gridview ::
        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdBase.DataSourceDataSet = ServiceProvider.SystemConfigGroupService.FindAllDataSet(false);
            grdBase.DataKeyName = new string[] { DataKeyName };
        }
        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {
            AddEditSystemConfigGroup f = new AddEditSystemConfigGroup();
            this.AddEditTab(string.Format(TabName.Add, ProgramName.SetupSystemConfigGroup), f);
        }
        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            AddEditSystemConfigGroup f = new AddEditSystemConfigGroup(dataKey[DataKeyName].ToString());
            this.AddEditTab(string.Format(TabName.Edit, ProgramName.SetupSystemConfigGroup), f);
        }
        public void grdBase_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            ServiceProvider.SystemConfigGroupService.Delete((List<Dictionary<string, object>>)sender);
        }
        public void grdBase_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            }
            else
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            }

            if (e.ColumnIndex == 2)
            {
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                e.CellStyle.Format = FormatString.FormatDate;

            }

        }
        
        #endregion

        protected void NotifyReturnEvent(object param)
        {
            if (param != null)
            {
                ControlMode controlMode = (ControlMode)param;
                if (tabControl1.TabPages.Count > 1)
                {
                    tabControl1.TabPages.RemoveAt(1);
                }
                if (controlMode == ControlMode.Save)
                {
                    grdBase.LoadData();
                }
                tabControl1.SelectedTab = tabPage1;
            }
        }

        #region :: Private Function ::
        private void AddEditTab(string TabTitle, AddEditSystemConfigGroup controlAddEdit)
        {
            if (tabControl1.TabPages.Count == 1 || (tabControl1.TabPages.Count > 1 && base.ShowConfirmMessage(GeneralMessage.ConfirmNewTab, "Confirm")))
            {
                controlAddEdit.NotifyReturnEvent += new Control.BaseUserContorl.NotifyReturnHandler(NotifyReturnEvent);
                tabPageAddEdit = new TabPage();
                tabPageAddEdit.Controls.Clear();
                tabPageAddEdit.Controls.Add(controlAddEdit);
                tabPageAddEdit.Text = TabTitle;

                if (tabControl1.TabPages.Count > 1)
                {
                    tabControl1.TabPages.RemoveAt(1);
                }
                tabControl1.TabPages.Remove(tabPageAddEdit);
                tabControl1.TabPages.Add(tabPageAddEdit);
            }
            tabControl1.SelectedTab = tabPageAddEdit;
        }
        #endregion
    }
}
