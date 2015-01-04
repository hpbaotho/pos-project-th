using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using System.Data.Common;
using System.Data;
using Core.Standards.Converters;

namespace POS.BL.Service.SO
{
    public class WorkPeriodService : ServiceBase<WorkPeriod>
    {
        public List<DuplicateItemDTO> IsDuplication(WorkPeriod workPeriod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@"  SELECT  'period code' as ColumnName
                                    , CASE WHEN COUNT(1) > 0 THEN CAST(1 as BIT) 
                                           ELSE CAST(0 as BIT)
                                      END AS isDuplicate
                                     FROM [db_period]  WITH(NOLOCK)
                                     WHERE 1= 1
                                     AND period_code = @period_code  
                                     AND period_id <> ISNULL(@period_id, 0)
                            ");

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("@period_code", workPeriod.period_code));
            param.Add(base.CreateParameter("@period_id", workPeriod.period_id));
            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }

        public DataSet FindWorkPeriod(WorkPeriod workPeriod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(" SELECT  * ");
            strSql.AppendLine(" FROM [db_period]  WITH(NOLOCK) ");
            strSql.AppendLine(" WHERE 1= 1 ");

            if(!string.IsNullOrEmpty(workPeriod.period_code))
                strSql.AppendLine(" AND period_code LIKE @period_code ");
            if (!string.IsNullOrEmpty(workPeriod.period_name))
                strSql.AppendLine(" AND period_name LIKE @period_name ");
            if (!string.IsNullOrEmpty(workPeriod.period_description))
                strSql.AppendLine(" AND period_description LIKE @period_description ");
            if (!string.IsNullOrEmpty(workPeriod.open_period_by))
                strSql.AppendLine(" AND open_period_by LIKE @open_period_by ");
            if (!string.IsNullOrEmpty(workPeriod.close_period_by))
                strSql.AppendLine(" AND close_period_by LIKE @close_period_by ");

            strSql.AppendLine(" ORDER BY period_code DESC ");
            
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("@period_code", "%" + workPeriod.period_code + "%"));
            param.Add(base.CreateParameter("@period_name", "%" + workPeriod.period_name + "%"));
            param.Add(base.CreateParameter("@period_description", "%" + workPeriod.period_description + "%"));
            param.Add(base.CreateParameter("@open_period_by", "%" + workPeriod.open_period_by + "%"));
            param.Add(base.CreateParameter("@close_period_by", "%" + workPeriod.close_period_by + "%"));
            return this.ExecuteQuery(strSql.ToString(), param.ToArray());
        }

        public bool IsPeriodStart()
        {
            string sql = @"
                            SELECT COUNT(1) as IsPeriodStart FROM db_period WITH(NOLOCK) WHERE active = 1
                          ";

            return (Converts.ParseLong(this.ExecuteScalar(sql).ToString()) > 0);

        }

        public WorkPeriod findActiveWorkPeriod()
        {
            string sql = @"
                            SELECT * 
                            FROM db_period WITH(NOLOCK) 
                            WHERE active = 1
                        ";

            return this.ExecuteQuery<WorkPeriod>(sql).FirstOrDefault();
        }
    }
}
