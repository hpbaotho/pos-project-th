using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Core.Standards.Validations;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Supplier, POS.BL", TableMapping = "db_supplier")]

    public class Supplier : EntityBase, IEntityMasterBase
    {
         [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
         public long supplier_id { get; set; }
        [EntityScalarProperty(DataCode = true)]
         public string supplier_code { get; set; }
         [EntityScalarProperty(ComboBoxDisplay = true)]
         public string supplier_name { get; set; }
         public string supplier_description { get; set; }
         public string supplier_address { get; set; }
         public string supplier_tel { get; set; }
         public string supplier_contract_person { get; set; }
         public bool active { get; set; }

         [SelfValidation(Ruleset = ValidationRuleset.Insert)]
         [SelfValidation(Ruleset = ValidationRuleset.Update)]
         public void EntityValidation(ValidationResults results)
         {
             //--- Required
           
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
