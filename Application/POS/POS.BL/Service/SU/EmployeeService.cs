using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;
using POS.BL.DTO;

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

        public List<DuplicateItemDTO> IsDuplicationEmployee(Employee employee)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [db_employee]  WITH(NOLOCK)
                                WHERE  employee_no = @employee_no
            ");

            //---Edit
            if (employee.employee_id > 0)
            {
                strSql.AppendLine(" AND employee_id <>  employee_id ");
            }

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("employee_no", employee.employee_no));
            param.Add(base.CreateParameter("employee_id", employee.employee_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
    }
}
