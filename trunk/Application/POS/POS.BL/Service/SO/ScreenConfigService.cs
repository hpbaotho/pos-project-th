using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Service;
using POS.BL.Entities.Entity;
using System.Transactions;
using POS.BL.Utilities;
using Core.Standards.Validations;
using Core.Standards.Exceptions;
using POS.BL.DTO;
using System.Data.Common;

namespace POS.BL.Service.SO
{
    public class ScreenConfigService : ServiceBase<ScreenConfig>
    {
        public List<DuplicateItemDTO> IsDuplication(ScreenConfig screenConfig)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@"  SELECT  'Code' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN CAST(1 as BIT) 
                                       ELSE CAST(0 as BIT)
                                  END AS isDuplicate
                                 FROM    [sc_screen_config]  WITH(NOLOCK)
                                 WHERE  control_code = @control_code  
                                 AND control_id<>ISNULL(@control_id,0)
                                 AND ISNULL(control_parent_id,0) = 0
                            ");



            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("@control_code", screenConfig.control_code));
            param.Add(base.CreateParameter("@control_id", screenConfig.control_id));
            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
        public void ClearControlByParenr(long? parentId)
        {
            string sql = @" DELETE sc_screen_config where control_parent_id=@control_parent_id ";
            this.ExecuteNonQuery(sql, this.CreateParameter("control_parent_id", parentId));
        }
        public ScreenConfig getScreenByCode(string screenCode)
        {
            string sql = @"
                            SELECT * 
                            FROM sc_screen_config WITH(NOLOCK) 
                            WHERE ISNULL(control_code,'')=@control_code
                        ";
            return this.ExecuteQueryOne<ScreenConfig>(sql, this.CreateParameter("@control_code", screenCode));
        }
        public List<ScreenConfig> getParentScreen()
        {
            string sql = @"
                            SELECT * 
                            FROM sc_screen_config WITH(NOLOCK) 
                            WHERE ISNULL(control_code,'')<>''
                        ";

            return this.ExecuteQuery<ScreenConfig>(sql).ToList();
        }
        public List<ScreenConfig> getChildScreenByParent(long? parentId)
        {
            string sql = @"
                            SELECT * 
                            FROM sc_screen_config WITH(NOLOCK) 
                            WHERE  control_parent_id=@control_parent_id
                        ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("@control_parent_id", parentId));
            return this.ExecuteQuery<ScreenConfig>(sql, param.ToArray()).ToList();
        }
        public void Save(ScreenConfig mainScreen, List<ScreenConfig> listControls)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                try
                {



                    if (!mainScreen.control_id.HasValue || mainScreen.control_id < 1)
                    {
                        mainScreen.control_id = this.Insert<long>(mainScreen, ValidationRuleset.Insert);
                    }
                    else
                    {
                        this.Update(mainScreen, ValidationRuleset.Update);
                    }
                    this.ClearControlByParenr(mainScreen.control_id);
                    foreach (ScreenConfig item in listControls)
                    {
                        item.control_code = string.Empty;
                        item.control_parent_id = mainScreen.control_id;

                        this.Insert(item, ValidationRuleset.Insert);
                    }

                    trans.Complete();
                }
                catch (ValidationException ex)
                {
                    trans.Dispose();
                    throw ex;
                }
            }
        }
    }
}
