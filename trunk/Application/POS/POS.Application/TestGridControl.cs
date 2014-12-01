using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.CustomControls.GridView;
using POS.Service.Services;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;

namespace POS
{
    public partial class TestGridControl : Form
    {
        public TestGridControl()
        {
            InitializeComponent();
        }

        private void TestGridControl_Load(object sender, EventArgs e)
        {
        }

        public void grdBase_onLoadDataGrid(object sender, CustomControls.GridView.DataBindArgs e)
        {
            DataTable dt = Converts.ConvertToDataTable(ServiceProvider.SystemConfigurationService.FindAll(true).ToArray<SystemConfiguration>());
            e.DataSource = dt;
        }
    }
}
