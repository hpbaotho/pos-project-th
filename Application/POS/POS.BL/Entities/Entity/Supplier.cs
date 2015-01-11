using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.Supplier, POS.BL", TableMapping = "db_supplier")]

    public class Supplier : EntityBase
    {
         [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
         public long supplier_id { get; set; }
         public string supplier_code { get; set; }
         public string supplier_name { get; set; }
         public string supplier_description { get; set; }
         public string supplier_address { get; set; }
         public string supplier_tel { get; set; }
         public string supplier_contract_person { get; set; }
         public bool active { get; set; }

    }
}
