﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Core.Standards.Validations;
using POS.BL.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Period, POS.BL", TableMapping = "in_period")]
    public class Period : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long period_id { get; set; }
        public long? period_group_id { get; set; }
        public string period_code { get; set; }
        public DateTime? period_date { get; set; }
        public bool active { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (period_group_id == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Group"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(period_code))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Code"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (period_date == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Date"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
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
