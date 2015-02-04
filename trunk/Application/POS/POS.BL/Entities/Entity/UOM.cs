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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.UOM, POS.BL", TableMapping = "db_uom")]
    public class UOM : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue=true)]
        public long uom_id { get; set; }
        [EntityScalarProperty(DataCode = true)]
        public string uom_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string uom_name { get; set; }
        public string uom_description { get; set; }
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
