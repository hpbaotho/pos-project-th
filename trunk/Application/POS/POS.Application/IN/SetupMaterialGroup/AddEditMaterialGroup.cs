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
using Core.Standards.Validations;
using POS.BL.Utilities;
using Core.Standards.Exceptions;

namespace POS.IN.SetupMaterialGroup
{
    public partial class AddEditMaterialGroup : BaseUserControl
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditMaterialGroup()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditMaterialGroup_Load);
        }
        public AddEditMaterialGroup(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditMaterialGroup_Load);
        }
        #endregion

        #region :: Private Function ::
        private void AddEditMaterialGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            MaterialGroup entity = new MaterialGroup();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                entity.material_group_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.MaterialGroupService.FindByKeys(entity, true);

                txtMatGroupCode.Text = entity.material_group_code;
                txtMatGroupName.Text = entity.material_group_name;
                txtMatGroupDesc.Text = entity.material_group_desc;
                chkActive.Checked = entity.active;
            }
            else
            {
                txtMatGroupCode.Text = String.Empty;
                txtMatGroupName.Text = String.Empty;
                txtMatGroupDesc.Text = String.Empty;
                chkActive.Checked = false;
            }
            EnableMode();
        }

        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtMatGroupCode.Enabled = false;
            }
            else
            {
                txtMatGroupCode.Enabled = true;
            }
        }

        private MaterialGroup GetData()
        {
            MaterialGroup entity = new MaterialGroup();
            entity.material_group_id = Converts.ParseLong(keyCode);
            entity.material_group_code = txtMatGroupCode.Text;
            entity.material_group_name = txtMatGroupName.Text;
            entity.material_group_desc = txtMatGroupDesc.Text;
            entity.active = chkActive.Checked;

            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void AddEditMaterialGroup_saveHandler()
        {
            try
            {
                MaterialGroup entity = GetData();
                if (mode == ObjectState.Add)
                {
                    ServiceProvider.MaterialGroupService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.MaterialGroupService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        private void AddEditMaterialGroup_resetHandler()
        {
            LoadData();
        }
        #endregion
    }
}
