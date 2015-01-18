using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.PhyLot, POS.BL", TableMapping = "[in_phy_lot]")]

    public class PhyLot : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long phy_lot_id { get; set; }
        public long? warehouse_id { get; set; }
        public double lot_no { get; set; }
        public long? material_id { get; set; }
        public DateTime? bf_date { get; set; }
        public DateTime? expire_date { get; set; }
        public double bf_qty { get; set; }
        public double bal_qty { get; set; }
    }
}
