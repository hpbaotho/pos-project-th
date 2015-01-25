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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MaterialGroup, POS.BL", TableMapping = "in_material_group")]

    public class MaterialGroup : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long material_group_id { get; set; }
        public string material_group_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string material_group_name { get; set; }
        public string material_group_desc { get; set; }
        public bool active { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (string.IsNullOrEmpty(material_group_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(material_group_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        public void CheckDuplicateInsert(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.MaterialGroupService.IsDuplicationMaterialGroup(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Material Group Code"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }

    }
}
