using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using System.Data.Common;
using POS.BL.Utilities;

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
    }
}
