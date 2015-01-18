using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.Entities.Entity
{
    public class OrderCheck : EntityBase
    {
        public int CheckNo {get;set;}
        public int period_id { get; set; }
    }
}
