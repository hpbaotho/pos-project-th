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
    public class BillOfMaterialDetailService : ServiceBase<BillOfMaterialDetail>
    {
        public DataSet GetGridBillOfMaterialDetail(long BOMHeadID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT in_bill_of_material_detail.bill_of_material_detail_id AS ID
                                    ,in_material.material_name AS Material
                                    ,BOMHeadSub.bill_of_material_head_name AS BOM
                                    ,CAST(in_bill_of_material_detail.amount AS int) AS Amount
                                    ,in_bill_of_material_detail.created_by AS [Created By]
                                    ,in_bill_of_material_detail.created_date AS [Created Date]
                                    ,in_bill_of_material_detail.updated_by AS [Updated By]
                                    ,in_bill_of_material_detail.updated_date AS [Updated Date] 
                                    FROM in_bill_of_material_detail WITH(NOLOCK)
                                    LEFT JOIN in_material WITH(NOLOCK)
                                    ON in_bill_of_material_detail.material_id = in_material.material_id
                                    LEFT JOIN in_bill_of_material_head BOMHeadSub WITH(NOLOCK)
                                    ON in_bill_of_material_detail.bill_of_material_head_id_sub = BOMHeadSub.bill_of_material_head_id
                                    WHERE 1=1
                                    AND in_bill_of_material_detail.bill_of_material_head_id = @bill_of_material_head_id 
                                    ");

            List<DbParameter> param = new List<DbParameter>();
            param.Add(this.CreateParameter("@bill_of_material_head_id", BOMHeadID));

            return base.ExecuteQuery(sql.ToString(), param.ToArray());
        }
    }
}
