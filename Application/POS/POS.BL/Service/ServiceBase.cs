using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Entity;
using Core.Standards.Validations;

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
    }
}
