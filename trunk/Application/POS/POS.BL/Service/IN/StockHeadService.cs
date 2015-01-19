using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class StockHeadService : ServiceBase<StockHead>
    {
        public DataSet GetStockHead()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT head.stock_head_id
	                            , head.transaction_no AS [Document No]
	                            , CAST(head.transaction_date AS NVARCHAR(20)) AS [Document Date]
	                            , warehouse.warehouse_name AS [Warehouse]
                                , periodGroup.period_group_name AS [Period Group]
                                , CAST(period.period_date AS NVARCHAR(20)) AS [Period]
	                            , head.remark AS [Remark]
                                , head.transaction_status AS [Status]
                             FROM in_stock_head head 
                                INNER JOIN db_warehouse warehouse
                                    ON warehouse.warehouse_id = head.warehouse_id
                                INNER JOIN in_period period
                                    ON period.period_id = head.period_id
	                            INNER JOIN in_period_group periodGroup
                                    ON periodGroup.period_group_id = period.period_group_id
                                 WHERE 1=1  ");

            //List<DbParameter> param = new List<DbParameter>();            

            //if (DocDateFrom.HasValue)
            //{
            //    sql.AppendLine(" AND CONVERT(date, transaction_date ) >= @DocDateFrom");
            //    param.Add(this.CreateParameter("@DocDateFrom", DocDateFrom.Value.Date));
            //}
            //if (DocDateTo.HasValue)
            //{
            //    sql.AppendLine(" AND  CONVERT(date, transaction_date ) <= @DocDateTo");
            //    param.Add(this.CreateParameter("@DocDateTo", DocDateTo.Value.Date));
            //}
            //if (!string.IsNullOrEmpty(DocumentNo))
            //{
            //    sql.AppendLine(" AND head.document_type_id = @DocumentNo");
            //    param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            //}

            //if (!string.IsNullOrEmpty(ReferenceNo))
            //{
            //    sql.AppendLine(" AND reference_no = @ReferenceNo");
            //    param.Add(this.CreateParameter("@ReferenceNo", ReferenceNo));
            //}
            //if (!string.IsNullOrEmpty(DestWareHouseID))
            //{
            //    sql.AppendLine(" AND warehouse.warehouse_id = @DestWareHouseID");
            //    param.Add(this.CreateParameter("@DestWareHouseID", DestWareHouseID));
            //}

            //if (!string.IsNullOrEmpty(DestOther))
            //{
            //    sql.AppendLine(" AND other_source like @DestOther");
            //    param.Add(this.CreateParameter("@DestOther", string.Format("{0}{1}{0}", "%", DestOther)));
            //}

            //if (IsDestWareHouse)
            //{
            //    sql.AppendLine(" AND head.warehouse_id IS NOT NULL");
            //}
            //if (IsWaste)
            //{
            //    sql.AppendLine(" AND head.is_waste IS NOT NULL");
            //}
            //if (IsDestOther)
            //{
            //    sql.AppendLine(" AND head.other_source IS NOT NULL");
            //}

            return base.ExecuteQuery(sql.ToString());
        }
    }
}
