using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.TranHead, POS.BL", TableMapping = "in_tran_head")]
    
    public class TranHead : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long tran_head_id { get; set; }
        public long document_type_id { get; set; }
        public string transaction_no { get; set; }
        public DateTime transaction_date { get; set; }
        public long transaction_status { get; set; }
        public string reference_no { get; set; }
        public long reason_id { get; set; }
        public long? supplier_id { get; set; }
        public long? warehouse_id { get; set; }
        public string other_source { get; set; }
        public string remark { get; set; }
    }
}
