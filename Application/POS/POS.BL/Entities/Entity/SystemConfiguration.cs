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
    [EntityMapping(EntityTypeName = "AFEOnline.BL.Entities.Entity.SystemConfiguration, AFEOnline.BL", TableMapping = "AFE_System_Configuration")]

    public class SystemConfiguration : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public int SystemConfigurationId { get; set; }

        public string SystemConfigurationGroupCode { get; set; }

        public string SystemConfigurationCode { get; set; }

        public string SystemConfigurationName { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }

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
