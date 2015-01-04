USE [POS]
GO

CREATE TABLE [dbo].[so_table](

	[table_id] [bigint] IDENTITY(1,1) NOT NULL,
	[table_code] [nvarchar](10) not null,
	[table_name] [nvarchar](300) null,
	[table_description] [nvarchar](max) null,
	[max_people] [int] null,
	[active] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_so_table] PRIMARY KEY CLUSTERED 
(
	[table_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[so_sales_order_head](

	[sales_order_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[table_id] [bigint] null,
	[sales_order_date] [datetime] null,
	[take_order_by] [nvarchar](100) null,
	[take_order_date] [datetime] NULL,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_so_sales_order_head] PRIMARY KEY CLUSTERED 
(
	[sales_order_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[so_sales_order_head]  WITH CHECK ADD  CONSTRAINT [fk_so_sales_order_head_table] FOREIGN KEY([table_id])
REFERENCES [dbo].[so_table] ([table_id])
GO

ALTER TABLE [dbo].[so_sales_order_head] CHECK CONSTRAINT [fk_so_sales_order_head_table]
GO

CREATE TABLE [dbo].[so_sales_order_detail](

	[sales_order_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[sales_order_head_id] [bigint] null,
	[menu_dining_type_id] [bigint] null,
	[order_amount] [int] null,
	[is_print] [bit] null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [pk_so_sales_order_detail] PRIMARY KEY CLUSTERED 
(
	[sales_order_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[so_sales_order_detail]  WITH CHECK ADD  CONSTRAINT [fk_so_sales_order_detail_head] FOREIGN KEY([sales_order_head_id])
REFERENCES [dbo].[so_sales_order_head] ([sales_order_head_id])
GO

ALTER TABLE [dbo].[so_sales_order_detail] CHECK CONSTRAINT [fk_so_sales_order_detail_head]
GO





