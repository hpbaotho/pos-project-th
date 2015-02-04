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
        /// <summary>
        /// let usprogrammer assign this value to hide some columns, assign this before loading data
        /// </summary>
        public List<string> HiddenColumnName { get; set; }



        public DataSet DataSourceDataSet { get; set; }
        public IEnumerable<object> DataSourceTable { get; set; }
        public string[] DataKeyName { get; set; }
        public object[] DataKeyValue { get; set; }
        public ObjectState FormMode { get; set; }
        //public DatabaseService<EntityBase> EntityService { get; set; }
        public BaseGrid()
        {
            InitializeComponent();
            this.Grid.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.Grid.RowHeadersVisible = false;

            //prevent the old thing to take effect, set its initial value
            BtnProcesEnable = false;
            BtnProcessCancelEnable = false;
            BtnProcessCompleteEnable = false;
        }

        /// <summary>
        /// an alteranative BaseGrid for displaying kitchen commands
        /// </summary>
        /// <param name="IsKitchenMode"></param>
        public BaseGrid(bool IsKitchenMode = true)
        {
            if (IsKitchenMode)
            {
                InitializeComponent();
                this.Grid.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
                this.Grid.RowHeadersVisible = false;
            }
        }

        #region :: private function ::
        public void LoadData(bool IsClearSelection = true)
        {
            LoadData();
            if( IsClearSelection )
                Grid.ClearSelection();
        }

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
                //hide s0me column
                if (HiddenColumnName != null && HiddenColumnName.Where(x => x == header.Name).Count() > 0)
                    header.Visible = false;

                //header.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //header.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //header.HeaderCell.Style.Font = new Font(DefaultFontControl.FontName, DefaultFontControl.FontSizeM, (FontStyle)DefaultFontControl.FontStyle);
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
            if (rowIndex >= 0)
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

        #region :: Custom Public Function eiei ::
        /// <summary>
        /// rearrange button according to each button's disability
        /// </summary>
        public void RearrangeButton()
        {

            int locationX = 0, locationY = 1;
            int buttonWidth = 53;

            //re-arrange the control by the inital X position
            List<System.Windows.Forms.Control> controlList = new List<System.Windows.Forms.Control>();
            controlList.AddRange(panel1.Controls.OfType<System.Windows.Forms.Control>());
            controlList = controlList.OrderBy(x => x.Location.X).ToList();

            //for each button in the panel
            foreach (System.Windows.Forms.Control control in controlList)//panel1.Controls)
            {
                Button currentBtn = control as Button;
                if (currentBtn != null)
                {
                    //of it is enabled, place it
                    if (currentBtn.Enabled)
                    {
                        currentBtn.Visible = true;
                        currentBtn.Location = new Point(locationX, locationY);
                        locationX += buttonWidth;
                    }
                    //otherwise just hide it
                    else
                        currentBtn.Visible = false;
                }
            }
        }

        public void AttachEventToButton(string ButtonName, EventHandler Event)
        {
            Button buttonToassign;
            buttonToassign = this.Controls.Find(ButtonName, true).FirstOrDefault() as Button;
            if (buttonToassign != null)
            {
                buttonToassign.Click += Event;//new System.EventHandler(this.btnRefresh_Click);
            }
            else
                throw new Exception("There's no  specific button");
        }
        #endregion :: Custom Public Function eiei ::


        #region custom weird property
        /// <summary>
        /// so that the programmer can somewaht implement the function
        /// </summary>
        public List<DataGridViewRow> GridSelectedRows
        {
            get
            {
                return Grid.Rows.Cast<DataGridViewRow>().Where(li => li.Selected && !li.IsNewRow).ToList();
            }
        }


        private bool BtnProcessCancelEnable { get { return btnProcessCancel.Enabled; } set { btnProcessCancel.Enabled = value; } }
        private bool BtnProcessCompleteEnable { get { return btnProcessComplete.Enabled; } set { btnProcessComplete.Enabled = value; } }
        private bool BtnProcesEnable { get { return btnProcess.Enabled; } set { btnProcess.Enabled = value; } }

        public bool btnAddEnable { get { return btnAdd.Enabled; } set { btnAdd.Enabled = value; } }
        public bool btnDeleteEnable { get { return btnDelete.Enabled; } set { btnDelete.Enabled = value; } }
        public bool btnSearchEnable { get { return btnSearch.Enabled; } set { btnSearch.Enabled = value; } }
        #endregion
        public bool btnAddVisible { get { return btnAdd.Visible; } set { btnAdd.Visible = value; } }
        public bool btnDeleteVisible { get { return btnDelete.Visible; } set { btnDelete.Visible = value; } }
        public bool btnSearchVisible { get { return btnSearch.Visible; } set { btnSearch.Visible = value; } }
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
