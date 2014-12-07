using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data;
using System.Data.Common;

namespace POS.BL.Service.SU
{
    public class SystemConfigurationService : ServiceBase<SystemConfiguration>
    {
        public DataSet GetSystemConfig(string Code)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM cbs_system_configuration
                            WHERE system_configuration_code = @Code  ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(base.CreateParameter("@Code", Code));

            return base.ExecuteQuery(sql.ToString(), parameters.ToArray());
        }
    }
}
