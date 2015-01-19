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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MenuMapping, POS.BL", TableMapping = "so_menu_mapping")]
    public class MenuMapping : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long menu_mapping_id { get; set; }
        public long? menu_id { get; set; }
        public long? bill_of_material_head_id { get; set; }
        public decimal? quantity { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (menu_id == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Menu"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (bill_of_material_head_id == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Bill of Material Head"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (quantity == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Quantity"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            //---
            if (quantity <= 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueMore, "Quantity", 0), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void ValidationDuplicate(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.MenuMappingService.IsDuplicationMenuMapping(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Bill of Material Head"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }
    }
}
