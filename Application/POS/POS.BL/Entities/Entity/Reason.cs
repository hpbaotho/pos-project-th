using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Reason, POS.BL", TableMapping = "db_reason")]
    public class Reason:EntityBase
    {
        public long reason_id { get; set; }
        public string reason_name { get; set; }
        public string reason_description { get; set; }
        public string module { get; set; }
        public long? document_type_id { get; set; }
        public bool active { get; set; }
    }
}
