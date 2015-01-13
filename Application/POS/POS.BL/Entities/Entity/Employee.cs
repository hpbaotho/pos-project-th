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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Employee, POS.BL", TableMapping = "db_employee")]
    
    public class Employee : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long employee_id { get; set; }
        public long employee_group_id { get; set; }
        public string employee_no { get; set; }
        public string first_name { get; set; } 
        public string mid_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string miss_login { get; set; }

        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        [SelfValidation(Ruleset = ValidationRuleset.Update)]
        public void EntityValidation(ValidationResults results)
        {
            //--- Required
            if (string.IsNullOrEmpty(employee_no))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Employee No"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(first_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "First Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(last_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Last Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(user_name))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "User Name"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (string.IsNullOrEmpty(user_password))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Password"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
        }
        [SelfValidation(Ruleset = ValidationRuleset.Insert)]
        public void CheckDuplicateInsert(ValidationResults results)
        {
            List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.EmployeeService.IsDuplicationEmployee(this);
            if (listDuplicateItemDTO != null)
            {
                if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Employee No"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
        }
        //[SelfValidation(Ruleset = ValidationRuleset.Update)]
        //public void CheckDuplicateUpdate(ValidationResults results)
        //{
        //    List<DuplicateItemDTO> listDuplicateItemDTO = ServiceProvider.AllocableAFEService.IsDuplicationAllocableAFE(this);
        //    if (
        //        (
        //           JVCode != Previous_JVCode
        //        || FieldCode != Previous_FieldCode
        //        )
        //        && listDuplicateItemDTO != null)
        //    {
        //        if (listDuplicateItemDTO.Where(item => item.ColumnName == "Key").Select(item => item.isDuplicate).FirstOrDefault())
        //        {
        //            ValidationResult result = new ValidationResult(string.Format(ErrorMessages.IsDuplicate, "Allocable AFE"), this, string.Empty, string.Empty, null);
        //            results.AddResult(result);
        //        }
        //    }
        //}
    }
}
