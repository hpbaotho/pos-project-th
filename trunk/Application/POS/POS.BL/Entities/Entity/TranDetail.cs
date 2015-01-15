using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.TranDetail, POS.BL", TableMapping = "in_tran_detail")]

    public class TranDetail : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long tran_detail_id { get; set; }
        [EntityScalarProperty(ParentKey = true)]
        public long tran_head_id { get; set; }
        public long material_id { get; set; }
        public long warehouse_id_dest { get; set; }
        public double? quantity { get; set; }
        public string remark { get; set; }
        public double? lot_no { get; set; }
    }
}
