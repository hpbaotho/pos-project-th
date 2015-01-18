using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class TranDetailService : ServiceBase<TranDetail>
    {
        public DataSet GetGridTranDetail(long tran_head_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   SELECT 
                                    tranDetail.tran_detail_id,
	                                tranDetail.tran_head_id,
	                                tranDetail.material_id,
	                                tranDetail.warehouse_id_dest,
	                                material.material_name AS Material,
	                                warehouse.warehouse_name AS Warehouse,
	                                phy.lot_no AS [Lot No.],
	                                tranDetail.quantity AS Quantity,
	                                uom.uom_name AS UOM,
	                                tranDetail.remark AS Remark
                                FROM in_tran_detail tranDetail
                                INNER JOIN in_material material ON material.material_id = tranDetail.material_id
                                INNER JOIN db_warehouse warehouse ON warehouse.warehouse_id = tranDetail.warehouse_id_dest
                                INNER JOIN in_phy_lot phy ON phy.warehouse_id = tranDetail.warehouse_id_dest
	                                AND phy.material_id = tranDetail.material_id
                                INNER JOIN db_uom uom ON uom.uom_id = material.uom_id_receive
                                WHERE 1=1 AND tranDetail.tran_head_id = @tran_head_id");

            DbParameter parm = base.CreateParameter("tran_head_id", tran_head_id);

            return base.ExecuteQuery(sql.ToString(), parm);
        }
    }
}
