using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;

namespace POS.BL.Service.DB
{
   public class WareHouseService:ServiceBase<WareHouse>
    {
       public List<ComboBoxDTO> FindWareHouseActive()
       {
           string sql = @" SELECT warehouse_id AS Value, warehouse_name AS Display FROM db_warehouse WITH(NOLOCK) WHERE active=1 ";
           return this.ExecuteQuery<ComboBoxDTO>(sql).ToList();

       }

    }
}
