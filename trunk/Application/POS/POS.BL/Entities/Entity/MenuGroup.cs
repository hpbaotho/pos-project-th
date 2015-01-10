using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MenuGroup, POS.BL", TableMapping = "so_menu_group")]
    public class MenuGroup : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? menu_group_id { get; set; }
        public string menu_group_code { get; set; }
        public string menu_group_name { get; set; }
        public string menu_group_description { get; set; }
        public int priorityValue { get; set; }
        public bool active { get; set; }

        [EntityScalarProperty(PersistenceIgnorance = true)]
        public long? dining_type_id { get; set; }
    }
}
