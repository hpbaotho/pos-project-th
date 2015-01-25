using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using System.Data.Common;
using POS.BL.Utilities;
using System.Data;

namespace POS.BL.Service.IN
{
    public class PeriodService : ServiceBase<Period>
    {
        public List<ComboBoxDTO> GetOpenPeriod(long PeriodGroupID)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT * FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendFormat(" AND ISNULL(period_status,'{0}') = @period_status ", INPeriodStatus.Open);
            SQL.AppendLine(" AND period_group_id = @PeriodGroupID ");

            DbParameter param = base.CreateParameter("period_status", INPeriodStatus.Open);
            DbParameter param1 = base.CreateParameter("PeriodGroupID", PeriodGroupID);

            List<Period> lstPeriod = base.ExecuteQuery<Period>(SQL.ToString(), param, param1).ToList();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            foreach (Period period in lstPeriod)
            {
                ComboBoxDTO dto = new ComboBoxDTO();
                dto.Value = period.period_id.ToString();
                dto.Display = period.period_code + ":" + DateTime.Parse(period.period_date.ToString()).ConvertDateToDisplay();
                lstComboBoxDTO.Add(dto);
            }

            lstComboBoxDTO.SetPleaseSelect();

            return lstComboBoxDTO;
        }

        public void ClosePeriod(long PeriodID)
        {
            Period entity = new Period() { period_id = PeriodID };
            entity = base.FindByKeys(entity, false);
            entity.period_status = INPeriodStatus.Close;
            base.Update(entity);
        }

        public DataSet GetGridPeriod(string periodCode, DateTime? periodDate)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT p.period_id AS ID, p.period_code AS [Period Code]
		                            , p.period_date AS [Period Date]
		                            , pg.period_group_name AS [Period Group]
		                            , p.active AS Active 
                              FROM in_period p
                              LEFT JOIN in_period_group pg ON pg.period_group_id = p.period_group_id
                              WHERE 1 = 1 ");
            
            List<DbParameter> param = new List<DbParameter>();
            if (!string.IsNullOrEmpty(periodCode))
            {
                sql.AppendLine(@" AND CHARINDEX(@period_code, p.period_code) > 0 ");
                param.Add(this.CreateParameter("@PeriodCode", periodCode));
            }
            if (periodDate.HasValue)
            {
                sql.AppendLine(" AND CONVERT(date, p.period_date ) >= @periodDate");
                param.Add(this.CreateParameter("@PeriodDate", periodDate.Value.Date));
            }

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<DuplicateItemDTO> IsDuplicationPeriode(Period period)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [in_period]  WITH(NOLOCK)
                                WHERE  period_code = @period_code
                                ");

            //---Edit
            //if (material.material_id > 0)
            //{
            //    strSql.AppendLine(" AND material_id <>  material_id ");
            //}

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("period_code", period.period_code));
            //param.Add(base.CreateParameter("employee_id", material.material_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
    }
}
