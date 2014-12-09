using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Role, POS.BL", TableMapping = "sc_role")]

    public class Role : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long role_id { get; set; }
        public string role_name { get; set; }
        public bool active { get; set; }
    }
}
