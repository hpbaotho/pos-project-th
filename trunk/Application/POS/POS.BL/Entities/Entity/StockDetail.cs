using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.StockDetail, POS.BL", TableMapping = "in_stock_detail")]

    public class StockDetail : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long stock_detail_id { get; set; }
        public long stock_head_id { get; set; }
        public long material_id { get; set; }        
        public DateTime bf_date { get; set; }
        public decimal lot_no { get; set; }
        public decimal bf_qty { get; set; }                
        public decimal bal_qty { get; set; }        
        public string remark { get; set; }
    }
}
