using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using System.Transactions;
using Core.Standards.Validations;
using POS.BL.DTO.SO;

namespace POS.BL.Service.SO
{
    public class SOTableService : ServiceBase<SOTable>
    {
        public SOTable GetTaleByCode(string TableCode)
        {
            string sql = @" SELECT * FROM so_table WITH(NOLOCK) where table_code=@table_code ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("@table_code", TableCode));
            return this.ExecuteQueryOne<SOTable>(sql, param.ToArray());
        }
        public bool SwitchTable(OrderHeadDTO orderHead, string orgTableCode, string NewTableCode)
        {
            bool result = false;
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                try
                {
                    SOTable NewlTable = ServiceProvider.SOTableService.GetTaleByCode(NewTableCode);
                    if (NewlTable!=null && NewlTable.IsAvailable)
                    {
                        this.CancelBookTable(orgTableCode);
                        this.BookTable(NewlTable.table_code);
                        ServiceProvider.SaleOrderHeaderService.UpdateOrderHeadTable(orderHead.sales_order_head_id, NewTableCode);
                        trans.Complete();
                        result = true;
                    }
                    else if (string.IsNullOrEmpty(NewTableCode))
                    {
                        this.CancelBookTable(orgTableCode);
                        ServiceProvider.SaleOrderHeaderService.UpdateOrderHeadTable(orderHead.sales_order_head_id, NewTableCode);
                        trans.Complete();
                        result = true;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return result;
        }
        public void CancelBookTable(string tableCode)
        {
            SOTable table = this.GetTaleByCode(tableCode);
            if (table != null)
            {
                table.IsAvailable = true;
                this.Update(table, ValidationRuleset.Update);
            }
        }
        public void BookTable(string tableCode)
        {
            SOTable table = this.GetTaleByCode(tableCode);
            if (table != null)
            {
                table.IsAvailable = false;
                this.Update(table, ValidationRuleset.Update);
            }
        }
    }
}
