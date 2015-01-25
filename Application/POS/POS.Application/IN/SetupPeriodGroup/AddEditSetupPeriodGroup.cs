using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.BL;
using Core.Standards.Validations;
using POS.BL.Utilities;
using Core.Standards.Exceptions;
using POS.Control;

namespace POS.IN.SetupPeriodGroup
{
    public partial class AddEditSetupPeriodGroup : BaseUserControl
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditSetupPeriodGroup()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditSetupPeriodGroup_Load);
        }
        public AddEditSetupPeriodGroup(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditSetupPeriodGroup_Load);
        }
        #endregion


        #region :: Private Function ::
        private void AddEditSetupPeriodGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            PeriodGroup entity = new PeriodGroup();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                entity.period_group_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.PeriodGroupService.FindByKeys(entity, true);

                txtPeriodGrCode.Text = entity.period_group_code;
                txtPeriodGrName.Text = entity.period_group_name;
                txtPeriodGrDesc.Text = entity.period_group_description;
                chkActive.Checked = entity.active;
            }
            else
            {
                txtPeriodGrCode.Text = String.Empty;
                txtPeriodGrName.Text = String.Empty;
                txtPeriodGrDesc.Text = String.Empty;
                chkActive.Checked = false;
            }
            EnableMode();
        }

        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtPeriodGrCode.Enabled = false;
            }
            else
            {
                txtPeriodGrCode.Enabled = true;
            }
        }

        private PeriodGroup GetData()
        {
            PeriodGroup entity = new PeriodGroup();
            entity.period_group_id = Converts.ParseLong(keyCode);
            entity.period_group_code = txtPeriodGrCode.Text;
            entity.period_group_name = txtPeriodGrName.Text;
            entity.period_group_description = txtPeriodGrDesc.Text;
            entity.active = chkActive.Checked;

            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void AddEditSetupPeriodGroup_saveHandler()
        {
            try
            {
                PeriodGroup entity = GetData();
                if (mode == ObjectState.Add)
                {
                    ServiceProvider.PeriodGroupService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.PeriodGroupService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        private void AddEditSetupPeriodGroup_resetHandler()
        {
            LoadData();
        }
        #endregion
    }
}
