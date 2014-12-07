using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.DTO
{
  public  class DuplicateItemDTO
    {
        public string ColumnName { get; set; }
        public bool isDuplicate { get; set; }
    }
}
