using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Validations;
using Core.Standards.Attributes;
using Core.Standards.Entity;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SystemConfiguration, POS.BL", TableMapping = "cbs_system_configuration")]

    public class SystemConfiguration : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public int system_configuration_id { get; set; }

        public string system_configuration_group_code { get; set; }

        public string system_configuration_code { get; set; }

        public string system_configuration_name { get; set; }

        public string description { get; set; }
        public string value { get; set; }
        public string value_type { get; set; }
        public bool active { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public string Module { get; set; }
        
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
