using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;
using Core.Standards.Validations;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using POS.BL.Utilities;
using POS.BL.DTO;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.PortfolioHead, POS.BL", TableMapping = "in_portfolio_head")]

    public class PortfolioHead : EntityBase, IEntityMasterBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long portfolio_head_id { get; set; }
        [EntityScalarProperty(DataCode = true)]
        public string portfolio_head_code { get; set; }
        public string portfolio_head_name { get; set; }
        public string portfolio_head_desc { get; set; }
        public bool active { get; set; }
    }
}
