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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.WareHouse, POS.BL", TableMapping = "db_warehouse")]

    public class WareHouse : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long warehouse_id { get; set; }
        [EntityScalarProperty(DataCode = true)]
        public string warehouse_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string warehouse_name { get; set; }
        public string warehouse_description { get; set; }
        public long? company_branch_id { get; set; }
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
