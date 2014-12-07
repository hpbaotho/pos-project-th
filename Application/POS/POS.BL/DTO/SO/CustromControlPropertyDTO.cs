using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Utilities;

namespace POS.BL.DTO.SO
{
    public class CustromControlPropertyDTO
    {
        public  CustromControlPropertyDTO() {
            this.control_type = ControlType.Button;
        }

        public long? control_id { get; set; }
        public long? control_parent_id { get; set; }

        public string control_type { get; set; }
        public string control_code { get; set; }
        public string ControlState { get; set; }
    }
}
