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
        public DataTable DataSourceTable { get; set; }

        //public DatabaseService<EntityBase> EntityService { get; set; }
        public BaseGrid()
        {
            InitializeComponent();
        }
        #region :: private function ::
        private void LoadData()
        {
            DataBindArgs LoadArg = new DataBindArgs();
            if (onLoadDataGrid != null)
            {

                onLoadDataGrid(Grid, LoadArg);
                Grid.DataSource = LoadArg.DataSource;
                Grid.Rows[5].Selected = true;
            }
        }
        private void AlertUpdate()
        {

        }
        private void ConfirmDelete()
        {

        }
        #endregion


        #region :: Event Function ::
        private void BaseGrid_Load(object sender, EventArgs e)
        {

            LoadData();

        }




        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            DataTable tb = Grid.DataSource as DataTable;
            DataTable tbEdit = tb.GetChanges(DataRowState.Modified);
            List<DataRow> editRows = tb.Rows.Cast<DataRow>().Where(li => li.RowState == DataRowState.Modified).ToList();
            List<DataRow> AddRows = tb.Rows.Cast<DataRow>().Where(li => li.RowState == DataRowState.Added).ToList();
            List<DataRow> DeleteRows = tb.Rows.Cast<DataRow>().Where(li => li.RowState == DataRowState.Deleted).ToList();

        }

        private void tsbtnAddRow_Click(object sender, EventArgs e)
        {
            
            if (onAddNewRow != null)
            {

                onAddNewRow(null, null);

                LoadData();
                AlertUpdate();

            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            RowEventArgs RowArg = new RowEventArgs() { RowIndex = e.RowIndex };
            if (onSelectedDataRow != null)
            {

                onSelectedDataRow(Grid.Rows[e.RowIndex], RowArg);

                LoadData();
                AlertUpdate();
                Grid.ClearSelection();
                //Grid.Rows
                Grid.Rows[e.RowIndex].Selected = true;

            }
            

        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> SelectedRows = Grid.Rows.Cast<DataGridViewRow>().Where(li => li.Selected).ToList();
            RowsEventArgs RowArg = new RowsEventArgs() { RowsSelected = SelectedRows };
            if (onDeleteDataRows != null)
            {

                onDeleteDataRows(SelectedRows, RowArg);
                LoadData();
                AlertUpdate();
                Grid.ClearSelection();
            }

        
           
        }




        #endregion

        public event EventHandler onAddNewRow;
        public event EventHandler<RowEventArgs> onSelectedDataRow;
        public event EventHandler<RowsEventArgs> onDeleteDataRows;
        public event EventHandler<DataBindArgs> onLoadDataGrid;

     

    






    }
    public class DataBindArgs : EventArgs
    {

        public DataTable DataSource { get; set; }

    }
    public class RowEventArgs : EventArgs
    {
        public int RowIndex { get; set; }
        public string Key { get; set; }


    }
    public class RowsEventArgs : EventArgs
    {
        public List<DataGridViewRow> RowsSelected { get; set; }
    }
}
