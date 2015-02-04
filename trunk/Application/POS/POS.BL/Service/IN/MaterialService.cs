using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;
using POS.BL.DTO;
using POS.BL.Utilities;

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

        public DataSet GetGridMaterial(Material entity)
        {
            //, ma.created_by AS [Created By], ma.created_date AS [Created Date]
            //, ma.updated_by AS [Updated By], ma.updated_date AS [Updated Date]  
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT  ma.material_id AS ID, ma.material_code AS [Material Code], ma.material_name AS [Material Name]
		                            , ma.material_description AS [Material Description], uomRe.uom_name AS [UOM Receive]
		                            , uomCount.uom_name AS [UOM Count], uomUse.uom_name AS [UOM Use], ma.active AS Active
		                            , ma.material_group_id AS [Group Id], ma.max_stock AS [Maximum Stock], ma.min_stock AS [Minimum Stock]
		                            , ma.shelf_life AS [Shelf Life], ma.material_cost AS [Material Cost]
		                            , ma.acceptable_variance AS [Acceptable Variance]
		                            , ma.material_pic AS [Picture]
                                    , mg.material_group_name AS [Material Group]
                              FROM in_material ma
                              INNER JOIN in_material_group mg ON mg.material_group_id = ma.material_group_id
                              LEFT JOIN db_uom uomRe on ma.uom_id_receive = uomRe.uom_id
                              LEFT JOIN db_uom uomCount on ma.uom_id_count = uomCount.uom_id
                              LEFT JOIN db_uom uomUse on ma.uom_id_use = uomUse.uom_id
                              WHERE 1 = 1 ");

            List<DbParameter> param = new List<DbParameter>();

            if (!string.IsNullOrEmpty(entity.material_code))
            {
                sql.AppendLine(@" AND CHARINDEX(@MaterialCode, ma.material_code) > 0 ");
                param.Add(this.CreateParameter("@MaterialCode", entity.material_code));                
            }
            if (!string.IsNullOrEmpty(entity.material_name))
            {
                sql.AppendLine(@" AND CHARINDEX(@MaterialName, ma.material_name) > 0 ");
                param.Add(this.CreateParameter("@MaterialName", entity.material_name));
            }
            if (!string.IsNullOrEmpty(entity.material_description))
            {
                sql.AppendLine(@" AND CHARINDEX(@MaterialDesc, ma.material_description) > 0 ");
                param.Add(this.CreateParameter("@MaterialDesc", entity.material_description));
            }
            if (entity.material_group_id!=null)
            {
                sql.AppendLine(@" AND ma.material_group_id = @MaterialGroupID ");
                param.Add(this.CreateParameter("@MaterialGroupID", entity.material_group_id));
            }            
            
            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<DuplicateItemDTO> IsDuplicationMaterial(Material material)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [in_material]  WITH(NOLOCK)
                                WHERE  material_code = @material_code
            ");

            //---Edit
            //if (material.material_id > 0)
            //{
            //    strSql.AppendLine(" AND material_id <>  material_id ");
            //}

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("material_code", material.material_code));
            //param.Add(base.CreateParameter("employee_id", material.material_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }

        public List<ComboBoxDTO> GetMaterialComboBoxDTO()
        {

            List<Material> lstEntity = new List<Material>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstComboBoxDTO.SetPleaseSelect();

            lstEntity = base.FindAll(false).ToList();

            foreach (Material child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = child.material_id.ToString();
                DTO.Display = child.material_code + ":" + child.material_name;
                lstComboBoxDTO.Add(DTO);
            }

            return lstComboBoxDTO;
        }
    }
}
