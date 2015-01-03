using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class TranHeadService : ServiceBase<TranHead>
    {
        public DataSet GetGridEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM in_tran_head ");

            return base.ExecuteQuery(sql.ToString());
        }
    }
}
