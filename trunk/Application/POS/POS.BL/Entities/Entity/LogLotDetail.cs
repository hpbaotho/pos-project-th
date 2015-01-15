using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.LogLotDetail, POS.BL", TableMapping = "[in_log_lot_detail]")]

    public class LogLotDetail:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long log_lot_detail { get; set; }
        public long? phy_log_lot_head_id { get; set; }
        public long? material_id { get; set; }
        public double quantity { get; set; }
    }
}
