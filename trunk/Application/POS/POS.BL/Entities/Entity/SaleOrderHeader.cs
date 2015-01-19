using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SaleOrderHeader, POS.BL", TableMapping = "[so_sales_order_head]")]
    public class SaleOrderHeader:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? sales_order_head_id { get; set; }
        public long? period_id { get; set; }
        public long? table_id { get; set; }
        public DateTime? sales_order_date { get; set; }
        public string take_order_by { get; set; }
        public DateTime take_order_date { get; set; }
        public bool is_cancel { get; set; }
        public bool is_start_time { get; set; }
        public DateTime? eating_start_time { get; set; }
        public int Person { get; set; }
        public bool is_payment_procress { get; set; }
        public string order_no { get; set; }
    }
}
