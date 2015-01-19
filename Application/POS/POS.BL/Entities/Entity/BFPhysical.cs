using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.BFPhysical, POS.BL", TableMapping = "in_bf_physical")]

    public class BFPhysical : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long bf_physical_id { get; set; }
        public long period_id { get; set; }
        public long warehouse_id { get; set; }
        public long material_id { get; set; }        
        public decimal bf_qty { get; set; }
        public decimal lot_no { get; set; }
        public decimal bal_qty { get; set; }
    }
}
