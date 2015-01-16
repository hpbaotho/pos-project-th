ALTER TABLE [in_portfolio_head]
DROP fk_in_portfolio_head_db_supplier, fk_in_portfolio_head_db_warehouse
GO
ALTER TABLE [in_portfolio_head]
DROP COLUMN [supplier_id], [warehouse_id]
GO
ALTER TABLE [in_tran_head]
ADD [transaction_status] NVARCHAR(1) --N, F

CREATE TABLE [dbo].[so_menu_mapping]
(
	[menu_mapping_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[bill_of_material_head_id] [bigint] NOT NULL,
	[quantity] [numeric](11,4) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_so_menu_mapping] PRIMARY KEY CLUSTERED 
(
	[menu_mapping_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[so_menu_mapping]  WITH CHECK ADD  CONSTRAINT [fk_so_menu_mapping_so_menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[so_menu] ([menu_id])
GO

ALTER TABLE [dbo].[so_menu_mapping]  WITH CHECK ADD  CONSTRAINT [fk_so_menu_mapping_in_bill_of_material_head] FOREIGN KEY([bill_of_material_head_id])
REFERENCES [dbo].[in_bill_of_material_head] ([bill_of_material_head_id])
GO

DROP TABLE [dbo].[in_log_lot_detail]
GO
DROP TABLE [dbo].[in_phy_lot_detail]
GO

ALTER TABLE [dbo].[in_portfolio_detail]
ALTER COLUMN warehouse_id [bigint] NULL
GO

ALTER TABLE [dbo].[in_portfolio_detail]
DROP [fk_in_portfolio_detail_db_warehouse]
GO


ALTER TABLE [dbo].[in_portfolio_head]
ADD active [bit] NULL
GO


ALTER TABLE [dbo].[in_portfolio_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_detail_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_phy_lot]
ADD [bal_qty] [NUMERIC] (11,4) NOT NULL
GO

ALTER TABLE [dbo].[in_log_lot]
ADD [bal_qty] [NUMERIC] (11,4) NOT NULL
GO

ALTER TABLE [dbo].[in_material]
DROP COLUMN [phy_lot], [log_lot]
GO