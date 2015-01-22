using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;
using POS.BL.DTO.IN;

namespace POS.BL.Service.IN
{
    public class LogLotService:ServiceBase<LogLot>
    {
        public decimal GetBalanceQty(long material_id, long warehouse_id)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT bal_qty FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendLine(" AND material_id = @material_id ");
            SQL.AppendLine(" AND warehouse_id = @warehouse_id ");

            DbParameter param1 = base.CreateParameter("material_id", material_id);
            DbParameter param2 = base.CreateParameter("warehouse_id", warehouse_id);

            object BalanceQtyObject = base.ExecuteScalar(SQL.ToString(), param1, param2);
            decimal BalanceQty = BalanceQtyObject.ToDecimal();

            return BalanceQty;
        }

        public LogLot GetLogLot(long material_id, long warehouse_id)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT * FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendLine(" AND material_id = @material_id ");
            SQL.AppendLine(" AND warehouse_id = @warehouse_id ");

            DbParameter param1 = base.CreateParameter("material_id", material_id);
            DbParameter param2 = base.CreateParameter("warehouse_id", warehouse_id);

            LogLot entity = base.ExecuteQueryOne<LogLot>(SQL.ToString(), param1, param2);
            if (entity == null || entity.log_lot_id == 0)
            {
                entity = new LogLot();
                entity.created_by = "System";
                entity.created_date = DateTime.Now;
                entity.updated_by = "System";
                entity.updated_date = DateTime.Now;
                entity.material_id = material_id;
                entity.warehouse_id = warehouse_id;
                entity.bal_qty = 0;

                entity.log_lot_id = base.Insert<long>(entity);
            }
            return entity;
        }

        //Decrease logical lot
        public void Stock_DecreaseLogical(StockDTO stockDTO)
        {

        }

        //Check from logical lot
        public void Stock_CheckAvailable(StockDTO stockDTO)
        {
            
        }

        public void Stock_CancelOrder(StockDTO stockDTO)
        {

        }

        public void Stock_CancelHeadOrder(long sales_order_head_id)
        {

        }

        //Increase logical lot
        public void Stock_IncreaseLogical(StockDTO stockDTO)
        {

        }
    }
}
