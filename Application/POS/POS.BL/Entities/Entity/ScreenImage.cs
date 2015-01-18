using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Core.Standards.Attributes;

namespace POS.BL.Entities.Entity
{
    [HasSelfValidation]
    [EntityMapping(EntityTypeName = "POS.BL.Entities.Entity.ScreenImage, POS.BL", TableMapping = "sc_screen_image")]

  public  class ScreenImage:EntityBase
    {
        [EntityScalarProperty(EntityKey = true, IdentityKey = true)]
        public long? sc_screen_image_id { get; set; }
        public long? control_id { get; set; }
        public byte[] image { get; set; }
    }
}
