using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.OrderCheck, POS.BL", TableMapping = "[so_order_check]")]

    public class OrderCheck : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? order_check_id { get; set; }
        public long? period_id { get; set; }
        public int CheckNo { get; set; }
    }
}
