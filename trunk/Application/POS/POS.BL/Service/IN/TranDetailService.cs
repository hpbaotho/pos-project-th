using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class TranDetailService : ServiceBase<TranDetail>
    {
        public DataSet GetGridEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM in_tran_detail ");

            return base.ExecuteQuery(sql.ToString());
        }
    }
}
