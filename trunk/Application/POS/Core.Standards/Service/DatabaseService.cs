using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Data;
using System.Data.Common;
using Core.Standards.Entity;
using Core.Standards.Attributes;
using System.Reflection;
using Core.Standards.Extensions;
using Core.Standards.Exceptions;
using System.Data.SqlClient;
using System.Transactions;

namespace Core.Standards.Service
{
    public class DatabaseService
    {
        protected virtual string ConnectionStringName { get; set; }
        internal Database dbManager;
        protected DatabaseService()
        {
            try
            {
                dbManager = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Parameter
        protected DbParameter CreateParameter(string parameterName, object value)
        {
            DbParameter parameter = dbManager.DbProviderFactory.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            // Handle mapping StrongType with DbType (may add more handle case).
            if ((value != null) && (value.GetType() == typeof(byte[])))
            {
                parameter.DbType = DbType.Binary;
            }

            return parameter;
        }
        protected DbParameter CreateParameter(string parameterName, object value, DbType dbType)
        {
            DbParameter parameter = this.CreateParameter(parameterName, value);
            parameter.DbType = dbType;

            return parameter;
        }
        protected string CreateParametersName(string parameterName, List<string> listObj)
        {
            StringBuilder sqlParam = new StringBuilder();
            // Build  Status Parameter.
            if ((listObj != null) && (listObj.Count > 0))
            {
                for (int index = 0; index < listObj.Count; index++)
                {
                    if (index > 0) sqlParam.Append(", ");

                    string param = string.Format("@{0}{1}", parameterName, index);
                    sqlParam.Append(param);
                }
            }

            return sqlParam.ToString();
        }
        protected List<DbParameter> CreateParameters(string parameterName, List<string> listObj)
        {
            List<DbParameter> listParam = new List<DbParameter>();

            for (int index = 0; index < listObj.Count; index++)
            {
                string param = string.Format("@{0}{1}", parameterName, index);
                listParam.Add(this.CreateParameter(param, listObj[index]));
            }

            return listParam;
        }
        #endregion

        #region Execute SQL Command

        protected DataSet ExecuteQuery(string SQLText, List<DbParameter> Parameter)
        {
            DataSet returnDs = null;

            DbCommand command = dbManager.GetSqlStringCommand(SQLText);
            command.CommandType = CommandType.Text;

            foreach (DbParameter Param in Parameter)
            {
                if (Param.Value == null)
                {
                    Param.Value = DBNull.Value;
                    Param.IsNullable = true;
                }
                command.Parameters.Add(Param);
            }

            returnDs = dbManager.ExecuteDataSet(command);
            command.Parameters.Clear();
            return returnDs;
        }
        protected DataSet ExecuteQuery(string query, params object[] parameters)
        {
            DataSet returnDs = null;
            DbCommand command = dbManager.GetSqlStringCommand(query);
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.IsNullable = true;
                    parameter.Value = DBNull.Value;
                }

                command.Parameters.Add(parameter);
            }

            returnDs = dbManager.ExecuteDataSet(command);
            return returnDs;
        }
        protected IEnumerable<TResult> ExecuteQuery<TResult>(string query, params DbParameter[] parameters) where TResult : new()
        {
            DataSet ds = this.ExecuteQuery(query, (parameters as object[]));
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {
                return ds.Tables[0].AsEnumerable<TResult>();
            }
            else
            {
                return new List<TResult>();
            }
        }
        protected TResult ExecuteQueryOne<TResult>(string query, params DbParameter[] parameters) where TResult : new()
        {
            DataSet ds = this.ExecuteQuery(query, (parameters as object[]));
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
            {

                return ds.Tables[0].Rows[0].AsEnumerable<TResult>(); ;
            }
            else
            {

                return default(TResult);
            }
        }

        protected int ExecuteNonQuery(string query, params object[] parameters)
        {
            int returnInt = 0;

            DbCommand command = dbManager.GetSqlStringCommand(query);
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                    parameter.IsNullable = true;
                }
                command.Parameters.Add(parameter);
            }

