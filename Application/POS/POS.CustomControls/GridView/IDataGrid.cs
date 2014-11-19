using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Service;
using Core.Standards.Entity;

namespace POS.CustomControls.GridView
{
    public interface IDataGrid
    {
        //void SetController(DatabaseService<EntityBase> service);
        void ClearGrid();
        void AddDataToGrid(EntityBase entity);
        void UpdateGridWithChangedUser(EntityBase entity);
        void RemoveFromGrid(EntityBase entity);
        string GetIdOfSelectedGrid();
        void SetSelectedGrid(EntityBase entity);
    }
}
