CREATE TABLE [dbo].[db_supplier](
	[supplier_id] [bigint] IDENTITY(1,1) NOT NULL,
	[supplier_code] nvarchar (20) null,
	[supplier_name] nvarchar(1000) null,
	[supplier_description] nvarchar(1000) null,
	[supplier_address] nvarchar(max) null,
	[supplier_tel] nvarchar(100) null,
	[supplier_contract_person] nvarchar(500) null,
	
	[active] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[db_warehouse](
	[warehouse_id] [bigint] IDENTITY(1,1) NOT NULL,
	[warehouse_code] nvarchar (20) null,
	[warehouse_name] nvarchar(1000) null,
	[warehouse_description] nvarchar(1000) null,
	[company_branch_id] [bigint] NULL,
	[active] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_warehouse] PRIMARY KEY CLUSTERED 
(
	[warehouse_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[db_warehouse]  WITH CHECK ADD  CONSTRAINT [fk_db_warehouse_company_branch] FOREIGN KEY([company_branch_id])
REFERENCES [dbo].[db_company_branch] ([company_branch_id])
GO
ALTER TABLE [dbo].[db_warehouse] CHECK CONSTRAINT [fk_db_warehouse_company_branch]
GO


CREATE TABLE [dbo].[db_dining_type](
	[dining_type_id] [bigint] IDENTITY(1,1) NOT NULL,
	[dining_type_code] nvarchar (20) null,
	[dining_type_name] nvarchar(1000) null,
	[dining_type_description] nvarchar(1000) null,
	[active] bit null,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_db_dining_type] PRIMARY KEY CLUSTERED 
(
	[dining_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

