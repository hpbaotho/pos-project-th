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

namespace POS.IN.BillOfMaterial
{
    public partial class AddEditBillOfMaterial : BaseAddEditMaster
    {
        #region :: Properties ::
        private ObjectState modeHead { get; set; }
        private ObjectState modeDetail { get; set; }
        private string keyCode { get; set; }
        private long keyCodeDetail { get; set; }
        string DataKeyName = "ID";
        public AddEditBillOfMaterial()
        {
            modeHead = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditHead_Load);
        }
        public AddEditBillOfMaterial(string Code)
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

            BillOfMaterialHead entity = new BillOfMaterialHead();
            if (modeHead == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                ddlBOMGroup.DataSource = ServiceProvider.BillOfMaterialGroupService.GetBillOfMaterialGroupComboBoxDTO();
                ddlBOMGroup.ValueMember = "Value";
                ddlBOMGroup.DisplayMember = "Display";

                //---Header
                entity.bill_of_material_head_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.BillOfMaterialHeadService.FindByKeys(entity, true);

                if (entity != null)
                {
                    ddlBOMGroup.SelectedValue = entity.bill_of_material_group_id.ToString();
                    txtBOMHeadCode.Text = entity.bill_of_material_head_code;
                    txtBOMHeadName.Text = entity.bill_of_material_head_name;
                    txtBOMHeadDescription.Text = entity.bill_of_material_head_description;
                    txtRemark.Text = entity.remark;

                    //---Detail
                    modeDetail = ObjectState.Add;
                    InitialGridDetail();
                    LoadDataDetail(0);
                }
            }
            else
            {
                ddlBOMGroup.SelectedIndex = 0;
                txtBOMHeadCode.Text = string.Empty;
                txtBOMHeadName.Text = string.Empty;
                txtBOMHeadDescription.Text = string.Empty;
                txtRemark.Text = string.Empty;
            }

        }
        private void EnableMode()
        {
            if (modeHead == ObjectState.Edit)
            {
                ddlBOMGroup.Enabled = false;
                pnlDetail.Visible = true;
            }
            else
            {
                ddlBOMGroup.Enabled = true;
                pnlDetail.Visible = false;
            }
        }
        private BillOfMaterialHead GetData()
        {
            BillOfMaterialHead entity = new BillOfMaterialHead();
            entity.bill_of_material_group_id = Converts.ParseLong(ddlBOMGroup.SelectedValue.ToStringNullable());
            entity.bill_of_material_head_id = Converts.ParseLong(keyCode);
            entity.bill_of_material_head_code = txtBOMHeadCode.Text;
            entity.bill_of_material_head_name = txtBOMHeadName.Text;
            entity.bill_of_material_head_description = txtBOMHeadDescription.Text;
            entity.remark = txtRemark.Text;
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
                BillOfMaterialHead entity = GetData();
                if (modeHead == ObjectState.Add)
                {
                    int menuID = ServiceProvider.BillOfMaterialHeadService.Insert<int>(entity, new string[] { ValidationRuleset.Insert });

                    keyCode = menuID.ToString();
                    modeHead = ObjectState.Edit;
                    LoadData();
                }
                else
                {
                    ServiceProvider.BillOfMaterialHeadService.Update(entity, new string[] { ValidationRuleset.Update });
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
            grdDetail.DataSourceDataSet = ServiceProvider.BillOfMaterialDetailService.GetGridBillOfMaterialDetail(Converts.ParseLong(keyCode));
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
            long ID = Converts.ParseLong(dataKey[DataKeyName].ToString());
            LoadDataDetail(ID);
        }
        public void grdDetail_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)sender;
                List<BillOfMaterialDetail> listEntity = new List<BillOfMaterialDetail>();
                foreach (Dictionary<string, object> item in list)
                {
                    listEntity.Add(new BillOfMaterialDetail() { bill_of_material_detail_id = Converts.ParseLong(item[DataKeyName].ToString()) });
                }
                ServiceProvider.BillOfMaterialDetailService.Delete(listEntity, new string[] { ValidationRuleset.Delete });
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
        private void LoadDataDetail(long BOMDetailID)
        {
            ddlMaterial.DataSource = ServiceProvider.MaterialService.GetMaterialComboBoxDTO();
            ddlMaterial.ValueMember = "Value";
            ddlMaterial.DisplayMember = "Display";

            ddlBOMDetail.DataSource = ServiceProvider.BillOfMaterialHeadService.GetBillOfMaterialHeadComboBoxDTOByID(null);
            ddlBOMDetail.ValueMember = "Value";
            ddlBOMDetail.DisplayMember = "Display";

            BillOfMaterialDetail entity = new BillOfMaterialDetail();
            if (modeDetail == ObjectState.Edit && BOMDetailID != 0)
            {
                //---Detail
                entity.bill_of_material_detail_id = BOMDetailID;
                entity = ServiceProvider.BillOfMaterialDetailService.FindByKeys(entity, true);
                if (entity != null)
                {
                    if (entity.material_id != null)
                    {
                        rdbMaterial.Checked = true;
                        rdbBOM.Checked = false;
                        ddlMaterial.Enabled = true;
                        ddlBOMDetail.Enabled = false;

                        ddlMaterial.SelectedValue = entity.material_id.ToString();
                        GetUOM();
                    }
                    else
                    {
                        rdbMaterial.Checked = false;
                        rdbBOM.Checked = true;
                        ddlMaterial.Enabled = false;
                        ddlBOMDetail.Enabled = true;

                        ddlBOMDetail.SelectedValue = entity.bill_of_material_head_id_sub.ToString();
                    }
                    txtAmount.Text = string.Format(Format.IntegerNumberFormatNoZero, entity.amount);
                   
                    keyCodeDetail = entity.bill_of_material_detail_id;
                }
            }
            else
            {
                keyCodeDetail = 0;

                rdbMaterial.Checked = true;
                rdbBOM.Checked = false;

                ddlMaterial.Enabled = true;
                ddlBOMDetail.Enabled = false;

                ddlMaterial.SelectedIndex = 0;
                txtUOM.Text = string.Empty;
                ddlBOMDetail.SelectedIndex = 0;
                txtAmount.Text = string.Empty;
            }

            grdDetail.LoadData();
        }
        private BillOfMaterialDetail GetDataDetail()
        {
            BillOfMaterialDetail entity = new BillOfMaterialDetail();
            entity.bill_of_material_detail_id = keyCodeDetail;
            entity.bill_of_material_head_id = Converts.ParseLong(keyCode);

            if (modeDetail == ObjectState.Add)
            {
                entity.material_id = Converts.ParseLongNullable(ddlMaterial.SelectedValue.ToString());
                entity.bill_of_material_head_id_sub = Converts.ParseLongNullable(ddlBOMDetail.SelectedValue.ToString());
                entity.amount = Converts.ParseDecimalNullable(txtAmount.Text);
                entity.IsCheckedMaterial = rdbMaterial.Checked;
                entity.lost_factor = 0;
                entity.created_by = "SYSTEM";
                entity.created_date = DateTime.Now;
                entity.updated_by = "SYSTEM";
                entity.updated_date = DateTime.Now;
            }
            else
            {
                entity = ServiceProvider.BillOfMaterialDetailService.FindByKeys(entity, false);
                if (entity != null)
                {
                    entity.material_id = Converts.ParseLongNullable(ddlMaterial.SelectedValue.ToString());
                    entity.bill_of_material_head_id_sub = Converts.ParseLongNullable(ddlBOMDetail.SelectedValue.ToString());
                    entity.amount = Converts.ParseDecimalNullable(txtAmount.Text);
                    entity.IsCheckedMaterial = rdbMaterial.Checked;
                    entity.updated_by = "SYSTEM";
                    entity.updated_date = DateTime.Now;
                }
            }

            return entity;
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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
                BillOfMaterialDetail entity = entity = GetDataDetail();
                if (modeDetail == ObjectState.Add)
                {
                    ServiceProvider.BillOfMaterialDetailService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.BillOfMaterialDetailService.Update(entity, new string[] { ValidationRuleset.Update });
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

        private void rdbMaterial_MouseClick(object sender, MouseEventArgs e)
        {
            ddlMaterial.Enabled = true;
            ddlBOMDetail.SelectedIndex = 0;
            ddlBOMDetail.Enabled = false;
        }

        #endregion

        private void rdbBOM_MouseClick(object sender, MouseEventArgs e)
        {
            ddlBOMDetail.Enabled = true;
            ddlMaterial.SelectedIndex = 0;
            ddlMaterial.Enabled = false;
        }

        private void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUOM();
        }

        private void GetUOM()
        {
            if (ddlMaterial.SelectedIndex != 0)
            {
                Material material = ServiceProvider.MaterialService.FindByKeys(new Material() { material_id = Converts.ParseLong(ddlMaterial.SelectedValue.ToString()) }, false);
                if (material != null)
                {
                    UOM uom = ServiceProvider.UOMService.FindByKeys(new UOM() { uom_id = material.uom_id_use.Value }, false);

                    txtUOM.Text = uom != null ? uom.uom_name : string.Empty;
                }
            }
            else
            {
                txtUOM.Text = string.Empty;
            }
        }
    }
}
