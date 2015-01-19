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

    public class Material : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long material_id { get; set; }
        public string material_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string material_name { get; set; }
        public string material_description { get; set; }
        public long? uom_id_receive { get; set; }
        public long? uom_id_count { get; set; }
        public long? uom_id_use { get; set; }
        public long? period_group_id { get; set; }
        public decimal phy_lot { get; set; }
        public decimal log_lot { get; set; }
        public bool active { get; set; }
        public string material_pic_path { get; set; }
        public string status { get; set; }
        public long? material_group_id { get; set; }
        public decimal max_stock { get; set; }
        public decimal min_stock { get; set; }
        public double shelf_life { get; set; }
        public decimal material_cost { get; set; }
        public double acceptable_variance { get; set; }
    }
}
