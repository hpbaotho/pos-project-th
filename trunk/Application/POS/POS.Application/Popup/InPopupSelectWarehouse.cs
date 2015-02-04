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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Core.Standards.Exceptions;
using POS.BL.Utilities;
using POS.BL.DTO;

namespace POS.Popup
{
    public partial class InPopupSelectWarehouse : PopupBase
    {
        public InPopupSelectWarehouse()
        {
            InitializeComponent();
            this.ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
            this.ddlWarehouse.ValueMember = "Value";
            this.ddlWarehouse.DisplayMember = "Display";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ddlWarehouse.SelectedIndex != 0)
            {
                ComboBoxDTO dto = new ComboBoxDTO();
                dto.Display = this.ddlWarehouse.Text.Substring(this.ddlWarehouse.Text.LastIndexOf(":") + 1); ;
                dto.Value = this.ddlWarehouse.SelectedValue.ToString();                
                this.ClosePopup(dto);
            }
            else
            {
                ValidationResults results = new ValidationResults();
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehouse"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
                base.ShowErrorMessage(new ValidationException(results));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClosePopup();
        }
    }
}
