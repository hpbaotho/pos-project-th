using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.LogLot, POS.BL", TableMapping = "in_log_lot")]

    public class LogLot : EntityBase
    {
       [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
       public long log_lot_id { get; set; }
       public long? warehouse_id { get; set; }
       public long? material_id { get; set; }
       public DateTime bf_date { get; set; }
       public double bf_qty { get; set; }
    }
}
