using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO.SO;
using System.Transactions;
using Core.Standards.Validations;
using System.Data.Common;
using POS.BL.Utilities;
using POS.BL.DTO;
using POS.BL.DTO.IN;

namespace POS.BL.Service.SO
{
    public class SaleOrderDetailService : ServiceBase<SaleOrderDetail>
    {
        public List<OrderDTO> SaveOrderDetail(List<OrderDTO> orderDetail, OrderHeadDTO orderHeader)
        {

            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                List<OrderDTO> MainMenu = orderDetail.Where(c => !c.condiment_of_order_detail_id.HasValue).ToList();

                if (orderHeader != null && orderHeader.sales_order_head_id.HasValue)
                {
                    for (int i = 0; i < MainMenu.Count; i++)
                    {
                        OrderDTO Saveitem = MainMenu[i];
                        Saveitem.sales_order_head_id = orderHeader.sales_order_head_id;
                        List<OrderDTO> condiMentMenu = orderDetail.Where(c => c.condiment_of_order_detail_id == Saveitem.sales_order_detail_id).ToList();

                        Saveitem = this.SaveOrderDetailItem(Saveitem);

                        #region :: Save Condiment ::
                        if (condiMentMenu != null && condiMentMenu.Count > 0)
                        {
                            for (int c = 0; c < condiMentMenu.Count; c++)
                            {
                                OrderDTO CondimentSaveitem = condiMentMenu[c];
                                CondimentSaveitem.sales_order_head_id = orderHeader.sales_order_head_id;
                                CondimentSaveitem.condiment_of_order_detail_id = Saveitem.sales_order_detail_id;
                                CondimentSaveitem = this.SaveOrderDetailItem(CondimentSaveitem);
                                if (CondimentSaveitem == null)
                                {
                                    orderDetail.Remove(condiMentMenu[c]);
                                }
                            }
                        }
                        #endregion


                        if (Saveitem == null)
                        {
                            orderDetail.Remove(MainMenu[i]);
                            MainMenu.RemoveAt(i);
                        }
                    }

                    trans.Complete();

                }
                else
                {
                    throw new Exception("Please Save Order Head before.");
                }
            }

            return orderDetail;
        }
        public OrderDTO SaveOrderDetailItem(OrderDTO saveItem)
        {
            SaleOrderDetail detailSave = new SaleOrderDetail();
            detailSave.ChkNo = saveItem.ChkNo;
            detailSave.condiment_of_order_detail_id = saveItem.condiment_of_order_detail_id;
            detailSave.is_print = saveItem.is_print;
            detailSave.menu_dining_type_id = saveItem.menu_dining_type_id;
            detailSave.sales_order_head_id = saveItem.sales_order_head_id;
            detailSave.order_amount = saveItem.order_amount;
            detailSave.order_unit_price = saveItem.order_unit_price;
            detailSave.is_cancel = saveItem.is_cancel;
            detailSave.Open_Condiment = saveItem.menu_name;
            detailSave.sales_order_detail_id = saveItem.sales_order_detail_id;

            if (saveItem.OrderState == ObjectState.Add)
            {
                saveItem.sales_order_detail_id = this.Insert<long>(detailSave, ValidationRuleset.Insert);
            }
            else if (saveItem.OrderState == ObjectState.Edit)
            {
                if (detailSave.is_cancel)
                {
                    ServiceProvider.LogLotService.Stock_CheckAvailable(new StockDTO() { sales_order_detail_id = detailSave.sales_order_detail_id.Value });
                }
                this.Update(detailSave, ValidationRuleset.Update);
            }
            else if (saveItem.OrderState == ObjectState.Delete)
            {
                this.Delete(detailSave, ValidationRuleset.Delete);
                saveItem = null;
            }

            return saveItem;
        }
        public List<OrderDTO> FindOrderDetail(long? order_head_id)
        {
            List<OrderDTO> result = new List<OrderDTO>();

            string sql = @"
                        SELECT * FROM so_sales_order_detail WITH(NOLOCK) 
                        WHERE sales_order_head_id=@order_head_id AND is_cancel=0

                        ";
            List<DbParameter> param = new List<DbParameter>();

            param.Add(base.CreateParameter("@order_head_id", order_head_id));
            List<SaleOrderDetail> orderdetail = this.ExecuteQuery<SaleOrderDetail>(sql, param.ToArray()).ToList();
            if (orderdetail != null && orderdetail.Count > 0)
            {
                foreach (SaleOrderDetail item in orderdetail)
                {
                    OrderDTO dtoItem = new OrderDTO();
                    dtoItem.OrderState = ObjectState.Nothing;
                    dtoItem.sales_order_detail_id = item.sales_order_detail_id;
                    dtoItem.sales_order_head_id = item.sales_order_head_id;
                    dtoItem.menu_dining_type_id = item.menu_dining_type_id;
                    dtoItem.order_amount = item.order_amount;
                    dtoItem.is_print = item.is_print;
                    dtoItem.is_cancel = item.is_cancel;
                    dtoItem.ChkNo = item.ChkNo;
                    dtoItem.menu_name = item.Open_Condiment;
                    dtoItem.condiment_of_order_detail_id = item.condiment_of_order_detail_id;
                    dtoItem.IsCondiment = item.condiment_of_order_detail_id.HasValue;
                    if (item.order_unit_price.HasValue)
                    {
                        dtoItem.order_unit_price = item.order_unit_price.Value;
                    }
                    // Update Form Menu DiningType
                    MenuDiningType menuDiningType = new MenuDiningType();
                    menuDiningType.menu_dining_type_id = item.menu_dining_type_id;
                    menuDiningType = ServiceProvider.MenuDiningTypeService.FindByKeys(menuDiningType, false);
                    if (menuDiningType != null)
                    {
                       
                        dtoItem.ref_menu_dining_type_id = menuDiningType.ref_menu_dining_type_id;
                        dtoItem.dining_type_id = menuDiningType.dining_type_id;

                        // Update Form Menu
                        SOMenu menuItem = new SOMenu();
                        menuItem.menu_id = menuDiningType.menu_id;
                        menuItem = ServiceProvider.MenuService.FindByKeys(menuItem, false);
                        dtoItem.menu_name = menuItem.menu_name;
                        dtoItem.menu_category_id = menuItem.menu_category_id;
                        dtoItem.menu_group_id = menuItem.menu_group_id;

                    }
                    result.Add(dtoItem);
                }
            }

            return result;
        }
        public List<ComboBoxDTO> GetCancelMenu(long SalesOrderHeadID)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(@"   SELECT 
                                     detail.sales_order_detail_id AS Value
	                                 , menu.menu_code + ':' + menu.menu_name AS Display
                                FROM so_sales_order_detail detail
                                INNER JOIN so_menu_dining_type dining
	                                ON dining.menu_dining_type_id = detail.menu_dining_type_id
                                INNER JOIN so_menu menu
	                                ON menu.menu_id = dining.menu_id
                                WHERE 1=1
                                    AND detail.is_cancel = 1 
                                    AND detail.sales_order_head_id = @SalesOrderHeadID
                                ");

            DbParameter param = base.CreateParameter("SalesOrderHeadID", "SalesOrderHeadID");
            List<ComboBoxDTO> lstComboBox = base.ExecuteQuery<ComboBoxDTO>(SQL.ToString(), param).ToList();
            lstComboBox.SetPleaseSelect();
            return lstComboBox;
        }
    }
}
