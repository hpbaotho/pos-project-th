using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Validations;
using Core.Standards.Attributes;
using Core.Standards.Entity;
using POS.BL.Utilities;
using POS.BL.DTO;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.ScreenConfig, POS.BL", TableMapping = "[sc_screen_config]")]

    public class ScreenConfig : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? control_id { get; set; }
        
        public string control_code { get; set; }
        public string control_type { get; set; }
        public string control_command { get; set; }
        public string control_command_group { get; set; }
        public int background_color { get; set; }
        public string background_image_path { get; set; }
        public int border_style { get; set; }
        public string display_text { get; set; }
        public int fore_color { get; set; }
        public string font { get; set; }
        public int position_top { get; set; }
        public int position_left { get; set; }
        public int control_width { get; set; }
        public int control_height { get; set; }
        public long? control_parent_id { get; set; }
        public decimal percent_width { get; set; }
        public decimal percent_height { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public string ObjectState { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void Validate(ValidationResults results)
        {
            if (string.IsNullOrEmpty(this.control_code) && this.control_parent_id == null)
            {
                ValidationResult result = new ValidationResult(ErrorMessage.ScreenCodeIsRequire, this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.ScreenConfigService.IsDuplication(this);
            if (listDuplicateItemDTO.Where(item => item.isDuplicate == true).FirstOrDefault() != null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Screen Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
    }
}
