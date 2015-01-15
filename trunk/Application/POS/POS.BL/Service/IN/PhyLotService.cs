using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;

namespace POS.BL.Service.IN
{
    public class PhyLotService:ServiceBase<PhyLot>
    {
        public double GetCurrentLotNo(PhyLot entity)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT MAX(lot_no) FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendFormat(" AND material_id = {0} ", entity.material_id);
            SQL.AppendFormat(" AND warehouse_id = {0} ", entity.warehouse_id);

            DbParameter param1 = base.CreateParameter("material_id",entity.material_id);
            DbParameter param2 = base.CreateParameter("warehouse_id",entity.warehouse_id);

            object maxLotNoObject = base.ExecuteScalar(SQL.ToString(), param1, param2);
            double LotNo = maxLotNoObject.ToDouble();

            return LotNo;
        }
    }
}