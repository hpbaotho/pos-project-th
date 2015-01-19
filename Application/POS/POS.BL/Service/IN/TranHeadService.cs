using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;
using POS.BL.Utilities;

namespace POS.BL.Service.IN
{
    public class TranHeadService : ServiceBase<TranHead>
    {

        public DataSet GetGridTranHead()
        {
            return GetGridTranHead(string.Empty, null, null, string.Empty, string.Empty,string.Empty, string.Empty,string.Empty );
        }

        //public DataSet GetWare
        public DataSet GetIssueMaterialOther(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo, string SourceWareHouseID, string SupplierID, string SourceOther)
        {
            return GetGridTranHead(DocumentNo, DocDateFrom, DocDateTo
         , ReferenceNo, SourceWareHouseID, SupplierID, SourceOther, DocumentTypeCode.IN.IssueMaterialWarehouseOther );
        }

        public DataSet GetReceiveMaterial(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo, string SourceWareHouseID, string SupplierID, string SourceOther)
        {
            return GetGridTranHead( DocumentNo,  DocDateFrom,  DocDateTo
            ,  ReferenceNo,  SourceWareHouseID,  SupplierID,  SourceOther,  string.Empty );
        }

        public DataSet GetGridTranHead(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo, string SourceWareHouseID,string SupplierID, string SourceOther, string DocTypeName )
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT head.tran_head_id
	                            , head.transaction_no AS [Document No]
	                            , CAST(head.transaction_date AS NVARCHAR(20)) AS [Document Date]
	                            , head.reference_no AS [Reference No]
                                , case 
									when head.supplier_id is not null then 'Supplier:' + supplier.supplier_name 
									when head.warehouse_id is not null then 'Warehouse:' + warehouse.warehouse_name 
									else 'Other:' + head.other_source
								end AS [Source]
                                , head.transaction_status AS [Status]
	                            , reason.reason_name AS [Reason]	                             
	                            , head.remark AS [Remark]
                             FROM in_tran_head head 
	                            left join db_reason reason
		                            on head.reason_id = reason.reason_id
	                            left join db_supplier supplier
		                            on head.supplier_id =  supplier.supplier_id 
	                            left join db_warehouse warehouse
		                            on head.warehouse_id =  warehouse.warehouse_id
                                left join db_document_type docType
                                    on head.document_type_id = docType.document_type_id
                                 WHERE 1=1  ");
            // Document No. - Textbox, Document Date - Calendar From-To, Reference No. - Textbox, Source - Radio + DDL, Status - DDL
            List<DbParameter> param = new List<DbParameter>();

            if (DocDateFrom.HasValue)
            {
                sql.AppendLine(" AND CONVERT(date, transaction_date ) >= @DocDateFrom");
                param.Add(this.CreateParameter("@DocDateFrom", DocDateFrom.Value.Date ));
            }
            if ( DocDateTo.HasValue) 
            {
                sql.AppendLine(" AND  CONVERT(date, transaction_date ) <= @DocDateTo");
                param.Add(this.CreateParameter("@DocDateTo", DocDateTo.Value.Date));
            }

            if (!string.IsNullOrEmpty(DocTypeName))
            {
                sql.AppendLine(" AND docType.document_type_name = @DocTypeName");
                param.Add(this.CreateParameter("@DocTypeName", DocTypeName));
            }
            if( !string.IsNullOrEmpty(DocumentNo))
            {
                sql.AppendLine(" AND head.transaction_no = @DocumentNo");
                param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            }
            //ReferenceNo, string SourceWareHouseID, string SourceOther
            if( !string.IsNullOrEmpty(ReferenceNo))
            {
                sql.AppendLine(" AND reference_no = @ReferenceNo");
                param.Add(this.CreateParameter("@ReferenceNo", ReferenceNo));
            }
            if (!string.IsNullOrEmpty(SourceWareHouseID))
            {
                sql.AppendLine(" AND warehouse.warehouse_id = @SourceWareHouseID");
                param.Add(this.CreateParameter("@SourceWareHouseID", SourceWareHouseID));
            }
            if (!string.IsNullOrEmpty( SupplierID ))
            {
                sql.AppendLine(" AND supplr.supplier_id = @SupplierID");
                param.Add(this.CreateParameter("@SupplierID", SupplierID));
            }  
            if( !string.IsNullOrEmpty(SourceOther))
            {
                sql.AppendLine(" AND other_source like @SourceOther");
                param.Add(this.CreateParameter("@SourceOther", string.Format("{0}{1}{0}", "%", SourceOther)));
            }

            return base.ExecuteQuery(sql.ToString(), param);
        }

        public TranHead GetTransactionByReferenceNo(string ReferenceNo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@" SELECT * FROM {0} WHERE 1=1 ", base.EntityTableName);
            sql.AppendLine(@" AND [reference_no] = @reference_no");
            DbParameter param = base.CreateParameter("reference_no", ReferenceNo);
            return base.ExecuteQueryOne<TranHead>(sql.ToString(), param);
        }
    }
}
