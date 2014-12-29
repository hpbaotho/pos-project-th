USE [POS]
GO

BEGIN TRAN

CREATE TABLE [dbo].[so_menu](
	[menu_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_code] [nvarchar](20) NULL,
	[menu_name] [nvarchar](500) NULL,
	[menu_description] [nvarchar](max) NULL,
	[menu_reference_id] [bigint] null,
	[active] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	
 CONSTRAINT [PK_so_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[so_menu_dining_type](
	[menu_dining_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[menu_id] [bigint] NULL,
	[dining_type_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_so_menu_dining_type] PRIMARY KEY CLUSTERED 
(
	[menu_dining_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[so_menu_dining_type]  WITH CHECK ADD  CONSTRAINT [fk_so_menu_dining_type_menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[so_menu] ([menu_id])
GO

ALTER TABLE [dbo].[so_menu_dining_type] CHECK CONSTRAINT [fk_so_menu_dining_type_menu]
GO


ALTER TABLE [dbo].[so_menu_dining_type]  WITH CHECK ADD  CONSTRAINT [fk_so_menu_dining_type_db_dining_type] FOREIGN KEY([dining_type_id])
REFERENCES [dbo].[db_dining_type] ([dining_type_id])
GO

ALTER TABLE [dbo].[so_menu_dining_type] CHECK CONSTRAINT [fk_so_menu_dining_type_db_dining_type]
GO


COMMIT TRAN




