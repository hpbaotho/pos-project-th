using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;

namespace POS.BL.Service.SO
{
    public class MenuGroupService : ServiceBase<MenuGroup>
    {
        public List<MenuGroup> FindByDiningType(long DiningTypeId)
        {
            string sql = @" SELECT * FROM(
                         SELECT DISTINCT menuGroup.* ,dining.dining_type_id
                        FROM so_menu_group menuGroup WITH(NOLOCK)
                        LEFT JOIN so_menu menu WITH(NOLOCK) ON menu.menu_group_id=menuGroup.menu_group_id
                        LEFT JOIN so_menu_dining_type dining  WITH(NOLOCK) ON dining.menu_id=menu.menu_id
                        WHERE menuGroup.active=1
                        AND ISNULL(dining.menu_id,0)<>0
                        AND ISNULL(dining.dining_type_id,0)=@dining_type_id
                        ) A
                        ORDER BY ISNULL(A.priorityValue,0) DESC,A.menu_group_code
                    ";

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("dining_type_id", DiningTypeId));

            return this.ExecuteQuery<MenuGroup>(sql, param.ToArray()).ToList();
        }
    }
}
