using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MenuDiningType, POS.BL", TableMapping = "[so_menu_dining_type]")]
    public class MenuDiningType : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? menu_dining_type_id { get; set; }
        public long? menu_id { get; set; }
        public long? dining_type_id { get; set; }
        public decimal menu_price { get; set; }
        public long? ref_menu_dining_type_id { get; set; }
        public DateTime? menu_effective_date { get; set; }
    }
}
