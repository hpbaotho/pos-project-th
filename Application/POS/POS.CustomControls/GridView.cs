using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

using System.Data.SqlClient;
using Core.Standards.Service;
using Core.Standards.Entity;

namespace POS.CustomControls
{
    public partial class GridView : UserControl
    {
        private DatabaseService<EntityBase> dbService ;
        public GridView()
        {
            InitializeComponent();
            string comd = "select * from " + dbService.EntityTableName;
            SqlDataAdapter adap = new SqlDataAdapter(comd,dbService.ConnectionStringName);
            
        }
    }
}
