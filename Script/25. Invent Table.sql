ALTER TABLE [dbo].[in_tran_head]
ADD Is_Waste [BIT] NULL
GO

ALTER TABLE [dbo].[in_tran_head]
DROP COLUMN [order_no_id]
GO

ALTER TABLE [dbo].[in_tran_head]
ADD [sales_order_detail_id] [BIGINT] NULL
GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_so_sales_order_detail] FOREIGN KEY([sales_order_detail_id])
REFERENCES [dbo].[so_sales_order_detail] ([sales_order_detail_id])
GO

ALTER TABLE [dbo].[in_tran_head]
ADD [reference_tran_head_id] [BIGINT] NULL
GO

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_in_tran_head] FOREIGN KEY([reference_tran_head_id])
REFERENCES [dbo].[in_tran_head] ([tran_head_id])
GO

ALTER TABLE [so_sales_order_head]
ADD [order_no] [NVARCHAR](20)
GO

ALTER TABLE [in_stock_detail]
DROP COLUMN bf_phy_lot, bf_log_lot, balance_phy_lot, balance_log_lot
GO

ALTER TABLE [in_stock_detail]
ADD [lot_no] [NUMERIC](11,4) NULL, [bf_qty] [NUMERIC](11,4) NULL, [bal_qty] [NUMERIC](11,4) NULL, [bf_date] [DATETIME] NULL
GO

ALTER TABLE [in_stock_head]
ALTER COLUMN [transaction_no] [NVARCHAR](20)
GO

ALTER TABLE [in_stock_head]
ALTER COLUMN [transaction_status] [NVARCHAR](1)
GO

ALTER TABLE [in_period]
ADD [period_status] [NVARCHAR](1)
GO