using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class StockDetailService : ServiceBase<StockDetail>
    {
        public DataSet GetStockDetail(long StockHeadID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT 
                                  stockDetail.stock_detail_id as stock_detail_id
								, material.material_id
	                            , material.material_name AS [Material]
	                            , stockDetail.lot_no AS [Lot No.]
	                            , stockDetail.bf_qty AS [Count]
                                , stockDetail.bal_qty AS [Adjust]
                                , UOM.uom_name AS [UOM]
                                , stockDetail.remark AS [Remark]
                            FROM in_stock_detail AS stockDetail 
                            INNER JOIN in_material AS material
                                ON material.material_id = stockDetail.material_id
                            INNER JOIN db_uom AS UOM
								ON UOM.uom_id = material.uom_id_count
                            WHERE 1=1 
                                AND stockDetail.stock_head_id = @StockHeadID
                            ");

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("StockHeadID", StockHeadID));            

            return base.ExecuteQuery(sql.ToString(), param);
        }
        public DataSet GetStockDetail(long PeriodGroupdID, long WarehouseID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT 
                                  null as stock_detail_id
								, material.material_id
	                            , material.material_name AS [Material]
	                            , phyLot.lot_no AS [Lot No.]
	                            , SUM(phyLot.bal_qty) AS [Count]
                                , SUM(phyLot.bal_qty) AS [Adjust]
                                , UOM.uom_name AS [UOM]
                                , '' AS [Remark]
                            FROM in_material AS material
                            INNER JOIN in_phy_lot AS phyLot
	                            ON phyLot.material_id = material.material_id
                            INNER JOIN in_period AS period
	                            ON period.period_group_id = material.period_group_id
                            INNER JOIN db_uom AS UOM
								ON UOM.uom_id = material.uom_id_count
                            WHERE 1=1 
                                AND phyLot.warehouse_id = @WarehouseID
                                AND period.period_group_id = @PeriodGroupdID  
                            GROUP BY material.material_id, material.material_name, phyLot.lot_no, UOM.uom_name
                            ");

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("PeriodGroupdID", PeriodGroupdID));            
            param.Add(base.CreateParameter("WarehouseID", WarehouseID));

            return base.ExecuteQuery(sql.ToString(), param);
        }
    }
}
