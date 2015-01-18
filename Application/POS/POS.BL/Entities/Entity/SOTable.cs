using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.SOTable, POS.BL", TableMapping = "[so_Table]")]

  public  class SOTable:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? table_id { get; set; }
        public string table_code { get; set; }
        public string table_name { get; set; }
        public string table_description { get; set; }
        public int? max_people { get; set; }
        public bool active { get; set; }
        public bool IsAvailable { get; set; }
    }
}
