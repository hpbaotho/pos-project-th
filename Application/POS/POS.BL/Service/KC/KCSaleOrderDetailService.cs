using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using System.Data;

namespace POS.BL.Service.KC
{
    public class KCSaleOrderDetailService : ServiceBase<MenuCategory>  // random T
    {
        public DataSet FindOrderByCriteria(string TableName, string MenuName)
        //public DataSet GetSaleOrder(string OrderId, DateTime? OrderDateFrom, DateTime? OrderDateTo
        //    , string  TableName , string OrderBy  )
        {
            StringBuilder sql = new StringBuilder(@"select sales_order_detail_id [ITEM_KEY]
                                                        , sales_order_date  [Order Date], table_name [Table Name]
	                                                    , menu_name [Menu], order_amount [Quantity]
	                                                    from so_sales_order_head saleHead with(nolock)
		                                                    left join so_table daTable  with(nolock)
			                                                    on saleHead.table_id = daTable.table_id
		                                                    left join so_sales_order_detail detail
			                                                    on saleHead.sales_order_head_id = detail.sales_order_head_id
		                                                    left join so_menu menu
			                                                    on detail.menu_dining_type_id = menu.menu_id
		                                                    where 1 = 1");

            List<DbParameter> param = new List<DbParameter>();

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

            sql.AppendLine(" ORDER BY  sales_order_date ASC");

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
            //return this.ExecuteQuery<SaleOrderHeader>(sql.ToString() , param.ToArray()).ToList();
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



            base.ExecuteNonQuery(sql.ToString(), this.CreateParameter("Status", Status) );
        }
    }
}
