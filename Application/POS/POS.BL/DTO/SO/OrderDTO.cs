using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.DTO.SO
{
public    class OrderDTO
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuStatus { get; set; }
        public int Qty { get; set; }
    }
}
