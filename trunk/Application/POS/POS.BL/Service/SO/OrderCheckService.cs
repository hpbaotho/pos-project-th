using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Validations;
using POS.BL.DTO.SO;

namespace POS.BL.Service.SO
{
    public class OrderCheckService : ServiceBase<OrderCheck>
    {
        public int GetCheckNo()
        {
            int result = 0;
            WorkPeriod activeWorkPeriod = ServiceProvider.WorkPeriodService.findActiveWorkPeriod();
            if (activeWorkPeriod != null)
            {

                string sql = @"
                            SELECT TOP 1 * FROM so_order_check
                            where period_id=@period_id
                            ";
                List<DbParameter> param = new List<DbParameter>();
                param.Add(this.CreateParameter("period_id", activeWorkPeriod.period_id));
                OrderCheck chkOrder = this.ExecuteQueryOne<OrderCheck>(sql, param.ToArray());
                if (chkOrder == null)
                {
                    result = 1;
                    chkOrder = new OrderCheck();
                    chkOrder.CheckNo = 1;
                    chkOrder.period_id = activeWorkPeriod.period_id;
                    this.Insert(chkOrder, ValidationRuleset.Insert);
                }
                else
                {
                    chkOrder.CheckNo += 1;
                    result = chkOrder.CheckNo;
                    this.Update(chkOrder, ValidationRuleset.Update);
                }
            }
            return result;
        }
       
    }
}
