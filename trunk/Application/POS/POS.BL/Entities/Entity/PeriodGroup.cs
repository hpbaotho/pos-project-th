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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.PeriodGroup, POS.BL", TableMapping = "in_period_group")]
    public class PeriodGroup : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long period_group_id { get; set; }
        [EntityScalarProperty(ComboBoxCode = true)]
        public string period_group_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string period_group_name { get; set; }
        public string period_group_description { get; set; }
        public bool active { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (string.IsNullOrEmpty(period_group_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Group Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(period_group_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Group Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        public void CheckDuplicateInsert(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.PeriodGroupService.IsDuplicationPeriodeGroup(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Period Group Code"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }
    }
}
