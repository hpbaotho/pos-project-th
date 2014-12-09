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

namespace POS
{
    public partial class SetupSystemConfigGroup : Control.FormBase
    {
        SystemConfigGroupService service = new SystemConfigGroupService(); 
        public SetupSystemConfigGroup()
        {
            InitializeComponent();
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(grdBase_onDeleteDataRows);
        }



        public void grdBase_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            service.Delete((List<Dictionary<string, object>>)sender);
        }

        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            using (AddEditSystemConfigGroup f = new AddEditSystemConfigGroup(dataKey["system_configuration_group_code"].ToString()))
            {
                DialogResult result = f.ShowDialog();

            }

        }

        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {
            using (AddEditSystemConfigGroup f = new AddEditSystemConfigGroup())
            {
                DialogResult result = f.ShowDialog();

            }
        }

        public void grdBase_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            }
            else {
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

        private void TestGridControl_Load(object sender, EventArgs e)
        {

        }

        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdBase.DataSourceTable = service.FindAll(true).ToList();
            grdBase.DataKeyName = new string[] { "system_configuration_group_code" };
            //DataTable dt = Converts.ConvertToDataTable(ServiceProvider.SystemConfigurationService.FindAll(true).ToArray());
            //e.DataSource = ServiceProvider.SystemConfigurationService.FindAll(true);
        }
    }
}
