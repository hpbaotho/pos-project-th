using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Entities.Entity;
using POS.BL.DTO.SO;
using System.Transactions;
using Core.Standards.Validations;
using System.Data.Common;
using POS.BL.DTO;
using POS.BL.Utilities;

namespace POS.BL.Service.SO
{
    public class SaleOrderHeaderService : ServiceBase<SaleOrderHeader>
    {
        public OrderHeadDTO SendOrderToKitchen(OrderHeadDTO orderHeadDTO)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                WorkPeriod activeWorkPeriod = ServiceProvider.WorkPeriodService.findActiveWorkPeriod();

                if (activeWorkPeriod != null && orderHeadDTO != null)
                {
                    SaleOrderHeader orderHead = new SaleOrderHeader();
                    if (!orderHeadDTO.sales_order_head_id.HasValue)
                    {

                        orderHead = new SaleOrderHeader();

                        orderHead.sales_order_date = DateTime.Now;
                        orderHead.take_order_by = UserAccount.UserData.UserName;
                        orderHead.take_order_date = DateTime.Now;
                        orderHead.period_id = activeWorkPeriod.period_id;
                        orderHead.sales_order_head_id = this.Insert<long>(orderHead, ValidationRuleset.Insert);
                        orderHeadDTO.sales_order_head_id = orderHead.sales_order_head_id;

                    }
                    else
                    {
                        orderHead.sales_order_head_id = orderHeadDTO.sales_order_head_id;
                    }
                    orderHead = this.FindByKeys(orderHead, false);
                    if (orderHead != null)
                    {
                        SOTable table = ServiceProvider.SOTableService.GetTaleByCode(orderHeadDTO.TableCode);
                        if (table != null)
                        {
                            orderHead.table_id = table.table_id;
                        }
                        orderHead.is_cancel = orderHeadDTO.IsCancle;
                        orderHead.is_start_time = orderHeadDTO.IsStartTime;
                        orderHead.eating_start_time = orderHeadDTO.StartTimeEating;
                        orderHead.Person = orderHeadDTO.Person;
                        this.Update(orderHead, ValidationRuleset.Update);
                    }
                    else
                    {
                        throw new Exception("Your order is loss.");
                    }

                    orderHeadDTO.OrderList = ServiceProvider.SaleOrderDetailService.SaveOrderDetail(orderHeadDTO.OrderList, orderHeadDTO);
                    trans.Complete();
                }
                else
                {
                    if (activeWorkPeriod == null)
                    {
                        throw new Exception("Please Opern Work Period");
                    }
                }
            }
            return orderHeadDTO;


        }
        public OrderHeadDTO GetOrderByTable(string tableCode)
        {
            OrderHeadDTO result = new OrderHeadDTO();

            SaleOrderHeader orderHead = this.GetOrdrtHeadByTable(tableCode);
            if (orderHead != null)
            {
                result.OrderList = ServiceProvider.SaleOrderDetailService.FindOrderDetail(orderHead.sales_order_head_id);
                result.sales_order_head_id = orderHead.sales_order_head_id;
                result.IsStartTime = orderHead.is_start_time;
                result.startTimeINDB = orderHead.eating_start_time;
                result.Person = orderHead.Person;
            }


            return result;
        }
        public SaleOrderHeader GetOrdrtHeadByTable(string tableCode)
        {
            string sql = @"
                        SELECT TOP 1 so_sales_order_head.* 
                        FROM so_sales_order_head WITH(NOLOCK)
                        LEFT JOIN so_table WITH(NOLOCK) ON so_table.table_id=so_sales_order_head.table_id
                        WHERE so_table.table_code=@tableCode
                    ";
            List<DbParameter> param = new List<DbParameter>();

            param.Add(base.CreateParameter("@tableCode", tableCode));
            SaleOrderHeader orderHead = this.ExecuteQueryOne<SaleOrderHeader>(sql, param.ToArray());
            return orderHead;
        }
        public void UpdateOrderHeadTable(long? sales_order_head_id, string tableCode)
        {
            if (sales_order_head_id.HasValue)
            {
                SOTable table = ServiceProvider.SOTableService.GetTaleByCode(tableCode);
                SaleOrderHeader updateTableItem = new SaleOrderHeader();
                updateTableItem.sales_order_head_id = sales_order_head_id;
                updateTableItem = this.FindByKeys(updateTableItem, false);
                if (updateTableItem != null)
                {
                    updateTableItem.table_id = table.table_id;
                    this.Update(updateTableItem, ValidationRuleset.Update);
                }
            }

        }

        public List<ComboBoxDTO> GetAllCancelOrder()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(@"   SELECT 
                                    * 
                                FROM so_sales_order_head head
                                WHERE EXISTS (
		                                SELECT 
			                                'x' 
		                                FROM so_sales_order_detail detail 
		                                WHERE detail.sales_order_head_id = head.sales_order_head_id
			                                AND detail.is_cancel = 1) ");
            List<SaleOrderHeader> listSaleOrderHeader = base.ExecuteQuery<SaleOrderHeader>(SQL.ToString()).ToList();
            List<ComboBoxDTO> lstComboBox = new List<ComboBoxDTO>();
            foreach (SaleOrderHeader entity in listSaleOrderHeader)
            {
                ComboBoxDTO dto = new ComboBoxDTO();
                dto.Value = entity.sales_order_head_id.Value.ToString();
                dto.Display = entity.order_no;
                lstComboBox.Add(dto);
            }
            lstComboBox.SetPleaseSelect();
            return lstComboBox;
        }
    }
}
