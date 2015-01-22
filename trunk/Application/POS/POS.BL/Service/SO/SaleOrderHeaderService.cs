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
using POS.BL.DTO.IN;

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

                       // orderHead.sales_order_date = DateTime.Now;
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
                        else
                        {
                            orderHead.table_id = null;
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
                    
                    if (orderHeadDTO.OrderList != null && orderHeadDTO.OrderList.Count > 0) {
                        orderHeadDTO.OrderList = orderHeadDTO.OrderList.Where(a => !a.is_cancel).ToList();
                    }
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
        public List<SaleOrderHeader> FindTakeAwayOrder()
        {
            string sql = @"
                        SELECT * FROM so_sales_order_head WITH(NOLOCK)
                        WHERE ISNULL(table_id,0) = 0  
                        AND ISNULL(is_cancel,1) = 0 
                        AND ISNULL(is_payment_procress,0) = 0
                        ORDER BY take_order_date
                    ";
            return this.ExecuteQuery<SaleOrderHeader>(sql).ToList();

        }
        public OrderHeadDTO GetOrderByTable(string tableCode)
        {
            OrderHeadDTO result = new OrderHeadDTO();

            SaleOrderHeader orderHead = this.GetOrdrtHeadByTable(tableCode);
            if (orderHead != null && !orderHead.is_cancel && !orderHead.is_payment_procress)
            {
                result.OrderList = ServiceProvider.SaleOrderDetailService.FindOrderDetail(orderHead.sales_order_head_id);
                result.sales_order_head_id = orderHead.sales_order_head_id;
                result.IsStartTime = orderHead.is_start_time;
                result.startTimeINDB = orderHead.eating_start_time;
                result.Person = orderHead.Person;
            }


            return result;
        }
        public OrderHeadDTO GetOrderOrderHeader(SaleOrderHeader Header)
        {
            OrderHeadDTO result = new OrderHeadDTO();

            SaleOrderHeader orderHead = this.FindByKeys(Header, false);

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
        public SaleOrderHeader GetOrdrtHeadByTable(string tableCode) {
            return this.GetOrdrtHeadByTable(tableCode, false, false);
        }
        public SaleOrderHeader GetOrdrtHeadByTable(string tableCode,bool? isCancel,bool? isPayProcress)
        {
            string sql = @"
                        SELECT TOP 1 so_sales_order_head.* 
                        FROM so_sales_order_head WITH(NOLOCK)
                        LEFT JOIN so_table WITH(NOLOCK) ON so_table.table_id=so_sales_order_head.table_id
                        WHERE so_table.table_code=@tableCode
                    ";
            List<DbParameter> param = new List<DbParameter>();
            if (isCancel.HasValue) {
                sql += " AND so_sales_order_head.is_cancel=@Cancel";
                param.Add(base.CreateParameter("@Cancel", isCancel));
            }
            if (isPayProcress.HasValue)
            {
                sql += " AND so_sales_order_head.is_payment_procress=@PayProcess";
                param.Add(base.CreateParameter("@PayProcess", isPayProcress));
            }
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
                    if (table != null)
                    {
                        updateTableItem.table_id = table.table_id;
                    }
                    else {
                        updateTableItem.table_id = null;
                    }
                    this.Update(updateTableItem, ValidationRuleset.Update);
                }
            }

        }
        public void CancleOrder(OrderHeadDTO orderHead)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                SaleOrderHeader order = new SaleOrderHeader();
                order.sales_order_head_id = orderHead.sales_order_head_id;
                order = this.FindByKeys(order, true);
                if (order != null)
                {
                    order.is_cancel = true;
                    ServiceProvider.LogLotService.Stock_CancelHeadOrder(order.sales_order_head_id.Value);
                    this.Update(order, ValidationRuleset.Update);
                }
                ServiceProvider.SOTableService.CancelBookTable(orderHead.TableCode);
                trans.Complete();
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
