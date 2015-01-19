using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.StockHead, POS.BL", TableMapping = "in_stock_head")]

    public class StockHead : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long stock_head_id { get; set; }
        public long period_id { get; set; }
        public long document_type_id { get; set; }
        public long warehouse_id { get; set; }
        public string transaction_no { get; set; }
        public DateTime transaction_date { get; set; }
        public string transaction_status { get; set; }
        public string remark { get; set; }
    }
}
