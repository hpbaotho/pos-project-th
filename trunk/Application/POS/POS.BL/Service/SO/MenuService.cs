using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;

namespace POS.BL.Service.SO
{
    public class MenuService : ServiceBase<SOMenu>
    {
        public List<SOMenu> LoadMainMenu(SOMenu mainMenu)
        {
            string sql = @"
                        SELECT * FROM so_menu WITH(NOLOCK)
                        WHERE ISNULL(menu_reference_id,0)=ISNULL(@menu_reference_id,0)
                        ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_reference_id", mainMenu.menu_reference_id));

            return this.ExecuteQuery<SOMenu>(sql, param.ToArray()).ToList();
        }
        public bool HaveMinuItem(SOMenu menu)
        {
            string sql = @"
                SELECT COUNT(1) MenuItem FROM  so_menu WITH(NOLOCK) where menu_reference_id=@menu_id
                ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_id", menu.menu_id));

            return (Converts.ParseLong(this.ExecuteScalar(sql, param).ToString()) > 0);

        }


    }
}
