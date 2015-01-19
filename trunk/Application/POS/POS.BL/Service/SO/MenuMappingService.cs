using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using POS.BL.DTO;
using System.Data.Common;
using System.Transactions;
using Core.Standards.Validations;

namespace POS.BL.Service.SO
{
    public class MenuMappingService : ServiceBase<MenuMapping>
    {
        public DataSet GetGridMenuMapping(string MenuName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT TOP 50 menu_id AS ID
                            , menu_code AS Code
                            , menu_name AS Name
                            , menu_description AS [Description]
                            , active AS Active
                            , created_by AS [Created By]
                            , created_date [Created Date]
                            , updated_by [Updated By]
                            , updated_date [Updated Date] 
                            --, isInventoryItem, menu_group_id, menu_category_id, priorityValue
                            FROM dbo.so_menu WITH(NOLOCK)
                            WHERE 1=1 ");

            if (!string.IsNullOrEmpty(MenuName))
            {
                sql.AppendLine(" AND  CHARINDEX(@menu_name,menu_name) > 0 ");
            }
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@menu_name", MenuName));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public DataSet GetGridMenuMappingDetail(long MenuId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT so_menu_mapping.menu_mapping_id AS ID
                                    ,in_bill_of_material_head.bill_of_material_head_name AS [Bill Of Material]
                                    ,CAST(so_menu_mapping.quantity AS int) AS Quantity
                                    ,so_menu_mapping.created_by AS [Created By]
                                    ,so_menu_mapping.created_date AS [Created Date]
                                    ,so_menu_mapping.updated_by AS [Updated By]
                                    ,so_menu_mapping.updated_date AS [Updated Date] 
                                    FROM so_menu_mapping WITH(NOLOCK)
                                    LEFT JOIN in_bill_of_material_head WITH(NOLOCK)
                                    ON so_menu_mapping.bill_of_material_head_id = in_bill_of_material_head.bill_of_material_head_id
                                    LEFT JOIN so_menu WITH(NOLOCK)
                                    ON so_menu_mapping.menu_id = so_menu.menu_id 
                                    WHERE 1=1
                                    AND so_menu_mapping.menu_id = @menu_id 
                                    ");

            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@menu_id", MenuId));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<DuplicateItemDTO> IsDuplicationMenuMapping(MenuMapping menuMapping)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [so_menu_mapping]  WITH(NOLOCK)
                                WHERE  menu_id =  @menu_id
                                AND bill_of_material_head_id = @bill_of_material_head_id
            ");

            //---Edit
            if (menuMapping.menu_mapping_id > 0)
            {
                strSql.AppendLine(" AND menu_mapping_id <> @menu_mapping_id ");
            }

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_id", menuMapping.menu_id));
            param.Add(base.CreateParameter("bill_of_material_head_id", menuMapping.bill_of_material_head_id));
            param.Add(base.CreateParameter("menu_mapping_id", menuMapping.menu_mapping_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }

        public int DeleteMappingMenu(List<long?> listMenuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@" DELETE so_menu_mapping
                                 WHERE menu_id IN ({0})
            ", string.Join(",", listMenuID.ToArray()));

            List<DbParameter> param = new List<DbParameter>();
            //param.Add(base.CreateParameter("menu_id", menuMapping.menu_id));

            return this.ExecuteNonQuery(strSql.ToString(), param.ToArray());
        }
    }
}
