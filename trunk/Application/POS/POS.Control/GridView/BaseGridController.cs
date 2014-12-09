using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Entity;

namespace POS.Control.GridView
{
    class BaseGridController:IDataGrid
    {
        #region :: Interface Method ::


        public void AddDataToGrid(BL.Service.ServiceBase<EntityBase> service)
        {
            throw new NotImplementedException();
        }

        public void UpdateGridWithChangedUser(BL.Service.ServiceBase<EntityBase> service)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGrid(BL.Service.ServiceBase<EntityBase> service)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedGrid(BL.Service.ServiceBase<EntityBase> service)
        {
            throw new NotImplementedException();
        }
        #endregion
    

    }
}
