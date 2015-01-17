using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using POS.BL.DTO;
using Core.Standards.Validations;
using POS.BL.Utilities;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.BillOfMaterialHead, POS.BL", TableMapping = "in_bill_of_material_head")]
    public class BillOfMaterialHead : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long bill_of_material_head_id { get; set; }
        public long? bill_of_material_group_id { get; set; }
        public string bill_of_material_head_code { get; set; }
        public string bill_of_material_head_name { get; set; }
        public string bill_of_material_head_description { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (bill_of_material_group_id == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill Of Material Group"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(bill_of_material_head_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill of Material Head Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(bill_of_material_head_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill Of Material Head Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        public void CheckDuplicateInsert(ValidationResults results)
        {
            //List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.EmployeeService.IsDuplicationEmployee(this);
            //if (listDuplicateItemDTO != null)
            //{
            //    if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
            //    {
            //        ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Employee No"), this, string.Empty, string.Empty, null);
            //        results.AddResult(result);
            //    }
            //}
        }
    }
}
