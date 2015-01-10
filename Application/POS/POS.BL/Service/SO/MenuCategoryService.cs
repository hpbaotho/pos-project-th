using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;

namespace POS.BL.Service.SO
{
    public class MenuCategoryService : ServiceBase<MenuCategory>
    {
        public List<MenuCategory> FindByMenuGroup(long MenuGroupId,long DiningTypeId)
        {
            string sql = @"
                       SELECT DISTINCT cat.* ,dining.dining_type_id
                        FROM so_menu_category cat WITH(NOLOCK)
                        LEFT JOIN so_menu menu WITH(NOLOCK) ON cat.menu_category_id=menu.menu_category_id
                        LEFT JOIN so_menu_dining_type dining  WITH(NOLOCK) ON dining.menu_id=menu.menu_id
                        WHERE cat.active=1
                        AND ISNULL(dining.menu_id,0)<>0
                        AND ISNULL(dining.dining_type_id,0)=@dining_type_id
                        AND menu.menu_group_id=@menu_group_id
                    ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_group_id", MenuGroupId));
            param.Add(base.CreateParameter("dining_type_id", DiningTypeId));

            return this.ExecuteQuery<MenuCategory>(sql, param.ToArray()).ToList();
        }
    }
}
