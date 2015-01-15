using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Entity;
using Core.Standards.Validations;
using POS.BL.DTO;
using System.Reflection;
using Core.Standards.Attributes;
using POS.BL.Utilities;

namespace POS.BL.Service
{
    public class ServiceBase<TEntity> : Core.Standards.Service.DatabaseService<TEntity> where TEntity : EntityBase, new()
    {
        //public UserAccount CurentUser { get { return System.Web.HttpContext.Current.Session[SessionName.UserAccount] as UserAccount; } }
        protected override string ConnectionStringName
        {
            get
            {
                return POS.BL.Utilities.ConnectionStringName.POSConnection;
            }
        }

        public List<ComboBoxDTO> FindByActiveOrID(TEntity entity = null)
        {
            PropertyInfo PropertyInfoComboBoxDisplay = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ComboBoxDisplay", true, true).FirstOrDefault();
            PropertyInfo PropertyInfoComboBoxValue = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ComboBoxValue", true, true).FirstOrDefault();
            if (PropertyInfoComboBoxDisplay == null) { PropertyInfoComboBoxDisplay = typeof(TEntity).GetProperties().Where(w => w.Name.Contains("Name")).FirstOrDefault(); }
            if (PropertyInfoComboBoxValue == null) { PropertyInfoComboBoxValue = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("IdentityKey", true, true).FirstOrDefault(); }

            List<TEntity> lstEntity = new List<TEntity>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstComboBoxDTO.SetPleaseSelect();

            if (typeof(TEntity).GetInterfaces().Contains(typeof(POS.BL.Entities.IEntityMasterBase)))
            {
                if (entity != null)
                {
                    TEntity Entity = base.FindByKeys(entity, false);
                    lstEntity.Add(Entity);
                }
                else
                {
                    lstEntity = base.FindAll(false).Where(w => ((POS.BL.Entities.IEntityMasterBase)w).active).ToList();
                }

                foreach (TEntity child in lstEntity)
                {
                    ComboBoxDTO DTO = new ComboBoxDTO();
                    PropertyInfo[] properties = child.GetType().GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.Name == PropertyInfoComboBoxDisplay.Name)
                        {
                            DTO.Display = property.GetValue(child, null).ToString();
                        }
                        else if (property.Name == PropertyInfoComboBoxValue.Name)
                        {
                            DTO.Value = property.GetValue(child, null).ToString();
                        }
                    }
                    DTO.Display = DTO.Display + " (" + DTO.Value + ")";
                    lstComboBoxDTO.Add(DTO);
                }
            }
            return lstComboBoxDTO;
        }
    }
}
