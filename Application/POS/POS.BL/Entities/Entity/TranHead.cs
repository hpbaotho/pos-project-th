﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Core.Standards.Validations;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.TranHead, POS.BL", TableMapping = "in_tran_head")]

    public class TranHead : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long tran_head_id { get; set; }
        public long document_type_id { get; set; }
        public string transaction_no { get; set; }
        public DateTime transaction_date { get; set; }
        public string reference_no { get; set; }
        public long reason_id { get; set; }
        public long? supplier_id { get; set; }
        public long? warehouse_id { get; set; }
        public string other_source { get; set; }
        public string remark { get; set; }
        public bool is_cancel_order { get; set; }
        public long? order_no_id { get; set; }
        public long? cancel_reason_id { get; set; }

        //[SelfValidation(Ruleset = ValidationRuleset.ReceiveMaterialInsert)]        
        //public void EntityValidation(ValidationResults results)
        //{
        //    //--- Required
        //    if (string.IsNullOrEmpty(reference_no))
        //    {
        //        ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Employee No"), this, string.Empty, string.Empty, null);
        //        results.AddResult(result);
        //    }
        //    if (reason_id!=0)
        //    {
        //        ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "First Name"), this, string.Empty, string.Empty, null);
        //        results.AddResult(result);
        //    }            
        //}
    }
}
