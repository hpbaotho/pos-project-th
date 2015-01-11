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
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long warehouse_id { get; set; }
        public string warehouse_code { get; set; }
        public string warehouse_name { get; set; }
        public string warehouse_description { get; set; }
        public long? company_branch_id { get; set; }
        public bool active { get; set; }
 //       public string created_by { get; set; }
 //       public DateTime created_date { get; set; }
 //       public string updated_by { get; set; }
 //       public DateTime updated_date { get; set; }

       
    }
}
