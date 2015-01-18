using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SOMenu, POS.BL", TableMapping = "so_menu")]

    public class SOMenu : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? menu_id { get; set; }
        public string menu_code { get; set; }
        public string menu_name { get; set; }
        public string menu_description { get; set; }
        public long? menu_reference_id { get; set; }
        public bool active { get; set; }
        public bool? isInventoryItem { get; set; }
        public long? menu_group_id { get; set; }
        public long? menu_category_id { get; set; }
        public int? priorityValue { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public decimal menu_price { get; set; }
        [EntityScalarProperty(PersistenceIgnorance = true)]
        public long? menu_dining_type_id { get; set; }
    }
}
