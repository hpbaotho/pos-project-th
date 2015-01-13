using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Entity;
using Core.Standards.Validations;
using POS.BL.DTO;
using System.Reflection;
using Core.Standards.Attributes;

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
            List<TEntity> lstEntity = new List<TEntity>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            if (entity != null)
            {
                TEntity Entity = base.FindByKeys(entity, false);
                lstEntity.Add(Entity);
            }
            else
            {
        
                lstEntity = base.FindAll(false).ToList();
                //  lstComboBoxDTO = lstEntity.Where(w => 1 == 1).ToList();
            }
            foreach (TEntity child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                PropertyInfo[] properties = child.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == PropertyInfoComboBoxDisplay.Name)
                    {
                        DTO.Display = property.GetValue(properties, null).ToString();
                    }
                    else if (property.Name == PropertyInfoComboBoxDisplay.Name) { DTO.Value = property.GetValue(properties, null).ToString(); }
                }
                lstComboBoxDTO.Add(DTO);
            }
            return lstComboBoxDTO;


        }
    }
}
