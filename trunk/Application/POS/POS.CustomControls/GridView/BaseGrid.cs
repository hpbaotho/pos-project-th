using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Standards.Service;
using Core.Standards.Entity;

namespace POS.CustomControls.GridView
{
    public partial class BaseGrid : UserControl
    {
        //public DatabaseService<EntityBase> EntityService { get; set; }
        public BaseGrid()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
            //string sql = "SELECT * FROM Stores";
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //sCommand = new SqlCommand(sql, connection);
            //sAdapter = new SqlDataAdapter(sCommand);
            //sBuilder = new SqlCommandBuilder(sAdapter);
            //sDs = new DataSet();
            //sAdapter.Fill(sDs, "Stores");
            //sTable = sDs.Tables["Stores"];
            //connection.Close();
            //dataGridView1.DataSource = sDs.Tables["Stores"];
            //dataGridView1.ReadOnly = true;
            //save_btn.Enabled = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            EventHandler loadEventHandler = onLoadDataGrid;
            if (loadEventHandler != null)
            {
                loadEventHandler(null, null);

            }
            //DataTable dtSource = UtilityDataGrid.ConvertToDataTable(EntityService.FindAll(false).ToArray());
            //Grid.DataSource = dtSource;
            //Grid.ReadOnly = true;


            //Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //if (dtSource.Rows.Count > 0)
            //{
            //    tsbtnDelete.Enabled = false;
            //    tsbtnSave.Enabled = false;
            //}
            //else
            //{
            //    tsbtnDelete.Enabled = true;
            //    tsbtnSave.Enabled = true;
            //}
        }
        public event EventHandler onAdditionalRecord;
        public event EventHandler onUpdateData;
        public event EventHandler onLoadDataGrid;
    }
    public class DataEventArgs : EventArgs
    {
        public bool IsValidation { get; set; }

    }
    public class RowEventArgs : EventArgs
    {
        public bool IsChanged { get; set; }

    }
}
