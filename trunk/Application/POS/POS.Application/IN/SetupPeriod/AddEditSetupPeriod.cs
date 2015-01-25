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
using POS.BL.DTO;

namespace POS.IN.SetupPeriod
{
    public partial class AddEditSetupPeriod : BaseUserControl
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditSetupPeriod()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.SetInitialControl();
            this.Load += new EventHandler(AddEditSetupPeriod_Load);
        }

        public AddEditSetupPeriod(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.SetInitialControl();
            this.Load += new EventHandler(AddEditSetupPeriod_Load);
        }
        #endregion


        #region :: Private Function ::
        private void AddEditSetupPeriod_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            Period entity = new Period();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                entity.period_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.PeriodService.FindByKeys(entity, true);

                txtPeriodCode.Text = entity.period_code;
                dpPeriodDate.Value = entity.period_date.Value;
                cboPeriodGr.SelectedValue = entity.period_group_id.ToString();
                chkActive.Checked = entity.active;
            }
            else
            {
                txtPeriodCode.Text = String.Empty;
                dpPeriodDate.Value = DateTime.Now;
                cboPeriodGr.SelectedValue = String.Empty;
                chkActive.Checked = false;
            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtPeriodCode.Enabled = false;
            }
            else
            {
                txtPeriodCode.Enabled = true;
            }
        }
        private Period GetData()
        {
            Period entity = new Period();
            entity.period_id = Converts.ParseLong(keyCode);
            entity.period_group_id = Converts.ParseLong(cboPeriodGr.SelectedValue.ToString());
            entity.period_code = txtPeriodCode.Text;
            entity.period_date = dpPeriodDate.Value;
            entity.active = chkActive.Checked;

            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void AddEditSetupPeriod_saveHandler()
        {
            try
            {
                Period entity = GetData();
                if (mode == ObjectState.Add)
                {
                    ServiceProvider.PeriodService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.PeriodService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        private void AddEditSetupPeriod_resetHandler()
        {
            LoadData();
        }

        private void SetInitialControl()
        {
            List<PeriodGroup> lstPeriodGroup = ServiceProvider.PeriodGroupService.FindAll(false).ToList();
            List<ComboBoxDTO> lstComboBoxDTOPeriodGroup = new List<ComboBoxDTO>();
            foreach (PeriodGroup periodGr in lstPeriodGroup)
            {
                if (periodGr.active)
                {
                    ComboBoxDTO DTO = new ComboBoxDTO();
                    DTO.Value = periodGr.period_group_id.ToString();
                    DTO.Display = periodGr.period_group_name;
                    lstComboBoxDTOPeriodGroup.Add(DTO);
                }
            }
            lstComboBoxDTOPeriodGroup.SetPleaseSelect();
            cboPeriodGr.DataSource = lstComboBoxDTOPeriodGroup;
            cboPeriodGr.ValueMember = "Value";
            cboPeriodGr.DisplayMember = "Display";
        }
        #endregion
    }
}
