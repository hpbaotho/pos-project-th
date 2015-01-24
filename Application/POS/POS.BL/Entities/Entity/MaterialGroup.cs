using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.MaterialGroup, POS.BL", TableMapping = "in_material_group")]

    public class MaterialGroup : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long material_group_id { get; set; }
        public string material_group_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string material_group_name { get; set; }
        public string material_group_desc { get; set; }
        public bool active { get; set; }
    }
}
