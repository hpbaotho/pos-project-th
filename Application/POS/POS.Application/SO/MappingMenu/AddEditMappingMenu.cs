using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.Utilities;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.BL;
using Core.Standards.Exceptions;
using Core.Standards.Validations;

namespace POS.SO.MappingMenu
{
    public partial class AddEditMappingMenu : BaseAddEditMaster
    {
        #region :: Properties ::
        private ObjectState modeHead { get; set; }
        private ObjectState modeDetail { get; set; }
        private string keyCode { get; set; }
        private long keyCodeDetail { get; set; }
        string DataKeyName = "ID";
        public AddEditMappingMenu()
        {
            modeHead = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditHead_Load);
        }
        public AddEditMappingMenu(string Code)
        {
            modeHead = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditHead_Load);
        }
        #endregion

        #region :: Header ::
        #region :: Private Function ::
        private void AddEditHead_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            EnableMode();

            SOMenu entity = new SOMenu();
            if (modeHead == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                //---Header
                entity.menu_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.MenuService.FindByKeys(entity, true);
                txtMenuCode.Text = entity.menu_code;
                txtMenuName.Text = entity.menu_name;
                txtMenuDescription.Text = entity.menu_description;
                chkActive.Checked = entity.active;

                //---Detail
                modeDetail = ObjectState.Add;
                InitialGridDetail();
                LoadDataDetail(0);
            }
            else
            {
                txtMenuCode.Text = string.Empty;
                txtMenuName.Text = string.Empty;
                txtMenuDescription.Text = string.Empty;
                chkActive.Checked = true;
            }

        }
        private void EnableMode()
        {
            if (modeHead == ObjectState.Edit)
            {
                txtMenuCode.Enabled = false;
                pnlDetail.Visible = true;
            }
            else
            {
                txtMenuCode.Enabled = true;
                pnlDetail.Visible = false;
            }
        }
        private SOMenu GetData()
        {
            SOMenu entity = new SOMenu();
            entity.menu_id = Converts.ParseLong(keyCode);
            entity.menu_code = txtMenuCode.Text;
            entity.menu_name = txtMenuName.Text;
            entity.menu_description = txtMenuDescription.Text;
            entity.menu_reference_id = null;
            entity.active = chkActive.Checked;
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;

            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void AddEditHead_saveHandler()
        {
            try
            {
                SOMenu entity = GetData();
                if (modeHead == ObjectState.Add)
                {
                    int menuID = ServiceProvider.MenuService.Insert<int>(entity, new string[] { ValidationRuleset.Insert });

                    keyCode = menuID.ToString();
                    modeHead = ObjectState.Edit;
                    LoadData();
                }
                else
                {
                    ServiceProvider.MenuService.Update(entity, new string[] { ValidationRuleset.Update });
                    LoadData();
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void AddEditHead_resetHandler()
        {
            LoadData();
        }
        #endregion
        #endregion

        #region :: Detail ::
        #region :: Event Gridview ::
        public void grdDetail_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdDetail.DataSourceDataSet = ServiceProvider.MenuMappingService.GetGridMenuMappingDetail(Converts.ParseLong(keyCode));
            grdDetail.DataKeyName = new string[] { DataKeyName };
        }
        public void grdDetail_onAddNewRow(object sender, EventArgs e)
        {
            modeDetail = ObjectState.Add;
            LoadDataDetail(0);
        }
        public void grdDetail_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            modeDetail = ObjectState.Edit;
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            long menuMappingID = Converts.ParseLong(dataKey[DataKeyName].ToString());
            LoadDataDetail(menuMappingID);
        }
        public void grdDetail_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)sender;
                List<MenuMapping> listEntity = new List<MenuMapping>();
                foreach (Dictionary<string, object> item in list)
                {
                    listEntity.Add(new MenuMapping() { menu_mapping_id = Converts.ParseLong(item[DataKeyName].ToString()) });
                }
                ServiceProvider.MenuMappingService.Delete(listEntity, new string[] { ValidationRuleset.Delete });
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
        }
        public void grdDetail_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;

            e.CellStyle.WrapMode = DataGridViewTriState.True;

            if (val != null)
            {
                Type dataType = val.GetType();

                if (e.ColumnIndex == 2)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    if (typeof(int) == dataType || typeof(decimal) == dataType || typeof(float) == dataType || typeof(long) == dataType || typeof(double) == dataType)
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (typeof(DateTime) == dataType)
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.Format = FormatString.FormatDate;
                    }
                    else
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
            }
        }
        #endregion
        #region :: Private Function ::
        private void InitialGridDetail()
        {
            grdDetail.onAddNewRow += new EventHandler(grdDetail_onAddNewRow);
            grdDetail.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdDetail_onSelectedDataRow);
            grdDetail.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(grdDetail_onDeleteDataRows);
            grdDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdDetail_onLoadDataGrid);
            grdDetail.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(grdDetail_onCellFormatting);

            grdDetail.LoadData();
        }
        private void LoadDataDetail(long menuMappingID)
        {
            ddlBomHead.DataSource = ServiceProvider.BillOfMaterialHeadService.GetBillOfMaterialHeadComboBoxDTOByID(null);
            ddlBomHead.ValueMember = "Value";
            ddlBomHead.DisplayMember = "Display";

            MenuMapping entity = new MenuMapping();
            if (modeDetail == ObjectState.Edit && menuMappingID != 0)
            {
                //---Detail
                entity.menu_mapping_id = menuMappingID;
                entity = ServiceProvider.MenuMappingService.FindByKeys(entity, true);
                if (entity != null)
                {
                    ddlBomHead.SelectedValue = entity.bill_of_material_head_id.ToString();
                    txtQuantity.Text = string.Format(Format.IntegerNumberFormatNoZero, entity.quantity);

                    keyCodeDetail = entity.menu_mapping_id;
                }
            }
            else
            {
                keyCodeDetail = 0;

                ddlBomHead.SelectedIndex = 0;
                txtQuantity.Text = string.Empty;
            }

            grdDetail.LoadData();
        }
        private MenuMapping GetDataDetail()
        {
            MenuMapping entity = new MenuMapping();
            entity.menu_mapping_id = keyCodeDetail;
            entity.menu_id = Converts.ParseLong(keyCode);

            if (modeDetail == ObjectState.Add)
            {
                entity.bill_of_material_head_id = Converts.ParseLongNullable(ddlBomHead.SelectedValue.ToString());
                entity.quantity = Converts.ParseDecimalNullable(txtQuantity.Text);
                entity.created_by = "SYSTEM";
                entity.created_date = DateTime.Now;
                entity.updated_by = "SYSTEM";
                entity.updated_date = DateTime.Now;
            }
            else
            {
                entity = ServiceProvider.MenuMappingService.FindByKeys(entity, false);
                if (entity != null)
                {
                    entity.bill_of_material_head_id = Converts.ParseLongNullable(ddlBomHead.SelectedValue.ToString());
                    entity.quantity = Converts.ParseDecimalNullable(txtQuantity.Text);
                    entity.updated_by = "SYSTEM";
                    entity.updated_date = DateTime.Now;
                }
            }

            return entity;
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
        #endregion

        #region :: Event Action ::
        private void AddEditDetail_Load(object sender, EventArgs e)
        {
            LoadDataDetail(0);
        }
        private void AddEditDetail_saveHandler()
        {
            try
            {
                MenuMapping entity = entity = GetDataDetail();
                if (modeDetail == ObjectState.Add)
                {
                    ServiceProvider.MenuMappingService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.MenuMappingService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                modeDetail = ObjectState.Add;
                LoadDataDetail(0);

                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void AddEditDetail_resetHandler()
        {
            LoadDataDetail(keyCodeDetail);
        }
        #endregion

        #endregion

    }
}
