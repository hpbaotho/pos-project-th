using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;

namespace POS.BL.Service.DB
{
   public class SupplierService:ServiceBase<Supplier>
    {
       public List<Supplier> FindSupplierActive()
       {
           string sql = @" SELECT * FROM db_supplier WITH(NOLOCK) WHERE active=1 ";
           return this.ExecuteQuery<Supplier>(sql).ToList();

       }
    }
}
