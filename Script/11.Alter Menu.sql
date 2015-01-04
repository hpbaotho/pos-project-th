USE POS

--ALTER TABLE dbo.so_menu_dining_type
--ADD menu_price decimal null

GO

/****** Object:  Table [dbo].[ap_payment_type]    Script Date: 01/04/2015 17:23:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ap_payment_type]') AND type in (N'U'))
DROP TABLE [dbo].[ap_payment_type]
GO

/****** Object:  Table [dbo].[ap_payment_type]    Script Date: 01/04/2015 17:23:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ar_receive_type](
	[receive_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_type_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_ar_receive_type] PRIMARY KEY CLUSTERED 
(
	[receive_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ap_vat_type]    Script Date: 01/04/2015 17:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ap_vat_type]') AND type in (N'U'))
DROP TABLE [dbo].[ap_vat_type]
GO

/****** Object:  Table [dbo].[ap_vat_type]    Script Date: 01/04/2015 17:26:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ar_vat_type](
	[vat_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[vat_type_name] [nvarchar](300) NULL,
	[active] [bit] NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_ar_vat_type] PRIMARY KEY CLUSTERED 
(
	[vat_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ar_vat_rate](
	[vat_rate_id] [bigint] IDENTITY(1,1) NOT NULL,
	[vat_rate_code] [nvarchar](20) NULL,
	[vat_type_id] [bigint] NULL,
	[vat_rate] [decimal] null,
	[effective_date] [datetime] null,
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_ar_vat_rate] PRIMARY KEY CLUSTERED 
(
	[vat_rate_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ar_vat_rate]  WITH CHECK ADD  CONSTRAINT [fk_ar_vat_rate_type] FOREIGN KEY([vat_type_id])
REFERENCES [dbo].[ar_vat_type] ([vat_type_id])
GO

ALTER TABLE [dbo].[ar_vat_rate] CHECK CONSTRAINT [fk_ar_vat_rate_type]
GO

CREATE TABLE [dbo].[ar_receive_type_detail](
	[receive_type_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_type_id] [bigint] NULL,
	[receive_type_detail_name] [nvarchar](300) null,
	[receive_type_detail_value] [decimal] null,	
	[active] [bit] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_type_detail] PRIMARY KEY CLUSTERED 
(
	[receive_type_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ar_receive_type_detail]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_type_detail_type] FOREIGN KEY([receive_type_id])
REFERENCES [dbo].[ar_receive_type] ([receive_type_id])
GO

ALTER TABLE [dbo].[ar_receive_type_detail] CHECK CONSTRAINT [fk_ar_receive_type_detail_type]
GO

--Receive
CREATE TABLE [dbo].[ar_receive_head](
	[receive_head_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_number] [bigint] NULL, --document number
	[receive_date] [datetime] null,
	[number_of_customer] [int] null,
	[cashier] [nvarchar](500) null,
	--[sales_order_head_id] [bigint] null,
	[gross_amount] [decimal] null,
	[net_amount] [decimal] null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_head] PRIMARY KEY CLUSTERED 
(
	[receive_head_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ar_receive_order](
	
	[receive_order_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_head_id] [bigint] null,
	[sales_order_head_id] [bigint] null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_order] PRIMARY KEY CLUSTERED 
(
	[receive_order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[ar_receive_order]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_order_so_sales_order_head] FOREIGN KEY([sales_order_head_id])
REFERENCES [dbo].[so_sales_order_head] ([sales_order_head_id])
GO

ALTER TABLE [dbo].[ar_receive_order] CHECK CONSTRAINT [fk_ar_receive_order_so_sales_order_head]
GO

ALTER TABLE [dbo].[ar_receive_order]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_order_receive_head] FOREIGN KEY([receive_head_id])
REFERENCES [dbo].[ar_receive_head] ([receive_head_id])
GO

ALTER TABLE [dbo].[ar_receive_order] CHECK CONSTRAINT [fk_ar_receive_order_receive_head]
GO

CREATE TABLE [dbo].[ar_receive_detail](
	
	[receive_detail_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_head_id] [bigint] null,
	[menu_dining_type_id] [bigint] null,
	[order_amount] [int] null,
	[menu_price] [decimal] null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_detail] PRIMARY KEY CLUSTERED 
(
	[receive_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[ar_receive_detail]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_detail_receive_head] FOREIGN KEY([receive_head_id])
REFERENCES [dbo].[ar_receive_head] ([receive_head_id])
GO

ALTER TABLE [dbo].[ar_receive_detail] CHECK CONSTRAINT [fk_ar_receive_detail_receive_head]
GO

ALTER TABLE [dbo].[ar_receive_detail]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_detail_so_menu_dining_type] FOREIGN KEY([menu_dining_type_id])
REFERENCES [dbo].[so_menu_dining_type] ([menu_dining_type_id])
GO

ALTER TABLE [dbo].[ar_receive_detail] CHECK CONSTRAINT [fk_ar_receive_detail_so_menu_dining_type]
GO

CREATE TABLE [dbo].[ar_receive_vat](
	
	[receive_vat_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_head_id] [bigint] null,
	[vat_type_id] [bigint] null,
	[vat_rate] [decimal] null,
	[vat_amount] [decimal] null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_vat] PRIMARY KEY CLUSTERED 
(
	[receive_vat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[ar_receive_vat]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_vat_receive_head] FOREIGN KEY([receive_head_id])
REFERENCES [dbo].[ar_receive_head] ([receive_head_id])
GO

ALTER TABLE [dbo].[ar_receive_vat] CHECK CONSTRAINT [fk_ar_receive_vat_receive_head]
GO

ALTER TABLE [dbo].[ar_receive_vat]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_vat_vat_type] FOREIGN KEY([vat_type_id])
REFERENCES [dbo].[ar_vat_type] ([vat_type_id])
GO

ALTER TABLE [dbo].[ar_receive_vat] CHECK CONSTRAINT [fk_ar_receive_vat_vat_type]
GO

CREATE TABLE [dbo].[ar_receive_payment](
	
	[receive_payment_id] [bigint] IDENTITY(1,1) NOT NULL,
	[receive_head_id] [bigint] null,
	[receive_type_detail_id] [bigint] null,
	[receive_value] [decimal] null,
	[receive_reference_number] [nvarchar](500) null,
	[receive_reference_date] [datetime] null,
	[receive_reference_description] [nvarchar](max) null,
	[receive_bank] [nvarchar](max) null,
	[is_cancel] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_ar_receive_payment] PRIMARY KEY CLUSTERED 
(
	[receive_payment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[ar_receive_payment]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_payment_receive_head] FOREIGN KEY([receive_head_id])
REFERENCES [dbo].[ar_receive_head] ([receive_head_id])
GO

ALTER TABLE [dbo].[ar_receive_payment] CHECK CONSTRAINT [fk_ar_receive_payment_receive_head]
GO

ALTER TABLE [dbo].[ar_receive_payment]  WITH CHECK ADD  CONSTRAINT [fk_ar_receive_payment_receive_type_detail] FOREIGN KEY([receive_type_detail_id])
REFERENCES [dbo].[ar_receive_type_detail] ([receive_type_detail_id])
GO

ALTER TABLE [dbo].[ar_receive_payment] CHECK CONSTRAINT [fk_ar_receive_payment_receive_type_detail]
GO

