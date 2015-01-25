using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using System.Data.Common;
using System.Data;

namespace POS.BL.Service.IN
{
    public class MaterialGroupService : ServiceBase<MaterialGroup>
    {
        public DataSet GetGridMaterialGroup(string materialGroupCode, string materialGroupName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT material_group_id AS ID,material_group_code AS [Material Group Code]
                                    , material_group_name AS [Materual Group Name], material_group_desc AS [Material Group Description]
                                    , active AS [Active]
                                    FROM in_material_group
                                    WHERE 1=1 ");

            if (!string.IsNullOrEmpty(materialGroupCode))
            {
                sql.AppendLine(@" AND CHARINDEX(@MaterialGroupCode, material_group_code) > 0 ");
            }
            if (!string.IsNullOrEmpty(materialGroupName))
            {
                sql.AppendLine(@" AND ( CHARINDEX(@MaterialGroupName, material_group_name) > 0
		                                OR CHARINDEX(@MaterialGroupName, material_group_desc) > 0
	                                  ) ");
            }
            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@MaterialGroupCode", materialGroupCode));
            param.Add(this.CreateParameter("@MaterialGroupName", materialGroupName));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<DuplicateItemDTO> IsDuplicationMaterialGroup(MaterialGroup material)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [in_material_group]  WITH(NOLOCK)
                                WHERE  material_group_code = @material_group_code
                                ");

            //---Edit
            //if (material.material_id > 0)
            //{
            //    strSql.AppendLine(" AND material_id <>  material_id ");
            //}

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("material_group_code", material.material_group_code));
            //param.Add(base.CreateParameter("employee_id", material.material_id));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
    }
}
