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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Reason, POS.BL", TableMapping = "db_reason")]
    public class Reason : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long reason_id { get; set; }
        public string reason_name { get; set; }
        public string reason_description { get; set; }
        public string module { get; set; }
        public long? document_type_id { get; set; }
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
