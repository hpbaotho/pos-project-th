CREATE TABLE [dbo].[in_period_group](
	[period_group_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_group_code] [nvarchar] (20) NOT NULL,
	[period_group_name] [nvarchar](200) NOT NULL,
	[period_group_description] [nvarchar](100) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_period_group] PRIMARY KEY CLUSTERED 
(
	[period_group_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[in_period](
	[period_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_group_id] [bigint] NOT NULL,
	[period_code] [nvarchar] (20) NOT NULL,
	[period_date] [datetime] NOT NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_period] PRIMARY KEY CLUSTERED 
(
	[period_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[in_stock_head](
	[stock_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_group_id] [bigint] NOT NULL,
	[period_id] [bigint] NOT NULL,
	[document_type_id] [bigint] NOT NULL,
	[warehouse_id] [bigint] NOT NULL,
	[transaction_no] [nvarchar](10) NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[transaction_status] [bigint] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_stock_head] PRIMARY KEY CLUSTERED 
(
	[stock_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[in_stock_detail](
	[stock_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[stock_head_id] [bigint] NOT NULL,
	[period_id] [bigint] NOT NULL,
	[material_id] [bigint] NOT NULL,
	[bf_phy_lot] [numeric](11,4) NOT NULL,
	[bf_log_lot] [numeric](11,4) NOT NULL,
	[balance_phy_lot] [numeric](11,4) NOT NULL,
	[balance_log_lot] [numeric](11,4) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_in_stock_detail] PRIMARY KEY CLUSTERED 
(
	[stock_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [in_stock_head]
ADD CONSTRAINT [fk_in_stock_head_db_warehouse]
FOREIGN KEY ([warehouse_id])
REFERENCES  [db_warehouse]([warehouse_id])

ALTER TABLE [in_stock_detail]
ADD CONSTRAINT [fk_in_stock_detail_in_material]
FOREIGN KEY ([material_id])
REFERENCES  [in_material]([material_id])

ALTER TABLE [in_stock_detail]
ADD CONSTRAINT [fk_in_stock_detail_in_stock_head]
FOREIGN KEY ([stock_head_id])
REFERENCES  [in_stock_head]([stock_head_id])

ALTER TABLE [in_period]
ADD CONSTRAINT [fk_in_period_in_period_group]
FOREIGN KEY ([period_group_id])
REFERENCES [in_period_group] ([period_group_id])

ALTER TABLE [in_material]
ADD [period_group_id] [bigint], [document_type_id] [bigint], [phy_lot] [numeric](11,4),[log_lot] [numeric](11,4), [material_pic_path] [nvarchar](500), [status] [nvarchar](10)

ALTER TABLE [in_receive_material_detail]
ADD [amount] [numeric](11,4)

ALTER TABLE [in_send_material_detail]
ADD [amount] [numeric](11,4)

ALTER TABLE [in_material]
ADD CONSTRAINT [fk_in_material_in_period_group]
FOREIGN KEY ([period_group_id])
REFERENCES [in_period_group] ([period_group_id])

ALTER TABLE [in_material]
ADD CONSTRAINT [fk_in_material_db_document_type]
FOREIGN KEY ([document_type_id])
REFERENCES [db_document_type] ([document_type_id])

ALTER TABLE [in_stock_head]
ADD CONSTRAINT [fk_in_stock_head_db_document_type]
FOREIGN KEY ([document_type_id])
REFERENCES [db_document_type] ([document_type_id])

ALTER TABLE [in_bill_of_material_group]
ALTER COLUMN [bill_of_material_group_code] [nvarchar] (20) NOT NULL

ALTER TABLE [in_bill_of_material_head]
ALTER COLUMN [bill_of_material_head_code] [nvarchar] (20) NOT NULL

ALTER TABLE [in_material]
ALTER COLUMN [material_code] [nvarchar] (20) NOT NULL
