using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.CustomControls;
using POS.Service.Services;
using POS.CustomControls.GridView;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.Service.Services.Service;

namespace POS
{
    public partial class Form1 : FormBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void coreButton1_Click(object sender, EventArgs e)
        {
            
                using (TestGridControl Ce = new TestGridControl())
            {
                Ce.ShowDialog();

                if (Ce.DialogResult == DialogResult.OK || Ce.DialogResult == DialogResult.Cancel)
                {
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            DataTable dt = Converts.ConvertToDataTable(ServiceProvider.SystemConfigurationService.FindAll(true).ToArray<SystemConfiguration>());
            dataGridView1.DataSource = dt;

            //dataGridView1.AutoGenerateColumns = true;

        }
    }
}
