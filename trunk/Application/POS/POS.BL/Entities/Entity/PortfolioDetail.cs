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
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.PortfolioDetail, POS.BL", TableMapping = "in_portfolio_detail")]

    public class PortfolioDetail : EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true, ComboBoxValue = true)]
        public long portfolio_detail_id { get; set; }
        public long portfolio_head_id { get; set; }
        public long material_id { get; set; }
    }
}
