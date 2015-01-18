using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;

namespace POS.BL.Service.DB
{
    public class DocumentLastRunningNumberService : ServiceBase<DocumentLastRunningNumber>
    {
        public DocumentLastRunningNumber GetLastRunningByDocumentType(long DocumentTypeID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT * FROM {0} ", base.EntityTableName);
            sql.AppendLine(" WHERE document_type_id = @document_type_id ");
            DbParameter param = base.CreateParameter("document_type_id", DocumentTypeID);
            DocumentLastRunningNumber entity = base.ExecuteQueryOne<DocumentLastRunningNumber>(sql.ToString(), param);
            if (entity == null || entity.document_last_running_number_id == 0)
            {
                entity.document_last_running_number = 0;
                entity.document_type_id = DocumentTypeID;
                entity.document_number_value = "0";
                entity.document_last_running_number_id = base.Insert<long>(entity);
            }
            return entity;
        }
    }
}
