using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using POS.BL.Utilities;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.IN
{
    public class BillOfMaterialHeadService : ServiceBase<BillOfMaterialHead>
    {
        public DataSet GetGridBOMHead(long? BOMGroup, string BOMHeadCode, string BOMHeadName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT TOP 50 
                            in_bill_of_material_head.bill_of_material_head_id AS ID
                            ,in_bill_of_material_group.bill_of_material_group_name AS [BOM Group Name]
                            ,in_bill_of_material_head.bill_of_material_head_code AS [BOM Code]
                            ,in_bill_of_material_head.bill_of_material_head_name AS [BOM Name]
                            ,in_bill_of_material_head.bill_of_material_head_description AS [Description]
                            ,in_bill_of_material_head.remark AS Remark
                            ,in_bill_of_material_head.created_by AS [Created By]
                            ,in_bill_of_material_head.created_date [Created Date]
                            ,in_bill_of_material_head.updated_by [Updated By]
                            ,in_bill_of_material_head.updated_date [Updated Date] 
                            FROM in_bill_of_material_head WITH(NOLOCK)
                            LEFT JOIN in_bill_of_material_group WITH(NOLOCK)
                            ON in_bill_of_material_head.bill_of_material_group_id = in_bill_of_material_group.bill_of_material_group_id
                            WHERE 1=1 ");

            if (BOMGroup.HasValue)
            {
                sql.AppendLine(" AND  in_bill_of_material_head.bill_of_material_group_id = @bill_of_material_group_id ");
            }
            if (!string.IsNullOrEmpty(BOMHeadCode))
            {
                sql.AppendLine(" AND  CHARINDEX(@bill_of_material_head_code,in_bill_of_material_head.bill_of_material_head_code) > 0 ");
            }
            if (!string.IsNullOrEmpty(BOMHeadName))
            {
                sql.AppendLine(" AND  CHARINDEX(@bill_of_material_head_name,in_bill_of_material_head.bill_of_material_head_name) > 0 ");
            }

            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@bill_of_material_group_id", BOMGroup));
            param.Add(this.CreateParameter("@bill_of_material_head_code", BOMHeadCode));
            param.Add(this.CreateParameter("@bill_of_material_head_name", BOMHeadName));
            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }

        public List<ComboBoxDTO> GetBillOfMaterialHeadComboBoxDTOByID(long? billOfMaterialHeadID)
        {

            List<BillOfMaterialHead> lstEntity = new List<BillOfMaterialHead>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstComboBoxDTO.SetPleaseSelect();

            if (billOfMaterialHeadID != null)
            {
                BillOfMaterialHead entity = new BillOfMaterialHead() { bill_of_material_head_id = billOfMaterialHeadID.Value };
                entity = base.FindByKeys(entity, false);
                lstEntity.Add(entity);
            }
            else
            {
                lstEntity = base.FindAll(false).ToList();
            }

            foreach (BillOfMaterialHead child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = child.bill_of_material_head_id.ToString();
                DTO.Display = child.bill_of_material_head_name;
                lstComboBoxDTO.Add(DTO);
            }

            return lstComboBoxDTO;
        }
    }
}
