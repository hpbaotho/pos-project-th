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
        public DataSet GetGridEmployee(string EmployeeNo, string Name)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT employee_id, employee_group_id, employee_no, first_name, mid_name, last_name
                             , user_name, miss_login, created_by, created_date, updated_by, updated_date 
                             FROM db_employee 
                             WHERE 1=1 ");

            if (!string.IsNullOrEmpty(EmployeeNo))
            {
                sql.AppendLine(" AND CHARINDEX(@EmployeeNo,employee_no) > 0");
            }
            if (!string.IsNullOrEmpty(Name))
            {
                sql.AppendLine(@" AND (    CHARINDEX(@Name,first_name) > 0 
                                        OR CHARINDEX(@Name,mid_name) > 0
                                        OR CHARINDEX(@Name,last_name) > 0  
                                      )");
            }
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@EmployeeNo", EmployeeNo));
            param.Add(this.CreateParameter("@Name", Name));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }
    }
}
