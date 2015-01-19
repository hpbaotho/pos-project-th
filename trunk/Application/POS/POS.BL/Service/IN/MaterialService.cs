using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using System.Data;

namespace POS.BL.Service.IN
{
    public class MaterialService : ServiceBase<Material>
    {
        public DataSet GetMaterialFromMenuOrder(long SalesOrderDetailID)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(@"   SELECT 
	                                material.*
                                FROM in_material AS material
                                INNER JOIN in_bill_of_material_detail AS BOMDetail
	                                ON BOMDetail.material_id = material.material_id
                                INNER JOIN in_bill_of_material_head AS BOMHead
	                                ON BOMHead.bill_of_material_head_id = BOMDetail.bill_of_material_head_id
                                INNER JOIN so_menu_mapping AS menuMapping
	                                ON menuMapping.bill_of_material_head_id = BOMHead.bill_of_material_head_id
                                INNER JOIN so_menu AS menu
	                                ON menu.menu_id = menuMapping.menu_id
                                INNER JOIN so_menu_dining_type AS dining
	                                ON dining.menu_id = menu.menu_id
                                INNER JOIN so_sales_order_detail AS orderDetail
	                                ON dining.menu_dining_type_id = orderDetail.menu_dining_type_id
                                WHERE 1=1
                                AND BOMDetail.sales_order_detail_id = @SalesOrderDetailID
                            ");
            DbParameter param = base.CreateParameter("SalesOrderDetailID", SalesOrderDetailID);
            return base.ExecuteQuery(SQL.ToString(), param);
        }
    }
}
