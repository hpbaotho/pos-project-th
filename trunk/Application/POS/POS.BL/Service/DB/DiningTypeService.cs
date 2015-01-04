using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;

namespace POS.BL.Service.DB
{
  public  class DiningTypeService:ServiceBase<DiningType>
    {
      public List<DiningType> FindDinningTypeActive() {
          string sql = @" SELECT * FROM db_dining_type WITH(NOLOCK) WHERE active=1 ";
          return this.ExecuteQuery<DiningType>(sql).ToList();

      }
    }
}
