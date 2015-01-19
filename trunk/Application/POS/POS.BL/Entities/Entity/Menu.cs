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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SOMenu, POS.BL", TableMapping = "so_menu")]

    public class SOMenu : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? menu_id { get; set; }
        public long? menu_category_id { get; set; }
        public long? menu_group_id { get; set; }
        public string menu_code { get; set; }
        public string menu_name { get; set; }
        public string menu_description { get; set; }
        public long? menu_reference_id { get; set; }
        public bool active { get; set; }
        public bool? isInventoryItem { get; set; }
        public int? priorityValue { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public decimal menu_price { get; set; }
        [EntityScalarProperty(PersistenceIgnorance = true)]
        public long? menu_dining_type_id { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (string.IsNullOrEmpty(menu_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Menu Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(menu_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Menu Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void ValidationDuplicate(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.MenuService.IsDuplicationMenu(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Menu Code"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }
    }
}
