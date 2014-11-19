using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.Service.Services;
using System.Data;
using System.Data.Common;

namespace POS.Service.Services.Service
{
    public class SystemConfigurationService : ServiceBase<SystemConfiguration>
    {
        public DataSet GetSystemConfig()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM cbs_system_configuration
                            WHERE system_configuration_code = '0101'  ");

            IList<DbParameter> parameters = new List<DbParameter>();
            //parameters.Add(base.CreateParameter("@Code", "0101"));

            return base.ExecuteQuery(sql.ToString(), parameters.ToArray());
        }
    }
}
