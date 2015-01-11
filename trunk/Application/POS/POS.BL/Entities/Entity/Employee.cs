using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

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
    }
}
