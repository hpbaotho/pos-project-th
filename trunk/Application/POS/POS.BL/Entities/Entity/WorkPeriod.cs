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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.WorkPeriod, POS.BL", TableMapping = "db_period")]

    public class WorkPeriod : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public int period_id { get; set; }

        public string period_code { get; set; }

        public string period_name { get; set; }

        public string period_description { get; set; }

        public string open_period_by { get; set; }
        public DateTime? open_period_date { get; set; }
        public string close_period_by { get; set; }
        public DateTime? close_period_date { get; set; }
        public bool active { get; set; }

        //[StringLengthValidator(1, 300, Ruleset = ValidationRuleset.Insert, MessageTemplateResourceType = typeof(ErrorMessage), MessageTemplateResourceName = "RequiredField", Tag = "AFE Type : AFE Name")]
        //[StringLengthValidator(1, 300, Ruleset = ValidationRuleset.Update, MessageTemplateResourceType = typeof(ErrorMessage), MessageTemplateResourceName = "RequiredField", Tag = "AFE Type : AFE Name")]


        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void CheckDuplicateWorkPeriod(ValidationResults results)
        {
            //if (ServiceProvider.SystemConfigurationService.CheckDuplicateSystemConfiguration(this))
            //{
            //    ValidationResult result = new ValidationResult(ErrorMessage.CustomDuplicateData.Replace("{DataField}", "System Configuration").Replace("{Container}", "system"), this, string.Empty, string.Empty, null);
            //    results.AddResult(result);
            //}
        }
    }
}

