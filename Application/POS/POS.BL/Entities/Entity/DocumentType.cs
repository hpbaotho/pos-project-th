using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.DocumentType, POS.BL", TableMapping = "db_document_type")]

    public class DocumentType:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long document_type_id { get; set; }
        public string document_type_name { get; set; }
        public string document_type_description { get; set; }
        public bool active { get; set; }
        public long? company_branch_id { get; set; }
    }
}
