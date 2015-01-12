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

        private void loadData(object sender, EventArgs e)
        {
            //Enable/ Visible start period and end period
            bool isPeriodStart = ServiceProvider.WorkPeriodService.IsPeriodStart();
            btnStartPeriod.Enabled = !isPeriodStart;
            btnEndPeriod.Enabled = isPeriodStart;

            //Find detail to current period
            WorkPeriod workPeriod = ServiceProvider.WorkPeriodService.findActiveWorkPeriod();
            if (workPeriod != null)
            {
                txtDateOfWorkPeriod.Text = workPeriod.open_period_date != null ? workPeriod.open_period_date.Value.ToString() : string.Empty;
                txtCurrentPeriodCode.Text = workPeriod.period_code.ToString();
                txtCurrentPeriodName.Text = workPeriod.period_name.ToString();
                txtCurrentOpenPeriodBy.Text = workPeriod.open_period_by.ToString();
                txtCurrentOpenPeriodDate.Text = workPeriod.open_period_date != null ? workPeriod.open_period_date.Value.ToString() : string.Empty;
            }

            this.bindData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.bindData();
        }

        private void bindData()
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
        }

    }
}
