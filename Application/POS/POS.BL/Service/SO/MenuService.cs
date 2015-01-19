using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using System.Data.Common;
using Core.Standards.Converters;
using POS.BL.DTO.SO;
using POS.BL.DTO;
using POS.BL.Utilities;
using System.Transactions;
using Core.Standards.Validations;
using Core.Standards.Exceptions;

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
                         ,DiningType.menu_dining_type_id
                         ,DiningType.dining_type_id
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
                            ORDER BY ISNULL(Menu.priorityValue,0) DESC ,Menu.menu_code
                         ";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_reference_id", menu_reference_id));
            param.Add(base.CreateParameter("dining_type_id", dining_type_id));
            param.Add(base.CreateParameter("menu_group_id", menu_group_id));
            param.Add(base.CreateParameter("menu_category_id", menu_category_id));
            return this.ExecuteQuery<OrderDTO>(sql, param.ToArray()).ToList();
        }
        public List<OrderDTO> LoadCondiMentMenu(long? ref_menu_dining_type_id)
        {
            string sql = @"SELECT 
                 Menu.menu_id
                 ,Menu.menu_name
                 ,ISNULL(DiningType.menu_price,0) menu_price
                 ,MenuCat.isCombo
                 ,CASE WHEN CAST(ISNULL(DiningType.menu_effective_date ,GETDATE()) AS DATE ) >= CAST( GETDATE() AS DATE) THEN 1  ELSE 0 END IsActiveMenu
                 ,Menu.isInventoryItem
                 ,Menu.menu_group_id
                 ,Menu.menu_category_id
                 ,DiningType.menu_dining_type_id
                 ,DiningType.dining_type_id
                  FROM so_menu Menu WITH(NOLOCK)
                  LEFT JOIN so_menu_dining_type DiningType WITH(NOLOCK) ON Menu.menu_id=DiningType.menu_id
                  LEFT JOIN so_menu_group MenuGroup WITH(NOLOCK) ON MenuGroup.menu_group_id =Menu.menu_group_id
                  LEFT JOIN so_menu_category MenuCat WITH(NOLOCK) ON MenuCat.menu_category_id =Menu.menu_category_id

                  WHERE  Menu.active=1
                   AND ISNULL(DiningType.menu_id,0) >0
                   AND DiningType.ref_menu_dining_type_id=@ref_menu_dining_type_id
";
            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("ref_menu_dining_type_id", ref_menu_dining_type_id));
            List<OrderDTO> result = new List<OrderDTO>();
            result = this.ExecuteQuery<OrderDTO>(sql, param.ToArray()).ToList();
            if (result == null)
            {
                result = new List<OrderDTO>();
            }
            result.Add(new OrderDTO() { menu_name = "Open Condiment" });
            return result;
        }
        public bool HaveMinuItem(long? menu_id, long? diningTypeId, long? menuGroupId, long? menuCategoryId)
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

        #region :: Master Menu ::
        public List<DuplicateItemDTO> IsDuplicationMenu(SOMenu soMenu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine(@" SELECT  'Key' as ColumnName
                                , CASE WHEN COUNT(*) > 0 THEN 1 
	                                   ELSE 0
                                  END AS isDuplicate
                                FROM    [so_menu]  WITH(NOLOCK)
                                WHERE  menu_code = @menu_code
            ");

            //---Edit
            if (soMenu.menu_id > 0)
            {
                strSql.AppendLine(" AND menu_id <>  menu_id ");
            }

            List<DbParameter> param = new List<DbParameter>();
            param.Add(base.CreateParameter("menu_id", soMenu.menu_id));
            param.Add(base.CreateParameter("menu_code", soMenu.menu_code));

            return this.ExecuteQuery<DuplicateItemDTO>(strSql.ToString(), param.ToArray()).ToList();
        }
        public List<ComboBoxDTO> GetMenuComboBoxDTO()
        {
            List<SOMenu> lstEntity = new List<SOMenu>();
            List<ComboBoxDTO> lstComboBoxDTO = new List<ComboBoxDTO>();
            lstComboBoxDTO.SetPleaseSelect();

            lstEntity = base.FindAll(false).Where(w => w.active).ToList();

            foreach (SOMenu child in lstEntity)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = child.menu_id.Value.ToString();
                DTO.Display = child.menu_name;
                lstComboBoxDTO.Add(DTO);
            }
            return lstComboBoxDTO;
        }
        public void DeleteSOMenuAndMappingMenu(List<SOMenu> listSOMenu)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                try
                {
                    //---Delete Detail
                    List<long?> listMenuID = listSOMenu.Select(item => item.menu_id).ToList();
                    ServiceProvider.MenuMappingService.DeleteMappingMenu(listMenuID);

                    //---Delete Header
                    ServiceProvider.MenuService.Delete(listSOMenu, new string[] { ValidationRuleset.Delete });
                }
                catch (ValidationException ex)
                {
                    trans.Dispose();

                    throw ex;
                }

                trans.Complete();
            }
        }
        #endregion

    }
}
