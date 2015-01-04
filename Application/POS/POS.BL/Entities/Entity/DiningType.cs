using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.DiningType, POS.BL", TableMapping = "[db_dining_type]")]

    public class DiningType : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? dining_type_id { get; set; }
        public string dining_type_code { get; set; }
        public string dining_type_name { get; set; }
        public string dining_type_description { get; set; }
        public bool active { get; set; }
    }
}
