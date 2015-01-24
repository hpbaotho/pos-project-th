using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

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

        public DataSet GetGridMaterial(string materialCode, string materialName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT ma.material_id AS ID, ma.material_code AS [Material Code], ma.material_name AS [Material Name]
		                            , ma.material_description AS [Material Description], uomRe.uom_name AS [UOM Receive]
		                            , uomCount.uom_name AS [UOM Count], uomUse.uom_name AS [UOM Use], ma.active AS Active
		                            , ma.created_by AS [Created By], ma.created_date AS [Created Date]
		                            , ma.updated_by AS [Updated By], ma.updated_date AS [Updated Date]  
		                            , ma.material_group_id AS [Group Id], ma.max_stock AS [Maximum Stock], ma.min_stock AS [Minimum Stock]
		                            , ma.shelf_life AS [Shelf Life], ma.material_cost AS [Material Cost]
		                            , ma.acceptable_variance AS [Acceptable Variance]
		                            , ma.material_pic AS [Picture]
                              FROM in_material ma
                              LEFT JOIN db_uom uomRe on ma.uom_id_receive = uomRe.uom_id
                              LEFT JOIN db_uom uomCount on ma.uom_id_count = uomRe.uom_id
                              LEFT JOIN db_uom uomUse on ma.uom_id_use = uomRe.uom_id
                              WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(materialCode))
            {
                sql.AppendLine(@" AND CHARINDEX(@MaterialCode, ma.material_code) > 0 ");
            }
            if (!string.IsNullOrEmpty(materialName))
            {
                sql.AppendLine(@" AND ( CHARINDEX(@MaterialName, ma.material_name) > 0
		                                OR CHARINDEX(@MaterialName, ma.material_description) > 0
	                                  ) ");
            }
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@MaterialCode", materialCode));
            param.Add(this.CreateParameter("@MaterialName", materialName));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }
    }
}
