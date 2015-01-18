using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using System.Data;
using POS.BL.Utilities;
using POS.BL.DTO;

namespace POS.BL.Service.KC
{
    public class KCSaleOrderDetailService : ServiceBase<MenuCategory>  // random T
    {
        public DataSet FindOrderInKitchenList(string TableName, string MenuName)
        {
            return FindOrderByCriteria(string.Empty, TableName, MenuName, false, true, KitichenStatus.Process, "sales_order_date Desc");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="MenuName"></param>
        /// <param name="OrderStatus">String.Empty if not inculde inthe cirtieria</param>
        /// <returns></returns>
        public DataSet FindOrderInKitchenHistory(string TableName, string MenuName, List<string>  OrderStatus)
        {
            // List<string> ktichenProcess = new List<string>() { KitichenStatus.Finish, KitichenStatus.Cancel };
            return FindOrderByCriteria(string.Empty, TableName, MenuName, null, null, OrderStatus, "sales_order_date ASC");
        }

        public DataSet FindOrderByCriteria(string OrderDetailID)
        {
            return FindOrderByCriteria(OrderDetailID, string.Empty, string.Empty, null, null, string.Empty, "sales_order_date ASC");
        }

        private DataSet FindOrderByCriteria(string OrderDetailID, string TableName, string MenuName
                , bool? IsCancel, bool? IsPrint, string KitchenStatus, string OrderBy)
        {
             List<string> KitchenStatusList = null;
            if( !string.IsNullOrEmpty( KitchenStatus ))
                    KitchenStatusList = new List<string>() { KitchenStatus };

            return FindOrderByCriteria(OrderDetailID, TableName, MenuName
                , IsCancel, IsPrint, KitchenStatusList , OrderBy);
        }

        private DataSet FindOrderByCriteria(string OrderDetailID, string TableName, string MenuName
                , bool? IsCancel, bool? IsPrint, List<string> KitchenStatus, string OrderBy)
        //public DataSet GetSaleOrder(string OrderId, DateTime? OrderDateFrom, DateTime? OrderDateTo
        //    , string  TableName , string OrderBy  )
        {
            StringBuilder sql = new StringBuilder(
            @"select sales_order_detail_id [ID]
	            , sales_order_date  [Order Date], table_name [Table Name]
	            , menu_name [Menu], order_amount [Quantity]
	            from so_sales_order_head saleHead with(nolock)
		            left join so_table daTable  with(nolock)
			            on saleHead.table_id = daTable.table_id
		            left join so_sales_order_detail detail with(nolock)
			            on saleHead.sales_order_head_id = detail.sales_order_head_id
		            left join so_menu_dining_type dinType
			            on dinType.menu_dining_type_id = detail.menu_dining_type_id
		            left join so_menu menu with(nolock)
			            on dinType.menu_id = menu.menu_id
		            where 1 = 1");

            List<DbParameter> param = new List<DbParameter>();


            if (KitchenStatus != null)
            {
                //sql.AppendLine(string.Format(" AND isnull(detail.kitchen_status,'{0}')   = @KitchenStatus", KitichenStatus.Process));
                //param.Add(this.CreateParameter("@KitchenStatus", KitchenStatus));

                sql.AppendLine(string.Format(" AND isnull(detail.kitchen_status,'{0}')   in ( '-1' ", KitichenStatus.Process));
                for (int runner = 0; runner < KitchenStatus.Count; runner++)
                {
                    string paramName = "@status" + runner;

                    sql.AppendLine(string.Format(",{0} ", paramName));
                    param.Add(this.CreateParameter(paramName, KitchenStatus[runner]));

                }
                sql.AppendLine(string.Format(" )"));
            }
            if (IsCancel.HasValue)
            {
                if (IsCancel.Value)
                {
                    sql.AppendLine(" AND detail.is_cancel = 1");
                    sql.AppendLine(" AND saleHead.is_cancel = 1");
                }
                else
                {
                    sql.AppendLine(" AND (detail.is_cancel = 0 OR detail.is_cancel is null) ");
                    sql.AppendLine(" AND (saleHead.is_cancel = 0 OR saleHead.is_cancel is null) ");
                }
            }
            if (IsPrint.HasValue)
            {
                if (IsPrint.Value)
                    sql.AppendLine(" AND detail.is_print = 1");
                else
                    sql.AppendLine(" AND (detail.is_print = 0 OR detail.is_print is null) ");
            }
            if (!string.IsNullOrEmpty(OrderDetailID))
            {
                sql.AppendLine(" AND sales_order_detail_id  = @OrderDetailID");
                param.Add(this.CreateParameter("@OrderDetailID", OrderDetailID));
            }
            if (!string.IsNullOrEmpty(TableName))
            {
                sql.AppendLine(" AND isnull(table_name,'')  like @TableName");
                param.Add(this.CreateParameter("@TableName", string.Format("{0}{1}{0}", "%", TableName)));
            }
            if (!string.IsNullOrEmpty(MenuName))
            {
                sql.AppendLine(" AND isnull(menu_name,'')  like @MenuName");
                param.Add(this.CreateParameter("@MenuName", string.Format("{0}{1}{0}", "%", MenuName)));
            }

            sql.AppendLine(" ORDER BY " + OrderBy);

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
            //return this.ExecuteQuery<SaleOrderHeader>(sql.ToString() , param.ToArray()).ToList();
        }

        public DataSet FindBOMDetailByOrderDetailId(string OrderDetailID)
        {
            StringBuilder sql = new StringBuilder(@"
           select material.material_code [Material Code], material.material_name [Material Name]
                , 0 [Quantity] , material.uom_id_count [UOM]
	                from so_sales_order_head saleHead with(nolock)
		                left join so_table daTable  with(nolock)
			                on saleHead.table_id = daTable.table_id
		                left join so_sales_order_detail detail with(nolock)
			                on saleHead.sales_order_head_id = detail.sales_order_head_id
		                left join so_menu_dining_type dinType
			                on dinType.menu_dining_type_id = detail.menu_dining_type_id
		                left join so_menu menu with(nolock)
			                on dinType.menu_id = menu.menu_id
		                left join so_menu_mapping mapping 
			                on mapping.menu_id = menu.menu_id
		                left join in_bill_of_material_head bomHead
			                on bomHead.bill_of_material_head_id = mapping.bill_of_material_head_id
						left join in_bill_of_material_detail bomDetail
							on bomDetail.bill_of_material_head_id = bomDetail.bill_of_material_head_id
						inner join in_material material
							on bomDetail.material_id = material.material_id
		                where 1 = 1
                            and detail.sales_order_detail_id = @OrderDetailID");

            List<DbParameter> param = new List<DbParameter>();

            param.Add(this.CreateParameter("@OrderDetailID", OrderDetailID));


            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }


        public List<ComboBoxDTO> GetEnumOrderDetailStatus()
        {
            List<ComboBoxDTO> anwer = new List<ComboBoxDTO>();

            //anwer.Add(new ComboBoxDTO() { Display = KitichenStatus.ProcessWording, Value = KitichenStatus.Process });
            anwer.Add(new ComboBoxDTO() { Display = KitichenStatus.FinishWording, Value = KitichenStatus.Finish });
            anwer.Add(new ComboBoxDTO() { Display = KitichenStatus.CancelWording, Value = KitichenStatus.Cancel });

            anwer.Insert(0, new ComboBoxDTO() { Value = string.Empty, Display = GeneralMessage.All });

            return anwer;
        }

        public DataSet FindBOMHeaderByOrderDetailId(string OrderDetailID)
        {
            StringBuilder sql = new StringBuilder(@"
                select billHead.bill_of_material_head_id [ID]
                        ,billHead.bill_of_material_head_code [BOM Code]
		                , billHead.bill_of_material_head_name [BOM Name]
		                , mapping.quantity [Quantity]
		                , billHead.[remark] [Remark]
	                from so_sales_order_head saleHead with(nolock)
		                left join so_table daTable  with(nolock)
			                on saleHead.table_id = daTable.table_id
		                left join so_sales_order_detail detail with(nolock)
			                on saleHead.sales_order_head_id = detail.sales_order_head_id
		                left join so_menu_dining_type dinType
			                on dinType.menu_dining_type_id = detail.menu_dining_type_id
		                left join so_menu menu with(nolock)
			                on dinType.menu_id = menu.menu_id
		                left join so_menu_mapping mapping 
			                on mapping.menu_id = menu.menu_id
		                left join in_bill_of_material_head billHead
			                on billHead.bill_of_material_head_id = mapping.bill_of_material_head_id
		                where 1 = 1
                            and detail.sales_order_detail_id = @OrderDetailID");

            List<DbParameter> param = new List<DbParameter>();

            param.Add(this.CreateParameter("@OrderDetailID", OrderDetailID));


            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }


        public void UpdateOrderDetailStatus(List<string> DetailIDList, string Status)
        {
            StringBuilder sql = new StringBuilder(@"update  so_sales_order_detail 
			                                            set kitchen_status = @Status
		                                                    where sales_order_detail_id in ( -1 ");
            foreach (string ID in DetailIDList)
            {
                sql.AppendLine(string.Format(", {0}", ID));
            }
            sql.AppendLine(" )");

            List<DbParameter> param = new List<DbParameter>();

            param.Add(base.CreateParameter("Status", Status));



            base.ExecuteNonQuery(sql.ToString(), this.CreateParameter("Status", Status));
        }
    }
}
