CREATE TABLE [dbo].[in_material_group](
	[material_group_id] [bigint] IDENTITY(1,1) NOT NULL,
	[material_group_code] [nvarchar](20) NOT NULL,
	[material_group_name] [nvarchar](1000) NOT NULL,
	[material_group_desc] [nvarchar](1000) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_material_group] PRIMARY KEY CLUSTERED 
(
	[material_group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[in_phy_lot](
	[phy_lot_id] [bigint] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[lot_no] [numeric](11,4) NOT NULL,
	[material_id] [bigint] NOT NULL,
	[bf_date] [datetime] NULL,
	[expire_date] [datetime] NULL,
	[bf_qty] [numeric](11,4) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_phy_lot] PRIMARY KEY CLUSTERED 
(
	[phy_lot_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[in_log_lot](
	[log_lot_id] [bigint] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[bf_date] [datetime] NULL,
	[bf_qty] [numeric](11,4) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_log_lot] PRIMARY KEY CLUSTERED 
(
	[log_lot_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[in_portfolio_head](
	[portfolio_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[portfolio_head_code] [nvarchar](20) NOT NULL,
	[portfolio_head_name] [nvarchar](200) NOT NULL,
	[portfolio_head_desc] [nvarchar](1000) NULL,
	[supplier_id] [bigint] NULL,
	[warehouse_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_portfolio_head] PRIMARY KEY CLUSTERED 
(
	[portfolio_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[in_portfolio_detail](
	[portfolio_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[portfolio_head_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_in_portfolio_detail] PRIMARY KEY CLUSTERED 
(
	[portfolio_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[in_material]
ADD [material_group_id] [bigint] NOT NULL,
	[max_stock] [numeric](11,4) NOT NULL,
	[min_stock] [numeric](11,4) NOT NULL,
	[shelf_life] [numeric](11,4) NOT NULL,
	[material_cost] [numeric](11,4) NOT NULL,
	[acceptable_variance] [numeric](11,4) NOT NULL
GO

ALTER TABLE [dbo].[in_tran_head]
ADD [is_cancel_order] [bit] NULL,
	[order_no_id] [bigint] NULL,
	[cancel_reason_id] [bigint] NULL
	

ALTER TABLE [dbo].[in_tran_head]  WITH CHECK ADD  CONSTRAINT [fk_in_tran_head_db_reason_cancel] FOREIGN KEY([cancel_reason_id])
REFERENCES [dbo].[db_reason] ([reason_id])
GO

ALTER TABLE [dbo].[in_tran_head]
DROP COLUMN [transaction_status]

ALTER TABLE [dbo].[in_tran_detail]
ADD [lot_no] [numeric](11,4) NULL

ALTER TABLE [dbo].[in_material]  WITH CHECK ADD  CONSTRAINT [fk_in_material_in_material_group] FOREIGN KEY([material_group_id])
REFERENCES [dbo].[in_material_group] ([material_group_id])
GO

ALTER TABLE [dbo].[in_phy_lot]  WITH CHECK ADD  CONSTRAINT [fk_in_phy_lot_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO

ALTER TABLE [dbo].[in_phy_lot]  WITH CHECK ADD  CONSTRAINT [fk_in_phy_lot_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_log_lot]  WITH CHECK ADD  CONSTRAINT [fk_in_log_lot_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO

ALTER TABLE [dbo].[in_log_lot]  WITH CHECK ADD  CONSTRAINT [fk_in_log_lot_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_portfolio_head]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_head_db_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[db_supplier] ([supplier_id])
GO

ALTER TABLE [dbo].[in_portfolio_head]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_head_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_portfolio_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_detail_in_portfolio_head] FOREIGN KEY([portfolio_head_id])
REFERENCES [dbo].[in_portfolio_head] ([portfolio_head_id])
GO

ALTER TABLE [dbo].[in_portfolio_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_detail_db_warehouse] FOREIGN KEY([warehouse_id])
REFERENCES [dbo].[db_warehouse] ([warehouse_id])
GO

ALTER TABLE [dbo].[in_portfolio_detail]  WITH CHECK ADD  CONSTRAINT [fk_in_portfolio_detail_in_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[in_material] ([material_id])
GO
