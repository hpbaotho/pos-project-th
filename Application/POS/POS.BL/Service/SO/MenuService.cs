using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;
using POS.BL.DTO.SO;

namespace POS.BL.Service.SO
{
    public class MenuService : ServiceBase<SOMenu>
    {
        public List<OrderDTO> LoadMainMenu(long? menu_reference_id, long? dining_type_id, long? menu_group_id, long? menu_category_id)
        {
            string sql = @"
                        SELECT 

                         Menu.menu_id
                         ,Menu.menu_name
                         ,ISNULL(DiningType.menu_price,0) menu_price
                         ,MenuCat.isCombo
                         ,CASE WHEN CAST(ISNULL(DiningType.menu_effective_date ,GETDATE()) AS DATE ) >= CAST( GETDATE() AS DATE) THEN 1  ELSE 0 END IsActiveMenu
						 ,Menu.isInventoryItem
                         ,Menu.menu_group_id
                         ,Menu.menu_category_id
                          FROM so_menu Menu WITH(NOLOCK)
                          LEFT JOIN so_menu_dining_type DiningType WITH(NOLOCK) ON Menu.menu_id=DiningType.menu_id
						  LEFT JOIN so_menu_group MenuGroup WITH(NOLOCK) ON MenuGroup.menu_group_id =Menu.menu_group_id
						  LEFT JOIN so_menu_category MenuCat WITH(NOLOCK) ON MenuCat.menu_category_id =Menu.menu_category_id

                          WHERE  Menu.active=1
                           AND ISNULL(DiningType.menu_id,0) >0
                           AND ISNULL(menu_reference_id,0)=ISNULL(@menu_reference_id,0)
                           AND DiningType.dining_type_id=ISNULL(@dining_type_id,DiningType.dining_type_id)
                           
                           AND ISNULL(Menu.menu_group_id,0)=ISNULL(@menu_group_id,0)
                           AND ISNULL(Menu.menu_category_id,0)=ISNULL(@menu_category_id,0)
                         ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_reference_id", menu_reference_id));
            param.Add(base.CreateParameter("dining_type_id", dining_type_id));
            param.Add(base.CreateParameter("menu_group_id", menu_group_id));
            param.Add(base.CreateParameter("menu_category_id", menu_category_id));
            return this.ExecuteQuery<OrderDTO>(sql, param.ToArray()).ToList();
        }
        public bool HaveMinuItem(long? menu_id,long? diningTypeId,long? menuGroupId,long? menuCategoryId)
        {
            string sql = @"
                SELECT COUNT(1) MenuItem 
                 FROM  so_menu WITH(NOLOCK) 
                 LEFT JOIN so_menu_dining_type dining ON dining.menu_id=so_menu.menu_reference_id
                 where dining.menu_id=@menu_id
                 AND dining.dining_type_id=@diningTypeId
                 AND so_menu.menu_category_id=@menuCategoryId
                 AND so_menu.menu_group_id=@menuGroupId
                ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_id", menu_id));
            param.Add(base.CreateParameter("menuCategoryId", menuCategoryId));
            param.Add(base.CreateParameter("menuGroupId", menuGroupId));
            param.Add(base.CreateParameter("diningTypeId", diningTypeId));

            return (Converts.ParseLong(this.ExecuteScalar(sql, param).ToString()) > 0);

        }


    }
}
