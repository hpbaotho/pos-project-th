﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL;
using POS.Control;
using POS.BL.Utilities;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using Core.Standards.Exceptions;

namespace POS.IN.ReceiveMaterial
{
    public partial class ucReceiveMaterial : BaseUserControl
    {
        TabPage tabPageAddEdit = new TabPage();
        string DataKeyName = "tran_head_id";
        AddEditReceiveMaterial addEditReceiveMaterial = new AddEditReceiveMaterial();
        string programName = ProgramName.SetupINReceiveMaterial;
        string tabName = "List Receive Material";

        public ucReceiveMaterial()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            tabPage1.Text = tabName;

            grdBase.onAddNewRow += new EventHandler(grdBase_onAddNewRow);
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(grdBase_onDeleteDataRows);
            grdBase.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBase_onLoadDataGrid);
            grdBase.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(grdBase_onCellFormatting);

            grdBase.LoadData();
        }
        #region :: Event Gridview ::
        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdBase.DataSourceDataSet = ServiceProvider.TranHeadService.FindAllDataSet(false);
            grdBase.DataKeyName = new string[] { DataKeyName };
        }
        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {
            addEditReceiveMaterial = new AddEditReceiveMaterial();
            this.AddEditTab(string.Format(TabName.Add, programName), addEditReceiveMaterial);
        }
        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            addEditReceiveMaterial = new AddEditReceiveMaterial(dataKey[DataKeyName].ToString());
            this.AddEditTab(string.Format(TabName.Edit, programName), addEditReceiveMaterial);
        }
        public void grdBase_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)sender;
                List<TranHead> listTranHead = new List<TranHead>();
                foreach (Dictionary<string, object> item in list)
                {
                    listTranHead.Add(new TranHead() { tran_head_id = Converts.ParseLong(item[DataKeyName].ToString()) });
                }
                ServiceProvider.TranHeadService.Delete(listTranHead);
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
        }
        public void grdBase_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            e.CellStyle.WrapMode = DataGridViewTriState.True;

            Type dataType = val.GetType();

            if (e.ColumnIndex == 2)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                if (typeof(int) == dataType || typeof(decimal) == dataType || typeof(float) == dataType || typeof(long) == dataType || typeof(double) == dataType)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (typeof(DateTime) == dataType)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.Format = FormatString.FormatDate;
                }
                else
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
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
        private void AddEditTab(string TabTitle, AddEditReceiveMaterial controlAddEdit)
        {
            if (tabControl1.TabPages.Count == 1 || (tabControl1.TabPages.Count > 1 && base.formBase.ShowConfirmMessage(GeneralMessage.ConfirmNewTab, "Confirm")))
            {
                controlAddEdit.NotifyReturnEvent += new Control.BaseUserControl.NotifyReturnHandler(NotifyReturnEvent);
                tabPageAddEdit = new TabPage();
                tabPageAddEdit.Controls.Clear();
                tabPageAddEdit.Controls.Add(controlAddEdit);
                tabPageAddEdit.Text = TabTitle;
                controlAddEdit.Dock = DockStyle.Fill;

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
