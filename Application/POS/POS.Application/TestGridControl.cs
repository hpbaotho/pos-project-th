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

namespace POS
{
    public partial class TestGridControl : Control.FormBase
    {
        public TestGridControl()
        {
            InitializeComponent();
            
        }

        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {

        }

        public void grdBase_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            if (e.ColumnIndex == 10 || e.ColumnIndex == 12 || e.ColumnIndex == 13 || e.ColumnIndex == 6 || e.ColumnIndex == 1)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
             if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }
            
            if (e.ColumnIndex == 10 || e.ColumnIndex == 12 || e.ColumnIndex == 13)
            {
                e.CellStyle.Format = FormatString.FormatDate;

            }

        }

        private void TestGridControl_Load(object sender, EventArgs e)
        {

        }

        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdBase.DataSourceTable = ServiceProvider.SystemConfigurationService.FindAll(true).ToList();
            //DataTable dt = Converts.ConvertToDataTable(ServiceProvider.SystemConfigurationService.FindAll(true).ToArray());
            //e.DataSource = ServiceProvider.SystemConfigurationService.FindAll(true);
        }
    }
}
