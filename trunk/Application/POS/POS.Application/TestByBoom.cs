using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Service.Services;

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
            DataSet ds = ServiceProvider.SystemConfigurationService.GetSystemConfig();
            if (ds != null)
            {
                textBox1.Text = ds.Tables[0].Rows[0]["system_configuration_code"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["system_configuration_name"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

    }
}
