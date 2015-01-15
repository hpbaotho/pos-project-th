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
using POS.Control.BaseMessageBox;
using POS.BL.Utilities;
using Core.Standards.Exceptions;

namespace POS.Control.GridView
{
    public partial class BaseGrid : BaseUserControl
    {
        public DataSet DataSourceDataSet { get; set; }
        public IEnumerable<object> DataSourceTable { get; set; }
        public string[] DataKeyName { get; set; }
        //public DatabaseService<EntityBase> EntityService { get; set; }
        public BaseGrid()
        {
            InitializeComponent();
            this.Grid.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.Grid.RowHeadersVisible = false;

        }
        #region :: private function ::
        public void LoadData()
        {
            Form form = this.FindForm();
            if (form != null)
            {
                Grid.Font = form.Font;
            }

            DataBindArgs LoadArg = new DataBindArgs();
            if (onLoadDataGrid != null)
            {
                onLoadDataGrid(Grid, LoadArg);
                if (DataSourceTable == null)
                {
                    Grid.DataSource = DataSourceDataSet;
                    Grid.DataMember = "Table";
                    Grid.AllowUserToAddRows = false;
                    Grid.AllowUserToDeleteRows = false;

                    tsslblTotalRows.Text = string.Format(FormatString.TotalRowsGrid, DataSourceDataSet.Tables[0].Rows.Count);
                }
                else
                {
                    Grid.DataSource = DataSourceTable.ToList();
                    tsslblTotalRows.Text = string.Format(FormatString.TotalRowsGrid, DataSourceTable.Count());
                }

            }
            foreach (DataGridViewColumn header in Grid.Columns)
            {
                header.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                header.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                header.HeaderCell.Style.Font = new Font(DefaultFontControl.FontName, DefaultFontControl.FontSizeM, (FontStyle)DefaultFontControl.FontStyle);
            }

        }
        private void UpdateDataRow(DataGridViewRow rowSelected)
        {
            RowEventArgs RowArg = new RowEventArgs();
            //Grid.Rows[rowIndex]
            if (rowSelected.IsNewRow)
            {
                UtilityMessage.Warning(GeneralMessage.NoSelectedDataUpdate, GeneralMessage.MessageBoxTitle);
            }
            else
            {
                //if (onSelectedDataRow != null && UtilityMessage.Confirm(GeneralMessage.ConfirmUpdate, GeneralMessage.MessageBoxTitle))
                if (onSelectedDataRow != null)
                {
                    RowArg.RowSelected = rowSelected;
                    onSelectedDataRow(GetUpdateDataKey(rowSelected), RowArg);
                    LoadData();
                    Grid.ClearSelection();
                    //Grid.Rows
                    //Grid.Rows[rowIndex].Selected = true;
                }
            }
        }
        private void DeleteData(List<DataGridViewRow> selectedRows)
        {

            if (selectedRows.Count > 0)
            {

                if (UtilityMessage.Confirm(GeneralMessage.ConfirmDelete, GeneralMessage.MessageBoxTitle))
                {
                    RowsEventArgs RowArg = new RowsEventArgs() { RowsSelected = selectedRows };
                    if (onDeleteDataRows != null)
                    {
                        onDeleteDataRows(GetDeleteDataKey(selectedRows), RowArg);
                        LoadData();
                        Grid.ClearSelection();
                        UtilityMessage.Alert(GeneralMessage.DeleteComplete, GeneralMessage.MessageBoxTitle);
                    }
                }
            }
            else
            {
                UtilityMessage.Warning(GeneralMessage.NoSelectedData, GeneralMessage.MessageBoxTitle);
            }
        }
        private Dictionary<string, object> GetUpdateDataKey(DataGridViewRow rowSelected)
        {
            Dictionary<string, object> DataKeys = new Dictionary<string, object>();
            foreach (string name in this.DataKeyName)
            {
                DataKeys.Add(name, rowSelected.Cells[name].Value);
            }
            return DataKeys;
        }
        private IEnumerable<Dictionary<string, object>> GetDeleteDataKey(List<DataGridViewRow> selectedRows)
        {
            List<Dictionary<string, object>> DataKeys = new List<Dictionary<string, object>>();
            foreach (DataGridViewRow rowSelected in selectedRows)
            {

                Dictionary<string, object> dicRow = new Dictionary<string, object>();
                foreach (string name in this.DataKeyName)
                {
                    dicRow.Add(name, rowSelected.Cells[name].Value);
                }
                DataKeys.Add(dicRow);
            }
            return DataKeys;
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
            }
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex > 0)
                UpdateDataRow(Grid.Rows[rowIndex]);


        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> SelectedRows = Grid.Rows.Cast<DataGridViewRow>().Where(li => li.Selected && !li.IsNewRow).ToList();
                DeleteData(SelectedRows);
            }
            catch (ValidationException ex)
            {
                formBase.ShowErrorMessage(ex);
            }
            catch (Exception ex)
            {
                formBase.ShowErrorMessage(ex.Message);
            }

        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = Grid.SelectedRows.Cast<DataGridViewRow>().Where(li => !li.IsNewRow).ToList();
            tsslblSelectedRows.Text = string.Format(FormatString.SelectedRowsGrid, list.Count);

        }

        private void Grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // DataGridViewColumn col = e.Column;
            if (onColumnAdded != null)
            {
                onColumnAdded(sender, e);
            }
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (onCellFormatting != null)
            {
                onCellFormatting(sender, e);
            }
        }
        #endregion

        #region :: Event Handler ::
        public event EventHandler onAddNewRow;
        public event EventHandler<RowEventArgs> onSelectedDataRow;
        public event EventHandler<RowsEventArgs> onDeleteDataRows;
        public event EventHandler<DataBindArgs> onLoadDataGrid;
        public event EventHandler<DataGridViewColumnEventArgs> onColumnAdded;
        public event EventHandler<DataGridViewCellFormattingEventArgs> onCellFormatting;
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
    public class DataBindArgs : EventArgs
    {

        public IEnumerable<object> DataSource { get; set; }

    }
    public class RowEventArgs : EventArgs
    {
        public int RowIndex { get; set; }
        public string Key { get; set; }
        public DataGridViewRow RowSelected { get; set; }

    }
    public class RowsEventArgs : EventArgs
    {
        public List<DataGridViewRow> RowsSelected { get; set; }
    }
}