            returnInt = dbManager.ExecuteNonQuery(command);
            return returnInt;
        }

        protected object ExecuteScalar(string query, params object[] parameters)
        {
            object returnObj = null;

            DbCommand command = dbManager.GetSqlStringCommand(query);
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.IsNullable = true;
                    parameter.Value = DBNull.Value;
                }

                command.Parameters.Add(parameter);
            }

            returnObj = dbManager.ExecuteScalar(command);
            return returnObj;
        }
        protected object ExecuteScalar(string SQLText, List<DbParameter> Parameter)
        {
            object returnObj = null;
            DbCommand command = dbManager.GetSqlStringCommand(SQLText);
            command.CommandType = CommandType.Text;

            foreach (DbParameter Param in Parameter)
            {
                if (Param.Value == null)
                {
                    Param.Value = DBNull.Value;
                    Param.IsNullable = true;
                }
                command.Parameters.Add(Param);
            }

            returnObj = dbManager.ExecuteScalar(command);
            command.Parameters.Clear();
            return returnObj;
        }
        protected object ExecuteScalar(string SQLText, Dictionary<string, object> Parameter)
        {
            object returnObj = null;

            DbCommand command = dbManager.GetSqlStringCommand(SQLText);
            command.CommandType = CommandType.Text;

            foreach (var Param in Parameter)
            {
                if (Param.Value != null && Param.Value != string.Empty)
                {
                    command.Parameters.Add(this.CreateParameter(Param.Key, Param.Value));
                }

            }

            returnObj = dbManager.ExecuteScalar(command);
            return returnObj;
        }


        #endregion

        #region Execute Store Procedure

        protected DataSet ExecuteQueryStoreProcedure(string storeProcedureName, List<DbParameter> parameters)
        {
            DataSet returnDs = null;
            DbCommand command = dbManager.GetStoredProcCommand(storeProcedureName);
            if ((parameters != null) && (parameters.Count() > 0))
            {

                parameters.Cast<DbParameter>().ToList().ForEach(p => dbManager.AddInParameter(command, p.ParameterName, p.DbType, p.Value));
                //dbManager.AssignParameters(command, parameters);
            }
            command.CommandTimeout = 0;
            returnDs = dbManager.ExecuteDataSet(command);
            return returnDs;
        }
        protected int ExecuteNonQueryStoreProcedure(string storeProcedureName, params object[] parameters)
        {
            int returnInt = 0;
            DbCommand command = dbManager.GetStoredProcCommand(storeProcedureName);
            if ((parameters != null) && (parameters.Count() > 0))
            {
                dbManager.AssignParameters(command, parameters);
            }

            returnInt = dbManager.ExecuteNonQuery(command);
            return returnInt;
        }
        protected object ExecuteScalarStoreProcedure(string storeProcedureName, params object[] parameters)
        {
            object returnObj = null;
            DbCommand command = dbManager.GetStoredProcCommand(storeProcedureName);
            if ((parameters != null) && (parameters.Count() > 0))
            {
                dbManager.AssignParameters(command, parameters);
            }

            returnObj = dbManager.ExecuteScalar(command);
            return returnObj;
        }



        #endregion

     
    }
    public class DatabaseService<TEntity> : DatabaseService where TEntity : EntityBase, new()
    {
        protected IRowMapper<TEntity> EntityRowMapper
        {
            get
            {
                IMapBuilderContext<TEntity> mapBuilderContext = MapBuilder<TEntity>.MapAllProperties();
                PropertyInfo[] properties = typeof(TEntity).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (this.EntityPersistenceIgnoranceProperties.Where(p => p.Name == property.Name).Count() != 0)
                    {
                        mapBuilderContext.DoNotMap(property);
                        continue;
                    }
                    if (!property.CanWrite)
                    {
                        mapBuilderContext.DoNotMap(property);
                        continue;
                    }
                }

                return mapBuilderContext.Build();
            }
        }
        protected string EntityTableName
        {
            get
            {
                if (typeof(TEntity).IsTaggedWithAttribute<EntityMappingAttribute>(true))
                {
                    return typeof(TEntity).GetCustomAttribute<EntityMappingAttribute>(true).TableMapping;
                }
                else
                {
                    throw new Exception("Entity mapping not specific.");
                }
            }
        }
        protected IList<PropertyInfo> EntityKeyProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("EntityKey", true, true);
            }
        }
        protected IList<PropertyInfo> EntityCodeProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("DataCode", true, true);
            }
        }
        protected IList<PropertyInfo> EntityIdentityKeyProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("IdentityKey", true, true);
            }
        }
        protected IList<PropertyInfo> EntityPersistenceIgnoranceProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("PersistenceIgnorance", true, true);
            }
        }
        protected IList<PropertyInfo> EntityIgnoreInsertProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("Insert", false, true);
            }
        }
        protected IList<PropertyInfo> EntityIgnoreUpdateProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("Update", false, true);
            }
        }
        protected IList<PropertyInfo> EntityForeignKey
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<FOREIGNObject>("EntieTypeName", true, true);
            }
        }

        #region :: Get Update By,Update Date Mapping Entity ::

        protected IList<PropertyInfo> EntityUpdateByProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ObjIsUpdateBy", true, true);
            }
        }
        protected IList<PropertyInfo> EntityUpdateByMappingProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ObjMapUpdateBy", true, true);
            }
        }


        protected IList<PropertyInfo> EntityUpdateDateProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ObjIsUpdateDate", true, true);
            }
        }
        protected IList<PropertyInfo> EntityUpdateDateMappingProperties
        {
            get
            {
                return typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ObjMapUpdateDate", true, true);
            }
        }
        #endregion


        #region Query
        public TEntity FindByKeys(TEntity objKeyCriteria, bool locked)
        {
            DbCommand command = this.GetSqlQueryCommand(objKeyCriteria, locked);
            DataSet ds = dbManager.ExecuteDataSet(command);
            //DataSet ds = null;
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                return ds.Tables[0].AsEnumerable<TEntity>().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public TEntity FindByCode(TEntity objKeyCriteria, bool locked)
        {
            DbCommand command = this.GetSqlQueryCommandCode(objKeyCriteria, locked);
            DataSet ds = dbManager.ExecuteDataSet(command);
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                return ds.Tables[0].AsEnumerable<TEntity>().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<TEntity> FindAll(bool locked)
        {
            DbCommand command = this.GetSqlQueryCommand(null, locked);
            DataSet ds = dbManager.ExecuteDataSet(command);
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                return ds.Tables[0].AsEnumerable<TEntity>();
            }
            else
            {
                return null;
            }
        }
        public DataSet FindDataSetByParentKey(TEntity Entity, bool locked = false)
        {
            DbCommand command = this.GetSqlQueryCommandParentKey(Entity, locked);
            DataSet ds = dbManager.ExecuteDataSet(command);
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        public DataSet FindAllDataSet(bool locked)
        {
            DbCommand command = this.GetSqlQueryCommand(null, locked);
            DataSet ds = dbManager.ExecuteDataSet(command);
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        private DbCommand GetSqlQueryCommandParentKey(TEntity objKeyCriteria, bool locked)
        {
            StringBuilder sql = new StringBuilder();
            IList<DbParameter> parameters = new List<DbParameter>();
            sql.AppendLine(" SELECT * ");
            sql.AppendFormat(" FROM {0} ", this.EntityTableName);
            if (!locked)
            {
                sql.Append(" WITH(NOLOCK) ");
            }

            if (objKeyCriteria != null)
            {
                sql.AppendLine(" WHERE 1 = 1 ");
                PropertyInfo[] properties = objKeyCriteria.GetType().GetProperties();
                List<PropertyInfo> lstPropertiesInfoParentKeys = typeof(TEntity).GetTaggedPropertyInfos<EntityScalarPropertyAttribute>("ParentKey", true, true).ToList();

                foreach (PropertyInfo property in properties)
                {
                    if (lstPropertiesInfoParentKeys.Where(p => p.Name == property.Name).Count() != 0)
                    {
                        sql.AppendFormat(" AND [{0}] = @{0} ", property.Name);
                        parameters.Add(this.CreateParameter(property.Name, property.GetValue(objKeyCriteria, null)));
                    }
                }
            }

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            if (parameters.Count > 0)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            return command;
        }
        private DbCommand GetSqlQueryCommandCode(TEntity objKeyCriteria, bool locked)
        {
            StringBuilder sql = new StringBuilder();
            IList<DbParameter> parameters = new List<DbParameter>();
            sql.AppendLine(" SELECT * ");
            sql.AppendFormat(" FROM {0} ", this.EntityTableName);
            if (!locked)
            {
                sql.Append(" WITH(NOLOCK) ");
            }

            if (objKeyCriteria != null)
            {
                sql.AppendLine(" WHERE 1 = 1 ");
                PropertyInfo[] properties = objKeyCriteria.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (this.EntityCodeProperties.Where(p => p.Name == property.Name).Count() != 0)
                    {
                        sql.AppendFormat(" AND [{0}] = @{0} ", property.Name);
                        parameters.Add(this.CreateParameter(property.Name, property.GetValue(objKeyCriteria, null)));
                    }
                }
            }

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            if (parameters.Count > 0)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            return command;
        }
        private DbCommand GetSqlQueryCommand(TEntity objKeyCriteria, bool locked)
        {
            StringBuilder sql = new StringBuilder();
            IList<DbParameter> parameters = new List<DbParameter>();
            sql.AppendLine(" SELECT * ");
            sql.AppendFormat(" FROM {0} ", this.EntityTableName);
            if (!locked)
            {
                sql.Append(" WITH(NOLOCK) ");
            }

            if (objKeyCriteria != null)
            {
                sql.AppendLine(" WHERE 1 = 1 ");
                PropertyInfo[] properties = objKeyCriteria.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (this.EntityKeyProperties.Where(p => p.Name == property.Name).Count() != 0)
                    {
                        sql.AppendFormat(" AND [{0}] = @{0} ", property.Name);
                        parameters.Add(this.CreateParameter(property.Name, property.GetValue(objKeyCriteria, null)));
                    }
                }
            }

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            if (parameters.Count > 0)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            return command;
        }
        private DbCommand GetMultiSqlQueryCommand(TEntity objKeyCriteria, bool locked)
        {
            string objType = objKeyCriteria.GetType().FullName;

            StringBuilder sql = new StringBuilder();
            IList<DbParameter> parameters = new List<DbParameter>();
            sql.AppendLine(" SELECT * ");
            sql.AppendFormat(" FROM {0} ", this.EntityTableName);
            if (!locked)
            {
                sql.Append(" WITH(NOLOCK) ");
            }

            if (objKeyCriteria != null)
            {
                sql.AppendLine(" WHERE 1 = 1 ");
                PropertyInfo[] properties = objKeyCriteria.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string prpertyType = property.DeclaringType.FullName;
                    if (prpertyType == objType)
                    {
                        double a = 0;
                        if (this.EntityKeyProperties.Where(p => p.Name == property.Name).Count() != 0 && property.GetValue(objKeyCriteria, null) != null)
                        {
                            if (!(property.PropertyType == typeof(bool) || property.PropertyType == typeof(Boolean) || property.PropertyType == typeof(string))
                                  && (double.TryParse(property.GetValue(objKeyCriteria, null).ToString(), out a) && a <= 0))
                            {
                                continue;
                            }

                        }
                        if (property.GetValue(objKeyCriteria, null) != null)
                        {
                            sql.AppendFormat(" AND [{0}] = @{0} ", property.Name);

                            parameters.Add(this.CreateParameter(property.Name, property.GetValue(objKeyCriteria, null)));
                        }
                    }

                }
            }

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            if (parameters.Count > 0)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            return command;
        }

        #endregion


        #region :: Insert Data ::

        private DbCommand GetSqlInsertCommand(TEntity entity, bool returnIdentityKey)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            IList<string> columnsName = new List<string>();
            IList<string> ValueName = new List<string>();
            IList<DbParameter> parameters = new List<DbParameter>();
            PropertyInfo[] identityKey = this.EntityIdentityKeyProperties.ToArray<PropertyInfo>();
            PropertyInfo[] persistenceIgnorance = this.EntityPersistenceIgnoranceProperties.ToArray<PropertyInfo>();
            PropertyInfo[] ignoreInsert = this.EntityIgnoreInsertProperties.ToArray<PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {

                if (identityKey.Contains(property)) continue;
                if (persistenceIgnorance.Contains(property)) continue;
                if (ignoreInsert.Contains(property)) continue;


                columnsName.Add(string.Format("[{0}]", property.Name));
                ValueName.Add(string.Format("{0}", property.Name));
                parameters.Add(this.CreateParameter(property.Name, property.GetValue(entity, null)));
            }


            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" INSERT INTO {0} ", this.EntityTableName);
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join(", ", columnsName.ToArray()));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join(", ", ValueName.AppendAll("@", null).ToArray()));
            sql.AppendLine(" ) ");

            if (returnIdentityKey)
            {
                sql.AppendLine(" SELECT SCOPE_IDENTITY(); ");
            }

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }
        public int Insert(TEntity entity, params string[] rulesets)
        {

            //System.Diagnostics.Debug.WriteLine("Enter Insert : " + DateTime.Now.ToString());
            // Validate Entity.
            ValidationResults validationResults = Validation.Validate<TEntity>(entity, rulesets);
            if (!validationResults.IsValid) throw new ValidationException(validationResults);

            // Get Insert Command.
            DbCommand command = this.GetSqlInsertCommand(entity, false);

            // Perform Insert Task.

            //int r =  dbManager.ExecuteNonQuery(command);
            //System.Diagnostics.Debug.WriteLine("End Insert : " + DateTime.Now.ToString());

            return dbManager.ExecuteNonQuery(command);
        }
        public TIdentity Insert<TIdentity>(TEntity entity, params string[] rulesets)
        {

            // Validate Entity.
            ValidationResults validationResults = Validation.Validate<TEntity>((TEntity)entity, rulesets);
            if (!validationResults.IsValid) throw new ValidationException(validationResults);

            //string sqlStatement = string.Concat(CreateInsertSql(objEntity), " SELECT SCOPE_IDENTITY(); ");
            DbCommand command = this.GetSqlInsertCommand(entity, true);
            object identity = dbManager.ExecuteScalar(command);

            return (TIdentity)TypeExtension.ChangeType(identity, typeof(TIdentity));
        }
        #endregion

        #region :: Update ::
        public int Update(TEntity entity, params string[] rulesets)
        {
            // Validate Duplicate


            // Validate Entity.
            ValidationResults validationResults = Validation.Validate<TEntity>(entity, rulesets);
            if (!validationResults.IsValid) throw new ValidationException(validationResults);

            // Get Update Command.
            DbCommand command = this.GetSqlUpdateCommand(entity);

            // Perform Update Task.
            return dbManager.ExecuteNonQuery(command);
        }
        private DbCommand GetSqlUpdateCommand(TEntity entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            IList<string> keyColumns = new List<string>();
            IList<string> updateColumns = new List<string>();
            IList<DbParameter> parameters = new List<DbParameter>();

            PropertyInfo[] identityKey = this.EntityIdentityKeyProperties.ToArray<PropertyInfo>();
            PropertyInfo[] persistenceIgnorance = this.EntityPersistenceIgnoranceProperties.ToArray<PropertyInfo>();
            PropertyInfo[] ignoreUpdate = this.EntityIgnoreUpdateProperties.ToArray<PropertyInfo>();
            PropertyInfo[] keyProperties = this.EntityKeyProperties.ToArray<PropertyInfo>();


            #region :: Set UpdateBy Update Date ::
            PropertyInfo[] updateByEntity = this.EntityUpdateByProperties.ToArray<PropertyInfo>();
            PropertyInfo[] updateByMapping = this.EntityUpdateByMappingProperties.ToArray<PropertyInfo>();



            if (updateByEntity != null && updateByEntity.Length > 0 && updateByMapping != null && updateByMapping.Length > 0)
            {
                PropertyInfo updateByEn = entity.GetType().GetProperty(updateByEntity[0].Name);
                PropertyInfo updateByMap = entity.GetType().GetProperty(updateByMapping[0].Name);
                updateByMap.SetValue(entity, updateByEn.GetValue(entity, null), null);
            }

            PropertyInfo[] updateDateEntity = this.EntityUpdateDateProperties.ToArray<PropertyInfo>();
            PropertyInfo[] updateDateMapping = this.EntityUpdateDateMappingProperties.ToArray<PropertyInfo>();
            if (updateDateEntity != null && updateDateEntity.Length > 0 && updateDateMapping != null && updateDateMapping.Length > 0)
            {
                PropertyInfo updateDateEn = entity.GetType().GetProperty(updateDateEntity[0].Name);
                PropertyInfo updateDateMap = entity.GetType().GetProperty(updateDateMapping[0].Name);
                updateDateMap.SetValue(entity, updateDateEn.GetValue(entity, null), null);
            }


            #endregion
            foreach (PropertyInfo property in properties)
            {
                if (keyProperties.Contains(property))
                {
                    keyColumns.Add(string.Format("[{0}] = @{0}", property.Name));
                    parameters.Add(this.CreateParameter(property.Name, property.GetValue(entity, null)));

                    continue;
                }


                if (identityKey.Contains(property)) continue;
                if (persistenceIgnorance.Contains(property)) continue;
                if (ignoreUpdate.Contains(property)) continue;

                updateColumns.Add(string.Format("[{0}] = @{0}", property.Name));
                parameters.Add(this.CreateParameter(property.Name, property.GetValue(entity, null)));
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" UPDATE {0} ", this.EntityTableName);
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join(", ", updateColumns.ToArray()));
            sql.AppendLine(" WHERE ");
            sql.AppendLine(string.Join(" AND ", keyColumns.ToArray()));

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }
        #endregion

        #region :: Delete ::
        public int Delete(List<TEntity> ListEntity, params string[] rulesets)
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (TEntity deleteItem in ListEntity)
                    {
                        result += Delete(deleteItem, rulesets);
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }

            }

            return result;

        }
        public int Delete(TEntity entity, params string[] rulesets)
        {
            // Validate Entity.
            ValidationResults validationResults = Validation.Validate<TEntity>(entity, rulesets);
            if (!validationResults.IsValid) throw new ValidationException(validationResults);

            // Get Update Command.
            DbCommand command = this.GetSqlDeleteCommand(entity);

            // Perform Update Task.
            try
            {
                return dbManager.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                //if (ex.Number == 547)
                //{
                //    throw new ValidationException(ErrorMessage.DeleteDataInUse);
                //}

                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private DbCommand GetSqlDeleteCommand(TEntity entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            IList<string> keyColumns = new List<string>();
            IList<DbParameter> parameters = new List<DbParameter>();

            foreach (PropertyInfo property in properties)
            {
                if (this.EntityKeyProperties.Where(p => p.Name == property.Name).Count() != 0)
                {
                    keyColumns.Add(string.Format("[{0}] = @{0}", property.Name));
                    parameters.Add(this.CreateParameter(property.Name, property.GetValue(entity, null)));
                }
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" DELETE {0} ", this.EntityTableName);
            sql.AppendLine(" WHERE ");
            sql.AppendLine(string.Join(" AND ", keyColumns.ToArray()));

            DbCommand command = dbManager.GetSqlStringCommand(sql.ToString());
            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }
        #endregion

    }
}
