using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Core.Standards.Validations;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using POS.BL.Utilities;
using POS.BL.DTO;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Material, POS.BL", TableMapping = "in_material")]

    public class Material : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long material_id { get; set; }
        public string material_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string material_name { get; set; }
        public string material_description { get; set; }
        public long? uom_id_receive { get; set; }
        public long? uom_id_count { get; set; }
        public long? uom_id_use { get; set; }
        public long? period_group_id { get; set; }
        //public decimal phy_lot { get; set; }
        //public decimal log_lot { get; set; }
        public bool active { get; set; }
        public byte[] material_pic { get; set; }
        public string status { get; set; }
        public long? material_group_id { get; set; }
        public decimal max_stock { get; set; }
        public decimal min_stock { get; set; }
        public double shelf_life { get; set; }
        public decimal material_cost { get; set; }
        public double acceptable_variance { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (string.IsNullOrEmpty(material_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(material_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (uom_id_receive == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "UOM Receive"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (uom_id_count == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "UOM Count"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (uom_id_use == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "UOM Use"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (max_stock == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Maximum Stock"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (min_stock == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Minimum Stock"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (shelf_life == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Shelf Life"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (material_cost == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Cost"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (acceptable_variance == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Acceptable Variance"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (material_group_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Group"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        public void CheckDuplicateInsert(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.MaterialService.IsDuplicationMaterial(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Material Code"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }
    }
}
