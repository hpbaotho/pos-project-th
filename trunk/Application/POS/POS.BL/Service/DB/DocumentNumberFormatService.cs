using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;

namespace POS.BL.Service.DB
{
    public class DocumentNumberFormatService : ServiceBase<DocumentNumberFormat>
    {
        public string GetDocumentRunningFormat(long DocumentTypeID)
        {
            StringBuilder sql = new StringBuilder();
            string RunningFormat = string.Empty;
            sql.AppendFormat(" SELECT document_number_format_name AS Value FROM {0} ", base.EntityTableName);
            sql.AppendLine(" WHERE document_type_id = @document_type_id ");
            DbParameter param = base.CreateParameter("document_type_id", DocumentTypeID);
            object RunningFormatObj = base.ExecuteScalar(sql.ToString(), param);
            if (RunningFormatObj != null && RunningFormatObj != DBNull.Value)
            {
                RunningFormat = RunningFormatObj.ToString();
            }

            return RunningFormat;
        }
    }
}
