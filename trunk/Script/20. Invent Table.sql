ALTER TABLE [dbo].[in_bill_of_material_head]
ADD [remark] NVARCHAR(1000) NULL

ALTER TABLE [dbo].[so_sales_order_detail]
ADD [kitchen_status] NVARCHAR(1) NULL

DROP TABLE in_phy_log_lot_head

CREATE TABLE [dbo].[in_bf_logical]
(
	[bf_logical_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_id] [bigint] NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[bf_qty] [numeric](11,4) NOT NULL,
	[bal_qty] [numeric](11,4) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_bf_logical] PRIMARY KEY CLUSTERED 
(
	[bf_logical_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[in_bf_logical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_logical_in_period] FOREIGN KEY([period_id])
REFERENCES [dbo].[in_period] ([period_id])
GO

ALTER TABLE [dbo].[in_bf_logical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_logical_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_bf_logical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_logical_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO



CREATE TABLE [dbo].[in_bf_physical]
(
	[bf_physical_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_id] [bigint] NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[lot_no] [numeric](11,4) NOT NULL,
	[bf_qty] [numeric](11,4) NOT NULL,
	[bal_qty] [numeric](11,4) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_bf_physical] PRIMARY KEY CLUSTERED 
(
	[bf_physical_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[in_bf_physical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_physical_in_period] FOREIGN KEY([period_id])
REFERENCES [dbo].[in_period] ([period_id])
GO

ALTER TABLE [dbo].[in_bf_physical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_physical_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_bf_physical]  WITH CHECK ADD  CONSTRAINT [fk_in_bf_physical_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO
