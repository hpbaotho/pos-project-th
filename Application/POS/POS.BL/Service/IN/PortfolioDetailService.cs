using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;
using POS.BL.DTO;

namespace POS.BL.Service.IN
{
    public class PortfolioDetailService : ServiceBase<PortfolioDetail>
    {
        public DataSet GetGridPortfolioDetail(PortfolioHead entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   SELECT  
	                                material.material_id,
	                                material.material_code,
	                                material.material_name,
	                                NULL AS warehouse_id,
	                                '' AS warehouse_name,
	                                uom.uom_name
                                FROM in_portfolio_detail AS detail
                                INNER JOIN in_material AS material ON detail.material_id = material.material_id
                                LEFT JOIN db_uom AS uom ON uom.uom_id = material.uom_id_receive 
                                WHERE 1=1 ");

            List<DbParameter> param = new List<DbParameter>();

            if (entity.portfolio_head_id != 0)
            {
                sql.AppendLine(@" AND detail.portfolio_head_id = @PortfolioHeadID ");
                param.Add(this.CreateParameter("@PortfolioHeadID", entity.portfolio_head_id));
            }

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }
    }
}
