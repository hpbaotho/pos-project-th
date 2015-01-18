using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SaleOrderDetail, POS.BL", TableMapping = "[so_sales_order_detail]")]
    public class SaleOrderDetail : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? sales_order_detail_id { get; set; }
        public long? condiment_of_order_detail_id { get; set; }
        public long? sales_order_head_id { get; set; }
        public long? menu_dining_type_id { get; set; }
        public int order_amount { get; set; }
        public bool is_print { get; set; }
        public bool is_cancel { get; set; }
        public int ChkNo { get; set; }
        public string Open_Condiment { get; set; }
    }
}
