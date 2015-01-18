using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;

namespace POS.BL.Service.IN
{
    public class PhyLotService : ServiceBase<PhyLot>
    {
        public double GetCurrentLotNo(PhyLot entity)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT MAX(lot_no) FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendLine(" AND material_id = @material_id ");
            SQL.AppendLine(" AND warehouse_id = @warehouse_id ");

            DbParameter param1 = base.CreateParameter("material_id", entity.material_id);
            DbParameter param2 = base.CreateParameter("warehouse_id", entity.warehouse_id);

            object maxLotNoObject = base.ExecuteScalar(SQL.ToString(), param1, param2);
            double LotNo = maxLotNoObject.ToDouble();

            return LotNo;
        }

        public PhyLot GetPhyLot(long material_id, long warehouse_id, double lot_no)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat(" SELECT * FROM {0} WHERE 1=1 ", base.EntityTableName);
            SQL.AppendLine(" AND material_id = @material_id ");
            SQL.AppendLine(" AND warehouse_id = @warehouse_id ");
            SQL.AppendLine(" AND lot_no = @lot_no ");

            DbParameter param1 = base.CreateParameter("material_id", material_id);
            DbParameter param2 = base.CreateParameter("warehouse_id", warehouse_id);
            DbParameter param3 = base.CreateParameter("lot_no", lot_no);

            PhyLot entity = base.ExecuteQueryOne<PhyLot>(SQL.ToString(), param1, param2, param3);
            if (entity == null || entity.phy_lot_id == 0)
            {
                entity = new PhyLot();
                entity.created_by = "System";
                entity.created_date = DateTime.Now;
                entity.updated_by = "System";
                entity.updated_date = DateTime.Now;
                entity.lot_no = lot_no;
                entity.material_id = material_id;
                entity.warehouse_id = warehouse_id;
                entity.bal_qty = 0;

                entity.phy_lot_id = base.Insert<long>(entity);
            }
            return entity;
        }

        public bool CheckLimitMaterial(long material_id, long warehouse_id, double quantity)
        {
            Material entityMaterial = new Material() { material_id = material_id };
            entityMaterial = ServiceProvider.MaterialService.FindByKeys(entityMaterial, false);

            double balanceQty = ServiceProvider.LogLotService.GetBalanceQty(material_id, warehouse_id);

            return (balanceQty + quantity) <= entityMaterial.max_stock;
        }
    }
}