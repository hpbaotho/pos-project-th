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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SystemConfigGroup, POS.BL", TableMapping = "db_system_configuration_group")]

    public class SystemConfigGroup : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = false)]
        public string system_configuration_group_code { get; set; }
        public string system_configuration_group_name { get; set; }
        public string system_configuration_group_description { get; set; }
    

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void CheckDuplicateSystemConfiguration(ValidationResults results)
        {
            //if (ServiceProvider.SystemConfigurationService.CheckDuplicateSystemConfiguration(this))
            //{
            //    ValidationResult result = new ValidationResult(ErrorMessage.CustomDuplicateData.Replace("{DataField}", "System Configuration").Replace("{Container}", "system"), this, string.Empty, string.Empty, null);
            //    results.AddResult(result);
            //}
        }
    }
}
