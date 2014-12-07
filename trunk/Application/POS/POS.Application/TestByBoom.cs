using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Service.SU;
using POS.BL.Entities.Entity;
using Core.Standards.Validations;
using Core.Standards.Converters;
using POS.BL;

namespace POS
{
    public partial class TestByBoom : Form
    {
        public TestByBoom()
        {
            InitializeComponent();
        }

        private void TestByBoom_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SystemConfiguration sys = ServiceProvider.SystemConfigurationService.FindByKeys(new SystemConfiguration() { system_configuration_id = Converts.ParseInt(label1.Text) }, false);
            if (sys != null)
            {
                sys.system_configuration_code = textBox1.Text;
                sys.system_configuration_name = textBox2.Text;
                ServiceProvider.SystemConfigurationService.Update(sys, new string[] { ValidationRuleset.Update });
            }
            LoadData();
        }
        private void LoadData()
        {
            DataSet ds = ServiceProvider.SystemConfigurationService.GetSystemConfig(textBox5.Text);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                label1.Text = ds.Tables[0].Rows[0]["system_configuration_id"].ToString();
                textBox1.Text = ds.Tables[0].Rows[0]["system_configuration_code"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["system_configuration_name"].ToString();
            }
            else
            {
                label1.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SystemConfiguration sys = new SystemConfiguration();
            sys.system_configuration_code = textBox3.Text;
            sys.system_configuration_name = textBox4.Text;
            //sys.CreatedBy = "PQBY";
            //sys.CreatedDate = DateTime.Now;
            //sys.UpdatedBy = "PQBY";
            //sys.UpdatedDate = DateTime.Now;
            ServiceProvider.SystemConfigurationService.Insert(sys, new string[] { ValidationRuleset.Insert });
            textBox3.Text = "";
            textBox4.Text = "";

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SystemConfiguration sys = ServiceProvider.SystemConfigurationService.FindByKeys(new SystemConfiguration() { system_configuration_id = Converts.ParseInt(label1.Text) }, false);
            if (sys != null)
            {
                ServiceProvider.SystemConfigurationService.Delete(sys, new string[] { ValidationRuleset.Delete });

            }
            LoadData();
        }

    }
}
