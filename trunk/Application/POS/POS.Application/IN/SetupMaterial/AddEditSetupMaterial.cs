using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.BL;
using System.IO;
using Core.Standards.Validations;
using POS.BL.Utilities;
using Core.Standards.Exceptions;
using POS.BL.DTO;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace POS.IN.SetupMaterial
{
    public partial class AddEditSetupMaterial : BaseUserControl
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditSetupMaterial()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.SetInitialControl();
            this.Load += new EventHandler(AddEditSetupMaterial_Load);
        }
        public AddEditSetupMaterial(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.SetInitialControl();
            this.Load += new EventHandler(AddEditSetupMaterial_Load);
        }
        #endregion 

        #region :: Private Function ::
        private void AddEditSetupMaterial_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            Material entity = new Material();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                entity.material_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.MaterialService.FindByKeys(entity, true);

                txtMaterialCode.Text = entity.material_code;
                txtMaterialName.Text = entity.material_name;
                txtMaterialDescription.Text = entity.material_description;
                cboMaterailGroup.SelectedValue = entity.material_group_id.ToString();
                cboUOMReceive.SelectedValue = entity.uom_id_receive.ToString();
                cboUOMCount.SelectedValue = entity.uom_id_count.ToString();
                cboUOMUse.SelectedValue = entity.uom_id_use.ToString();
                chkActive.Checked = entity.active;
                txtMaxStock.Text = entity.max_stock.ToString();
                txtMinStock.Text = entity.min_stock.ToString();
                txtShelfLife.Text = entity.shelf_life.ToString();
                txtMaterialCost.Text = entity.material_cost.ToString();
                txtAcceptableVariance.Text = entity.acceptable_variance.ToString();
                if (entity.material_pic != null)
                {
                    picMaterial.Image = Image.FromStream(new MemoryStream(entity.material_pic));
                }
                else
                {
                    picMaterial.Image = null;
                }
            }
            else
            {
                txtMaterialCode.Text = String.Empty;
                txtMaterialName.Text = String.Empty;
                txtMaterialDescription.Text = String.Empty;
                cboMaterailGroup.SelectedValue = String.Empty;
                cboUOMReceive.SelectedValue = String.Empty;
                cboUOMCount.SelectedValue = String.Empty;
                cboUOMUse.SelectedValue = String.Empty;
                chkActive.Checked = false;
                txtMaxStock.Text = String.Empty;
                txtMinStock.Text = String.Empty;
                txtShelfLife.Text = String.Empty;
                txtMaterialCost.Text = String.Empty;
                txtAcceptableVariance.Text = String.Empty;
                picMaterial.Image = null;//Image.FromStream(new MemoryStream(entity.material_pic));
            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtMaterialCode.Enabled = false;
            }
            else
            {
                txtMaterialCode.Enabled = true;
            }
        }
        private Material GetData()
        {
            Material entity = new Material();
            entity.material_id = Converts.ParseLong(keyCode);
            entity.material_group_id = Converts.ParseLong(cboMaterailGroup.SelectedValue.ToString());
            entity.material_code = txtMaterialCode.Text;
            entity.material_name = txtMaterialName.Text;
            entity.material_description = txtMaterialDescription.Text;
            entity.uom_id_receive = Converts.ParseLong(cboUOMReceive.SelectedValue.ToString());
            entity.uom_id_count = Converts.ParseLong(cboUOMCount.SelectedValue.ToString());
            entity.uom_id_use = Converts.ParseLong(cboUOMUse.SelectedValue.ToString());
            entity.period_group_id = null;
            //entity.phy_lot = txtMidName.Text;
            //entity.log_lot = txtLastName.Text;
            entity.active = chkActive.Checked;
            entity.status = null;
            entity.max_stock = Converts.ParseDecimal(txtMaxStock.Text);
            entity.min_stock = Converts.ParseDecimal(txtMinStock.Text);
            entity.shelf_life = Converts.ParseDouble(txtShelfLife.Text);
            entity.material_cost = Converts.ParseDecimal(txtMaterialCost.Text);
            entity.acceptable_variance = Converts.ParseDouble(txtAcceptableVariance.Text);
            if (picMaterial.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picMaterial.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] buff = ms.GetBuffer();
                entity.material_pic = buff;
            }
            else
            {
                entity.material_pic = null;
            }
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion


        #region :: Event Action ::
        private void AddEditSetupMaterial_saveHandler()
        {
            try
            {
                Material entity = GetData();
                if (mode == ObjectState.Add)
                {
                    ServiceProvider.MaterialService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.MaterialService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        private void AddEditSetupMaterial_resetHandler()
        {
            LoadData();
        }

        private void SetInitialControl()
        {
            List<UOM> lstUOM = ServiceProvider.UOMService.FindAll(false).ToList();
            List<ComboBoxDTO> lstComboBoxDTOUOMReceive = new List<ComboBoxDTO>();
            List<ComboBoxDTO> lstComboBoxDTOUOMCount = new List<ComboBoxDTO>();
            List<ComboBoxDTO> lstComboBoxDTOUOMUse = new List<ComboBoxDTO>();
            foreach (UOM uom in lstUOM)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = uom.uom_id.ToString();
                DTO.Display = uom.uom_name;
                lstComboBoxDTOUOMReceive.Add(DTO);
                lstComboBoxDTOUOMCount.Add(DTO);
                lstComboBoxDTOUOMUse.Add(DTO);
            }
            lstComboBoxDTOUOMReceive.SetPleaseSelect();
            cboUOMReceive.DataSource = lstComboBoxDTOUOMReceive;
            cboUOMReceive.ValueMember = "Value";
            cboUOMReceive.DisplayMember = "Display";

            lstComboBoxDTOUOMCount.SetPleaseSelect();
            cboUOMCount.DataSource = lstComboBoxDTOUOMCount;
            cboUOMCount.ValueMember = "Value";
            cboUOMCount.DisplayMember = "Display";

            lstComboBoxDTOUOMUse.SetPleaseSelect();
            cboUOMUse.DataSource = lstComboBoxDTOUOMUse;
            cboUOMUse.ValueMember = "Value";
            cboUOMUse.DisplayMember = "Display";

            List<MaterialGroup> lstMatGroup = ServiceProvider.MaterialGroupService.FindAll(false).ToList();
            List<ComboBoxDTO> lstComboBoxDTOMatGroup= new List<ComboBoxDTO>();
            foreach (MaterialGroup matGroup in lstMatGroup)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = matGroup.material_group_id.ToString();
                DTO.Display = matGroup.material_group_name;
                lstComboBoxDTOMatGroup.Add(DTO);
            }
            lstComboBoxDTOMatGroup.SetPleaseSelect();
            cboMaterailGroup.DataSource = lstComboBoxDTOMatGroup;
            cboMaterailGroup.ValueMember = "Value";
            cboMaterailGroup.DisplayMember = "Display";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    picMaterial.Image = Image.FromFile(fileName);
                    txtMaterialPic.Text = fileName;
                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

    }
}
