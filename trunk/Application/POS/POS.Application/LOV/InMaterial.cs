using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.DTO.SO;
using POS.Control;
using POS.BL;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;

namespace POS.LOV
{
    public partial class InMaterial : PopupBase
    {
        string DataKeyID = "ID";
        public InMaterial()
        {
            InitializeComponent();
        }
        private void grdBase_onLoadDataGrid(object sender, Control.GridView.DataBindArgs e)
        {
            Material entity = new Material();
            entity.material_name = txtName.Text;
            entity.material_description = txtDesc.Text;
            entity.material_code = txtCode.Text;
            if (cbxGroup.SelectedIndex > 0)
            {
                entity.material_group_id = cbxGroup.SelectedValue.ToLong();
            }
            grdBase.DataSourceDataSet = ServiceProvider.MaterialService.GetGridMaterial(entity);

            grdBase.DataKeyName = new string[] { DataKeyID };
            grdBase.HiddenColumnName = new List<string>() { "ID", "Group Id", "Acceptable Variance", "Picture" };

            //try to set its visibility 
            this.grdBase.btnAddVisible = false;
            this.grdBase.btnDeleteVisible = false;
            this.grdBase.btnAddEnable = false;
            this.grdBase.btnDeleteEnable = false;
            grdBase.RearrangeButton();
        }
        private void InMaterial_Load(object sender, EventArgs e)
        {
            cbxGroup.DataSource = ServiceProvider.MaterialGroupService.FindByActiveOrID();
            cbxGroup.ValueMember = "Value";
            cbxGroup.DisplayMember = "Display";
        }
        private void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            Material entity = new Material();
            entity.material_id = dataKey[DataKeyID].ToLong();
            entity = ServiceProvider.MaterialService.FindByKeys(entity, false);
            this.ClosePopup(entity);
        }
    }
}
