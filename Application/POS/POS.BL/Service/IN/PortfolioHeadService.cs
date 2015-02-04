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
    public class PortfolioHeadService : ServiceBase<PortfolioHead>
    {
        public DataSet GetGridPortfolioHead(PortfolioHead entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT 
                                    head.portfolio_head_id AS ID, 
                                    head.portfolio_head_code AS [Portfolio Code],
                                    head.portfolio_head_name AS [Portfolio Name],
                                    head.portfolio_head_desc AS [Portfolio Description]
                              FROM in_portfolio_head head                              
                              WHERE 1 = 1 ");

            List<DbParameter> param = new List<DbParameter>();

            if (!string.IsNullOrEmpty(entity.portfolio_head_code))
            {
                sql.AppendLine(@" AND CHARINDEX(@PortfolioHeadCode, head.portfolio_head_code) > 0 ");
                param.Add(this.CreateParameter("@PortfolioHeadCode", entity.portfolio_head_code));
            }
            if (!string.IsNullOrEmpty(entity.portfolio_head_name))
            {
                sql.AppendLine(@" AND CHARINDEX(@PortfolioHeadName, head.portfolio_head_name) > 0 ");
                param.Add(this.CreateParameter("@PortfolioHeadName", entity.portfolio_head_name));
            }
            if (!string.IsNullOrEmpty(entity.portfolio_head_desc))
            {
                sql.AppendLine(@" AND CHARINDEX(@PortfolioHeadDesc, head.portfolio_head_desc) > 0 ");
                param.Add(this.CreateParameter("@PortfolioHeadDesc", entity.portfolio_head_desc));
            }
            
            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }
    }
}
