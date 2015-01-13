using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.WareHouse, POS.BL", TableMapping = "db_warehouse")]

    public class WareHouse : EntityBase 
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long warehouse_id { get; set; }
        public string warehouse_code { get; set; }
        [EntityScalarProperty(ComboBoxDisplay = true)]
        public string warehouse_name { get; set; }
        public string warehouse_description { get; set; }
        public long? company_branch_id { get; set; }
        public bool active { get; set; }



    }
}
