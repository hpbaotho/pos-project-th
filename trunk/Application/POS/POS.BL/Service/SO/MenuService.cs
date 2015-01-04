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
        public List<OrderDTO> LoadMainMenu(SOMenu mainMenu, long? dining_type_id) {
            return LoadMainMenu(mainMenu, dining_type_id, null);
        }
        public List<OrderDTO> LoadMainMenu(SOMenu mainMenu)
        {
            return LoadMainMenu(mainMenu, null, null);
        }
        private List<OrderDTO> LoadMainMenu(SOMenu mainMenu, long? dining_type_id, long? sales_order_head_id)
        {
            string sql = @"
                        SELECT 
                          Detail.sales_order_detail_id
                          ,Detail.sales_order_head_id
                          ,ISNULL(Detail.menu_dining_type_id,Detail.menu_dining_type_id) menu_dining_type_id
                          ,Detail.order_amount
                          ,Detail.is_print
                          ,Detail.is_cancel
                         ,Menu.menu_id
                         ,Menu.menu_name
                         ,ISNULL(DiningType.menu_price,0) menu_price
                         ,DiningType.isInventoryItem
                          FROM so_menu Menu WITH(NOLOCK)
                          INNER JOIN so_menu_dining_type DiningType WITH(NOLOCK) ON Menu.menu_id=DiningType.menu_id
	                      LEFT JOIN so_sales_order_detail Detail ON ISNULL(detail.menu_dining_type_id,0)=DiningType.menu_dining_type_id
	  
                          WHERE  Menu.active=1
                           AND ISNULL(menu_reference_id,0)=ISNULL(@menu_reference_id,0)
                           AND DiningType.dining_type_id=ISNULL(@dining_type_id,DiningType.dining_type_id)
                           AND ISNULL(Detail.sales_order_head_id,0)=ISNULL(@sales_order_head_id,0)
                        ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_reference_id", mainMenu.menu_reference_id));
            param.Add(base.CreateParameter("dining_type_id", dining_type_id));
            param.Add(base.CreateParameter("sales_order_head_id", sales_order_head_id));

            return this.ExecuteQuery<OrderDTO>(sql, param.ToArray()).ToList();
        }
        public bool HaveMinuItem(long? menu_id)
        {
            string sql = @"
                SELECT COUNT(1) MenuItem FROM  so_menu WITH(NOLOCK) where menu_reference_id=@menu_id
                ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_id", menu_id));

            return (Converts.ParseLong(this.ExecuteScalar(sql, param).ToString()) > 0);

        }


    }
}
