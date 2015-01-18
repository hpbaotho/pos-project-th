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
            PropertyInfo PropertyInfoComboBoxCode = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ComboBoxCode", true, true).FirstOrDefault();

            if (PropertyInfoComboBoxDisplay == null) { PropertyInfoComboBoxDisplay = typeof(TEntity).GetProperties().Where(w => w.Name.Contains("name")).FirstOrDefault(); }
            if (PropertyInfoComboBoxValue == null) { PropertyInfoComboBoxValue = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("IdentityKey", true, true).FirstOrDefault(); }
            if (PropertyInfoComboBoxCode == null) { PropertyInfoComboBoxCode = typeof(TEntity).GetProperties().Where(w => w.Name.Contains("code")).FirstOrDefault(); }

            List<TEntity> lstEntity = new List<TEntity>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();

            if (typeof(TEntity).GetInterfaces().Contains(typeof(POS.BL.Entities.IEntityMasterBase)))
            {
                lstEntity = base.FindAll(false).Where(w => ((POS.BL.Entities.IEntityMasterBase)w).active).ToList();

                if (entity != null)
                {
                    TEntity Entity = base.FindByKeys(entity, false);
                    lstEntity.Add(Entity);
                }

                foreach (TEntity child in lstEntity)
                {
                    ComboBoxDTO DTO = new ComboBoxDTO();
                    PropertyInfo[] properties = child.GetType().GetProperties();
                    string Code = string.Empty;
                    string Display = string.Empty;
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.Name == PropertyInfoComboBoxDisplay.Name)
                        {
                            Display = property.GetValue(child, null).ToString();
                        }
                        else if (property.Name == PropertyInfoComboBoxValue.Name)
                        {
                            DTO.Value = property.GetValue(child, null).ToString();
                        }
                        else if (property.Name == PropertyInfoComboBoxCode.Name)
                        {
                            Code = property.GetValue(child, null).ToString();
                        }

                    }
                    DTO.Display = Code + ":" + Display;
                    if (lstComboBoxDTO.Where(w => w.Value == DTO.Value).Count() == 0)
                    {
                        lstComboBoxDTO.Add(DTO);
                    }
                }
            }
            lstComboBoxDTO = lstComboBoxDTO.OrderBy(o => o.Display).ToList();
            lstComboBoxDTO.SetPleaseSelect();
            return lstComboBoxDTO;
        }
    }
}
