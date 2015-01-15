using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.Entities
{
    public interface IEntityMasterBase
    {
        bool active { get; set; }
    }
}
