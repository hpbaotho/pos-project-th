using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using Core.Standards.Validations;

namespace POS.BL.Service.SU
{
    public class SystemConfigGroupService : ServiceBase<SystemConfigGroup>
    {
        public int Insert(SystemConfigGroup entity)
        {
            return base.Insert(entity, new string[] { ValidationRuleset.Insert });
        }
        public int Update(SystemConfigGroup entity)
        {
            return base.Update(entity, new string[] { ValidationRuleset.Update });
        }
        public List<SystemConfigGroup> GetEntites(List<Dictionary<string, object>> listKey)
        {
            List<SystemConfigGroup> entities = new List<SystemConfigGroup>();

            foreach (Dictionary<string, object> item in listKey)
            {
                SystemConfigGroup entity = new SystemConfigGroup() { system_configuration_group_code = item["system_configuration_group_code"].ToString() };
                entities.Add(base.FindByKeys(entity, true));

            }


            return entities;

        }
        public int Delete(List<Dictionary<string, object>> listKey)
        {
            int count = 0;
            List<SystemConfigGroup> entities = GetEntites(listKey);
            foreach (SystemConfigGroup entity in entities)
            {
                count += base.Delete(entity, new string[] { ValidationRuleset.Delete });
            }
            return count;
        }
    }
}
