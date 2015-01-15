using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Material, POS.BL", TableMapping = "in_material")]

   public class Material :EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long material_id { get; set; }
        public string material_code { get; set; }
        public string material_name { get; set; }
        public string material_description { get; set; }
        public long? uom_id_receive { get; set; }
        public long? uom_id_count { get; set; }
        public long? uom_id_use { get; set; }
        public bool active { get; set; }
        public long? period_group_id { get; set; }
        public double phy_lot { get; set; }
        public double log_lot { get; set; }
        public string material_pic_path { get; set; }
        public string status { get; set; }
    }
}
