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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.UOMRatio, POS.BL", TableMapping = "db_uom_ratio")]
    public class UOMRatio : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long uom_ratio_id { get; set; }
        public long? uom_id_from { get; set; }
        public long? uom_id_to { get; set; }
        public string uom_ratio_description { get; set; }
        public decimal? uom_ratio { get; set; }
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
