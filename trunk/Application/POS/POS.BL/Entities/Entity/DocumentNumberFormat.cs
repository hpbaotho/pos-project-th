using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.DocumentNumberFormat, POS.BL", TableMapping = "db_document_number_format")]

    public class DocumentNumberFormat:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long document_number_format_id { get; set; }
        public long? document_type_id { get; set; }
        public string document_number_format_name { get; set; }
        public string document_number_format_description { get; set; }
        public bool active { get; set; }
    }
}
