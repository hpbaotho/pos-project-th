USE [POS]
GO


CREATE TABLE [dbo].[sc_screen_image](
	[sc_screen_image_id] [bigint] IDENTITY(1,1) NOT NULL,
	[control_id] [bigint] NOT NULL,
	[image] varbinary(MAX) NOT NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_screen_image_id] PRIMARY KEY CLUSTERED 
(
	[sc_screen_image_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


ALTER TABLE sc_screen_config 
DROP COLUMN background_image_path
GO

ALTER TABLE sc_screen_config
ADD [sc_screen_image_id] [bigint] NULL
Go

ALTER TABLE [dbo].[sc_screen_config]  WITH CHECK ADD  CONSTRAINT [FK_sc_screen_config_sc_screen_image] FOREIGN KEY([sc_screen_image_id])
REFERENCES [dbo].[sc_screen_image] ([sc_screen_image_id])
GO

ALTER TABLE so_Table
ADD IsAvailable BIT NULL
GO

ALTER TABLE so_sales_order_head
ADD period_id bigint not null
Go
ALTER TABLE so_sales_order_head
ADD is_start_time bit  null,
 eating_start_time datetime,
 Person int
Go

ALTER TABLE [dbo].[so_sales_order_head]  WITH CHECK ADD  CONSTRAINT [FK_so_sales_order_head_db_period] FOREIGN KEY([period_id])
REFERENCES [dbo].[db_period] ([period_id])
GO

ALTER TABLE so_sales_order_detail
ADD ChkNo INT NOT NULL
GO


ALTER TABLE so_sales_order_detail
ADD Open_Condiment NVARCHAR(300) NOT NULL
GO


CREATE TABLE [dbo].[so_order_check](
	[order_check_id] [bigint] IDENTITY(1,1) NOT NULL,
	[period_id] [bigint] NOT NULL,
	[CheckNo] int NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL
 CONSTRAINT [pk_order_check] PRIMARY KEY CLUSTERED 
(
	[order_check_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[so_order_check]  WITH CHECK ADD  CONSTRAINT [FK_so_order_check_db_period] FOREIGN KEY([period_id])
REFERENCES [dbo].[db_period] ([period_id])
GO

