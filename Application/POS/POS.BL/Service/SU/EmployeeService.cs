using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.SU
{
    public class EmployeeService : ServiceBase<Employee>
    {
        public DataSet GetGridEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM db_employee ");

            return base.ExecuteQuery(sql.ToString());
        }
    }
}
