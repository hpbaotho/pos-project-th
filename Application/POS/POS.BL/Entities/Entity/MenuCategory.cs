using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MenuCategory, POS.BL", TableMapping = "so_menu_category")]

    public class MenuCategory:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? menu_category_id { get; set; }
        public string menu_category_code { get; set; }
        public string menu_category_name { get; set; }
        public string menu_group_description { get; set; }
        public int priorityValue { get; set; }
        public bool active { get; set; }
        public bool isCombo { get; set; }
        public bool isCondiment { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public long? dining_type_id { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public long? menu_group_id { get; set; }
    }
}
