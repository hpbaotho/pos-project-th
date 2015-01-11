using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;

namespace POS.BL.Service.DB
{
   public class WareHouseService:ServiceBase<WareHouse>
    {
       public List<WareHouse> FindWareHouseActive()
       {
           string sql = @" SELECT * FROM db_warehouse WITH(NOLOCK) WHERE active=1 ";
           return this.ExecuteQuery<WareHouse>(sql).ToList();

       }

    }
}
