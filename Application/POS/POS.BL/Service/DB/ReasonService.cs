using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO;
using POS.BL.Utilities;

namespace POS.BL.Service.DB
{
    public class ReasonService : ServiceBase<Reason>
    {
        public List<ComboBoxDTO> GetReasonComboBoxDTOByDocumentTypeID(long DocumentTypeID, long? ReasonID = null)
        {

            List<Reason> lstEntity = new List<Reason>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstEntity = base.FindAll(false).Where(w => w.active && w.document_type_id == DocumentTypeID).ToList();

            if (ReasonID != null && lstEntity.Where(w=>w.reason_id == ReasonID.Value).Count() == 0)
            {
                Reason entity = new Reason() { reason_id = ReasonID.Value };
                entity = base.FindByKeys(entity, false);
                lstEntity.Add(entity);
            }

            foreach (Reason child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = child.reason_id.ToString();
                DTO.Display = child.reason_name;
                lstComboBoxDTO.Add(DTO);
            }
            lstComboBoxDTO = lstComboBoxDTO.OrderBy(o => o.Display).ToList();
            lstComboBoxDTO.SetPleaseSelect();
            return lstComboBoxDTO;
        }
    }
}
