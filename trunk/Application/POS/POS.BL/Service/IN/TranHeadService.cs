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
            return GetGridTranHead(string.Empty, null, null, string.Empty, string.Empty, string.Empty);
        }

        public DataSet GetGridTranHead(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo, string SourceWareHouseID, string SourceOther)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"SELECT tran_head_id AS ID
	                            , head.document_type_id AS [Document ID]
	                            , transaction_no AS [Transaction No]
	                            , transaction_date AS [Transaction Date]
	                             , reference_no AS [Reference No]
	                             ,  reason_name AS [Reason]
	                             ,  supplier_name AS [Supplier]
	                             , warehouse_name [Warehouse]
	                             , other_source AS [Other Source]
	                             ,remark AS [Remark]
                             FROM in_tran_head head 
	                            left join db_reason reason
		                            on head.reason_id = reason.reason_id
	                            left join db_supplier supplr
		                            on head.supplier_id =  supplr.supplier_id 
	                            left join db_warehouse warehouse
		                            on head.warehouse_id =  warehouse.warehouse_id
                                 WHERE 1=1  ");
            // Document No. - Textbox, Document Date - Calendar From-To, Reference No. - Textbox, Source - Radio + DDL, Status - DDL
            List<DbParameter> param = new List<DbParameter>();

            if( !string.IsNullOrEmpty(DocumentNo))
            {
                sql.AppendLine(" AND head.document_type_id = @DocumentNo");
                param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            }
            //ReferenceNo, string SourceWareHouseID, string SourceOther
            if( !string.IsNullOrEmpty(ReferenceNo))
            {
                sql.AppendLine(" AND reference_no = @ReferenceNo");
                param.Add(this.CreateParameter("@ReferenceNo", ReferenceNo));
            }  
            if( !string.IsNullOrEmpty(SourceWareHouseID))
            {
                sql.AppendLine(" AND warehouse.warehouse_id = @SourceWareHouseID");
                param.Add(this.CreateParameter("@SourceWareHouseID", SourceWareHouseID));
            }  
            if( !string.IsNullOrEmpty(SourceOther))
            {
                sql.AppendLine(" AND head.document_type_id like @SourceOther");
                param.Add(this.CreateParameter("@SourceOther", string.Format("{0}{1}{0}", "%", SourceOther)));
            }

            return base.ExecuteQuery(sql.ToString(), param);
        }
    }
}
