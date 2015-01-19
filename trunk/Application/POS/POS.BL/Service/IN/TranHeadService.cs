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
        public DataSet GetGridTranHeadReceiveMaterial(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo,bool IsSourceWareHouse, bool IsSupplier, bool IsSourceOther, string SourceWareHouseID,string SupplierID, string SourceOther)
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
                                INNER JOIN db_document_type docType 
                                    ON docType.document_type_id = head.document_type_id
	                            left join db_reason reason
		                            on head.reason_id = reason.reason_id
	                            left join db_supplier supplier
		                            on head.supplier_id =  supplier.supplier_id 
	                            left join db_warehouse warehouse
		                            on head.warehouse_id =  warehouse.warehouse_id
                                 WHERE 1=1  
                                    AND docType.document_type_name = @document_type_name");
            // Document No. - Textbox, Document Date - Calendar From-To, Reference No. - Textbox, Source - Radio + DDL, Status - DDL
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@document_type_name", DocumentTypeCode.IN.ReceiveMaterial));

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

            if(IsSourceWareHouse)
            {
                sql.AppendLine(" AND head.warehouse_id IS NOT NULL");                
            }
            if(IsSupplier)
            {
                sql.AppendLine(" AND head.supplier_id IS NOT NULL");                
            }
            if (IsSourceOther)
            {
                sql.AppendLine(" AND head.other_source IS NOT NULL");                
            }
            
            return base.ExecuteQuery(sql.ToString(), param);
        }
        public DataSet GetGridTranHeadIssueMaterial(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string ReferenceNo, bool IsDestWareHouse, bool IsWaste, bool IsDestOther, string DestWareHouseID, string DestOther)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT head.tran_head_id
	                            , head.transaction_no AS [Document No]
	                            , CAST(head.transaction_date AS NVARCHAR(20)) AS [Document Date]
	                            , head.reference_no AS [Reference No]
                                , case 
									when ISNULL(head.Is_Waste,0) = 1 then 'Waste'
									when head.warehouse_id is not null then 'Warehouse:' + warehouse.warehouse_name 
									else 'Other:' + head.other_source
								end AS [Destination]
                                , head.transaction_status AS [Status]
	                            , reason.reason_name AS [Reason]	                             
	                            , head.remark AS [Remark]
                             FROM in_tran_head head 
                                INNER JOIN db_document_type docType 
                                    ON docType.document_type_id = head.document_type_id
	                            left join db_reason reason
		                            on head.reason_id = reason.reason_id
	                            left join db_supplier supplier
		                            on head.supplier_id =  supplier.supplier_id 
	                            left join db_warehouse warehouse
		                            on head.warehouse_id =  warehouse.warehouse_id
                                 WHERE 1=1  
                                    AND docType.document_type_name = @document_type_name");
            
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@document_type_name", DocumentTypeCode.IN.IssueMaterial));

            if (DocDateFrom.HasValue)
            {
                sql.AppendLine(" AND CONVERT(date, transaction_date ) >= @DocDateFrom");
                param.Add(this.CreateParameter("@DocDateFrom", DocDateFrom.Value.Date));
            }
            if (DocDateTo.HasValue)
            {
                sql.AppendLine(" AND  CONVERT(date, transaction_date ) <= @DocDateTo");
                param.Add(this.CreateParameter("@DocDateTo", DocDateTo.Value.Date));
            }
            if (!string.IsNullOrEmpty(DocumentNo))
            {
                sql.AppendLine(" AND head.transaction_no = @DocumentNo");
                param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            }
            
            if (!string.IsNullOrEmpty(ReferenceNo))
            {
                sql.AppendLine(" AND reference_no = @ReferenceNo");
                param.Add(this.CreateParameter("@ReferenceNo", ReferenceNo));
            }
            if (!string.IsNullOrEmpty(DestWareHouseID))
            {
                sql.AppendLine(" AND warehouse.warehouse_id = @DestWareHouseID");
                param.Add(this.CreateParameter("@DestWareHouseID", DestWareHouseID));
            }
            
            if (!string.IsNullOrEmpty(DestOther))
            {
                sql.AppendLine(" AND other_source like @DestOther");
                param.Add(this.CreateParameter("@DestOther", string.Format("{0}{1}{0}", "%", DestOther)));
            }

            if (IsDestWareHouse)
            {
                sql.AppendLine(" AND head.warehouse_id IS NOT NULL");
            }
            if (IsWaste)
            {
                sql.AppendLine(" AND head.is_waste IS NOT NULL");
            }
            if (IsDestOther)
            {
                sql.AppendLine(" AND head.other_source IS NOT NULL");
            }

            return base.ExecuteQuery(sql.ToString(), param);
        }
        public DataSet GetGridTranHeadIssueSold(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string OrderNo)
        {
            StringBuilder sql = new StringBuilder();
                sql.AppendLine(@"SELECT head.tran_head_id
	                                , head.transaction_no AS [Document No]
	                                , CAST(head.transaction_date AS NVARCHAR(20)) AS [Document Date]
								    , orderHead.order_no AS [Order No]
								    , orderHead.sales_order_date AS [Order Date]
								    , menu.menu_name AS [Menu]
								    , CASE WHEN ISNULL(orderDetail.is_cancel,0) = 0 THEN 'Normal'
									    ELSE 'Cancel'
									    END
								    AS [Order Status]
								    , refHead.transaction_no AS [Rerference Document No.]
                                    , head.transaction_status AS [Status]
	                                , head.remark AS [Remark]
                                FROM in_tran_head head 
                                INNER JOIN db_document_type docType 
                                    ON docType.document_type_id = head.document_type_id
	                            LEFT JOIN in_tran_head refHead 
                                    ON refHead.tran_head_id = head.reference_tran_head_id
	                            LEFT JOIN so_sales_order_detail orderDetail 
                                    ON orderDetail.sales_order_detail_id = head.sales_order_detail_id
	                            LEFT JOIN so_sales_order_head orderHead 
                                    ON orderDetail.sales_order_head_id = orderHead.sales_order_head_id
								LEFT JOIN so_menu_dining_type diningType
									ON diningType.menu_dining_type_id = orderDetail.menu_dining_type_id
								LEFT JOIN so_menu menu
									ON menu.menu_id = diningType.menu_id
                                 WHERE 1=1  
                                    AND docType.document_type_name = @document_type_name");
            
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@document_type_name", DocumentTypeCode.IN.IssueSold));

            if (DocDateFrom.HasValue)
            {
                sql.AppendLine(" AND CONVERT(date, head.transaction_date ) >= @DocDateFrom");
                param.Add(this.CreateParameter("@DocDateFrom", DocDateFrom.Value.Date));
            }
            if (DocDateTo.HasValue)
            {
                sql.AppendLine(" AND  CONVERT(date, head.transaction_date ) <= @DocDateTo");
                param.Add(this.CreateParameter("@DocDateTo", DocDateTo.Value.Date));
            }
            if (!string.IsNullOrEmpty(DocumentNo))
            {
                sql.AppendLine(" AND head.transaction_no = @DocumentNo");
                param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            }
            
            if (!string.IsNullOrEmpty(OrderNo))
            {
                sql.AppendLine(" AND orderHead.order_no = @OrderNo");
                param.Add(this.CreateParameter("@OrderNo", OrderNo));
            }

            return base.ExecuteQuery(sql.ToString(), param);
        }
        public DataSet GetGridTranHeadReceiveOrder(string DocumentNo, DateTime? DocDateFrom, DateTime? DocDateTo
            , string OrderNo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT head.tran_head_id
	                                , head.transaction_no AS [Document No]
	                                , CAST(head.transaction_date AS NVARCHAR(20)) AS [Document Date]
								    , orderHead.order_no AS [Order No]
								    , orderHead.sales_order_date AS [Order Date]
								    , menu.menu_name AS [Menu]
								    , CASE WHEN ISNULL(orderDetail.is_cancel,0) = 0 THEN 'Normal'
									    ELSE 'Cancel'
									    END
								    AS [Order Status]
								    , refHead.transaction_no AS [Rerference Document No.]
                                    , head.transaction_status AS [Status]
	                                , head.remark AS [Remark]
                                FROM in_tran_head head 
                                INNER JOIN db_document_type docType 
                                    ON docType.document_type_id = head.document_type_id
	                            LEFT JOIN in_tran_head refHead 
                                    ON refHead.tran_head_id = head.reference_tran_head_id
	                            LEFT JOIN so_sales_order_detail orderDetail 
                                    ON orderDetail.sales_order_detail_id = head.sales_order_detail_id
	                            LEFT JOIN so_sales_order_head orderHead 
                                    ON orderDetail.sales_order_head_id = orderHead.sales_order_head_id
								LEFT JOIN so_menu_dining_type diningType
									ON diningType.menu_dining_type_id = orderDetail.menu_dining_type_id
								LEFT JOIN so_menu menu
									ON menu.menu_id = diningType.menu_id
                                 WHERE 1=1  
                                    AND docType.document_type_name = @document_type_name");
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@document_type_name", DocumentTypeCode.IN.ReceiveOrder));

            if (DocDateFrom.HasValue)
            {
                sql.AppendLine(" AND CONVERT(date, head.transaction_date ) >= @DocDateFrom");
                param.Add(this.CreateParameter("@DocDateFrom", DocDateFrom.Value.Date));
            }
            if (DocDateTo.HasValue)
            {
                sql.AppendLine(" AND  CONVERT(date, head.transaction_date ) <= @DocDateTo");
                param.Add(this.CreateParameter("@DocDateTo", DocDateTo.Value.Date));
            }
            if (!string.IsNullOrEmpty(DocumentNo))
            {
                sql.AppendLine(" AND head.transaction_no = @DocumentNo");
                param.Add(this.CreateParameter("@DocumentNo", DocumentNo));
            }
            if (!string.IsNullOrEmpty(OrderNo))
            {
                sql.AppendLine(" AND orderHead.order_no = @OrderNo");
                param.Add(this.CreateParameter("@OrderNo", OrderNo));
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
