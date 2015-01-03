using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL;
using POS.BL.Entities.Entity;

namespace POS.SO
{
    public partial class WorkPeriodSetup : POS.Control.FormBase
    {
        public WorkPeriodSetup()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            WorkPeriod workPeriod = new WorkPeriod();
            workPeriod.period_code = txtPeriodCode.Text.Trim();
            workPeriod.period_name = txtPeriodName.Text.Trim();
            workPeriod.period_description = txtPeriodDesc.Text.Trim();
            workPeriod.open_period_by = txtOpenPeriodBy.Text.Trim();
            workPeriod.close_period_by = txtClosePeriodBy.Text.Trim();

            grdWorkPeriod.AutoGenerateColumns = false;
            grdWorkPeriod.DataSource = ServiceProvider.WorkPeriodService.FindWorkPeriod(workPeriod);
            
            grdWorkPeriod.DataMember = "Table";
            grdWorkPeriod.AllowUserToAddRows = false;
            grdWorkPeriod.AllowUserToDeleteRows = false;
            grdWorkPeriod.ReadOnly = true;
            //grdWorkPeriod.ColumnCount = 2;
            //grdWorkPeriod.EditMode = 
            //grdWorkPeriod.AllowUserToAddRowsChanged = false;

        }



      

    }
}
