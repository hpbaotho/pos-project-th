using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Period, POS.BL", TableMapping = "in_period")]
    public class Period : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long period_id { get; set; }
        public long? period_group_id { get; set; }
        public string period_code { get; set; }
        public DateTime period_date { get; set; }
        public bool active { get; set; }
    }
}
