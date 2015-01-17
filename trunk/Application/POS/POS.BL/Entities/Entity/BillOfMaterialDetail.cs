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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.BillOfMaterialDetail, POS.BL", TableMapping = "in_bill_of_material_detail")]
    public class BillOfMaterialDetail : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long bill_of_material_detail_id { get; set; }
        public long? bill_of_material_head_id { get; set; }
        public long? material_id { get; set; }
        public long? bill_of_material_head_id_sub { get; set; }
        public decimal? amount { get; set; }
        public int? lost_factor { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (bill_of_material_head_id == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill Of Material Head"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (bill_of_material_head_id_sub == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill of Material Head Sub"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (amount == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Amount"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (lost_factor == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Lost Factor"), this, string.Empty, string.Empty, null);
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
