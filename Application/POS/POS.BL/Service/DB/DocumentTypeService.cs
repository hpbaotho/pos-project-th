using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using System.Transactions;
using Core.Standards.Converters;

namespace POS.BL.Service.DB
{
    public class DocumentTypeService : ServiceBase<DocumentType>
    {
        public long GetDocumentTypeIDByDocumentTypeCode(string DocumentTypeCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT document_type_id FROM {0} ", base.EntityTableName);
            sql.AppendLine(" WHERE document_type_name = @document_type_name ");
            DbParameter param = base.CreateParameter("document_type_name", DocumentTypeCode);
            object documentTypeIDObj = this.ExecuteScalar(sql.ToString(), param);
            long documentTypeID = 0;
            if (documentTypeIDObj != null && documentTypeIDObj != DBNull.Value)
            {
                documentTypeID = Converts.ParseLong(documentTypeIDObj.ToString());
            }
            return documentTypeID;
        }

        public string GetDocumentNumberByDocumentTypeCode(string DocumentTypeCode, DateTime DocumentDate, params string[] Parameter)
        {
            string documentNo = string.Empty;
            using (TransactionScope ts = new TransactionScope())
            {
                long documentTypeID = this.GetDocumentTypeIDByDocumentTypeCode(DocumentTypeCode);

                DocumentLastRunningNumber entityDocumentLastRunningNo = ServiceProvider.DocumentLastRunningNumberService.GetLastRunningByDocumentType(documentTypeID);
                string RunningFormat = ServiceProvider.DocumentNumberFormatService.GetDocumentRunningFormat(documentTypeID);

                long LastRunningNo = (entityDocumentLastRunningNo.document_last_running_number + 1);

                string Year = DocumentDate.ToString("yy");
                string Month = DocumentDate.ToString("MM");
                string Day = DocumentDate.ToString("dd");
                string RunningNo = LastRunningNo.ToString().PadLeft(4, '0');

                documentNo = string.Format(RunningFormat, DocumentTypeCode, Year, Month, Day, Parameter).Replace("[RUNNING]",RunningNo);

                entityDocumentLastRunningNo.document_last_running_number = LastRunningNo;
                ServiceProvider.DocumentLastRunningNumberService.Update(entityDocumentLastRunningNo);

                ts.Complete();
            }
            return documentNo;
        }
    }
}
