CREATE TABLE [dbo].[sc_user_permission](
	[user_permission_id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_branch_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_sc_user_permission] PRIMARY KEY CLUSTERED 
(
	[user_permission_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sc_user_permission]  WITH CHECK ADD  CONSTRAINT [fk_sc_user_permission_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].db_company_branch ([company_branch_id])
GO

ALTER TABLE [dbo].[sc_user_permission] CHECK CONSTRAINT [fk_sc_user_permission_company_branch]
GO

CREATE TABLE [dbo].[db_device](
	[device_id] [bigint] IDENTITY(1,1) NOT NULL,
	[device_name] nvarchar(1000) null,
	[device_description] nvarchar(1000) null,
	[device_ip] nvarchar(1000) not null,
	[company_branch_id] [bigint] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_device] PRIMARY KEY CLUSTERED 
(
	[device_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[db_device]  WITH CHECK ADD  CONSTRAINT [fk_db_device_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].db_company_branch ([company_branch_id])
GO

ALTER TABLE [dbo].[db_device] CHECK CONSTRAINT [fk_db_device_company_branch]
GO

CREATE TABLE [dbo].[db_uom](
	[uom_id] [bigint] IDENTITY(1,1) NOT NULL,
	[uom_code] nvarchar (20) null,
	[uom_name] nvarchar(1000) null,
	[uom_description] nvarchar(1000) null,
	[active] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_uom] PRIMARY KEY CLUSTERED 
(
	[uom_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[db_uom_ratio](
	[uom_ratio_id] [bigint] IDENTITY(1,1) NOT NULL,
	[uom_id_from] [bigint] NULL,
	[uom_id_to] [bigint] NULL,
	[uom_ratio_description] nvarchar(1000) null,
	[uom_ratio] [decimal] NULL,
	[active] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_uom_ratio] PRIMARY KEY CLUSTERED 
(
	[uom_ratio_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[db_uom_ratio]  WITH CHECK ADD  CONSTRAINT [fk_db_uom_ratio_uom_from] FOREIGN KEY([uom_id_from])
REFERENCES [dbo].[db_uom] ([uom_id])
GO

ALTER TABLE [dbo].[db_uom_ratio] CHECK CONSTRAINT [fk_db_uom_ratio_uom_from]
GO

ALTER TABLE [dbo].[db_uom_ratio]  WITH CHECK ADD  CONSTRAINT [fk_db_uom_ratio_uom_to] FOREIGN KEY([uom_id_to])
REFERENCES [dbo].[db_uom] ([uom_id])
GO

ALTER TABLE [dbo].[db_uom_ratio] CHECK CONSTRAINT [fk_db_uom_ratio_uom_to]
GO

CREATE TABLE [dbo].[db_reason](
	[reason_id] [bigint] IDENTITY(1,1) NOT NULL,
	[reason_name] NVARCHAR(500) null,
	[reason_description] NVARCHAR(max) null,
	[module] NVARCHAR(500) null,
	[document_type_id] bigint null, 
	[active] [bit] null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_reason] PRIMARY KEY CLUSTERED 
(
	[reason_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[db_reason]  WITH CHECK ADD  CONSTRAINT [fk_db_reason_document_type] FOREIGN KEY(document_type_id)
REFERENCES [dbo].db_document_type (document_type_id)
GO

ALTER TABLE [dbo].[db_reason] CHECK CONSTRAINT [fk_db_reason_document_type]
GO





