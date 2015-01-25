using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using POS.BL.Utilities;

namespace POS.BL.Service.IN
{
    public class BillOfMaterialGroupService : ServiceBase<BillOfMaterialGroup>
    {
        public List<ComboBoxDTO> GetBillOfMaterialGroupComboBoxDTO()
        {

            List<BillOfMaterialGroup> lstEntity = new List<BillOfMaterialGroup>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstComboBoxDTO.SetStringEmpty();

            lstEntity = base.FindAll(false).ToList();

            foreach (BillOfMaterialGroup child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = child.bill_of_material_group_id.ToString();
                DTO.Display = child.bill_of_material_group_code + ":" + child.bill_of_material_group_name;
                lstComboBoxDTO.Add(DTO);
            }

            return lstComboBoxDTO;
        }
    }
}
