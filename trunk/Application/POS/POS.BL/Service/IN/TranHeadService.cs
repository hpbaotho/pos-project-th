using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class TranHeadService : ServiceBase<TranHead>
    {
        public DataSet GetGridTranHead()
        {
            StringBuilder sql = new StringBuilder();
          //  sql.AppendLine(@"SELECT * FROM in_tran_head ");
            sql.AppendLine(@"SELECT tran_head_id AS ID, document_type_id AS [Document ID], transaction_no AS [Transaction No], transaction_date AS [Transaction Date], transaction_status AS [Transaction Status]
                             , reference_no AS [Reference No],  reason_id AS [Reason ID],  supplier_id AS [Supplier ID], warehouse_id [Warehouse ID], other_source AS [Other Source],remark AS [Remark]
                             FROM in_tran_head 
                             WHERE 1=1 ");


            return base.ExecuteQuery(sql.ToString());
        }
    }
}
