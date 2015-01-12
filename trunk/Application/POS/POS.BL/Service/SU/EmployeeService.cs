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
            sql.AppendLine(@"SELECT employee_id AS ID, employee_group_id AS [Group ID], employee_no AS [Employee No], first_name AS [First Name], mid_name AS [Mid Name], last_name AS [Last Name]
                             , user_name AS [User Name], miss_login AS [Miss Login], created_by AS [Created By], created_date AS [Created Date], updated_by AS [Updated By], updated_date AS [Updated Date] 
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
