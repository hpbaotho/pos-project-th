using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using POS.BL.Utilities;

namespace POS.BL.Service.IN
{
    public class BillOfMaterialHeadService : ServiceBase<BillOfMaterialHead>
    {
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
