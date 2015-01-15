using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;


namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.DocumentLastRunningNumber, POS.BL", TableMapping = "db_document_last_running_number")]

    public class DocumentLastRunningNumber : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long document_last_running_number_id { get; set; }
        public long? document_type_id { get; set; }
        public string document_number_value { get; set; }
        public long document_last_running_number { get; set; }

    }
}
