using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MenuMapping, POS.BL", TableMapping = "so_menu_mapping")]
    public class MenuMapping : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long menu_mapping_id { get; set; }
        public long menu_id { get; set; }
        public long bill_of_material_head_id { get; set; }
        public decimal quantity { get; set; }
    }
}
