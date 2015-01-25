using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class PeriodGroupService : ServiceBase<PeriodGroup>
    {
        public DataSet GetGridPeriodGroup(string periodGroupCode, string periodGroupName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   SELECT period_group_id AS ID, period_group_code AS [Period Group Code]
		                                , period_group_name AS [Period Group Name], period_group_description AS [Period Group Description]
		                                , active AS Active 
                                FROM in_period_group
                                WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(periodGroupCode))
            {
                sql.AppendLine(@" AND CHARINDEX(@PeriodGroupCode, period_group_code) > 0 ");
            }
            if (!string.IsNullOrEmpty(periodGroupName))
            {
                sql.AppendLine(@" AND ( CHARINDEX(@PeriodGroupName, period_group_name) > 0
		                                OR CHARINDEX(@PeriodGroupName, period_group_description) > 0
	                                  ) ");
            }
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@PeriodGroupCode", periodGroupCode));
            param.Add(this.CreateParameter("@PeriodGroupName", periodGroupName));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<DuplicateItemDTO> IsDuplicationPeriodeGroup(PeriodGroup periodGroup)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [in_period_group]  WITH(NOLOCK)
                                WHERE  period_group_code = @period_group_code
                                ");

            //---Edit
            //if (material.material_id > 0)
            //{
            //    strSql.AppendLine(" AND material_id <>  material_id ");
            //}

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("period_group_code", periodGroup.period_group_code));
            //param.Add(base.CreateParameter("employee_id", material.material_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
    }
}
